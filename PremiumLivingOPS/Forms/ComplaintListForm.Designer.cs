namespace PremiumLivingOPS.Forms;

partial class ComplaintListForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnSearch, btnNew;
    private DataGridView dgvComplaints;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        BackColor = UITheme.SurfaceGray; Padding = new Padding(24);
        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = UITheme.SurfaceGray };
        lblTitle  = new Label { Text = "📢 Complaints", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search…", Size = new Size(220, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(648, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnNew = new Button { Text = "+ New Complaint", Size = new Size(130, 28), Location = new Point(736, 14), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnNew.FlatAppearance.BorderSize = 0; btnNew.Click += btnNew_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnNew });
        dgvComplaints = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        dgvComplaints.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Complaint ID",       Name = "CID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",           Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Product Serial",     Name = "Serial" },
            new DataGridViewTextBoxColumn { HeaderText = "Date",               Name = "Date" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",             Name = "Status" },
            new DataGridViewTextBoxColumn { HeaderText = "Preferred Resolution",Name = "Resolution" },
        });
        dgvComplaints.CellDoubleClick += dgvComplaints_CellDoubleClick;
        Controls.AddRange(new Control[] { dgvComplaints, pnlHeader });
        ResumeLayout(false);
    }
}
