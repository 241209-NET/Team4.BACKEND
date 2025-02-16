
namespace ECommerce.API.Model;

public class Department
{

    public int Id { get; set; }
    public string Name { get; set; } = "";

    public List<Item> Items { get; set; } = [];

}