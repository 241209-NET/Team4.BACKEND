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

    public List<Item> GetItemsInStock()
    {
        return _ecommerceContext.Items.ToList();
    }
    
}

