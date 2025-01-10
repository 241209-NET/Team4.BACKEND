using ECommerce.API.Model; 
using ECommerce.API.Repository; 

namespace ECommerce.API.Service; 

public class ItemService : IItemService
{
    public readonly IItemRepository _itemRepository; 

    public ItemService(IItemRepository itemRepository) => _itemRepository = itemRepository; 

    //include methods with the business logic below

    //list all users

    //add new user

    //user login
}