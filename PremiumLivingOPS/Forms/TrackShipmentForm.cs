using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Track Shipment – mirrors track-shipment.html</summary>
public partial class TrackShipmentForm : Form
{
    public TrackShipmentForm()
    {
        InitializeComponent();
        LoadShipments();
    }

    private void LoadShipments(string search = "")
    {
        dgvShipments.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT s.ShipmentID, s.OrderID, c.CustomerName,
                                  s.ScheduledDate, s.ActualDeliveryDate, s.Status, s.DriverName
                           FROM Shipment s JOIN `Order` o ON s.OrderID = o.OrderID
                           JOIN Customer c ON o.CustomerID = c.CustomerID
                           WHERE s.ShipmentID LIKE @s OR s.OrderID LIKE @s OR c.CustomerName LIKE @s
                           ORDER BY s.ScheduledDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvShipments.Rows.Add(r["ShipmentID"], r["OrderID"], r["CustomerName"],
                                      r["ScheduledDate"], r["ActualDeliveryDate"], r["Status"], r["DriverName"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadShipments(txtSearch.Text.Trim());

    private void btnMarkDelivered_Click(object s, EventArgs e)
    {
        if (dgvShipments.SelectedRows.Count == 0) { MessageBox.Show("Select a shipment."); return; }
        string sid = dgvShipments.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string sql = "UPDATE Shipment SET Status='Delivered', ActualDeliveryDate=CURDATE() WHERE ShipmentID=@sid;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@sid", sid); cmd.ExecuteNonQuery();
            string upd = "UPDATE `Order` SET Status='Delivered' WHERE OrderID=(SELECT OrderID FROM Shipment WHERE ShipmentID=@sid);";
            using var u = new MySqlCommand(upd, conn);
            u.Parameters.AddWithValue("@sid", sid); u.ExecuteNonQuery();
            LoadShipments();
            MessageBox.Show("Marked as Delivered.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
