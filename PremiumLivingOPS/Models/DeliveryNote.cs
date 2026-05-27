namespace PremiumLivingOPS.Models;

public class DeliveryNote
{
    public string   DeliveryID      { get; set; } = "";
    public string   ShipmentID      { get; set; } = "";
    public DateTime DeliveryDate    { get; set; }
    public int?     OutstandingQty  { get; set; }
    public string   ShippingAddress { get; set; } = "";
    public string   ShipToName      { get; set; } = "";
}
