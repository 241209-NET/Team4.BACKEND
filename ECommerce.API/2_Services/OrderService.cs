using ECommerce.API.Exceptions;
using ECommerce.API.Model;
using ECommerce.API.Repository; 

namespace ECommerce.API.Service; 

public class OrderService : IOrderService
{
    public readonly IOrderRepository _orderRepository; 

    public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public Order AddItemToOrder(Item item, Order order)
    {
        GetOrderById(order.OrderId); //Will throw NotFoundException if order not found

        //Want to Check if item exists too...

        // Can add more logic abouut item and order here...


        return _orderRepository.AddItemToOrder(item, order);

    }

    public Order CompleteCheckout(Order order)
    {
        GetOrderById(order.OrderId); //Will throw NotFoundException if order not found

        //prob want to check if order is already completed...

        return _orderRepository.CompleteCheckout(order);
    }

    public Order DeleteItemFromOrder(Item item, Order order)
    {
        Order orderFromDb = GetOrderById(order.OrderId); // will throw notfound if order not found

        if (!orderFromDb.Items.Contains(item)) throw new Exception("Item not Found in Order"); 
                // Not sure if this will ever get thrown 
                // when would we try to delete an item that isnt a part of the Order list?
                // if kept need to create new exception.
        
        return _orderRepository.DeleteItemFromOrder(item, order);

        
    }

    public List<Item>? GetItemsInOrderById(int id)
    {
        GetOrderById(id); //will throw exception if ...

        return _orderRepository.GetItemsInOrderById(id);

    }

    public float GetItemsTotal(Order order)
    {
        if (_orderRepository.GetItemsInOrderById(order.OrderId) == null)
            return 0;

        return _orderRepository.GetItemsTotal(order);
    }

    public Order GetOrderById(int id)
    {
        return _orderRepository.GetOrderById(id) ?? throw new NotFoundException("Order not found");
    }

    public DateTime GetOrderStatus(int id)
    {
        GetOrderById(id); // ...

        return _orderRepository.GetOrderStatus(id);

    }

    public Order UpdateItemQuantityInOrder(Item item, Order order)
    {
         var orderFromDb = GetOrderById(order.OrderId); // ...

        if (!orderFromDb.Items.Contains(item)) throw new Exception("Item not Found in Order"); 
                // Not sure if this will ever get thrown 
                // when would we try to delete an item that isnt a part of the Order list?
                // if kept need to create new exception.

        if (item.Quantity < 0 ) throw new Exception("Invalid Item Quantity");
                // Not sure if this will ever get thrown 

        return _orderRepository.UpdateItemQuantityInOrder(item, order);
    }
}