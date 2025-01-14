using Moq; 
using ECommerce.API.Model; 
using ECommerce.API.Repository; 
using ECommerce.API.Service;
using AutoMapper;
using ECommerce.API.DTO;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using ECommerce.API.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Features;

namespace ECommerce.TEST;

public class ItemTesting
{
    [Fact]
    public void GetItemByIdTest()
    {

        //arrange
        Mock<IItemRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new(); 

        ItemService itemService = new(mockRepo.Object); 
        
        var expectedItem = new Item {DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []};


        mockRepo.Setup(repo => repo.GetItemById(expectedItem.ItemId)).Returns(expectedItem);

        //act
        var getItem = itemService.GetItemById(expectedItem.ItemId);

        //assert
        Assert.NotNull(getItem);
        Assert.Equal(getItem, expectedItem);


    }
    
    [Fact]
    public void GetItemByIdNoIdTest()
    {
        Mock<IItemRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new(); 

        ItemService itemService = new(mockRepo.Object); 
        var expectedItem = new Item {ItemId = 0, DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []};
        var unexpectedItem = new Item {ItemId = 1, DepartmentId = 0, Price = 0.99f, Quantity = 1, Name = "Evil Test Pizza", Description = "nope", Orders = []};

        mockRepo.Setup(repo => repo.GetItemById(expectedItem.ItemId)).Returns(expectedItem);

        var getItem = Assert.Throws<NotFoundException>(() => itemService.GetItemById(unexpectedItem.ItemId));
        //Assert.That(getItem.Message, Is.EqualTo("ItemNotFound"));

    }
    

    [Fact]
    public void GetItemsInStockTest()
    {
        //arrange
        Mock<IItemRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new(); 

        ItemService itemService = new(mockRepo.Object); 
        
        List<Item> itemList = [
            new Item {DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []},
            new Item {DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza 2", Description = "test", Orders = []},
            new Item {DepartmentId = 0, Price = 0.99f, Quantity = 0, Name = "Test Pizza 3", Description = "test", Orders = []}
        ];

        List<Item> itemList2 = [
            new Item {DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []},
            new Item {DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza 2", Description = "test", Orders = []},
        ];

        mockRepo.Setup(repo => repo.GetItemsInStock())
                .Returns(itemList2);

        //act
        var getItem = itemService.GetItemsInStock();

        //assert
        Assert.NotNull(getItem);
        Assert.Equal(getItem, itemList2);
    }

    [Fact]
    public void AddItemTest()
    {
        Mock<IItemRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new(); 

        ItemService itemService = new(mockRepo.Object); 
        var expectedItem = new Item {DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []};
        mockRepo.Setup(repo => repo.AddNewItem(It.IsAny<Item>())).Returns(expectedItem);

        //act
        var addItem = itemService.AddNewItem(expectedItem);
        Assert.NotNull(addItem);
        Assert.Equal(expectedItem, addItem);
    }


    [Fact]
    public void DeleteItemByIdTest()
    {
        Mock<IItemRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new(); 

        ItemService itemService = new(mockRepo.Object); 
        var expectedItem = new Item {DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []};


        mockRepo.Setup(repo => repo.DeleteItemById(expectedItem.ItemId)).Returns(expectedItem);

        var toDelete = itemService.DeleteItemById(expectedItem.ItemId);

        //Assert
        Assert.NotNull(toDelete);
        Assert.Equal(expectedItem, toDelete);
    }

    [Fact]
    public void DeleteItemByIdTestNoId()
    {
        Mock<IItemRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new(); 

        ItemService itemService = new(mockRepo.Object); 
        var expectedItem = new Item {ItemId = 0, DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []};
        var unexpectedItem = new Item {ItemId = 1, DepartmentId = 0, Price = 0.99f, Quantity = 1, Name = "Evil Test Pizza", Description = "nope", Orders = []};

        mockRepo.Setup(repo => repo.DeleteItemById(expectedItem.ItemId)).Returns(expectedItem);


        //Assert
        var getItem = Assert.Throws<NotFoundException>(() => itemService.DeleteItemById(unexpectedItem.ItemId));

    }

    [Fact]
    public void UpdateItemQuantityByIdTest()
    {
        
        Mock<IItemRepository> mockRepo = new();
        Mock<IMapper> mockMapper = new(); 

        ItemService itemService = new(mockRepo.Object); 
        var expectedItem = new Item {ItemId = 1, DepartmentId = 0, Price = 0.99f, Quantity = 2, Name = "Test Pizza", Description = "test", Orders = []};
        var expectedItem2 = new Item {ItemId = 1, DepartmentId = 0, Price = 0.99f, Quantity = 3, Name = "Test Pizza", Description = "test", Orders = []};


        //this and delete might be flawed
        mockRepo.Setup(repo => repo.UpdateItemQuantityById(3, expectedItem.ItemId))
                .Returns(expectedItem2);
        
        var toUpdate = itemService.UpdateItemQuantityById(3, expectedItem.ItemId);
        Assert.Equal(3, toUpdate.Quantity);
    }
    
}