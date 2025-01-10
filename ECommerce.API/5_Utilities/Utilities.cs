using ECommerce.API.DTO;
using ECommerce.API.Model;

namespace ECommerce.API.Util;

public static class Utilities
{
    public static User DTOToObject(UserInfoDTO userDTO) 
    {
        return new User{Username = userDTO.Username, Password = userDTO.Password};
    }
}