using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Invoice management – mirrors invoice.html</summary>
public partial class InvoiceForm : Form
{
    public InvoiceForm()
    {
        InitializeComponent();
        LoadInvoices();
    }

    private void LoadInvoices(string search = "")
    {
        dgvInvoices.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT i.InvoiceID, i.InvoiceDate, c.CustomerName,
                                  i.TotalAmount, i.PaymentStatus
                           FROM Invoice i JOIN Customer c ON i.CustomerID = c.CustomerID
                           WHERE i.InvoiceID LIKE @s OR c.CustomerName LIKE @s
                           ORDER BY i.InvoiceDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvInvoices.Rows.Add(r["InvoiceID"], r["InvoiceDate"], r["CustomerName"],
                                     $"HK${r["TotalAmount"]:N2}", r["PaymentStatus"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "DB Error"); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadInvoices(txtSearch.Text.Trim());

    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new InvoiceEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadInvoices();
    }

    private void dgvInvoices_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgvInvoices.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new InvoiceEditDialog(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadInvoices();
    }
}
