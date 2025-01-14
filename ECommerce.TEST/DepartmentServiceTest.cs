using Moq;
using ECommerce.API.Model;
using ECommerce.API.Repository;
using ECommerce.API.Service;
using ECommerce.API.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.TEST;

public class DepartmentServiceTest
{

    [Fact]
    public void GetAllDepartmentsTest()
    {
        //Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService departmentService = new(mockRepo.Object);

        List<Department> departments = [
            new Department { Id = 1, Name = "Books"},
            new Department { Id = 2, Name = "Electronics"}
        ];

        mockRepo.Setup(repo => repo.GetAllDepartments()).Returns(departments);

        //Act
        var result = departmentService.GetAllDepartments().ToList();

        //Assert
        Assert.Equal(departments, result);

    }


    [Fact]
    public void TestCreateNewDepartment()
    {
        //Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService DepartmentService = new(mockRepo.Object);

        List<Department> departments = [
            new Department { Id = 1, Name = "Books"},
            new Department { Id = 2, Name = "Electronics"}
        ];

        Department newDepartment = new Department { Id = 3, Name = "KitchenWare" };

        mockRepo.Setup(repo => repo.AddDepartment(It.IsAny<Department>()))
            .Callback((Department Department) => departments.Add(Department))
            .ReturnsAsync(newDepartment);


        //Act
        var myDepartment = DepartmentService.AddDepartment(newDepartment);

        //Assert
        Assert.Contains(newDepartment, departments);
        mockRepo.Verify(x => x.AddDepartment(It.IsAny<Department>()), Times.Once());
    }

    [Fact]
    public void TestGetDepartmentById()
    {
        // Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService DepartmentService = new(mockRepo.Object);
        Department Department = new Department { Id = 1, Name = "Books" };

        mockRepo.Setup(repo => repo.GetDepartmentById(1)).Returns(Department);

        // Act
        var result = DepartmentService.GetDepartmentById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(Department.Id, result.Id);
        mockRepo.Verify(repo => repo.GetDepartmentById(1), Times.Once);
    }

    [Fact]
    public void GetDepartmentById_NoID_Test()
    {
        //Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService DepartmentService = new(mockRepo.Object);
        List<Department> DepartmentList = [
            new Department { Id = 1, Name = "Books"},
            new Department { Id = 2, Name = "Electronics"}
        ];

        // Department TobedeletedDepartment = new Department { Id = 1, Name = "Books" };

        var deleteDepartment = DepartmentList[0];

        mockRepo.Setup(repo => repo.GetDepartmentById(1)).Returns(deleteDepartment);


        //Act
        // DepartmentService.DeleteDepartmentById(1);

        //Assert

        var getItem = Assert.Throws<NotFoundException>(() => DepartmentService.GetDepartmentById(3));
    }


    [Fact]
    public void TestGetDepartmentByName()
    {
        // Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService DepartmentService = new(mockRepo.Object);
        List<Department> DepartmentList = [
            new Department { Id = 1, Name = "Books"},
            new Department { Id = 2, Name = "Electronics"}
        ];

        mockRepo.Setup(repo => repo.GetDepartmentByName("Books")).Returns(DepartmentList);

        // Act
        var result = DepartmentService.GetDepartmentByName("Books");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(DepartmentList[0].Name, result.ToList()[0].Name);
        mockRepo.Verify(repo => repo.GetDepartmentByName("Books"), Times.Once);
    }

    [Fact]
    public void GetDepartmentByName_NoName_Test()
    {
        //Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService DepartmentService = new(mockRepo.Object);
        List<Department> DepartmentList = [
            new Department { Id = 1, Name = "Books"},
            new Department { Id = 2, Name = "Electronics"}
        ];

        // Department TobedeletedDepartment = new Department { Id = 1, Name = "Books" };

        var newDepartment = DepartmentList[0];

        mockRepo.Setup(repo => repo.GetDepartmentByName("Books")).Returns(DepartmentList);


        //Act
        var deptlist = DepartmentService.GetDepartmentByName("NoBooks") ?? [];

        List<Department> emptylist = new List<Department>();

        //Assert

        Assert.Equal(deptlist.ToList(), emptylist.ToList());
    }

    [Fact]
    public void DeleteDepartmentByIdTest()
    {
        //Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService DepartmentService = new(mockRepo.Object);
        List<Department> DepartmentList = [
            new Department { Id = 1, Name = "Books"},
            new Department { Id = 2, Name = "Electronics"}
        ];

        Department TobedeletedDepartment = new Department { Id = 1, Name = "Books" };

        var deleteDepartment = DepartmentList[0];

        mockRepo.Setup(repo => repo.DeleteDepartmentById(1)).Returns(deleteDepartment);


        //Act
        DepartmentService.DeleteDepartmentById(1);

        //Assert
        Assert.Equal(deleteDepartment.Id, TobedeletedDepartment.Id);
    }

    [Fact]
    public void DeleteDepartmentById_NoID_Test()
    {
        //Arrange
        Mock<IDepartmentRepository> mockRepo = new();
        DepartmentService DepartmentService = new(mockRepo.Object);
        List<Department> DepartmentList = [
            new Department { Id = 1, Name = "Books"},
            new Department { Id = 2, Name = "Electronics"}
        ];

        Department TobedeletedDepartment = new Department { Id = 1, Name = "Books" };

        var deleteDepartment = DepartmentList[0];

        mockRepo.Setup(repo => repo.DeleteDepartmentById(1)).Returns(deleteDepartment);


        //Act
        // DepartmentService.DeleteDepartmentById(1);

        //Assert

        var getItem = Assert.Throws<NotFoundException>(() => DepartmentService.DeleteDepartmentById(3));
    }
}