using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Financial Report – mirrors fin-report.html</summary>
public partial class FinReportForm : Form
{
    public FinReportForm() { InitializeComponent(); LoadSummary(); }

    private void LoadSummary()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            // Revenue
            using var c1 = new MySqlCommand("SELECT IFNULL(SUM(TotalAmount),0) FROM Invoice WHERE PaymentStatus='Paid' AND MONTH(InvoiceDate)=MONTH(CURDATE()) AND YEAR(InvoiceDate)=YEAR(CURDATE());", conn);
            lblRevenue.Text = $"HK${Convert.ToDecimal(c1.ExecuteScalar()):N2}";
            // Outstanding
            using var c2 = new MySqlCommand("SELECT IFNULL(SUM(TotalAmount),0) FROM Invoice WHERE PaymentStatus!='Paid';", conn);
            lblOutstanding.Text = $"HK${Convert.ToDecimal(c2.ExecuteScalar()):N2}";
            // Expenses
            using var c3 = new MySqlCommand("SELECT IFNULL(SUM(TotalAmount),0) FROM PurchaseOrder WHERE Status='Received' AND MONTH(OrderDate)=MONTH(CURDATE()) AND YEAR(OrderDate)=YEAR(CURDATE());", conn);
            lblExpenses.Text = $"HK${Convert.ToDecimal(c3.ExecuteScalar()):N2}";
            // Load invoice detail
            LoadInvoiceDetail();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void LoadInvoiceDetail()
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT i.InvoiceID, c.CustomerName, i.InvoiceDate,
                                  i.TotalAmount, i.PaymentStatus
                           FROM Invoice i JOIN Customer c ON i.CustomerID=c.CustomerID
                           ORDER BY i.InvoiceDate DESC LIMIT 200;";
            using var cmd = new MySqlCommand(sql, conn);
            using var r   = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["InvoiceID"], r["CustomerName"], r["InvoiceDate"],
                             $"HK${r["TotalAmount"]:N2}", r["PaymentStatus"]);
        }
        catch { }
    }

    private void btnRefresh_Click(object s, EventArgs e) => LoadSummary();
}
