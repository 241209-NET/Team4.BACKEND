using ECommerce.API.Exceptions;
using ECommerce.API.Model; 
using ECommerce.API.DTO; 
using ECommerce.API.Repository;
using AutoMapper;
using ECommerce.API.Util; 

namespace ECommerce.API.Service; 

public class UserService : IUserService
{
    public readonly IUserRepository _userRepository; 

    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository; 
        _mapper = mapper;
    }

    //include methods with the business logic below

    //list all users
    public IEnumerable<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers(); 
    }

    //Add new user
    public User AddNewUser(UserInfoDTO newUser)
    {   
        //If the username doesn't already exist, add the new user and return the result
        if(!DoesUsernameExist(newUser.Username)){
            User fromDTO = _mapper.Map<User>(newUser); 
            return _userRepository.AddNewUser(fromDTO);
        }else{
            throw new UsernameAlreadyExistsException("This Username Is Already Taken"); 
        }

    }

    //user login
    public User UserLogin(UserInfoDTO loginUser)
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