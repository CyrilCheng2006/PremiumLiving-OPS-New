using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Schedule Delivery – mirrors schedule-delivery.html</summary>
public partial class ScheduleDeliveryForm : Form
{
    public ScheduleDeliveryForm()
    {
        InitializeComponent();
        LoadPendingOrders();
        LoadScheduled();
    }

    private void LoadPendingOrders()
    {
        dgvPending.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT o.OrderID, c.CustomerName, o.DeliveryDate, o.ShippingAddress, o.Status
                           FROM `Order` o JOIN Customer c ON o.CustomerID = c.CustomerID
                           WHERE o.Status IN ('Confirmed','Processing')
                           ORDER BY o.DeliveryDate;";
            using var cmd = new MySqlCommand(sql, conn);
            using var r   = cmd.ExecuteReader();
            while (r.Read())
                dgvPending.Rows.Add(r["OrderID"], r["CustomerName"], r["DeliveryDate"], r["ShippingAddress"], r["Status"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void LoadScheduled()
    {
        dgvScheduled.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT s.ShipmentID, s.OrderID, c.CustomerName, s.ScheduledDate, s.Status, s.DriverName
                           FROM Shipment s JOIN `Order` o ON s.OrderID = o.OrderID
                           JOIN Customer c ON o.CustomerID = c.CustomerID
                           ORDER BY s.ScheduledDate DESC LIMIT 100;";
            using var cmd = new MySqlCommand(sql, conn);
            using var r   = cmd.ExecuteReader();
            while (r.Read())
                dgvScheduled.Rows.Add(r["ShipmentID"], r["OrderID"], r["CustomerName"], r["ScheduledDate"], r["Status"], r["DriverName"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSchedule_Click(object s, EventArgs e)
    {
        if (dgvPending.SelectedRows.Count == 0) { MessageBox.Show("Select an order."); return; }
        string orderId = dgvPending.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string sId = $"SH-{DateTime.Now:yyyyMMddHHmmss}";
            string sql = "INSERT INTO Shipment (ShipmentID, OrderID, ScheduledDate, Status, DriverName) VALUES (@sid,@oid,@dt,'Scheduled',@drv);";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@sid", sId);
            cmd.Parameters.AddWithValue("@oid", orderId);
            cmd.Parameters.AddWithValue("@dt",  dtpSchedule.Value.Date);
            cmd.Parameters.AddWithValue("@drv", txtDriver.Text.Trim());
            cmd.ExecuteNonQuery();
            string upd = "UPDATE `Order` SET Status='Scheduled' WHERE OrderID=@oid;";
            using var u = new MySqlCommand(upd, conn);
            u.Parameters.AddWithValue("@oid", orderId); u.ExecuteNonQuery();
            LoadPendingOrders(); LoadScheduled();
            MessageBox.Show("Delivery scheduled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
