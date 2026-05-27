namespace PremiumLivingOPS.Models;

public class Order
{
    public string   OrderID          { get; set; } = "";
    public string?  QuotationID      { get; set; }
    public string   CustomerID       { get; set; } = "";
    public string   CustomerName     { get; set; } = "";  // joined
    public string?  AddressID        { get; set; }
    public string   SalesID          { get; set; } = "";
    public DateTime IssuedTime       { get; set; }
    public DateTime DeliveryDate     { get; set; }
    public string   ShippingAddress  { get; set; } = "";
    public string   BillingAddress   { get; set; } = "";
    public double?  SubTotal         { get; set; }
    public string?  DiscountType     { get; set; }
    public double?  DiscountValue    { get; set; }
    public double?  DiscountAmount   { get; set; }
    public double   GrandTotal       { get; set; }
    public string   OrderContactName { get; set; } = "";
    public string   OrderStatus      { get; set; } = "";
}
