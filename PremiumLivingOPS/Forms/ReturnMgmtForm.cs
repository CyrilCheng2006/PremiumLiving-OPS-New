using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Return Management – mirrors return-mgmt.html</summary>
public partial class ReturnMgmtForm : Form
{
    public ReturnMgmtForm()
    {
        InitializeComponent();
        LoadReturns();
    }

    private void LoadReturns(string search = "")
    {
        dgvReturns.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT r.ReturnID, r.OrderID, c.CustomerName,
                                  r.ReturnDate, r.Reason, r.ResolutionType, r.Status
                           FROM `Return` r
                           JOIN `Order` o ON r.OrderID = o.OrderID
                           JOIN Customer c ON o.CustomerID = c.CustomerID
                           WHERE r.ReturnID LIKE @s OR c.CustomerName LIKE @s
                           ORDER BY r.ReturnDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvReturns.Rows.Add(r["ReturnID"], r["OrderID"], r["CustomerName"],
                                    r["ReturnDate"], r["Reason"], r["ResolutionType"], r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadReturns(txtSearch.Text.Trim());

    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new ReturnEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadReturns();
    }

    private void btnApprove_Click(object s, EventArgs e)
    {
        if (dgvReturns.SelectedRows.Count == 0) { MessageBox.Show("Select a return record."); return; }
        string rid = dgvReturns.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string sql = "UPDATE `Return` SET Status='Approved' WHERE ReturnID=@rid;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@rid", rid); cmd.ExecuteNonQuery();
            LoadReturns();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
