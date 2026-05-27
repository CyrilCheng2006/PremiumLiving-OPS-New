namespace PremiumLivingOPS.Models;

public class Product
{
    public string  ItemID      { get; set; } = "";
    public string  ItemName    { get; set; } = "";   // joined from Item
    public decimal SalesPrice  { get; set; }
    public string  Category    { get; set; } = "";
}
