using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Accounts Payable – mirrors accounts-pay.html</summary>
public partial class AccountsPayForm : Form
{
    public AccountsPayForm() { InitializeComponent(); LoadAP(); }

    private void LoadAP(string search = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT po.POID, s.SupplierName, po.OrderDate, po.ExpectedDate,
                                  po.TotalAmount, po.Status,
                                  DATEDIFF(po.ExpectedDate, CURDATE()) AS DaysUntilDue
                           FROM PurchaseOrder po JOIN Supplier s ON po.SupplierID = s.SupplierID
                           WHERE po.Status NOT IN ('Cancelled')
                             AND (po.POID LIKE @s OR s.SupplierName LIKE @s)
                           ORDER BY po.ExpectedDate;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["POID"], r["SupplierName"], r["OrderDate"],
                             r["ExpectedDate"], $"HK${r["TotalAmount"]:N2}", r["Status"], r["DaysUntilDue"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadAP(txtSearch.Text.Trim());

    private void btnMarkPaid_Click(object s, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Select a PO."); return; }
        string id = dgv.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            using var cmd = new MySqlCommand("UPDATE PurchaseOrder SET Status='Received' WHERE POID=@id;", conn);
            cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery();
            LoadAP();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
