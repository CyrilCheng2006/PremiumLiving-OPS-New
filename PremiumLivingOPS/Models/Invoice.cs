namespace PremiumLivingOPS.Models;

public class Invoice
{
    public string   InvoiceID        { get; set; } = "";
    public string   OrderID          { get; set; } = "";
    public DateTime InvoiceDate      { get; set; }
    public double?  DepositAmount    { get; set; }
    public double   PaidAmount       { get; set; }
    public double   RemainingBalance { get; set; }
    public double   TotalAmount      { get; set; }
    public string   PaymentStatus    { get; set; } = "";
    public DateTime DueDate          { get; set; }
}
