using ECommerce.API.Model; 
using ECommerce.API.Repository; 

namespace ECommerce.API.Service; 

public class UserService : IUserService
{
    public readonly IUserRepository _userRepository; 

    public UserService(IUserRepository userRepository) => _userRepository = userRepository; 

    //include methods with the business logic below

    //list all users

    //add new user

    //user login
}