using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>New / edit complaint – mirrors new-complaint.html</summary>
public partial class ComplaintNewForm : Form
{
    private readonly string? _cid;
    public ComplaintNewForm(string? id = null)
    {
        _cid = id;
        InitializeComponent();
        LoadCustomers();
        LoadOrders();
        if (_cid != null) LoadExisting();
    }

    private void LoadCustomers()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer ORDER BY CustomerName;", conn);
            using var r    = cmd.ExecuteReader();
            cboCustomer.Items.Clear();
            while (r.Read()) cboCustomer.Items.Add(new ComboItem(r.GetString(0), r.GetString(1)));
        }
        catch { }
    }

    private void LoadOrders()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT OrderID FROM `Order` ORDER BY OrderDate DESC LIMIT 100;", conn);
            using var r    = cmd.ExecuteReader();
            cboOrder.Items.Clear();
            while (r.Read()) cboOrder.Items.Add(r.GetString(0));
        }
        catch { }
    }

    private void LoadExisting()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT * FROM Complaint WHERE ComplaintID=@id;", conn);
            cmd.Parameters.AddWithValue("@id", _cid);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            foreach (ComboItem ci in cboCustomer.Items) if (ci.Id == r.GetString("CustomerID")) { cboCustomer.SelectedItem = ci; break; }
            cboOrder.SelectedItem = r["OrderID"]?.ToString();
            txtSerial.Text = r["ProductSerial"]?.ToString() ?? "";
            txtDesc.Text   = r["ComplaintDescription"]?.ToString() ?? "";
            cboResolution.SelectedItem = r["PreferredResolution"]?.ToString();
            cboStatus.SelectedItem     = r["Status"]?.ToString();
            txtContact.Text = r["ContactInfo"]?.ToString() ?? "";
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (cboCustomer.SelectedItem is not ComboItem cust) { MessageBox.Show("Select a customer."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string cid = _cid ?? $"CMP-{DateTime.Now:yyyyMMddHHmmss}";
            if (_cid == null)
            {
                string ins = "INSERT INTO Complaint (ComplaintID,CustomerID,StaffID,OrderID,ProductSerial,ComplaintDate,ComplaintDescription,PreferredResolution,Status,ContactInfo) " +
                             "VALUES (@cid,@cust,@sid,@oid,@ser,CURDATE(),@desc,@res,'Open',@con);";
                using var cmd = new MySqlCommand(ins, conn);
                cmd.Parameters.AddWithValue("@cid",  cid);
                cmd.Parameters.AddWithValue("@cust", cust.Id);
                cmd.Parameters.AddWithValue("@sid",  SessionManager.CurrentStaff.StaffID);
                cmd.Parameters.AddWithValue("@oid",  cboOrder.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@ser",  txtSerial.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@res",  cboResolution.SelectedItem?.ToString() ?? "Refund");
                cmd.Parameters.AddWithValue("@con",  txtContact.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                string upd = "UPDATE Complaint SET OrderID=@oid, ProductSerial=@ser, ComplaintDescription=@desc, PreferredResolution=@res, Status=@st, ContactInfo=@con WHERE ComplaintID=@cid;";
                using var cmd = new MySqlCommand(upd, conn);
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@oid", cboOrder.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@ser", txtSerial.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@res", cboResolution.SelectedItem?.ToString() ?? "Refund");
                cmd.Parameters.AddWithValue("@st",  cboStatus.SelectedItem?.ToString() ?? "Open");
                cmd.Parameters.AddWithValue("@con", txtContact.Text);
                cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
