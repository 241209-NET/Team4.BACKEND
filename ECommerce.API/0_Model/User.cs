using ECommerce.API.Exceptions;

namespace ECommerce.API.Model; 

public class User
{

    public int UserId { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }

    public List<Order> Orders { get; set; } = [];

/*
    public User(string username, string password)
    {
      this.Username = username; 
      this.Password = password; 
    }*/
   
}