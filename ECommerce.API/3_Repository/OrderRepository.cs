using System.Collections;
using ECommerce.API.Data;
using ECommerce.API.Model;
using ECommerce.API.Service;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repository; 

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceContext _ecommerceContext; 

    public OrderRepository(ECommerceContext ecommerceContext) => _ecommerceContext = ecommerceContext;

    public IEnumerable<Order>? GetAllOrders()
    {
        return _ecommerceContext.Orders.Include(o => o.Items).ToList();
    }

    public  Order? GetOrderById(int id)
    {
        return _ecommerceContext.Orders
            .FirstOrDefault(o => o.OrderId == id);
    }

    public Order CreateNewOrder(Order order){

        _ecommerceContext.Orders.Add(order);
        _ecommerceContext.SaveChanges();
        return order;

    }
}

