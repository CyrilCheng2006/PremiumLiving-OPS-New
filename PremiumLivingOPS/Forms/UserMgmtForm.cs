using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>User / Staff management – mirrors user-mgmt.html</summary>
public partial class UserMgmtForm : Form
{
    public UserMgmtForm() { InitializeComponent(); LoadStaff(); }

    private void LoadStaff(string search = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT StaffID, StaffName, StaffRole, Email, Phone, Status
                           FROM Staff
                           WHERE StaffID LIKE @s OR StaffName LIKE @s
                           ORDER BY StaffName;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["StaffID"], r["StaffName"], r["StaffRole"], r["Email"], r["Phone"], r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadStaff(txtSearch.Text.Trim());
    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new UserEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadStaff();
    }
    private void dgv_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new UserEditDialog(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadStaff();
    }
}
