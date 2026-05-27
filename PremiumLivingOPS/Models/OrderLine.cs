namespace PremiumLivingOPS.Models;

public class OrderLine
{
    public string  OrderID  { get; set; } = "";
    public string  ItemID   { get; set; } = "";
    public string  ItemName { get; set; } = "";  // joined
    public int     Quantity { get; set; }
    public double  Price    { get; set; }
}
