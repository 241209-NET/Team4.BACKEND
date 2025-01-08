using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Model;

public class Order
{
    
    public required int OrderId { get; set; }

    [ForeignKey("User")]
    public required int UserId{ get; set; }

    public double TotalPrice { get; set; } = 0.0;
    
    public List<Item> Items { get; set; } = [];

    public bool IsOrdered { get; set; } = false;

    public string Address { get; set; } = "";

    public DateTime OrderDate { get; set; } = DateTime.Now;

}