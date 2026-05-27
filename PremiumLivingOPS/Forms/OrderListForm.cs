using PremiumLivingOPS.Helpers;
using MySql.Data.MySqlClient;

namespace PremiumLivingOPS.Forms;

public partial class OrderListForm : Form
{
    public OrderListForm() { InitializeComponent(); LoadOrders(); }

    private void LoadOrders(string search = "", string status = "All")
    {
        dgvOrders.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT o.OrderID, c.CustomerName, o.IssuedTime, o.DeliveryDate,
                                  o.GrandTotal, o.OrderStatus, o.OrderContactName
                           FROM `Order` o
                           JOIN Customer c ON c.CustomerID = o.CustomerID
                           WHERE 1=1";
            if (!string.IsNullOrEmpty(search))
                sql += " AND (o.OrderID LIKE @s OR c.CustomerName LIKE @s)";
            if (status != "All")
                sql += " AND o.OrderStatus = @st";
            sql += " ORDER BY o.IssuedTime DESC;";

            using var cmd = new MySqlCommand(sql, conn);
            if (!string.IsNullOrEmpty(search))  cmd.Parameters.AddWithValue("@s",  $"%{search}%");
            if (status != "All")                 cmd.Parameters.AddWithValue("@st", status);

            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvOrders.Rows.Add(r["OrderID"], r["CustomerName"],
                    ((DateTime)r["IssuedTime"]).ToString("yyyy-MM-dd"),
                    ((DateTime)r["DeliveryDate"]).ToString("yyyy-MM-dd"),
                    $"HK$ {r["GrandTotal"]:N2}", r["OrderStatus"], r["OrderContactName"]);
        }
        catch (Exception ex)
        { MessageBox.Show(ex.Message, "Error"); }
    }

    private void txtSearch_TextChanged(object s, EventArgs e) =>
        LoadOrders(txtSearch.Text, cmbStatus.Text);
    private void cmbStatus_SelectedIndexChanged(object s, EventArgs e) =>
        LoadOrders(txtSearch.Text, cmbStatus.Text);
    private void btnNewOrder_Click(object s, EventArgs e)
    {
        using var dlg = new NewOrderForm();
        if (dlg.ShowDialog() == DialogResult.OK) LoadOrders();
    }
    private void dgvOrders_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgvOrders.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new NewOrderForm(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadOrders();
    }
}
