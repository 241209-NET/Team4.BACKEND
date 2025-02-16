using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Model;

public class Item
{
    public Item(){}
    public Item(int itemId, int departmentId, float price, int quantity, string name, string description)
    {
        ItemId = itemId;
        DepartmentId = departmentId;
        Price = price;
        Quantity = quantity;
        Name = name;
        Description = description;
        Orders = [];
    }
    public int ItemId { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public List<Order>? Orders { get; set; } = [];

}