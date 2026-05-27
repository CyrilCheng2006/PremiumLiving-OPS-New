using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Create a new Return request.</summary>
public partial class ReturnEditDialog : Form
{
    public ReturnEditDialog()
    {
        InitializeComponent();
        LoadOrders();
    }

    private void LoadOrders()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT OrderID FROM `Order` WHERE Status IN ('Delivered') ORDER BY OrderDate DESC LIMIT 200;", conn);
            using var r    = cmd.ExecuteReader();
            cboOrder.Items.Clear();
            while (r.Read()) cboOrder.Items.Add(r.GetString(0));
        }
        catch { }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (cboOrder.SelectedItem == null) { MessageBox.Show("Select an order."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string rid = $"RET-{DateTime.Now:yyyyMMddHHmmss}";
            string sql = "INSERT INTO `Return` (ReturnID, OrderID, StaffID, ReturnDate, Reason, ResolutionType, Status) VALUES (@rid,@oid,@sid,CURDATE(),@rsn,@res,'Pending');";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@rid", rid);
            cmd.Parameters.AddWithValue("@oid", cboOrder.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@sid", SessionManager.CurrentStaff!.StaffID);
            cmd.Parameters.AddWithValue("@rsn", txtReason.Text);
            cmd.Parameters.AddWithValue("@res", cboResolution.SelectedItem?.ToString() ?? "Refund");
            cmd.ExecuteNonQuery();
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
