namespace ECommerce.API.Model;

public class Order
{
    
    public required int OrderId_PK { get; set; }

    public required int UserId_FK { get; set; }

    public double TotalPrice { get; set; } = 0.0;
    
    public List<Item> Items { get; set; } = new List<Item>();

    public bool IsOrdered { get; set; } = false;

    public string Address { get; set; } = "";

    public DateTime OrderDate { get; set; } = DateTime.Now;

}