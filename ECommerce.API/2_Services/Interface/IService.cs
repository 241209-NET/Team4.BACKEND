using ECommerce.API.Model; 

namespace ECommerce.API.Service; 

public interface IUserService
{
    //include the contract for all methods in the UserService

    public IEnumerable<User> GetAllUsers();
    public User AddNewUser(User newUser); 
    public User UserLogin(User loginUser); 
    public User GetUserById(int id);
    public User GetUserByName(string name); 
    public User UpdateUserById(User updateUser); 
    public User DeleteUserById(int id); 
    public Boolean DoesUsernameExist(string username);

}

public interface IItemService
{
    
}
//Add interfaces for the other services (based on models) below