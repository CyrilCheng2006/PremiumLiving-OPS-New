using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

public partial class UserEditDialog : Form
{
    private readonly string? _id;
    public UserEditDialog(string? id = null) { _id = id; InitializeComponent(); if (_id != null) LoadExisting(); }

    private void LoadExisting()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT * FROM Staff WHERE StaffID=@id;", conn);
            cmd.Parameters.AddWithValue("@id", _id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            txtName.Text  = r["StaffName"]?.ToString() ?? "";
            txtEmail.Text = r["Email"]?.ToString() ?? "";
            txtPhone.Text = r["Phone"]?.ToString() ?? "";
            cboRole.SelectedItem   = r["StaffRole"]?.ToString();
            cboStatus.SelectedItem = r["Status"]?.ToString();
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Name is required."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            if (_id == null)
            {
                string sid = $"STF-{DateTime.Now:yyyyMMddHHmmss}";
                string sql = "INSERT INTO Staff (StaffID,StaffName,StaffRole,Email,Phone,Status,PasswordHash) VALUES (@id,@n,@r,@e,@p,@st,MD5(@pw));";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", sid); cmd.Parameters.AddWithValue("@n",  txtName.Text);
                cmd.Parameters.AddWithValue("@r",  cboRole.SelectedItem?.ToString() ?? "Staff");
                cmd.Parameters.AddWithValue("@e",  txtEmail.Text); cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@st", cboStatus.SelectedItem?.ToString() ?? "Active");
                cmd.Parameters.AddWithValue("@pw", txtPassword.Text.Trim() == "" ? "password123" : txtPassword.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                string sql = txtPassword.Text.Trim() == ""
                    ? "UPDATE Staff SET StaffName=@n,StaffRole=@r,Email=@e,Phone=@p,Status=@st WHERE StaffID=@id;"
                    : "UPDATE Staff SET StaffName=@n,StaffRole=@r,Email=@e,Phone=@p,Status=@st,PasswordHash=MD5(@pw) WHERE StaffID=@id;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", _id); cmd.Parameters.AddWithValue("@n",  txtName.Text);
                cmd.Parameters.AddWithValue("@r",  cboRole.SelectedItem?.ToString() ?? "Staff");
                cmd.Parameters.AddWithValue("@e",  txtEmail.Text); cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@st", cboStatus.SelectedItem?.ToString() ?? "Active");
                if (txtPassword.Text.Trim() != "") cmd.Parameters.AddWithValue("@pw", txtPassword.Text);
                cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
