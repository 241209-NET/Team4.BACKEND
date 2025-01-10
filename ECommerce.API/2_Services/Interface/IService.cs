using ECommerce.API.Model; 
using ECommerce.API.DTO; 

namespace ECommerce.API.Service; 

public interface IUserService
{
    //include the contract for all methods in the UserService

    public IEnumerable<User> GetAllUsers();
    public User AddNewUser(UserInfoDTO newUser);
    public User UserLogin(UserInfoDTO loginUser);
    public User GetUserById(int id);
    public User GetUserByName(string name); 
    public User UpdateUserById(User updateUser); 
    public User DeleteUserById(int id); 
    public Boolean DoesUsernameExist(string username);

}

public interface IItemService
{
    public Item GetItemById(int id);
    public IEnumerable<Item> GetItemsInStock();
    public Item AddNewItem(Item newItem);
    public Item DeleteItemById(int id);

}

public interface IOrderService
{
    public Order GetOrderById(int id);
    public List<Item>? GetItemsInOrderById(int id);
    public Order AddItemToOrder(Item item, Order order);

    public Order DeleteItemFromOrder(Item item, Order order);

    public Order UpdateItemQuantityInOrder(Item item, Order order);

    public float GetItemsTotal(Order order);

    public DateTime GetOrderStatus(int id);

    public Order CompleteCheckout(Order order);
}
//Add interfaces for the other services (based on models) below

public interface IDepartmentService
{
    public IEnumerable<Department> GetAllDepartments();
    public Department? GetDepartmentById(int id);
    public IEnumerable<Department>? GetDepartmentByName(string name);
    public Department DeleteDepartmentById(int id);
    public Task<Department> AddDepartment(Department department);
}