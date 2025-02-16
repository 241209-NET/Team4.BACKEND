using ECommerce.API.Exceptions;
using ECommerce.API.Model; 
using ECommerce.API.DTO; 
using ECommerce.API.Service; 
using Microsoft.AspNetCore.Mvc; 

namespace ECommerce.API.Controller; 

[Route("/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService; 

    public UserController(IUserService userService) => _userService = userService; 

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var userList = _userService.GetAllUsers(); 
        return Ok(userList); 
    }


    [HttpPost]
    public IActionResult AddNewUser(UserInfoDTO newUser)
    {
        try{
            var addedUser = _userService.AddNewUser(newUser); 
            return Ok(addedUser); 

        }catch(UsernameAlreadyExistsException){
            return Conflict("Username already exists");
        }

    }

    [HttpPost("/login")]
    public IActionResult UserLogin(UserInfoDTO loginUser)
    {
        User checkedAccount = _userService.UserLogin(loginUser); 
        if(checkedAccount is null){
            //If the username doesn't exist or the password doesn't match, return 401 Unauthorized
            return Unauthorized("Username or Password is incorrect"); 
        }

        return Ok(checkedAccount); 
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var findUser = _userService.GetUserById(id); 

        return Ok(findUser);
    }

    [HttpGet("username/{name}")]
    public IActionResult GetUserByName(string name)
    {
        var findUser = _userService.GetUserByName(name); 

        return Ok(findUser); 
    }

    [HttpPut]
    public IActionResult UpdateUser(User updateUser)
    {
        var updatedUser = _userService.UpdateUserById(updateUser); 

        return Ok(updatedUser); 
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var deleteUser = _userService.DeleteUserById(id); 

        return Ok(deleteUser); 
    }




}