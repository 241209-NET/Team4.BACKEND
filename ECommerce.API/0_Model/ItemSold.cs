using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Model;
public class ItemSold
{
    public int ItemSoldId { get; set; }

    [ForeignKey("Item")]
    public int ItemId_FK { get; set; }

    public int QuantitySold { get; set; }

}
