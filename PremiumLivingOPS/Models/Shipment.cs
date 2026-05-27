namespace PremiumLivingOPS.Models;

public class Shipment
{
    public string   ShipmentID      { get; set; } = "";
    public string   OrderID         { get; set; } = "";
    public string   TrackingNumber  { get; set; } = "";
    public DateTime ShipDate        { get; set; }
    public string   DeliveryMethod  { get; set; } = "";
    public string   ShipmentStatus  { get; set; } = "";
    public string   ShipmentType    { get; set; } = "";
    public double   TotalAmount     { get; set; }
}
