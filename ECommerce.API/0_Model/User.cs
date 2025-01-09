namespace ECommerce.API.Model; 

public class User
{

    public int UserId { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }

    public List<Order> Orders { get; set; } = [];
   
}