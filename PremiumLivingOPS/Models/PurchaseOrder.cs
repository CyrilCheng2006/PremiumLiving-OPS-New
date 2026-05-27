namespace PremiumLivingOPS.Models;

public class PurchaseOrder
{
    public string   PurchaseID      { get; set; } = "";
    public string   RequestID       { get; set; } = "";
    public string   SupplierID      { get; set; } = "";
    public string   SupplierName    { get; set; } = "";  // joined
    public double   POTotalAmount   { get; set; }
    public DateTime OrderDate       { get; set; }
    public string   PurchaseStatus  { get; set; } = "";
}
