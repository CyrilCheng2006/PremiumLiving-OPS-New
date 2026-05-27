using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Create / view an Invoice – mirrors invoice.html form.</summary>
public partial class InvoiceEditDialog : Form
{
    private readonly string? _invoiceId;
    public InvoiceEditDialog(string? id = null)
    {
        _invoiceId = id;
        InitializeComponent();
        LoadCustomers();
        LoadOrders();
        if (_invoiceId != null) LoadExisting();
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
            cboCustomer.DisplayMember = "Name"; cboCustomer.ValueMember = "Id";
        }
        catch { }
    }

    private void LoadOrders()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT OrderID FROM `Order` WHERE Status IN ('Confirmed','Processing') ORDER BY OrderDate DESC;", conn);
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
            using var cmd  = new MySqlCommand("SELECT * FROM Invoice WHERE InvoiceID = @id;", conn);
            cmd.Parameters.AddWithValue("@id", _invoiceId);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            foreach (ComboItem ci in cboCustomer.Items) if (ci.Id == r.GetString("CustomerID")) { cboCustomer.SelectedItem = ci; break; }
            cboOrder.SelectedItem = r["OrderID"]?.ToString();
            txtBillingAddr.Text   = r["BillingAddress"]?.ToString() ?? "";
            txtShippingAddr.Text  = r["ShippingAddress"]?.ToString() ?? "";
            cboPayStatus.SelectedItem = r["PaymentStatus"]?.ToString();
            txtComments.Text      = r["OtherComments"]?.ToString() ?? "";
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
            string iid = _invoiceId ?? $"INV-{DateTime.Now:yyyyMMddHHmmss}";
            if (_invoiceId == null)
            {
                string ins = "INSERT INTO Invoice (InvoiceID,CustomerID,StaffID,OrderID,InvoiceDate,BillingAddress,ShippingAddress,TotalAmount,PaymentStatus,OtherComments) " +
                             "VALUES (@id,@cid,@sid,@oid,CURDATE(),@ba,@sa,0,@ps,@cmt);";
                using var cmd = new MySqlCommand(ins, conn);
                cmd.Parameters.AddWithValue("@id",  iid);
                cmd.Parameters.AddWithValue("@cid", cust.Id);
                cmd.Parameters.AddWithValue("@sid", SessionManager.CurrentStaff.StaffID);
                cmd.Parameters.AddWithValue("@oid", cboOrder.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@ba",  txtBillingAddr.Text);
                cmd.Parameters.AddWithValue("@sa",  txtShippingAddr.Text);
                cmd.Parameters.AddWithValue("@ps",  cboPayStatus.SelectedItem?.ToString() ?? "Unpaid");
                cmd.Parameters.AddWithValue("@cmt", txtComments.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                string upd = "UPDATE Invoice SET BillingAddress=@ba, ShippingAddress=@sa, PaymentStatus=@ps, OtherComments=@cmt WHERE InvoiceID=@id;";
                using var cmd = new MySqlCommand(upd, conn);
                cmd.Parameters.AddWithValue("@id", iid); cmd.Parameters.AddWithValue("@ba", txtBillingAddr.Text);
                cmd.Parameters.AddWithValue("@sa", txtShippingAddr.Text); cmd.Parameters.AddWithValue("@ps", cboPayStatus.SelectedItem?.ToString() ?? "Unpaid");
                cmd.Parameters.AddWithValue("@cmt", txtComments.Text);
                cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
