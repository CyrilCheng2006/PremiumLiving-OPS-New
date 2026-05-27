using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>
/// Shell form: left-side navigation sidebar + right-side content area.
/// Mirrors the HTML prototype sidebar layout.
/// </summary>
public partial class MainForm : Form
{
    private Form? _currentChild;

    public MainForm()
    {
        InitializeComponent();
        ApplyTheme();
        lblStaffName.Text = SessionManager.CurrentStaff?.StaffName ?? "";
        lblRole.Text      = SessionManager.CurrentStaff?.StaffRole ?? "";
        LoadPage(new DashboardForm());
    }

    private void ApplyTheme()
    {
        this.Text          = "PremiumLiving Operations System";
        this.WindowState   = FormWindowState.Maximized;
        this.BackColor     = UITheme.SurfaceGray;
        this.MinimumSize   = new Size(1280, 720);
    }

    // ---- Navigation click handlers ----
    private void NavDashboard_Click(object s, EventArgs e)         => LoadPage(new DashboardForm());
    private void NavCustomers_Click(object s, EventArgs e)          => LoadPage(new CustomerListForm());
    private void NavOrders_Click(object s, EventArgs e)             => LoadPage(new OrderListForm());
    private void NavQuotations_Click(object s, EventArgs e)         => LoadPage(new QuotationForm());
    private void NavInvoices_Click(object s, EventArgs e)           => LoadPage(new InvoiceForm());
    private void NavComplaints_Click(object s, EventArgs e)         => LoadPage(new ComplaintListForm());
    private void NavScheduleDelivery_Click(object s, EventArgs e)   => LoadPage(new ScheduleDeliveryForm());
    private void NavTrackShipment_Click(object s, EventArgs e)      => LoadPage(new TrackShipmentForm());
    private void NavDeliveryNote_Click(object s, EventArgs e)       => LoadPage(new DeliveryNoteForm());
    private void NavReplySlip_Click(object s, EventArgs e)          => LoadPage(new ReplySlipForm());
    private void NavStockLevel_Click(object s, EventArgs e)         => LoadPage(new StockLevelForm());
    private void NavStockAlert_Click(object s, EventArgs e)         => LoadPage(new StockAlertForm());
    private void NavStockReport_Click(object s, EventArgs e)        => LoadPage(new StockReportForm());
    private void NavPurchaseOrder_Click(object s, EventArgs e)      => LoadPage(new PurchaseOrderForm());
    private void NavSuppliers_Click(object s, EventArgs e)          => LoadPage(new SupplierListForm());
    private void NavTransfer_Click(object s, EventArgs e)           => LoadPage(new TransferFormPage());
    private void NavMaterialRequest_Click(object s, EventArgs e)    => LoadPage(new MaterialRequestForm());
    private void NavAccountsRecv_Click(object s, EventArgs e)       => LoadPage(new AccountsRecvForm());
    private void NavAccountsPay_Click(object s, EventArgs e)        => LoadPage(new AccountsPayForm());
    private void NavFinReport_Click(object s, EventArgs e)          => LoadPage(new FinReportForm());
    private void NavUserMgmt_Click(object s, EventArgs e)           => LoadPage(new UserMgmtForm());
    private void NavAuditLog_Click(object s, EventArgs e)           => LoadPage(new AuditLogForm());
    private void NavSysConfig_Click(object s, EventArgs e)          => LoadPage(new SysConfigForm());
    private void NavReturnMgmt_Click(object s, EventArgs e)         => LoadPage(new ReturnMgmtForm());
    private void NavProductInfo_Click(object s, EventArgs e)        => LoadPage(new ProductInfoForm());

    private void btnLogout_Click(object s, EventArgs e)
    {
        if (MessageBox.Show("Logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            SessionManager.Logout();
            this.Close();
        }
    }

    /// <summary>Load a page Form into the content panel.</summary>
    private void LoadPage(Form page)
    {
        _currentChild?.Hide();
        _currentChild?.Dispose();

        page.TopLevel      = false;
        page.FormBorderStyle = FormBorderStyle.None;
        page.Dock          = DockStyle.Fill;
        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(page);
        page.Show();
        _currentChild = page;
    }
}
