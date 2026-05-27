using PremiumLivingOPS.Helpers;
using MySql.Data.MySqlClient;

namespace PremiumLivingOPS.Forms;

/// <summary>Create / view an Order with OrderLine items.</summary>
public partial class NewOrderForm : Form
{
    private readonly string? _orderId;

    public NewOrderForm(string? orderId = null)
    {
        _orderId = orderId;
        InitializeComponent();
        LoadDropdowns();
        if (orderId != null) LoadOrder(orderId);
        this.Text = orderId == null ? "New Order" : $"Order {orderId}";
    }

    private void LoadDropdowns()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            // Customers
            cmbCustomer.Items.Clear();
            using (var cmd = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer ORDER BY CustomerName;", conn))
            using (var r = cmd.ExecuteReader())
                while (r.Read())
                    cmbCustomer.Items.Add(new ComboItem(r.GetString(0), r.GetString(1)));

            // Products
            cmbProduct.Items.Clear();
            using (var cmd2 = new MySqlCommand(
                "SELECT p.ItemID, i.ItemName, p.SalesPrice FROM Product p JOIN Item i ON i.ItemID=p.ItemID ORDER BY i.ItemName;", conn))
            using (var r2 = cmd2.ExecuteReader())
                while (r2.Read())
                    cmbProduct.Items.Add(new ComboItem(r2.GetString(0), $"{r2.GetString(1)} (HK${r2.GetDecimal(2):N2})"));
        }
        catch { }
    }

    private void LoadOrder(string id)
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand(
                "SELECT * FROM `Order` WHERE OrderID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            txtOrderId.Text      = r.GetString("OrderID");
            txtContact.Text      = r.GetString("OrderContactName");
            txtShipAddr.Text     = r.GetString("ShippingAddress");
            txtBillAddr.Text     = r.GetString("BillingAddress");
            dtDelivery.Value     = r.GetDateTime("DeliveryDate");
            cmbStatus.Text       = r.GetString("OrderStatus");
            r.Close();

            // Load order lines
            using var cmd2 = new MySqlCommand(
                "SELECT ol.ItemID, i.ItemName, ol.Quantity, ol.Price FROM OrderLine ol JOIN Item i ON i.ItemID=ol.ItemID WHERE ol.OrderID=@id;", conn);
            cmd2.Parameters.AddWithValue("@id", id);
            using var r2 = cmd2.ExecuteReader();
            while (r2.Read())
                dgvLines.Rows.Add(r2["ItemID"], r2["ItemName"], r2["Quantity"], $"{r2["Price"]:N2}");
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnAddLine_Click(object s, EventArgs e)
    {
        if (cmbProduct.SelectedItem is not ComboItem item) return;
        dgvLines.Rows.Add(item.Value, item.Text, (int)nudQty.Value, 0);
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (cmbCustomer.SelectedItem is not ComboItem cust) { MessageBox.Show("Select a customer."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);

            if (_orderId == null)
            {
                // Generate new OrderID
                string newId = "ORD-" + DateTime.Now.ToString("yyMMddHHmm");
                string sql = @"INSERT INTO `Order`
                    (OrderID,CustomerID,SalesID,IssuedTime,DeliveryDate,ShippingAddress,BillingAddress,GrandTotal,OrderContactName,OrderStatus)
                    VALUES(@oid,@cid,@sid,CURDATE(),@dd,@sa,@ba,0,@cn,'Pending');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@oid", newId);
                cmd.Parameters.AddWithValue("@cid", cust.Value);
                cmd.Parameters.AddWithValue("@sid", SessionManager.CurrentStaff.StaffID);
                cmd.Parameters.AddWithValue("@dd",  dtDelivery.Value.Date);
                cmd.Parameters.AddWithValue("@sa",  txtShipAddr.Text);
                cmd.Parameters.AddWithValue("@ba",  txtBillAddr.Text);
                cmd.Parameters.AddWithValue("@cn",  txtContact.Text);
                cmd.ExecuteNonQuery();
                txtOrderId.Text = newId;
            }
            else
            {
                using var cmd = new MySqlCommand(
                    "UPDATE `Order` SET OrderStatus=@st, DeliveryDate=@dd, ShippingAddress=@sa WHERE OrderID=@oid", conn);
                cmd.Parameters.AddWithValue("@st",  cmbStatus.Text);
                cmd.Parameters.AddWithValue("@dd",  dtDelivery.Value.Date);
                cmd.Parameters.AddWithValue("@sa",  txtShipAddr.Text);
                cmd.Parameters.AddWithValue("@oid", _orderId);
                cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
    }

    private void btnCancel_Click(object s, EventArgs e) => Close();
}

/// <summary>Helper for ComboBox items with value + display text.</summary>
public class ComboItem
{
    public string Value { get; }
    public string Text  { get; }
    public ComboItem(string value, string text) { Value = value; Text = text; }
    public override string ToString() => Text;
}
