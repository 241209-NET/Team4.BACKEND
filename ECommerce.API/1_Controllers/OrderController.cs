using ECommerce.API.Exceptions;
using ECommerce.API.Model;
using ECommerce.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controller;

[Route("/[controller]")]
[ApiController]

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
     private readonly IItemService _itemService;

    public OrderController(IOrderService orderService) => _orderService = orderService; 

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        try
        {
            var res = _orderService.GetAllOrders();
            return Ok(res);
        }
        catch (Exception e)
        {
            return Conflict(e);
        }
    }


    [HttpGet]
    [Route("/{id}")]
    public IActionResult GetOrderById(int id){

        try{
            var res = _orderService.GetOrderById(id);
            return Ok(res);
        } catch (NotFoundException e){
            return NotFound(e);
        }
    }


    [HttpPost]
    public IActionResult CreateNewOrder(Order order)
    {
        try
        {
            var res = _orderService.CreateNewOrder(order);
            return Ok(res);
        }
        catch (NotFoundException e){
            return NotFound(e);
        } 

        catch (Exception e){
            return NotFound(e);
        }
    }
}