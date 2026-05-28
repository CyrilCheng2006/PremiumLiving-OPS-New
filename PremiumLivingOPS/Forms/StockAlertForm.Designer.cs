namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class StockAlertForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle, lblCount;
    private Button btnRefresh;
    private DataGridView dgvAlerts;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        BackColor = UITheme.SurfaceGray; Padding = new Padding(24);
        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 56 };
        lblTitle   = new Label { Text = "⚠ Stock Alerts", Font = UITheme.FontTitle, ForeColor = UITheme.Danger, AutoSize = true, Location = new Point(0, 8) };
        lblCount   = new Label { Text = "", Font = UITheme.FontBody, ForeColor = UITheme.TextMuted, AutoSize = true, Location = new Point(300, 18) };
        btnRefresh = new Button { Text = "Refresh", Size = new Size(80, 28), Location = new Point(800, 14), BackColor = UITheme.Info, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnRefresh.FlatAppearance.BorderSize = 0; btnRefresh.Click += btnRefresh_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblCount, btnRefresh });

        dgvAlerts = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvAlerts.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Type",          Name = "Type" },
            new DataGridViewTextBoxColumn { HeaderText = "Item ID",       Name = "IID" },
            new DataGridViewTextBoxColumn { HeaderText = "Item Name",     Name = "IName" },
            new DataGridViewTextBoxColumn { HeaderText = "Current Stock", Name = "Qty" },
            new DataGridViewTextBoxColumn { HeaderText = "Reorder Level", Name = "Reorder" },
            new DataGridViewTextBoxColumn { HeaderText = "Shortage",      Name = "Shortage" },
        });
        Controls.AddRange(new Control[] { dgvAlerts, pnlHeader });
        ResumeLayout(false);
    }
}
