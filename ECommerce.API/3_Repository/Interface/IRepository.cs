using ECommerce.API.Model; 

namespace ECommerce.API.Repository; 

public interface IUserRepository
{

    //include the contract for all methods in the UserRepository
    public IEnumerable<User> GetAllUsers();
    public User AddNewUser(User newUser);
    public User GetUserByName(string userName); 
    public User GetUserById(int userId);
    public User UpdateUserById(User updateUser); 
    public User DeleteUserById(int id); 

}

public interface IItemRepository
{
    
}

//add interfaces for other repositories (based on model) below