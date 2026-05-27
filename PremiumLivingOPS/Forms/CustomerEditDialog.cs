using PremiumLivingOPS.Helpers;
using MySql.Data.MySqlClient;

namespace PremiumLivingOPS.Forms;

/// <summary>Add / Edit Customer dialog.</summary>
public partial class CustomerEditDialog : Form
{
    private readonly string? _customerId;

    public CustomerEditDialog(string? customerId = null)
    {
        _customerId = customerId;
        InitializeComponent();
        if (customerId != null) LoadCustomer(customerId);
        this.Text = customerId == null ? "Add Customer" : "Edit Customer";
    }

    private void LoadCustomer(string id)
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand(
                "SELECT * FROM Customer WHERE CustomerID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var r = cmd.ExecuteReader();
            if (r.Read())
            {
                txtID.Text    = r.GetString("CustomerID");
                txtName.Text  = r.GetString("CustomerName");
                txtEmail.Text = r.GetString("EmailAddress");
                txtPhone.Text = r.GetString("PhoneNumber");
                txtID.Enabled = false;
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtID.Text) ||
            string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Customer ID and Name are required.");
            return;
        }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);

            string sql = _customerId == null
                ? "INSERT INTO Customer (CustomerID,CustomerName,EmailAddress,PhoneNumber) VALUES (@id,@name,@email,@phone)"
                : "UPDATE Customer SET CustomerName=@name, EmailAddress=@email, PhoneNumber=@phone WHERE CustomerID=@id";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id",    txtID.Text.Trim());
            cmd.Parameters.AddWithValue("@name",  txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            cmd.ExecuteNonQuery();
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
    }

    private void btnCancel_Click(object s, EventArgs e) => Close();
}
