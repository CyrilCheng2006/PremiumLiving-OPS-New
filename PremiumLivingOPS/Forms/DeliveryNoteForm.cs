using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Generate & view Delivery Notes – mirrors delivery-note.html</summary>
public partial class DeliveryNoteForm : Form
{
    public DeliveryNoteForm()
    {
        InitializeComponent();
        LoadDeliveryNotes();
    }

    private void LoadDeliveryNotes(string search = "")
    {
        dgvNotes.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT dn.DeliveryNoteID, dn.ShipmentID, c.CustomerName,
                                  dn.IssueDate, dn.DeliveryAddress, dn.Notes
                           FROM DeliveryNote dn
                           JOIN Shipment s ON dn.ShipmentID = s.ShipmentID
                           JOIN `Order` o  ON s.OrderID = o.OrderID
                           JOIN Customer c ON o.CustomerID = c.CustomerID
                           WHERE dn.DeliveryNoteID LIKE @s OR c.CustomerName LIKE @s
                           ORDER BY dn.IssueDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvNotes.Rows.Add(r["DeliveryNoteID"], r["ShipmentID"], r["CustomerName"],
                                  r["IssueDate"], r["DeliveryAddress"], r["Notes"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadDeliveryNotes(txtSearch.Text.Trim());

    private void btnGenerate_Click(object s, EventArgs e)
    {
        string shipId = txtShipmentId.Text.Trim();
        if (string.IsNullOrEmpty(shipId)) { MessageBox.Show("Enter a Shipment ID."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            // Check if already exists
            using var chk = new MySqlCommand("SELECT COUNT(*) FROM DeliveryNote WHERE ShipmentID=@sid;", conn);
            chk.Parameters.AddWithValue("@sid", shipId);
            if (Convert.ToInt32(chk.ExecuteScalar()) > 0) { MessageBox.Show("Delivery Note already exists for this shipment."); return; }
            // Get delivery address from order
            string addrSql = "SELECT o.ShippingAddress FROM Shipment s JOIN `Order` o ON s.OrderID=o.OrderID WHERE s.ShipmentID=@sid;";
            using var addrCmd = new MySqlCommand(addrSql, conn);
            addrCmd.Parameters.AddWithValue("@sid", shipId);
            string addr = addrCmd.ExecuteScalar()?.ToString() ?? "";
            string dnId = $"DN-{DateTime.Now:yyyyMMddHHmmss}";
            string ins  = "INSERT INTO DeliveryNote (DeliveryNoteID, ShipmentID, IssueDate, DeliveryAddress, Notes) VALUES (@dnid,@sid,CURDATE(),@addr,@notes);";
            using var cmd = new MySqlCommand(ins, conn);
            cmd.Parameters.AddWithValue("@dnid",  dnId);
            cmd.Parameters.AddWithValue("@sid",   shipId);
            cmd.Parameters.AddWithValue("@addr",  addr);
            cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
            cmd.ExecuteNonQuery();
            LoadDeliveryNotes();
            MessageBox.Show($"Delivery Note {dnId} generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
