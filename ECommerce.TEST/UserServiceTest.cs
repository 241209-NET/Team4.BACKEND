using Moq; 
using ECommerce.API.Model; 
using ECommerce.API.Repository; 
using ECommerce.API.Service;
using AutoMapper;
using ECommerce.API.DTO;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using ECommerce.API.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.TEST; 

public class UserServiceTest
{
    //Test GetAllUsers();
    [Fact]
    public void GetAllUsersTest()
    {
        //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); //does this work? 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        mockRepo.Setup(repo => repo.GetAllUsers()).Returns(userList); 

        //Act
        var result = userService.GetAllUsers().ToList(); 

        //Assert
        Assert.Equal(userList, result); 
    }


    [Fact]
    public void AddNewUserTest()
    {
         //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); //does this work? 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        //User newUser = new User{UserId = 5, Username = "Dale", Password = "DalePassword"}; 
        UserInfoDTO newUserDTO = new UserInfoDTO{Username = "Dale", Password = "DalePassword"}; 
        UserInfoDTO duplicate = new UserInfoDTO{Username = "Alex", Password = "AlexPassword"}; 
        User addedUser = new User{UserId = 5, Username = "Dale", Password="DalePassword"}; 

        mockMapper.Setup(m => m.Map<UserInfoDTO, User>(It.IsAny<UserInfoDTO>()))
            .Returns(new User{Username = "Dale", Password = "DalePassword"});
        //pretty sure this is doing nothing


        mockRepo.Setup(repo => repo.AddNewUser(It.IsAny<User>()))
            .Callback((User u) => userList.Add(u)); 

        //Act
        var myUser = userService.AddNewUser(newUserDTO); 

        //Assert
        Assert.Contains(myUser, userList); 

        //Assert.Throws<UsernameAlreadyExistsException>(() => userService.AddNewUser(duplicate));
        //Attempted to check the exception branch, but the test fails (no exception is thrown)
        //need to setup behavior to throw exception? no idea how to do that
        //need to set up a new test in order to try to check this branch? 
    }

    //public User UserLogin(UserInfoDTO loginUser);
    [Fact]
    public void UserLoginTest()
    {
        //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); //does this work? 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        UserInfoDTO LoginDTO = new UserInfoDTO{Username = "Alex", Password = "AlexPassword"}; 
        User loginUser = new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}; 

        mockRepo.Setup(repo => repo.GetUserByName(It.IsAny<string>()))
            .Returns((string x) => userList.Find(u => u.Username == x)); 
            //returns list item with LoginDTO username

        //Act
        var result = userService.UserLogin(LoginDTO); //returns list item that matches username
        

        //Assert
        Assert.Equal(result.Username, loginUser.Username); 
        Assert.Equal(result.Password, LoginDTO.Password); 
    }

    [Fact]
    public void UserLoginNoNameTest()
    {
        //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); //does this work? 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        UserInfoDTO LoginDTO = new UserInfoDTO{Username = "Dale", Password = "DalePassword"}; 
        User loginUser = new User{UserId = 1, Username = "Dale", Password = "DalePassword"}; 

        mockRepo.Setup(repo => repo.GetUserByName(It.IsAny<string>()))
            .Returns((string x) => userList.Find(u => u.Username == x)); 
            //returns null?

        //Act
        var result = userService.UserLogin(LoginDTO); //should be null
        

        //Assert
        Assert.Null(result); 
    }

    [Fact]
    public void UserLoginNoPasswordTest()
    {
        //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); //does this work? 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        UserInfoDTO LoginDTO = new UserInfoDTO{Username = "Alex", Password = "DalePassword"}; 
        User loginUser = new User{UserId = 1, Username = "Alex", Password = "DalePassword"}; 

        mockRepo.Setup(repo => repo.GetUserByName(It.IsAny<string>()))
            .Returns((string x) => userList.Find(u => u.Username == x));

        Assert.Equal(LoginDTO.Username, userList[0].Username); //Assert that the username can be found in the list

        //Act
        var result = userService.UserLogin(LoginDTO); 

        //Assert
        Assert.Null(result); //Then assert that the actual result is null (fails on password step)
        
    }


    [Fact]
    public void GetUserByIdTest()
    {
         //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        mockRepo.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((int x) => userList.Find(u => u.UserId == x)); 

        //Act
        var result = userService.GetUserById(1); 

        //Assert
        Assert.Equal(userList[0], result); 
    }


    [Fact]
    public void GetUserByNameTest()
    {
         //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        mockRepo.Setup(repo => repo.GetUserByName(It.IsAny<string>())).Returns((string x) => userList.Find(u => u.Username == x)); 
        //Act
        var result = userService.GetUserByName("Alex"); 

        //Assert
        Assert.Equal(userList[0], result); 
    }


    [Fact]
    public void UpdateUserByIdTest()
    {
         //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        var updateUser = new User{UserId = 1, Username = "Dale", Password = "DalePassword"};

        mockRepo.Setup(repo => repo.UpdateUserById(It.IsAny<User>()))
            .Returns((User u) => {
                var foundUser = userList.Find(x => x.UserId == u.UserId); 
                foundUser.Username = u.Username; 
                foundUser.Password = u.Password; 
                return foundUser; 
            }); 
        
        //Act
        var changeUser = userService.UpdateUserById(updateUser); 

        Assert.Equal(changeUser.Username, updateUser.Username); 
        Assert.Equal(changeUser.Password, updateUser.Password); 
        //assert that their usernames & passwords are equal
        //don't be afraid to do multiple asserts
    }


    [Fact]
    public void DeleteUserByIdTest()
    {
        //Arrange
        Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        var deleteUser = userList[0]; 

        mockRepo.Setup(repo => repo.DeleteUserById(It.IsAny<int>()))
            .Callback((int x) => userList.Remove(userList.Find(u => u.UserId == x))); 
        
        //Act
        userService.DeleteUserById(1); 

        //Assert
        Assert.DoesNotContain(deleteUser, userList); 
    }


   //This is not doing anything, apparently
   //Made this to try and cut out the return true branch of DoesUsernameExist, but report says that branch is still uncovered
    [Fact]
    public void DoesUsernameExistTest()
    {
         Mock<IUserRepository> mockRepo = new(); 
        Mock<IMapper> mockMapper = new(); //does this work? 

        UserService userService = new(mockRepo.Object, mockMapper.Object); 

        List<User> userList = [
            new User{UserId = 1, Username = "Alex", Password = "AlexPassword"}, 
            new User{UserId = 2, Username = "Jake", Password = "JakePassword"}, 
            new User{UserId = 3, Username = "Frank", Password = "FrankPassword"}, 
            new User{UserId = 4, Username = "Clive", Password = "ClivePassword"}, 
        ];

        mockRepo.Setup(repo => repo.GetUserByName(It.IsAny<string>()))
            .Returns((string x) => userList.Find(u => u.Username == x)); 

        //Act
        var result = userService.GetUserByName("Dale"); 

        //Assert
        Assert.Null(result); 
        
    }
   
}