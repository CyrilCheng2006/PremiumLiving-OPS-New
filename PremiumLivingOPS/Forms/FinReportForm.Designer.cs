namespace PremiumLivingOPS.Forms;

partial class FinReportForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader, pnlCards;
    private Label lblTitle, lblRevLbl, lblRevenue, lblOutLbl, lblOutstanding, lblExpLbl, lblExpenses;
    private Button btnRefresh;
    private DataGridView dgv;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        SuspendLayout(); BackColor = UITheme.SurfaceGray; Padding = new Padding(24);
        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = UITheme.SurfaceGray };
        lblTitle  = new Label { Text = "📈 Financial Report", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        btnRefresh = new Button { Text = "🔄 Refresh", Size = new Size(100, 28), Location = new Point(776, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnRefresh.FlatAppearance.BorderSize = 0; btnRefresh.Click += btnRefresh_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, btnRefresh });

        pnlCards = new Panel { Location = new Point(0, 64), Size = new Size(900, 90), BackColor = UITheme.SurfaceGray };
        // Revenue card
        var cRev = new Panel { Location = new Point(0, 0), Size = new Size(280, 80), BackColor = UITheme.SurfaceWhite };
        lblRevLbl  = new Label { Text = "Monthly Revenue",  Location = new Point(10, 8),  AutoSize = true, ForeColor = UITheme.TextMid };
        lblRevenue = new Label { Text = "HK$0.00", Location = new Point(10, 32), AutoSize = true, Font = UITheme.FontTitle, ForeColor = UITheme.Success };
        cRev.Controls.AddRange(new Control[] { lblRevLbl, lblRevenue });
        // Outstanding card
        var cOut = new Panel { Location = new Point(300, 0), Size = new Size(280, 80), BackColor = UITheme.SurfaceWhite };
        lblOutLbl      = new Label { Text = "Outstanding AR",   Location = new Point(10, 8),  AutoSize = true, ForeColor = UITheme.TextMid };
        lblOutstanding = new Label { Text = "HK$0.00", Location = new Point(10, 32), AutoSize = true, Font = UITheme.FontTitle, ForeColor = UITheme.Warning };
        cOut.Controls.AddRange(new Control[] { lblOutLbl, lblOutstanding });
        // Expenses card
        var cExp = new Panel { Location = new Point(600, 0), Size = new Size(280, 80), BackColor = UITheme.SurfaceWhite };
        lblExpLbl  = new Label { Text = "Monthly Expenses", Location = new Point(10, 8),  AutoSize = true, ForeColor = UITheme.TextMid };
        lblExpenses = new Label { Text = "HK$0.00", Location = new Point(10, 32), AutoSize = true, Font = UITheme.FontTitle, ForeColor = UITheme.Danger };
        cExp.Controls.AddRange(new Control[] { lblExpLbl, lblExpenses });
        pnlCards.Controls.AddRange(new Control[] { cRev, cOut, cExp });

        dgv = new DataGridView { Location = new Point(0, 162), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom, Size = new Size(900, 400), BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle, RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        dgv.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { HeaderText = "Invoice ID",     Name = "IID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",       Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Date",           Name = "Date" },
            new DataGridViewTextBoxColumn { HeaderText = "Amount",         Name = "Amount" },
            new DataGridViewTextBoxColumn { HeaderText = "Payment Status", Name = "Status" },
        });
        Controls.AddRange(new Control[] { pnlHeader, pnlCards, dgv }); ResumeLayout(false);
    }
}
