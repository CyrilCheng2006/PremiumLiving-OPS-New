using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

public partial class ProductEditDialog : Form
{
    private readonly string? _id;
    public ProductEditDialog(string? id = null) { _id = id; InitializeComponent(); if (_id != null) LoadExisting(); }

    private void LoadExisting()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT * FROM Product WHERE ProductID=@id;", conn);
            cmd.Parameters.AddWithValue("@id", _id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            txtName.Text         = r["ProductName"]?.ToString() ?? "";
            txtCategory.Text     = r["Category"]?.ToString() ?? "";
            numPrice.Value       = Convert.ToDecimal(r["UnitPrice"]);
            numStock.Value       = Convert.ToDecimal(r["StockQuantity"]);
            numReorder.Value     = Convert.ToDecimal(r["ReorderLevel"]);
            cboStatus.SelectedItem = r["Status"]?.ToString();
            txtDescription.Text  = r["Description"]?.ToString() ?? "";
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Product name required."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            if (_id == null)
            {
                string pid = $"PRD-{DateTime.Now:yyyyMMddHHmmss}";
                string sql = "INSERT INTO Product (ProductID,ProductName,Category,UnitPrice,StockQuantity,ReorderLevel,Status,Description) VALUES (@id,@n,@cat,@p,@s,@r,@st,@d);";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",  pid);           cmd.Parameters.AddWithValue("@n",   txtName.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text); cmd.Parameters.AddWithValue("@p",   numPrice.Value);
                cmd.Parameters.AddWithValue("@s",   numStock.Value);   cmd.Parameters.AddWithValue("@r",   numReorder.Value);
                cmd.Parameters.AddWithValue("@st",  cboStatus.SelectedItem?.ToString() ?? "Active");
                cmd.Parameters.AddWithValue("@d",   txtDescription.Text); cmd.ExecuteNonQuery();
            }
            else
            {
                string sql = "UPDATE Product SET ProductName=@n,Category=@cat,UnitPrice=@p,StockQuantity=@s,ReorderLevel=@r,Status=@st,Description=@d WHERE ProductID=@id;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",  _id);             cmd.Parameters.AddWithValue("@n",   txtName.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text); cmd.Parameters.AddWithValue("@p",   numPrice.Value);
                cmd.Parameters.AddWithValue("@s",   numStock.Value);   cmd.Parameters.AddWithValue("@r",   numReorder.Value);
                cmd.Parameters.AddWithValue("@st",  cboStatus.SelectedItem?.ToString() ?? "Active");
                cmd.Parameters.AddWithValue("@d",   txtDescription.Text); cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
