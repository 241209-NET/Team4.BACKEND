using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Model;

public class Order
{
    public Order(){}

    public Order(int orderId, int userId, double totalPrice, List<ItemSold> items, string address, DateTime date){
        OrderId = orderId;
        UserId = userId;
        TotalPrice = totalPrice;
        Items = items;
        Address = address;
        OrderDate = date;
    }
    public int OrderId { get; set; }

    [ForeignKey("User")]
    public int UserId{ get; set; }

    public double TotalPrice { get; set; } = 0.0;
    
    public List<ItemSold> Items { get; set; }

    public string Address { get; set; } = "";

    public DateTime OrderDate { get; set; } = DateTime.Now;
}
