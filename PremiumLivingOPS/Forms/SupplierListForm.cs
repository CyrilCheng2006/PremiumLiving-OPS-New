using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Supplier list – mirrors supplier-list.html</summary>
public partial class SupplierListForm : Form
{
    public SupplierListForm() { InitializeComponent(); LoadSuppliers(); }

    private void LoadSuppliers(string search = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT SupplierID, SupplierName, ContactPerson, Phone, Email, Address, Status
                           FROM Supplier
                           WHERE SupplierID LIKE @s OR SupplierName LIKE @s
                           ORDER BY SupplierName;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["SupplierID"], r["SupplierName"], r["ContactPerson"], r["Phone"], r["Email"], r["Address"], r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadSuppliers(txtSearch.Text.Trim());
    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new SupplierEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadSuppliers();
    }
    private void dgv_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new SupplierEditDialog(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadSuppliers();
    }
}
