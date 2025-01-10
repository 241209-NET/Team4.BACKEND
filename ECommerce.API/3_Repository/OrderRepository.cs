using ECommerce.API.Data;
using ECommerce.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repository; 

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceContext _ecommerceContext; 

    public OrderRepository(ECommerceContext ecommerceContext) => _ecommerceContext = ecommerceContext;

    public List<Order>? GetAllOrders()
    {
        return _ecommerceContext.Orders.ToList();
    }

    public Order AddItemToOrder(int orderId, int itemId, int quantity)
    {
        var itemToAdd = _ecommerceContext.Items.Find(itemId);
        var orderToAddTo = _ecommerceContext.Orders.Find(orderId);
        itemToAdd.Quantity = quantity;
        orderToAddTo.Items.Add(itemToAdd);
        _ecommerceContext.Orders.Update(orderToAddTo);
        _ecommerceContext.SaveChanges();
        return orderToAddTo;
    }

    public Order CompleteCheckout(int orderId)
    {
        //NEED TO UPDATE QUANTITY OF ITEM 
        //fOREACH ITEM IN LIST
            // -1 FOR each id in list
        var order = _ecommerceContext.Orders.Find(orderId);
        order.IsOrdered = true;
        order.OrderDate = DateTime.Now;
        _ecommerceContext.Orders.Update(order);
        _ecommerceContext.SaveChanges();
        return _ecommerceContext.Orders.Find(orderId);
    }

    public Order DeleteItemFromOrder(int orderId, int itemId)
    {
        var orderToDeleteFrom = _ecommerceContext.Orders.Find(orderId);
        var itemToDelete = _ecommerceContext.Items.Find(itemId);
        orderToDeleteFrom.Items.Remove(itemToDelete);
        _ecommerceContext.Orders.Update(orderToDeleteFrom);
        _ecommerceContext.SaveChanges();
        return _ecommerceContext.Orders.Find(orderId);
    }

    public List<Item>? GetItemsInOrderById(int id)
    {
        return _ecommerceContext.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.OrderId == id)
            .Items;
        
    }

    // COULD WE JUST SUM FROK THE PARAMETER ORDER ( DO WE NEED DB QUERY? )
    public float GetItemsTotal(int orderId)
    {
        float total = 0;

        var orderFromDb = _ecommerceContext.Orders
            .Include(o => o.Items)
            .FirstOrDefault(o => o.OrderId == orderId);
        
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

    public bool GetOrderStatus(int id)
    {
        var order = _ecommerceContext.Orders
            .FirstOrDefault(o => o.OrderId == id);

        return order.IsOrdered;
    }
 
    //DEF WANT TO ASK ABOUT THIS
    public Order UpdateItemQuantityInOrder(int orderId, int itemId, int quantity)
    {
        // i want to get an order from the database
        //if want to get the list of items in that order
        //i want to find the item in the list of items
        //i want to update the quantity of that item
        //i want to save the changes to the database
        //i want to return the updated order

        var order = _ecommerceContext.Orders.Find(orderId)!;
        var itemToUpdate = order.Items.FirstOrDefault(i => i.ItemId == itemId)!;
        // take that item
        // dupicate it
        // update that new part of lsit

         itemToUpdate.Quantity = quantity;

        _ecommerceContext.Orders.Update(order);
        _ecommerceContext.SaveChanges();
        return _ecommerceContext.Orders.Find(orderId)!;




    }

    // dupicate item in list
    /*
    public List<Order> Dupicate item in list(int orderId, int itemId)
    - Get my order from Orders.items
    - go through my list of items
        - find the item == itemId
        - Crfeate another instance of that item
        - update the order.items
    - return that list
    
    */


    // remove  item from list

    /*
    public List<Order> Dupicate item in list(int orderId, int itemId)
    - Get my order from Orders.items
    - go through my list of items
        - find the item == itemId
        - Delete an instance of that item 
        - update the order.items
    - return that list
    
    */




}

