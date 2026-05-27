using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Product Info management – mirrors product-info.html</summary>
public partial class ProductInfoForm : Form
{
    public ProductInfoForm() { InitializeComponent(); LoadProducts(); }

    private void LoadProducts(string search = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT ProductID, ProductName, Category, UnitPrice,
                                  StockQuantity, ReorderLevel, Status
                           FROM Product
                           WHERE ProductID LIKE @s OR ProductName LIKE @s OR Category LIKE @s
                           ORDER BY ProductName;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["ProductID"], r["ProductName"], r["Category"],
                             $"HK${r["UnitPrice"]:N2}", r["StockQuantity"],
                             r["ReorderLevel"], r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadProducts(txtSearch.Text.Trim());
    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new ProductEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadProducts();
    }
    private void dgv_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new ProductEditDialog(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadProducts();
    }
}
