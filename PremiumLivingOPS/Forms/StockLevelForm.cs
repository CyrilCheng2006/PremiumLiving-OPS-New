using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Stock Level viewer – mirrors stock-level.html</summary>
public partial class StockLevelForm : Form
{
    public StockLevelForm()
    {
        InitializeComponent();
        LoadStock();
    }

    private void LoadStock(string search = "")
    {
        dgvStock.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT w.WarehouseItemID, p.ProductID, p.ProductName,
                                  p.Category, w.Quantity, w.ReorderLevel, w.Location
                           FROM WarehouseItem w
                           JOIN Product p ON w.ProductID = p.ProductID
                           WHERE p.ProductName LIKE @s OR p.ProductID LIKE @s
                           ORDER BY p.Category, p.ProductName;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                int qty    = Convert.ToInt32(r["Quantity"]);
                int reorder = Convert.ToInt32(r["ReorderLevel"]);
                int rowIdx = dgvStock.Rows.Add(
                    r["WarehouseItemID"], r["ProductID"], r["ProductName"],
                    r["Category"], qty, reorder, r["Location"]);
                if (qty <= reorder)
                    dgvStock.Rows[rowIdx].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "DB Error"); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadStock(txtSearch.Text.Trim());
    private void btnRefresh_Click(object s, EventArgs e) => LoadStock();
}
