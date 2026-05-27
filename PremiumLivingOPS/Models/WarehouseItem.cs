namespace PremiumLivingOPS.Models;

public class WarehouseItem
{
    public string WarehouseItemID       { get; set; } = "";
    public string ItemID                { get; set; } = "";
    public string ItemName              { get; set; } = "";  // joined
    public string WarehouseID           { get; set; } = "";
    public string WarehouseLocation     { get; set; } = "";  // joined
    public int    WarehouseItemQuantity { get; set; }
    public int    ReorderLevel          { get; set; }
}
