using ECommerce.API.Model; 
using ECommerce.API.Repository; 

namespace ECommerce.API.Service; 

public class UserService : IUserService
{
    public readonly IUserRepository _userRepository; 

    public UserService(IUserRepository userRepository) => _userRepository = userRepository; 

    //include methods with the business logic below

    //list all users
    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers(); 
    }

    //add new user
    public User AddNewUser(User newUser)
    {
        User addedUser = null; 
        
        //If the username doesn't already exist, add the new user and return the result
        if(!DoesUsernameExist(newUser.Username)){
             addedUser = _userRepository.AddNewUser(newUser);
        }

        //Else, return null
        return addedUser; 
    }

    //user login
    public User UserLogin(User loginUser)
    {
        User foundUser = _userRepository.GetUserByName(loginUser.Username); 
        if(foundUser is not null){
            if(foundUser.Password == loginUser.Password){
                return foundUser; 
            }else{
                foundUser = null; 
            }
        }

        return foundUser; 
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id); 
    }

    public User GetUserByName(string name)
    {
        return _userRepository.GetUserByName(name); 
    }

    public User UpdateUserById(User updateUser)
    {
        return _userRepository.UpdateUserById(updateUser); 
    }

    public User DeleteUserById(int id)
    {
        return _userRepository.DeleteUserById(id); 
    }

    //Find whether a username exists
    public Boolean DoesUsernameExist(string username)
    {
        if(_userRepository.GetUserByName(username) is null)
        {
            return false; 
        }

        return true; 
    }

}