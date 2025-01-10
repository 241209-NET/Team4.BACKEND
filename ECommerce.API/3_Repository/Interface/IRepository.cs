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
    
}

public interface IOrderRepository
{

    public Order? GetOrderById(int id);

    public List<Item>? GetItemsInOrderById(int id);
    public Order AddItemToOrder(Item item, Order order);

    public Order DeleteItemFromOrder(Item item, Order order);

    public Order UpdateItemQuantityInOrder(Item item, Order order);

    public float GetItemsTotal(Order order);

    public DateTime GetOrderStatus(int id);

    public Order CompleteCheckout(Order order);
    
}