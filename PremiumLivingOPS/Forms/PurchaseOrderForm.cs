using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Purchase Order management – mirrors purchase-order.html</summary>
public partial class PurchaseOrderForm : Form
{
    public PurchaseOrderForm() { InitializeComponent(); LoadPOs(); }

    private void LoadPOs(string search = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT po.POID, s.SupplierName, po.OrderDate, po.ExpectedDate,
                                  po.TotalAmount, po.Status
                           FROM PurchaseOrder po JOIN Supplier s ON po.SupplierID = s.SupplierID
                           WHERE po.POID LIKE @s OR s.SupplierName LIKE @s
                           ORDER BY po.OrderDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["POID"], r["SupplierName"], r["OrderDate"],
                             r["ExpectedDate"], $"HK${r["TotalAmount"]:N2}", r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadPOs(txtSearch.Text.Trim());
    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new PurchaseOrderEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadPOs();
    }
    private void dgv_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new PurchaseOrderEditDialog(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadPOs();
    }
}
