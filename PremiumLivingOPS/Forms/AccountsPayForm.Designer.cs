namespace PremiumLivingOPS.Forms;

partial class AccountsPayForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader; private Label lblTitle; private TextBox txtSearch; private Button btnSearch, btnMarkPaid; private DataGridView dgv;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        SuspendLayout(); BackColor = UITheme.SurfaceGray; Padding = new Padding(24);
        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = UITheme.SurfaceGray };
        lblTitle  = new Label { Text = "💸 Accounts Payable", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search PO or Supplier…", Size = new Size(220, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(648, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnMarkPaid = new Button { Text = "Mark Received", Size = new Size(120, 28), Location = new Point(736, 14), BackColor = UITheme.Success, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnMarkPaid.FlatAppearance.BorderSize = 0; btnMarkPaid.Click += btnMarkPaid_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnMarkPaid });
        dgv = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None, RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false };
        dgv.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { HeaderText = "PO ID",         Name = "POID" },
            new DataGridViewTextBoxColumn { HeaderText = "Supplier",      Name = "Supplier" },
            new DataGridViewTextBoxColumn { HeaderText = "Order Date",    Name = "OrderDate" },
            new DataGridViewTextBoxColumn { HeaderText = "Due Date",      Name = "DueDate" },
            new DataGridViewTextBoxColumn { HeaderText = "Amount",        Name = "Amount" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",        Name = "Status" },
            new DataGridViewTextBoxColumn { HeaderText = "Days Until Due",Name = "Days" },
        });
        Controls.AddRange(new Control[] { dgv, pnlHeader }); ResumeLayout(false);
    }
}
