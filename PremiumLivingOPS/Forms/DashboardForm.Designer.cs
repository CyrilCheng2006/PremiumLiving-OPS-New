using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

partial class DashboardForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblPageTitle;
    // KPI cards
    private Label lblOrdersToday, lblOrdersTodayCaption;
    private Label lblPendingOrders, lblPendingOrdersCaption;
    private Label lblLowStock, lblLowStockCaption;
    private Label lblOpenComplaints, lblOpenComplaintsCaption;
    private Label lblMonthlyRevenue, lblMonthlyRevenueCaption;
    private Label lblPendingShipments, lblPendingShipmentsCaption;

    protected override void Dispose(bool disposing)
    { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private Panel MakeKPICard(string caption, Color accent, out Label valueLabel)
    {
        var pnl = new Panel
        {
            Size      = new Size(200, 100),
            BackColor = UITheme.SurfaceWhite,
            Padding   = new Padding(16)
        };
        var lblVal = new Label
        {
            Font      = new Font("Segoe UI", 28f, FontStyle.Bold),
            ForeColor = accent,
            AutoSize  = true,
            Location  = new Point(16, 14)
        };
        var lblCap = new Label
        {
            Text      = caption,
            Font      = UITheme.FontSmall,
            ForeColor = UITheme.TextMuted,
            AutoSize  = true,
            Location  = new Point(16, 62)
        };
        pnl.Controls.AddRange(new Control[] { lblVal, lblCap });
        valueLabel = lblVal;
        return pnl;
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        SuspendLayout();
        this.BackColor = UITheme.SurfaceGray;
        this.Padding   = new Padding(24);

        lblPageTitle = new Label
        {
            Text      = "Dashboard",
            Font      = UITheme.FontTitle,
            ForeColor = UITheme.TextDark,
            AutoSize  = true,
            Location  = new Point(24, 24)
        };
        this.Controls.Add(lblPageTitle);

        // KPI cards row
        var kpiData = new[]
        {
            ("Orders Today",        UITheme.Info),
            ("Pending Orders",      UITheme.Warning),
            ("Low Stock Items",     UITheme.Danger),
            ("Open Complaints",     UITheme.Danger),
            ("Monthly Revenue",     UITheme.Success),
            ("Pending Shipments",   UITheme.Info),
        };

        var valueLabels = new Label[6];
        int cx = 24;
        for (int i = 0; i < kpiData.Length; i++)
        {
            var card = MakeKPICard(kpiData[i].Item1, kpiData[i].Item2, out valueLabels[i]);
            card.Location = new Point(cx, 70);
            this.Controls.Add(card);
            cx += 216;
        }

        lblOrdersToday       = valueLabels[0];
        lblPendingOrders     = valueLabels[1];
        lblLowStock          = valueLabels[2];
        lblOpenComplaints    = valueLabels[3];
        lblMonthlyRevenue    = valueLabels[4];
        lblPendingShipments  = valueLabels[5];

        ResumeLayout(false);
    }
}
