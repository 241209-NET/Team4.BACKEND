namespace ECommerce.API.Model; 

public class User
{

    public int userId { get; set; }

    public required string username { get; set; }

    public required string password { get; set; }
   
}