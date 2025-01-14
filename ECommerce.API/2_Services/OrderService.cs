using System.Runtime.InteropServices;
using ECommerce.API.Exceptions;
using ECommerce.API.Model;
using ECommerce.API.Repository; 

namespace ECommerce.API.Service; 

public class OrderService : IOrderService
{
    public readonly IOrderRepository _orderRepository; 
    public readonly IItemService _ItemService;

    public OrderService(IOrderRepository orderRepository, IItemService itemService){
        _orderRepository = orderRepository;
        _ItemService = itemService;
    } 

    public IEnumerable<Order>? GetAllOrders(){

        return _orderRepository.GetAllOrders();
    }

    public Order CreateNewOrder(Order order){

        if(order.Items.Count == 0) throw new NotFoundException("There are no items in the cart!");

        foreach(ItemSold i in order.Items)
        {
            _ItemService.UpdateItemQuantityById(i.QuantitySold, i.ItemId_FK);
        }
       
        return _orderRepository.CreateNewOrder(order);
    }

    public Order GetOrderById(int id)
    {
        var order = _orderRepository.GetOrderById(id) ?? throw new NotFoundException("Order not found");
        return order;
    }

}