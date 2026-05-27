using PremiumLivingOPS.Helpers;
using MySql.Data.MySqlClient;

namespace PremiumLivingOPS.Forms;

public partial class DashboardForm : Form
{
    public DashboardForm()
    {
        InitializeComponent();
        LoadKPIs();
    }

    private void LoadKPIs()
    {
        try
        {
            using var conn = DBHelper.GetConnection();

            // Total orders today
            lblOrdersToday.Text = QueryScalar(conn,
                "SELECT COUNT(*) FROM `Order` WHERE IssuedTime = CURDATE()").ToString();

            // Pending orders
            lblPendingOrders.Text = QueryScalar(conn,
                "SELECT COUNT(*) FROM `Order` WHERE OrderStatus IN ('Pending','Processing')").ToString();

            // Low stock items
            lblLowStock.Text = QueryScalar(conn,
                "SELECT COUNT(*) FROM WarehouseItem WHERE WarehouseItemQuantity <= ReorderLevel").ToString();

            // Open complaints
            lblOpenComplaints.Text = QueryScalar(conn,
                "SELECT COUNT(*) FROM Complaint WHERE ComplaintStatus IN ('Pending','Processing')").ToString();

            // Monthly revenue
            var rev = QueryScalar(conn,
                "SELECT IFNULL(SUM(PaidAmount),0) FROM Invoice " +
                "WHERE MONTH(InvoiceDate)=MONTH(NOW()) AND YEAR(InvoiceDate)=YEAR(NOW())");
            lblMonthlyRevenue.Text = $"HK$ {rev:N0}";

            // Pending shipments
            lblPendingShipments.Text = QueryScalar(conn,
                "SELECT COUNT(*) FROM Shipment WHERE ShipmentStatus='Pending'").ToString();
        }
        catch { /* show zeros on DB error */ }
    }

    private static object QueryScalar(MySqlConnection conn, string sql)
    {
        using var cmd = new MySqlCommand(sql, conn);
        return cmd.ExecuteScalar() ?? 0;
    }
}
