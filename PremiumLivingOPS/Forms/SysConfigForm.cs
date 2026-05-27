using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>System Configuration – mirrors sys-config.html</summary>
public partial class SysConfigForm : Form
{
    public SysConfigForm() { InitializeComponent(); LoadConfig(); }

    private void LoadConfig()
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT ConfigKey, ConfigValue, Description FROM SystemConfig ORDER BY ConfigKey;", conn);
            using var r    = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["ConfigKey"], r["ConfigValue"], r["Description"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                string key = row.Cells[0].Value?.ToString() ?? "";
                string val = row.Cells[1].Value?.ToString() ?? "";
                using var cmd = new MySqlCommand("UPDATE SystemConfig SET ConfigValue=@v WHERE ConfigKey=@k;", conn);
                cmd.Parameters.AddWithValue("@v", val); cmd.Parameters.AddWithValue("@k", key);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Configuration saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
