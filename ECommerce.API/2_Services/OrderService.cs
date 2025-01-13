using ECommerce.API.Exceptions;
using ECommerce.API.Model;
using ECommerce.API.Repository; 

namespace ECommerce.API.Service; 

public class OrderService : IOrderService
{
    public readonly IOrderRepository _orderRepository; 
    public readonly IItemRepository _itemRepository;

    public OrderService(IOrderRepository orderRepository) => _orderRepository = orderRepository;

    public List<Order>? GetAllOrders(){

        return _orderRepository.GetAllOrders();
    }

    public Order AddItemToOrder(int orderId, int itemId, int quantity)
    {
        GetOrderById(orderId); //Will throw NotFoundException if order not found

        var item = _itemRepository.GetItemById(itemId) ?? throw new NotFoundException("Item Not Found");
        // Can add more logic abouut item and order here...


        return _orderRepository.AddItemToOrder(orderId, itemId, quantity);

    }

    public Order CompleteCheckout(int orderId)
    {
        GetOrderById(orderId); //Will throw NotFoundException if order not found

        //prob want to check if order is already completed...
        if (_orderRepository.GetOrderStatus(orderId)) throw new Exception("Order already completed"); //NEED NEW EXCEPTION

        return _orderRepository.CompleteCheckout(orderId);
    }

    public Order DeleteItemFromOrder(int orderId, int itemId)
    {
        GetOrderById(orderId); // will throw notfound if order not found

        var item = _itemRepository.GetItemById(itemId) ?? throw new NotFoundException("Item Not Found");

                // when would we try to delete an item that isnt a part of the Order list?
                // if kept need to create new exception.
        
        return _orderRepository.DeleteItemFromOrder(orderId, itemId);

        
    }

    public List<Item>? GetItemsInOrderById(int id)
    {
        GetOrderById(id); //will throw exception if ...

        return _orderRepository.GetItemsInOrderById(id);

    }

    public float GetItemsTotal(int orderId)
    {
        GetOrderById(orderId);

        if (_orderRepository.GetItemsInOrderById(orderId) == null)
            return 0;

        return _orderRepository.GetItemsTotal(orderId);
    }

    public Order GetOrderById(int id)
    {
        return _orderRepository.GetOrderById(id) ?? throw new NotFoundException("Order not found");
    }

    public bool GetOrderStatus(int id)
    {
        GetOrderById(id); // ...

        return _orderRepository.GetOrderStatus(id);

    }


    public List<Item> DuplicateItemInList(int orderId, int itemId)
    {
        var orderFromDb = GetOrderById(orderId); // ...
        var item = _itemRepository.GetItemById(itemId) ?? throw new NotFoundException("Item Doesnt Exist!");

        if (!orderFromDb.Items.Contains(item)) throw new NotFoundException("Item not Found in Order!"); 

        return  _orderRepository.DuplicateItemInList(orderId, itemId);

    }

        public List<Item> RemoveItemInList(int orderId, int itemId)
    {
        var orderFromDb = GetOrderById(orderId); // ...
        var item = _itemRepository.GetItemById(itemId) ?? throw new NotFoundException("Item Doesnt Exist!");

        if (!orderFromDb.Items.Contains(item)) throw new NotFoundException("Item not Found in Order!"); 

        return  _orderRepository.DuplicateItemInList(orderId, itemId);
        
    }
}