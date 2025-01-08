namespace ECommerce.API.Model;

public class Item
{

    public int ItemId { get; set; }
    public int Price { get; set;}
    public int Quantity { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

}