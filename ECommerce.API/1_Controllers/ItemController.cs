using ECommerce.API.Model; 
using ECommerce.API.Service; 
using Microsoft.AspNetCore.Mvc; 

namespace ECommerce.API.Controller; 

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    //list an item by id
    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        return Ok(_itemService.GetItemById(id));
    }

    // get items in stock
    [HttpGet]
    public IActionResult GetItemsInStock()
    {
        return Ok(_itemService.GetItemsInStock());
    }

    //get items in stock by department id
    [HttpGet("departmentId/{id}")]
    public IActionResult GetItemsInStockByDepartmentId(int id)
    {
        return Ok(_itemService.GetItemsInStockByDepartmentId(id));
    }

    // add item
    [HttpPost]
    public IActionResult AddItem(Item newItem)
    {
        return Ok(_itemService.AddNewItem(newItem));
    }
    // delete item by id
    [HttpDelete("{id}")]
    public IActionResult DeleteItemById(int id)
    {
        return Ok(_itemService.DeleteItemById(id));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItemQuantityById(int quantity, int id)
    {
        return Ok(_itemService.UpdateItemQuantityById(quantity, id));
    }

}