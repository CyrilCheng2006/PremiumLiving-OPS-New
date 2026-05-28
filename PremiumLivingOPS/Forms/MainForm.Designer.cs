namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    // Layout panels
    private Panel pnlSidebar;
    private Panel pnlContent;
    private Panel pnlHeader;

    // Sidebar brand
    private Label lblBrand;
    private Label lblBrandSub;

    // Staff info
    private Label lblStaffName;
    private Label lblRole;

    // Nav buttons (one per module)
    private Button btnNavDashboard;
    private Button btnNavCustomers;
    private Button btnNavOrders;
    private Button btnNavQuotations;
    private Button btnNavInvoices;
    private Button btnNavComplaints;
    private Button btnNavScheduleDelivery;
    private Button btnNavTrackShipment;
    private Button btnNavDeliveryNote;
    private Button btnNavReplySlip;
    private Button btnNavStockLevel;
    private Button btnNavStockAlert;
    private Button btnNavStockReport;
    private Button btnNavPurchaseOrder;
    private Button btnNavSuppliers;
    private Button btnNavTransfer;
    private Button btnNavMaterialRequest;
    private Button btnNavAccountsRecv;
    private Button btnNavAccountsPay;
    private Button btnNavFinReport;
    private Button btnNavUserMgmt;
    private Button btnNavAuditLog;
    private Button btnNavSysConfig;
    private Button btnNavReturnMgmt;
    private Button btnNavProductInfo;
    private Button btnLogout;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        SuspendLayout();

        // ===== SIDEBAR =====
        pnlSidebar = new Panel
        {
            Dock      = DockStyle.Left,
            Width     = 220,
            BackColor = UITheme.PrimaryDark
        };

        lblBrand = new Label
        {
            Text      = "PremiumLiving",
            Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
            ForeColor = UITheme.AccentGold,
            AutoSize  = false,
            Size      = new Size(220, 28),
            Location  = new Point(0, 18),
            TextAlign = ContentAlignment.MiddleCenter
        };

        lblBrandSub = new Label
        {
            Text      = "Operations System",
            Font      = UITheme.FontSmall,
            ForeColor = Color.LightGray,
            AutoSize  = false,
            Size      = new Size(220, 18),
            Location  = new Point(0, 46),
            TextAlign = ContentAlignment.MiddleCenter
        };

        lblStaffName = new Label
        {
            Font      = UITheme.FontBody,
            ForeColor = Color.White,
            AutoSize  = false,
            Size      = new Size(220, 20),
            Location  = new Point(0, 78),
            TextAlign = ContentAlignment.MiddleCenter
        };

        lblRole = new Label
        {
            Font      = UITheme.FontSmall,
            ForeColor = UITheme.AccentGold,
            AutoSize  = false,
            Size      = new Size(220, 16),
            Location  = new Point(0, 96),
            TextAlign = ContentAlignment.MiddleCenter
        };

        // Build nav buttons helper
        var navItems = new (string Text, EventHandler Handler)[]
        {
            ("\uD83D\uDCCA Dashboard",           NavDashboard_Click),
            ("\uD83D\uDC65 Customers",            NavCustomers_Click),
            ("\uD83D\uDED2 Orders",               NavOrders_Click),
            ("\uD83D\uDCC4 Quotations",           NavQuotations_Click),
            ("\uD83E\uDFBE Invoices",             NavInvoices_Click),
            ("\uD83D\uDCE2 Complaints",           NavComplaints_Click),
            ("\uD83D\uDE9A Schedule Delivery",    NavScheduleDelivery_Click),
            ("\uD83D\uDCE6 Track Shipment",       NavTrackShipment_Click),
            ("\uD83D\uDCC3 Delivery Note",        NavDeliveryNote_Click),
            ("\uD83D\uDCDD Reply Slip",           NavReplySlip_Click),
            ("\uD83C\uDFEA Stock Level",          NavStockLevel_Click),
            ("\u26A0 Stock Alert",                NavStockAlert_Click),
            ("\uD83D\uDCC8 Stock Report",         NavStockReport_Click),
            ("\uD83D\uDED2 Purchase Order",       NavPurchaseOrder_Click),
            ("\uD83C\uDFED Suppliers",            NavSuppliers_Click),
            ("\uD83D\uDD04 Transfer",             NavTransfer_Click),
            ("\uD83E\uDDF1 Material Request",     NavMaterialRequest_Click),
            ("\uD83D\uDCB0 Accounts Receivable", NavAccountsRecv_Click),
            ("\uD83D\uDCB3 Accounts Payable",    NavAccountsPay_Click),
            ("\uD83D\uDCCA Financial Report",     NavFinReport_Click),
            ("\uD83D\uDC64 User Management",      NavUserMgmt_Click),
            ("\uD83D\uDDD2 Audit Log",            NavAuditLog_Click),
            ("\u2699 System Config",              NavSysConfig_Click),
            ("\uD83D\uDD04 Return Management",    NavReturnMgmt_Click),
            ("\uD83D\uDECB Product Info",         NavProductInfo_Click),
        };

        int navY = 124;
        foreach (var (text, handler) in navItems)
        {
            var btn = new Button
            {
                Text      = text,
                Size      = new Size(220, 32),
                Location  = new Point(0, navY),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font      = UITheme.FontBody,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding   = new Padding(12, 0, 0, 0),
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize   = 0;
            btn.FlatAppearance.MouseOverBackColor = UITheme.AccentGold;
            btn.Click += handler;
            pnlSidebar.Controls.Add(btn);
            navY += 32;
        }

        btnLogout = new Button
        {
            Text      = "\uD83D\uDEAA Logout",
            Size      = new Size(220, 36),
            Location  = new Point(0, navY + 8),
            FlatStyle = FlatStyle.Flat,
            BackColor = UITheme.Danger,
            ForeColor = Color.White,
            Font      = UITheme.FontBody,
            Cursor    = Cursors.Hand
        };
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.Click += btnLogout_Click;
        pnlSidebar.Controls.AddRange(new Control[]
            { lblBrand, lblBrandSub, lblStaffName, lblRole, btnLogout });

        // ===== CONTENT =====
        pnlContent = new Panel
        {
            Dock      = DockStyle.Fill,
            BackColor = UITheme.SurfaceGray
        };

        this.Controls.AddRange(new Control[] { pnlContent, pnlSidebar });
        this.ResumeLayout(false);
    }
}
