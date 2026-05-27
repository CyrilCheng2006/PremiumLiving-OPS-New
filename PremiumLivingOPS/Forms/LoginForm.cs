using PremiumLivingOPS.Helpers;
using PremiumLivingOPS.Models;
using MySql.Data.MySqlClient;

namespace PremiumLivingOPS.Forms;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        ApplyTheme();
    }

    private void ApplyTheme()
    {
        this.BackColor   = UITheme.PrimaryDark;
        this.ForeColor   = Color.White;
        this.Text        = "PremiumLiving OPS — Login";
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(480, 560);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string staffId  = txtStaffId.Text.Trim();
        string password = txtPassword.Text;

        if (string.IsNullOrEmpty(staffId) || string.IsNullOrEmpty(password))
        {
            ShowError("Please enter Staff ID and Password.");
            return;
        }

        try
        {
            using var conn = DBHelper.GetConnection();
            const string sql = "SELECT StaffID, StaffName, StaffRole, Email, Department " +
                               "FROM Staff WHERE StaffID = @id AND StaffPassword = @pwd LIMIT 1;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id",  staffId);
            cmd.Parameters.AddWithValue("@pwd", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var staff = new Staff
                {
                    StaffID     = reader.GetString("StaffID"),
                    StaffName   = reader.GetString("StaffName"),
                    StaffRole   = reader.GetString("StaffRole"),
                    Email       = reader.GetString("Email"),
                    Department  = reader.GetString("Department")
                };
                reader.Close();

                // Log login event
                DBHelper.SetCurrentStaff(conn, staff.StaffID);
                string logSql = "INSERT INTO `Log` (LogID, StaffID, LogType, TargetTable, LogTimeStamp) " +
                                "VALUES (UUID(), @sid, 'Login', 'Staff', NOW());";
                using var logCmd = new MySqlCommand(logSql, conn);
                logCmd.Parameters.AddWithValue("@sid", staff.StaffID);
                logCmd.ExecuteNonQuery();

                SessionManager.CurrentStaff = staff;
                var main = new MainForm();
                main.Show();
                this.Hide();
                main.FormClosed += (_, _) => this.Close();
            }
            else
            {
                ShowError("Invalid Staff ID or Password.");
            }
        }
        catch (Exception ex)
        {
            ShowError($"Connection error: {ex.Message}");
        }
    }

    private void ShowError(string msg) =>
        MessageBox.Show(msg, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
