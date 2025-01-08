using ECommerce.API.Data; 
using ECommerce.API.Model; 
using Microsoft.VisualBasic; 

namespace ECommerce.API.Repository; 

public class ItemRepository : IItemRepository
{
    private readonly ECommerceContext _ecommerceContext; 

    public ItemRepository(ECommerceContext ecommerceContext) => _ecommerceContext = ecommerceContext; 

    //CRUD Operations Below

    
}

