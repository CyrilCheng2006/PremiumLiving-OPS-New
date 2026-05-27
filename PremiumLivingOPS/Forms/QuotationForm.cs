using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;
using PremiumLivingOPS.Models;

namespace PremiumLivingOPS.Forms;

/// <summary>Quotation management – mirrors quotation.html</summary>
public partial class QuotationForm : Form
{
    public QuotationForm()
    {
        InitializeComponent();
        LoadQuotations();
    }

    private void LoadQuotations(string search = "")
    {
        dgvQuotations.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT q.QuotationID, q.QuotationDate, q.ValidUntil,
                                  c.CustomerName, q.TotalAmount, q.Status
                           FROM Quotation q
                           JOIN Customer c ON q.CustomerID = c.CustomerID
                           WHERE q.QuotationID LIKE @s OR c.CustomerName LIKE @s
                           ORDER BY q.QuotationDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvQuotations.Rows.Add(
                    r["QuotationID"], r["QuotationDate"], r["ValidUntil"],
                    r["CustomerName"], $"HK${r["TotalAmount"]:N2}", r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "DB Error"); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadQuotations(txtSearch.Text.Trim());
    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new QuotationEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadQuotations();
    }
    private void dgvQuotations_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgvQuotations.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new QuotationEditDialog(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadQuotations();
    }
}
