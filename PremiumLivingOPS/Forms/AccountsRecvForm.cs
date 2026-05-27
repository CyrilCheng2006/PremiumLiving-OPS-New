using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Accounts Receivable – mirrors accounts-recv.html</summary>
public partial class AccountsRecvForm : Form
{
    public AccountsRecvForm() { InitializeComponent(); LoadAR(); }

    private void LoadAR(string search = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT i.InvoiceID, c.CustomerName, i.InvoiceDate,
                                  i.TotalAmount, i.PaymentStatus,
                                  DATEDIFF(CURDATE(), i.InvoiceDate) AS DaysOutstanding
                           FROM Invoice i JOIN Customer c ON i.CustomerID = c.CustomerID
                           WHERE i.PaymentStatus != 'Paid'
                             AND (i.InvoiceID LIKE @s OR c.CustomerName LIKE @s)
                           ORDER BY i.InvoiceDate;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["InvoiceID"], r["CustomerName"], r["InvoiceDate"],
                             $"HK${r["TotalAmount"]:N2}", r["PaymentStatus"], r["DaysOutstanding"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadAR(txtSearch.Text.Trim());

    private void btnMarkPaid_Click(object s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Select an invoice."); return; }
        string id = dgv.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            using var cmd = new MySqlCommand("UPDATE Invoice SET PaymentStatus='Paid' WHERE InvoiceID=@id;", conn);
            cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery();
            LoadAR();
            MessageBox.Show("Marked as Paid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
