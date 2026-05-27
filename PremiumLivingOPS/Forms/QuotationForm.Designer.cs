namespace PremiumLivingOPS.Forms;

partial class QuotationForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnNew;
    private DataGridView dgvQuotations;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        BackColor = UITheme.SurfaceGray;
        Padding   = new Padding(24);

        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = UITheme.SurfaceGray };
        lblTitle  = new Label
        {
            Text = "📄 Quotations", Font = UITheme.FontTitle,
            ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8)
        };
        txtSearch = new TextBox { PlaceholderText = "Search by ID or Customer…", Size = new Size(240, 28), Location = new Point(420, 14) };
        btnSearch = new Button
        {
            Text = "Search", Size = new Size(80, 28), Location = new Point(668, 14),
            BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
        };
        btnSearch.FlatAppearance.BorderSize = 0;
        btnSearch.Click += btnSearch_Click;
        btnNew = new Button
        {
            Text = "+ New Quotation", Size = new Size(130, 28), Location = new Point(756, 14),
            BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
        };
        btnNew.FlatAppearance.BorderSize = 0;
        btnNew.Click += btnNew_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnNew });

        dgvQuotations = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite,
            BorderStyle = BorderStyle.None, RowHeadersVisible = false,
            AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        dgvQuotations.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Quotation ID", Name = "QuotationID" },
            new DataGridViewTextBoxColumn { HeaderText = "Date",         Name = "QuotationDate" },
            new DataGridViewTextBoxColumn { HeaderText = "Valid Until",  Name = "ValidUntil" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",     Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Total",        Name = "Total" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",       Name = "Status" },
        });
        dgvQuotations.CellDoubleClick += dgvQuotations_CellDoubleClick;

        Controls.AddRange(new Control[] { dgvQuotations, pnlHeader });
        ResumeLayout(false);
    }
}
