using ECommerce.API.Data;
using ECommerce.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repository; 

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceContext _ecommerceContext; 

    public OrderRepository(ECommerceContext ecommerceContext) => _ecommerceContext = ecommerceContext;

    public Order AddItemToOrder(Item item, Order order)
    {
        order.Items.Add(item);
        _ecommerceContext.Orders.Update(order);
        _ecommerceContext.SaveChanges();
        return order;
    }

    public Order CompleteCheckout(Order order)
    {
        order.IsOrdered = true;
        order.OrderDate = DateTime.Now;
        _ecommerceContext.Orders.Update(order);
        _ecommerceContext.SaveChanges();
        return order;
    }

    public Order DeleteItemFromOrder(Item item, Order order)
    {
        order.Items.Remove(item);
        _ecommerceContext.Orders.Update(order);
        _ecommerceContext.SaveChanges();
        return order;
    }

    public List<Item>? GetItemsInOrderById(int id)
    {
        return _ecommerceContext.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.OrderId == id)!
            .Items;
    }

    // COULD WE JUST SUM FROK THE PARAMETER ORDER ( DO WE NEED DB QUERY? )
    public float GetItemsTotal(Order order)
    {
        float total = 0;

        var orderFromDb = _ecommerceContext.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.OrderId == order.OrderId);
        
        foreach (Item item in orderFromDb!.Items)
        {
            total += item.Price;
        }

        return total;
    }

    public Order? GetOrderById(int id)
    {
        return _ecommerceContext.Orders
            .FirstOrDefault(o => o.OrderId == id);
    }

    public DateTime GetOrderStatus(int id)
    {
        var order = _ecommerceContext.Orders
            .FirstOrDefault(o => o.OrderId == id);

        return order!.OrderDate;
    }
 
    //DEF WANT TO ASK ABOUT THIS
    public Order UpdateItemQuantityInOrder(Item item, Order order)
    {
        // i want to get an order from the database
        //if want to get the list of items in that order
        //i want to find the item in the list of items
        //i want to update the quantity of that item
        //i want to save the changes to the database
        //i want to return the updated order

        var Order = _ecommerceContext.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.OrderId == order.OrderId)!;


        var itemToUpdate = Order.Items
            .FirstOrDefault(i => i.ItemId == item.ItemId)!;


        itemToUpdate.Quantity = item.Quantity;
        _ecommerceContext.Orders.Update(Order);
        _ecommerceContext.SaveChanges();
        return Order;




    }



}

