using ECommerce.API.Model; 
using ECommerce.API.Repository;
using ECommerce.API.Exceptions;

namespace ECommerce.API.Service; 

public class ItemService : IItemService
{
    public readonly IItemRepository _itemRepository; 

    public ItemService(IItemRepository itemRepository) => _itemRepository = itemRepository; 

    //include methods with the business logic below

    //get item by id
    public Item GetItemById(int id)
    {
        return _itemRepository.GetItemById(id) ?? throw new NotFoundException("Item not found");
    }

    //get all items in stock

    public IEnumerable<Item> GetItemsInStock()
    {
        return _itemRepository.GetItemsInStock() ?? throw new NotFoundException("No items in stock");
    }

    public Item AddNewItem(Item newItem)
    {
        //not sure what exception to throw
        return _itemRepository.AddNewItem(newItem) ?? throw new Exception("Invalid Item");
    }

    public Item DeleteItemById(int id)
    {
        return _itemRepository.DeleteItemById(id) ?? throw new NotFoundException("Item not found");
    }
}