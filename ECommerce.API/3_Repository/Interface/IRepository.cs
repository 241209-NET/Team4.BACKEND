using ECommerce.API.Model; 

namespace ECommerce.API.Repository; 

public interface IUserRepository
{

    //include the contract for all methods in the UserRepository
    public IEnumerable<User> GetAllUsers();
    public User AddNewUser(User newUser);
    public User GetUserByName(string userName); 
    public User GetUserById(int userId);
    public User UpdateUserById(User updateUser); 
    public User DeleteUserById(int id); 

}

public interface IItemRepository
{
    public Item? GetItemById(int id);
    public IEnumerable<Item>? GetItemsInStock();
    public Item? AddNewItem(Item item);
    public Item? DeleteItemById(int id);

}

public interface IOrderRepository
{

    public List<Order>? GetAllOrders();
    public Order? GetOrderById(int id);

    public List<Item>? GetItemsInOrderById(int id);
    public Order AddItemToOrder(int orderId, int itemId, int quantity);

    public Order DeleteItemFromOrder(int orderId, int itemId);

    public Order UpdateItemQuantityInOrder(int orderId, int itemId, int quantity);

    public float GetItemsTotal(int orderId);

    public bool GetOrderStatus(int id);

    public Order CompleteCheckout(int orderId);
    
}

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
    public Department? GetDepartmentById(int id);
    public IEnumerable<Department>? GetDepartmentByName(string name);
    public Department DeleteDepartmentById(int id);
    public Task<Department> AddDepartment(Department department);
}