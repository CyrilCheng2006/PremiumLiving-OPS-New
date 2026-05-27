namespace PremiumLivingOPS.Models;

public class RawMaterial
{
    public string  ItemID        { get; set; } = "";
    public string  ItemName      { get; set; } = "";   // joined from Item
    public decimal PurchasePrice { get; set; }
    public string  MaterialType  { get; set; } = "";
}
