namespace PremiumLivingOPS.Forms;

partial class ReturnMgmtForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnSearch, btnNew, btnApprove;
    private DataGridView dgvReturns;

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
        lblTitle  = new Label { Text = "🔄 Return Management", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search Return ID or Customer…", Size = new Size(260, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(688, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnNew = new Button { Text = "+ New Return", Size = new Size(110, 28), Location = new Point(776, 14), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnNew.FlatAppearance.BorderSize = 0; btnNew.Click += btnNew_Click;
        btnApprove = new Button { Text = "Approve", Size = new Size(80, 28), Location = new Point(896, 14), BackColor = UITheme.Success, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnApprove.FlatAppearance.BorderSize = 0; btnApprove.Click += btnApprove_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnNew, btnApprove });
        dgvReturns = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false
        };
        dgvReturns.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Return ID",    Name = "RID" },
            new DataGridViewTextBoxColumn { HeaderText = "Order ID",     Name = "OID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",     Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Return Date",  Name = "Date" },
            new DataGridViewTextBoxColumn { HeaderText = "Reason",       Name = "Reason" },
            new DataGridViewTextBoxColumn { HeaderText = "Resolution",   Name = "Resolution" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",       Name = "Status" },
        });
        Controls.AddRange(new Control[] { dgvReturns, pnlHeader });
        ResumeLayout(false);
    }
}
