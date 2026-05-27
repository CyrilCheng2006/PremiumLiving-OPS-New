using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Stock Report – mirrors stock-report.html</summary>
public partial class StockReportForm : Form
{
    public StockReportForm()
    {
        InitializeComponent();
        LoadCategories();
        LoadReport();
    }

    private void LoadCategories()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT DISTINCT Category FROM Product ORDER BY Category;", conn);
            using var r    = cmd.ExecuteReader();
            cboCategory.Items.Clear();
            cboCategory.Items.Add("All");
            while (r.Read()) cboCategory.Items.Add(r.GetString(0));
            cboCategory.SelectedIndex = 0;
        }
        catch { }
    }

    private void LoadReport()
    {
        dgvReport.Rows.Clear();
        lblTotal.Text = "";
        try
        {
            using var conn = DBHelper.GetConnection();
            string catFilter = cboCategory.SelectedItem?.ToString() == "All" ? "" :
                               $" AND p.Category = '{MySqlHelper.EscapeString(cboCategory.SelectedItem?.ToString() ?? "")}' ";
            string sql = $@"SELECT p.ProductID, p.ProductName, p.Category,
                                   w.Quantity, w.ReorderLevel,
                                   p.UnitPrice,
                                   (w.Quantity * p.UnitPrice) AS StockValue
                            FROM WarehouseItem w JOIN Product p ON w.ProductID = p.ProductID
                            WHERE 1=1 {catFilter}
                            ORDER BY p.Category, p.ProductName;";
            using var cmd = new MySqlCommand(sql, conn);
            decimal totalValue = 0m;
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                decimal sv = Convert.ToDecimal(r["StockValue"]);
                totalValue += sv;
                dgvReport.Rows.Add(r["ProductID"], r["ProductName"], r["Category"],
                                   r["Quantity"], r["ReorderLevel"],
                                   $"HK${r["UnitPrice"]:N2}", $"HK${sv:N2}");
            }
            lblTotal.Text = $"Total Stock Value: HK${totalValue:N2}";
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "DB Error"); }
    }

    private void btnGenerate_Click(object s, EventArgs e) => LoadReport();
}
