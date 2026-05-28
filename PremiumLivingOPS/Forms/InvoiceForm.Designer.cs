namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class InvoiceForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnSearch, btnNew;
    private DataGridView dgvInvoices;

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
        lblTitle  = new Label { Text = "🧾 Invoices", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search Invoice ID or Customer…", Size = new Size(260, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(688, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnNew = new Button { Text = "+ New Invoice", Size = new Size(120, 28), Location = new Point(776, 14), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnNew.FlatAppearance.BorderSize = 0; btnNew.Click += btnNew_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnNew });

        dgvInvoices = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite,
            BorderStyle = BorderStyle.None, RowHeadersVisible = false,
            AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        dgvInvoices.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Invoice ID",     Name = "InvoiceID" },
            new DataGridViewTextBoxColumn { HeaderText = "Date",           Name = "Date" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",       Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Total",          Name = "Total" },
            new DataGridViewTextBoxColumn { HeaderText = "Payment Status", Name = "PayStatus" },
        });
        dgvInvoices.CellDoubleClick += dgvInvoices_CellDoubleClick;
        Controls.AddRange(new Control[] { dgvInvoices, pnlHeader });
        ResumeLayout(false);
    }
}
