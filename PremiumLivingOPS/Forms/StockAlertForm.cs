using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Low-Stock Alerts – mirrors stock-alert.html</summary>
public partial class StockAlertForm : Form
{
    public StockAlertForm()
    {
        InitializeComponent();
        LoadAlerts();
    }

    private void LoadAlerts()
    {
        dgvAlerts.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            // Finished products below reorder
            string sql = @"SELECT 'Finished Product' AS ItemType, p.ProductID AS ItemID,
                                  p.ProductName AS ItemName, w.Quantity, w.ReorderLevel,
                                  (w.ReorderLevel - w.Quantity) AS Shortage
                           FROM WarehouseItem w JOIN Product p ON w.ProductID = p.ProductID
                           WHERE w.Quantity <= w.ReorderLevel
                           UNION ALL
                           SELECT 'Raw Material', r.MaterialID, r.MaterialName, r.StockQuantity,
                                  r.ReorderLevel, (r.ReorderLevel - r.StockQuantity)
                           FROM RawMaterial r
                           WHERE r.StockQuantity <= r.ReorderLevel
                           ORDER BY Shortage DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            using var rd  = cmd.ExecuteReader();
            while (rd.Read())
            {
                int rowIdx = dgvAlerts.Rows.Add(
                    rd["ItemType"], rd["ItemID"], rd["ItemName"],
                    rd["Quantity"], rd["ReorderLevel"], rd["Shortage"]);
                dgvAlerts.Rows[rowIdx].DefaultCellStyle.BackColor =
                    Convert.ToInt32(rd["Quantity"]) == 0
                    ? Color.FromArgb(255, 200, 200)
                    : Color.FromArgb(255, 243, 205);
            }
            lblCount.Text = $"{dgvAlerts.Rows.Count} alert(s) found";
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "DB Error"); }
    }

    private void btnRefresh_Click(object s, EventArgs e) => LoadAlerts();
}
