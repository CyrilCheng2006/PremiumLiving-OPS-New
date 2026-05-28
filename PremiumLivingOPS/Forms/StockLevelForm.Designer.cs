namespace PremiumLivingOPS.Forms;

using PremiumLivingOPS.Helpers;
partial class StockLevelForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnSearch, btnRefresh;
    private DataGridView dgvStock;

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
        lblTitle  = new Label { Text = "🏪 Stock Level", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search product…", Size = new Size(240, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search",  Size = new Size(80, 28), Location = new Point(668, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnRefresh = new Button { Text = "Refresh", Size = new Size(80, 28), Location = new Point(756, 14), BackColor = UITheme.Info, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnRefresh.FlatAppearance.BorderSize = 0; btnRefresh.Click += btnRefresh_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnRefresh });

        dgvStock = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        dgvStock.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Item ID",       Name = "WID" },
            new DataGridViewTextBoxColumn { HeaderText = "Product ID",    Name = "PID" },
            new DataGridViewTextBoxColumn { HeaderText = "Product Name",  Name = "PName" },
            new DataGridViewTextBoxColumn { HeaderText = "Category",      Name = "Cat" },
            new DataGridViewTextBoxColumn { HeaderText = "Quantity",      Name = "Qty" },
            new DataGridViewTextBoxColumn { HeaderText = "Reorder Level", Name = "Reorder" },
            new DataGridViewTextBoxColumn { HeaderText = "Location",      Name = "Location" },
        });
        Controls.AddRange(new Control[] { dgvStock, pnlHeader });
        ResumeLayout(false);
    }
}
