using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Reply Slip (Delivery Confirmation) – mirrors reply-slip.html</summary>
public partial class ReplySlipForm : Form
{
    public ReplySlipForm()
    {
        InitializeComponent();
        LoadReplySlips();
    }

    private void LoadReplySlips(string search = "")
    {
        dgvSlips.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT rs.ReplySlipID, rs.DeliveryNoteID, c.CustomerName,
                                  rs.SignedDate, rs.ReceivedBy, rs.Remarks
                           FROM ReplySlip rs
                           JOIN DeliveryNote dn ON rs.DeliveryNoteID = dn.DeliveryNoteID
                           JOIN Shipment s ON dn.ShipmentID = s.ShipmentID
                           JOIN `Order` o ON s.OrderID = o.OrderID
                           JOIN Customer c ON o.CustomerID = c.CustomerID
                           WHERE rs.ReplySlipID LIKE @s OR c.CustomerName LIKE @s
                           ORDER BY rs.SignedDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvSlips.Rows.Add(r["ReplySlipID"], r["DeliveryNoteID"], r["CustomerName"],
                                  r["SignedDate"], r["ReceivedBy"], r["Remarks"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadReplySlips(txtSearch.Text.Trim());

    private void btnRecord_Click(object s, EventArgs e)
    {
        string dnId = txtDNId.Text.Trim();
        if (string.IsNullOrEmpty(dnId)) { MessageBox.Show("Enter a Delivery Note ID."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string rsId = $"RS-{DateTime.Now:yyyyMMddHHmmss}";
            string ins  = "INSERT INTO ReplySlip (ReplySlipID, DeliveryNoteID, SignedDate, ReceivedBy, Remarks) VALUES (@rid,@dnid,CURDATE(),@rec,@rem);";
            using var cmd = new MySqlCommand(ins, conn);
            cmd.Parameters.AddWithValue("@rid",  rsId);
            cmd.Parameters.AddWithValue("@dnid", dnId);
            cmd.Parameters.AddWithValue("@rec",  txtReceivedBy.Text.Trim());
            cmd.Parameters.AddWithValue("@rem",  txtRemarks.Text.Trim());
            cmd.ExecuteNonQuery();
            LoadReplySlips();
            MessageBox.Show($"Reply Slip {rsId} recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
