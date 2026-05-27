using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Audit Log viewer – mirrors audit-log.html</summary>
public partial class AuditLogForm : Form
{
    public AuditLogForm() { InitializeComponent(); LoadLogs(); }

    private void LoadLogs(string search = "")
    {
        dgv.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT al.LogID, al.TableName, al.OperationType,
                                  al.RecordID, s.StaffName, al.ChangedAt
                           FROM AuditLog al
                           LEFT JOIN Staff s ON al.StaffID = s.StaffID
                           WHERE al.TableName LIKE @s OR al.OperationType LIKE @s
                              OR s.StaffName LIKE @s OR al.RecordID LIKE @s
                           ORDER BY al.ChangedAt DESC
                           LIMIT 500;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgv.Rows.Add(r["LogID"], r["TableName"], r["OperationType"],
                             r["RecordID"], r["StaffName"], r["ChangedAt"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadLogs(txtSearch.Text.Trim());
    private void btnRefresh_Click(object s, EventArgs e) => LoadLogs(txtSearch.Text.Trim());
}
