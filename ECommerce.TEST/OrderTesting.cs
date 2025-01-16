using Moq;
using ECommerce.API.Repository;
using ECommerce.API.Model;
using ECommerce.API.Service;
using Xunit;
using Microsoft.Identity.Client;
using ECommerce.API.Exceptions;

namespace ECommerce.TEST;
public class UnitTest1
{
    [Fact]
    public void CreateNewOrder()
    {
        Mock<IOrderRepository> mockOrder = new();
        Mock<IItemService> mockService = new();
        OrderService _orderService = new(mockOrder.Object, mockService.Object);
    
        // Arrange
        ItemSold item1 = new ItemSold{ItemSoldId = 1, ItemId_FK = 1, QuantitySold = 10};
        ItemSold item2 = new ItemSold{ItemSoldId = 1, ItemId_FK = 2, QuantitySold = 10};


        Order order1 = new(
            orderId: 1,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );

        Order order2 = new(
            orderId: 2,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );

        List<Order> orders = [order1, order2];
        

        Order order3 = new Order(
            orderId: 3,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );

        

        mockOrder.Setup(m => m.CreateNewOrder(It.IsAny<Order>()))
            .Callback((Order t) => orders.Add(t))  
            .Returns(order3);

        // Act
        _orderService.CreateNewOrder(order3);

        // Assert
        Assert.Contains(order3, orders);
        mockOrder.Verify(m => m.CreateNewOrder(It.IsAny<Order>()), Times.Once());
    }

    [Fact]
    public void GetOrderById()
    {
        Mock<IOrderRepository> mockOrder = new();
        Mock<IItemService> mockService = new();
        OrderService _orderService = new(mockOrder.Object, mockService.Object);
    
        // Arrange
        ItemSold item1 = new ItemSold{ItemSoldId = 1, ItemId_FK = 1, QuantitySold = 10};
        ItemSold item2 = new ItemSold{ItemSoldId = 1, ItemId_FK = 2, QuantitySold = 10};


        Order order1 = new(
            orderId: 1,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );


        List<Order> orders = [order1];
    
        mockOrder.Setup(m => m.GetOrderById(It.IsAny<int>()))
             .Returns((int id) => orders.FirstOrDefault(t => t.OrderId == id));

        // Act
        var o = _orderService.GetOrderById(1);

        // Assert
        Assert.Equal(orders[0].OrderId, o.OrderId);
        mockOrder.Verify(m => m.GetOrderById(It.IsAny<int>()), Times.Once());


    }

    [Fact]
    public void GetAllOrders()
    {
        Mock<IOrderRepository> mockOrder = new();
        Mock<IItemService> mockService = new();
        OrderService _orderService = new(mockOrder.Object, mockService.Object);
    
        // Arrange
        ItemSold item1 = new ItemSold{ItemSoldId = 1, ItemId_FK = 1, QuantitySold = 10};
        ItemSold item2 = new ItemSold{ItemSoldId = 1, ItemId_FK = 2, QuantitySold = 10};


        Order order1 = new(
            orderId: 1,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );

        Order order2 = new(
            orderId: 2,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );

        Order order3 = new Order(
            orderId: 3,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );

        List<Order> orders = [order1, order2, order3];
        



        

        mockOrder.Setup(m => m.GetAllOrders())
            .Returns(orders);
    

        // Act
        var orderList = _orderService.GetAllOrders();

        // Assert
        Assert.Equal(orders, orderList);
        mockOrder.Verify(m => m.GetAllOrders(), Times.Once());
    }

           
    [Fact]
    public void GetOrderDNE()
    {
        Mock<IOrderRepository> mockOrder = new();
        Mock<IItemService> mockService = new();
        OrderService _orderService = new(mockOrder.Object, mockService.Object);
    
        // Arrange
        ItemSold item1 = new ItemSold{ItemSoldId = 1, ItemId_FK = 1, QuantitySold = 10};
        ItemSold item2 = new ItemSold{ItemSoldId = 1, ItemId_FK = 2, QuantitySold = 10};


        Order order1 = new(
            orderId: 1,
            userId: 2,
            totalPrice: 99.99,
            items: [item1, item2],
            address: "123 Main St",
            date: DateTime.Now
        );


        List<Order> orders = [order1];
    
        mockOrder.Setup(m => m.GetOrderById(It.IsAny<int>()))
             .Returns((int id) => orders.FirstOrDefault(t => t.OrderId == id));

        // Act

        // Assert
        Assert.Throws<NotFoundException>(() => _orderService.GetOrderById(3));
        mockOrder.Verify(m => m.GetOrderById(It.IsAny<int>()), Times.Once());

    }

    [Fact]
    public void OrderUpdatesItemQuantity()
    {
        Mock<IOrderRepository> mockOrder = new();
        Mock<IItemService> mockService = new();
        OrderService _orderService = new(mockOrder.Object, mockService.Object);
    
        // Arrange
        ItemSold item1 = new ItemSold{ItemSoldId = 1, ItemId_FK = 1, QuantitySold = 5};


        Item itemStock = new Item(1,1,1.0f,10,"","");


        Order order1 = new(
            orderId: 1,
            userId: 2,
            totalPrice: 99.99,
            items: [item1],
            address: "123 Main St",
            date: DateTime.Now
        );

        Order order2 = new(
            orderId: 2,
            userId: 2,
            totalPrice: 99.99,
            items: [item1],
            address: "123 Main St",
            date: DateTime.Now
        );


        List<Order> orders = [order1];
    
        mockOrder.Setup(m => m.CreateNewOrder(It.IsAny<Order>()))
            .Callback((Order t) => orders.Add(t))  
            .Returns(order2);

        mockService.Setup(mockService => mockService.UpdateItemQuantityById(It.IsAny<int>(), It.IsAny<int>()))
            .Callback((int itemId, int quantity) => 
            {
            foreach (ItemSold i in order2.Items)
            {
                if (itemStock.ItemId == i.ItemId_FK)
                {
                itemStock.Quantity -= i.QuantitySold;
                }
            }
            })
            .Returns(itemStock);

        // Act
        var o = _orderService.CreateNewOrder(order2);

        // Assert
        Assert.Equal(5,itemStock.Quantity);
        mockOrder.Verify(m => m.CreateNewOrder(It.IsAny<Order>()), Times.Once());
        mockService.Verify(m => m.UpdateItemQuantityById(It.IsAny<int>(), It.IsAny<int>()), Times.Once());

    }

        [Fact]
    public void OrderUpdatesItemQuantityEmpty()
    {
        Mock<IOrderRepository> mockOrder = new();
        Mock<IItemService> mockService = new();
        OrderService _orderService = new(mockOrder.Object, mockService.Object);
    
        // Arrange
        ItemSold item1 = new ItemSold{ItemSoldId = 1, ItemId_FK = 1, QuantitySold = 5};


        Item itemStock = new Item(1,1,1.0f,10,"","");


        Order order1 = new(
            orderId: 1,
            userId: 2,
            totalPrice: 99.99,
            items: [item1],
            address: "123 Main St",
            date: DateTime.Now
        );

        Order order2 = new(
            orderId: 2,
            userId: 2,
            totalPrice: 99.99,
            items: [],
            address: "123 Main St",
            date: DateTime.Now
        );


        List<Order> orders = [order1];
    
        mockOrder.Setup(m => m.CreateNewOrder(It.IsAny<Order>()))
            .Callback((Order t) => orders.Add(t))  
            .Returns(order2);

        mockService.Setup(mockService => mockService.UpdateItemQuantityById(It.IsAny<int>(), It.IsAny<int>()))
            .Callback((int itemId, int quantity) => 
            {
            foreach (ItemSold i in order2.Items)
            {
                if (itemStock.ItemId == i.ItemId_FK)
                {
                itemStock.Quantity -= i.QuantitySold;
                }
            }
            })
            .Returns(itemStock);

        // Act

        // Assert
        Assert.Throws<NotFoundException>(() => _orderService.CreateNewOrder(order2));
        mockOrder.Verify(m => m.CreateNewOrder(It.IsAny<Order>()), Times.Never());
        mockService.Verify(m => m.UpdateItemQuantityById(It.IsAny<int>(), It.IsAny<int>()), Times.Never());

    }
}

