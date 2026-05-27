using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Stock Transfer Form – mirrors transfer-form.html</summary>
public partial class TransferFormPage : Form
{
    public TransferFormPage()
    {
        InitializeComponent();
        LoadProducts();
        LoadTransfers();
    }

    private void LoadProducts()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT ProductID, ProductName FROM Product ORDER BY ProductName;", conn);
            using var r    = cmd.ExecuteReader();
            cboProduct.Items.Clear();
            while (r.Read()) cboProduct.Items.Add(new ComboItem(r.GetString(0), r.GetString(1)));
            cboProduct.DisplayMember = "Name"; cboProduct.ValueMember = "Id";
        }
        catch { }
    }

    private void LoadTransfers()
    {
        dgvTransfers.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT tf.TransferID, p.ProductName, tf.Quantity,
                                  tf.FromLocation, tf.ToLocation, tf.TransferDate, tf.Status
                           FROM TransferForm tf
                           JOIN Product p ON tf.ProductID = p.ProductID
                           ORDER BY tf.TransferDate DESC LIMIT 200;";
            using var cmd = new MySqlCommand(sql, conn);
            using var r   = cmd.ExecuteReader();
            while (r.Read())
                dgvTransfers.Rows.Add(r["TransferID"], r["ProductName"], r["Quantity"],
                                      r["FromLocation"], r["ToLocation"], r["TransferDate"], r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSubmit_Click(object s, EventArgs e)
    {
        if (cboProduct.SelectedItem is not ComboItem ci) { MessageBox.Show("Select a product."); return; }
        if (string.IsNullOrWhiteSpace(txtFrom.Text) || string.IsNullOrWhiteSpace(txtTo.Text))
        { MessageBox.Show("Enter From and To locations."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string tid = $"TF-{DateTime.Now:yyyyMMddHHmmss}";
            string sql = "INSERT INTO TransferForm (TransferID,ProductID,StaffID,Quantity,FromLocation,ToLocation,TransferDate,Status,Remarks) " +
                         "VALUES (@tid,@pid,@sid,@qty,@frm,@to,CURDATE(),'Pending',@rem);";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tid", tid);
            cmd.Parameters.AddWithValue("@pid", ci.Id);
            cmd.Parameters.AddWithValue("@sid", SessionManager.CurrentStaff.StaffID);
            cmd.Parameters.AddWithValue("@qty", (int)numQty.Value);
            cmd.Parameters.AddWithValue("@frm", txtFrom.Text.Trim());
            cmd.Parameters.AddWithValue("@to",  txtTo.Text.Trim());
            cmd.Parameters.AddWithValue("@rem", txtRemarks.Text.Trim());
            cmd.ExecuteNonQuery();
            LoadTransfers();
            MessageBox.Show($"Transfer {tid} submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtFrom.Clear(); txtTo.Clear(); txtRemarks.Clear(); numQty.Value = 1;
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
