using ECommerce.API.Data; 
using ECommerce.API.Model; 
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repository; 

public class ItemRepository : IItemRepository
{
    private readonly ECommerceContext _ecommerceContext; 

    public ItemRepository(ECommerceContext ecommerceContext) => _ecommerceContext = ecommerceContext; 

    //get item by id
    public Item? GetItemById(int id)
    {
        return _ecommerceContext.Items.Find(id); 
    }

    // get items in stock

    public IEnumerable<Item>? GetItemsInStock()
    {
        return _ecommerceContext.Items
        .Where(i => i.Quantity > 0)
        .ToList();
    }

    // add item
    public Item? AddNewItem(Item newItem)
    {
        _ecommerceContext.Add(newItem);
        _ecommerceContext.SaveChanges(); 

        return GetItemById(newItem.ItemId);
;
    }

    //delete item
    public Item? DeleteItemById(int id)
    {
        var oldItem = GetItemById(id); 
        _ecommerceContext.Items.Remove(oldItem!); 
        _ecommerceContext.SaveChanges(); 

        return oldItem; 
    }

    public Item? UpdateItemQuantityById(int quantity, int id)
    {
        var newItem = GetItemById(id);
        newItem.Quantity -= quantity; 
        _ecommerceContext.SaveChanges(); 

        return GetItemById(newItem.ItemId);
    }
    
}

