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
    public IEnumerable<Item> GetItemsInStockByDepartmentId(int id);
    public Item AddNewItem(Item newItem);
    public Item DeleteItemById(int id);
    public Item UpdateItemQuantityById(int quantity, int id);

}

public interface IOrderService
{
    public IEnumerable<Order>? GetAllOrders();
    public Order GetOrderById(int id);
    public Order CreateNewOrder(Order order);

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