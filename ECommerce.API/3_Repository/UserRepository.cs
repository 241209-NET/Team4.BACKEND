using ECommerce.API.Data; 
using ECommerce.API.Model; 
using Microsoft.VisualBasic; 

namespace ECommerce.API.Repository; 

public class UserRepository : IUserRepository
{
    private readonly ECommerceContext _ecommerceContext; 

    public UserRepository(ECommerceContext ecommerceContext) => _ecommerceContext = ecommerceContext; 

    //CRUD Operations Below

    
}

