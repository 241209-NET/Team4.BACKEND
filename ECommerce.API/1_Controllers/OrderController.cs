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

    [HttpPatch]
    [Route("{orderId}/items/{itemId}")]
    public IActionResult AddItemToOrder(int orderId, int itemId, int quantity)
    {
        try
        {
            var res = _orderService.AddItemToOrder(orderId, itemId, quantity);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
    }

    [HttpPatch]
    [Route("{orderId}/checkout")]
    public IActionResult CompleteCheckout(int orderId)
    {
        try
        {
            var res = _orderService.CompleteCheckout(orderId);
            return Ok(res);
        }
        catch (NotFoundException e){
            return NotFound(e);
        } 

        catch (Exception e){
            return NotFound(e);
        }
    }

    [HttpDelete]
    [Route("{orderId}/items/{itemId}")]
    public IActionResult RemoveItemFromOrder(int orderId, int itemId)
    {
        try
        {
            var res = _orderService.DeleteItemFromOrder(orderId, itemId);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
    }
    
    [HttpGet]
    [Route("{orderId}/items")]
    public IActionResult GetItemsInOrder(int orderId)
    {
        try
        {
            var res = _orderService.GetItemsInOrderById(orderId);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
    }

    [HttpGet]
    [Route("{orderId}/total-price")]
    public IActionResult GetTotalPriceOfOrder(int orderId)
    {
        try
        {
            var res = _orderService.GetItemsTotal(orderId);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
    }

    [HttpGet]
    [Route("{orderId}/status")]
    public IActionResult GetOrderStatus(int orderId)
    {
        try
        {
            var res = _orderService.GetOrderStatus(orderId);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
    }

    [HttpPatch]
    [Route("{orderId}/items/{itemId}/quantity")]
    public IActionResult UpdateItemQuantityInOrder(int orderId, int itemId, int quantity)
    {
        try
        {
            var res = _orderService.UpdateItemQuantityInOrder(orderId, itemId, quantity);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e);
        }
        catch (Exception e)
        {
            return Conflict(e);
        }
    }
    




}