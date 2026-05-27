using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

public partial class SupplierEditDialog : Form
{
    private readonly string? _id;
    public SupplierEditDialog(string? id = null) { _id = id; InitializeComponent(); if (_id != null) LoadExisting(); }

    private void LoadExisting()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT * FROM Supplier WHERE SupplierID=@id;", conn);
            cmd.Parameters.AddWithValue("@id", _id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            txtName.Text    = r["SupplierName"]?.ToString() ?? "";
            txtContact.Text = r["ContactPerson"]?.ToString() ?? "";
            txtPhone.Text   = r["Phone"]?.ToString() ?? "";
            txtEmail.Text   = r["Email"]?.ToString() ?? "";
            txtAddress.Text = r["Address"]?.ToString() ?? "";
            cboStatus.SelectedItem = r["Status"]?.ToString();
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Supplier name is required."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            if (_id == null)
            {
                string sid = $"SUP-{DateTime.Now:yyyyMMddHHmmss}";
                string sql = "INSERT INTO Supplier (SupplierID,SupplierName,ContactPerson,Phone,Email,Address,Status) VALUES (@id,@n,@c,@p,@e,@a,@st);";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", sid); cmd.Parameters.AddWithValue("@n",  txtName.Text);
                cmd.Parameters.AddWithValue("@c",  txtContact.Text); cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@e",  txtEmail.Text);   cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                cmd.Parameters.AddWithValue("@st", cboStatus.SelectedItem?.ToString() ?? "Active"); cmd.ExecuteNonQuery();
            }
            else
            {
                string sql = "UPDATE Supplier SET SupplierName=@n,ContactPerson=@c,Phone=@p,Email=@e,Address=@a,Status=@st WHERE SupplierID=@id;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", _id); cmd.Parameters.AddWithValue("@n",  txtName.Text);
                cmd.Parameters.AddWithValue("@c",  txtContact.Text); cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@e",  txtEmail.Text);   cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                cmd.Parameters.AddWithValue("@st", cboStatus.SelectedItem?.ToString() ?? "Active"); cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
