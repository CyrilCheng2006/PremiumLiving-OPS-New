namespace PremiumLivingOPS.Models;

public class Complaint
{
    public string  ComplaintID          { get; set; } = "";
    public string? OrderID              { get; set; }
    public string  StaffID              { get; set; } = "";
    public string? ComplaintDescription { get; set; }
    public string  ComplaintStatus      { get; set; } = "";
}
