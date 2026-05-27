namespace PremiumLivingOPS.Models;

public class Quotation
{
    public string   QuotationID        { get; set; } = "";
    public string   CustomerID         { get; set; } = "";
    public string   CustomerName       { get; set; } = "";  // joined
    public DateTime ExpiryDate         { get; set; }
    public double?  DepositRequired    { get; set; }
    public double   TotalAmount        { get; set; }
    public string?  LeadTimeEstimated  { get; set; }
    public string?  TermsandCondition  { get; set; }
    public string   QuotationStatus    { get; set; } = "";
}
