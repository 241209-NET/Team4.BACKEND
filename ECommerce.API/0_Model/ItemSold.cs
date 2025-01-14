using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Model;
public class ItemSold(int orderID, int itemId, int userId, int quantitySold)
{
    [ForeignKey("Order")]
    public int OrderId_FK { get; set; } = orderID;

    [ForeignKey("Item")]
    public int ItemId_FK { get; set; } = itemId;

    [ForeignKey("User")]
    public int UserId_FK { get; set; } = userId;
    public int QuantitySold { get; set; } = quantitySold;

}
