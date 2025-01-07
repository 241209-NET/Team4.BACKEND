using ECommerce.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data; 

public class ECommerceContext : DbContext
{
    public ECommerceContext(){}
    public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options){}

    //Add other required DbSets here
    public DbSet<User> Users { get; set; }

    
}