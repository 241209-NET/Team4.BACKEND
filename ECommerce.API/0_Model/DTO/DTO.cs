using ECommerce.API.Model; 

namespace ECommerce.API.DTO; 

public class UserInfoDTO
{
    public required string Username { get; set; }

    public required string Password { get; set; }
}