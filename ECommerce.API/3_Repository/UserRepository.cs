using ECommerce.API.Data; 
using ECommerce.API.Model; 
using Microsoft.VisualBasic; 

namespace ECommerce.API.Repository; 

public class UserRepository : IUserRepository
{
    private readonly ECommerceContext _ecommerceContext; 

    public UserRepository(ECommerceContext ecommerceContext) => _ecommerceContext = ecommerceContext; 

    //CRUD Operations Below

    //Get all users
    public IEnumerable<User> GetAllUsers()
    {
        return _ecommerceContext.Users.ToList(); 
    }

    //Create new user
    public User AddNewUser(User newUser)
    {
        _ecommerceContext.Add(newUser);
        _ecommerceContext.SaveChanges(); 

        return GetUserByName(newUser.Username); 
    }

    //Get User By UserName
    public User GetUserByName(string userName)
    {

        return _ecommerceContext.Users.FirstOrDefault(user => user.Username == userName); 

    }

    //Get User By Id
    public User GetUserById(int userId)
    {
        return _ecommerceContext.Users.Find(userId); 
    }

    public User UpdateUserById(User updateUser)
    {
        User existingUser = GetUserById(updateUser.UserId); 

        existingUser.Username = updateUser.Username; 
        existingUser.Password = updateUser.Password; 
        _ecommerceContext.SaveChanges(); 

        return GetUserById(updateUser.UserId); 
    }

    public User DeleteUserById(int id)
    {
        User deleteUser = GetUserById(id); 
        _ecommerceContext.Users.Remove(deleteUser); 
        _ecommerceContext.SaveChanges(); 

        return deleteUser; 
    }



    
}

