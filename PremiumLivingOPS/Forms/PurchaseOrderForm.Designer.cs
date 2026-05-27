namespace PremiumLivingOPS.Forms;

partial class PurchaseOrderForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnSearch, btnNew;
    private DataGridView dgv;

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
        lblTitle  = new Label { Text = "📋 Purchase Orders", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search PO ID or Supplier…", Size = new Size(260, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(688, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnNew = new Button { Text = "+ New PO", Size = new Size(100, 28), Location = new Point(776, 14), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnNew.FlatAppearance.BorderSize = 0; btnNew.Click += btnNew_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnNew });
        dgv = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None, RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
        dgv.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { HeaderText = "PO ID",         Name = "POID" },
            new DataGridViewTextBoxColumn { HeaderText = "Supplier",      Name = "Supplier" },
            new DataGridViewTextBoxColumn { HeaderText = "Order Date",    Name = "OrderDate" },
            new DataGridViewTextBoxColumn { HeaderText = "Expected Date", Name = "ExpDate" },
            new DataGridViewTextBoxColumn { HeaderText = "Total",         Name = "Total" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",        Name = "Status" },
        });
        dgv.CellDoubleClick += dgv_CellDoubleClick;
        Controls.AddRange(new Control[] { dgv, pnlHeader });
        ResumeLayout(false);
    }
}
