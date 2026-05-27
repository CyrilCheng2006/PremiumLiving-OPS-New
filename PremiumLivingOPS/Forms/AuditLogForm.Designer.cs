namespace PremiumLivingOPS.Forms;

partial class AuditLogForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader; private Label lblTitle; private TextBox txtSearch; private Button btnSearch, btnRefresh; private DataGridView dgv;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        SuspendLayout(); BackColor = UITheme.SurfaceGray; Padding = new Padding(24);
        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = UITheme.SurfaceGray };
        lblTitle  = new Label { Text = "🗒️ Audit Log", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search Table / Action / Staff…", Size = new Size(260, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(688, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnRefresh = new Button { Text = "🔄 Refresh", Size = new Size(90, 28), Location = new Point(776, 14), BackColor = UITheme.SurfaceWhite, ForeColor = UITheme.TextDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnRefresh.FlatAppearance.BorderSize = 1; btnRefresh.Click += btnRefresh_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnRefresh });
        dgv = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None, RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        dgv.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { HeaderText = "Log ID",     Name = "LID" },
            new DataGridViewTextBoxColumn { HeaderText = "Table",      Name = "Table" },
            new DataGridViewTextBoxColumn { HeaderText = "Action",     Name = "Action" },
            new DataGridViewTextBoxColumn { HeaderText = "Record ID",  Name = "RecordID" },
            new DataGridViewTextBoxColumn { HeaderText = "Staff",      Name = "Staff" },
            new DataGridViewTextBoxColumn { HeaderText = "Changed At", Name = "ChangedAt" },
        });
        Controls.AddRange(new Control[] { dgv, pnlHeader }); ResumeLayout(false);
    }
}
