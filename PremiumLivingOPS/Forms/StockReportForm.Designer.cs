namespace PremiumLivingOPS.Forms;

partial class StockReportForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader, pnlFooter;
    private Label lblTitle, lblCategory, lblTotal;
    private ComboBox cboCategory;
    private Button btnGenerate;
    private DataGridView dgvReport;

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
        lblTitle    = new Label { Text = "📈 Stock Report", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        lblCategory = new Label { Text = "Category:", AutoSize = true, Location = new Point(420, 18) };
        cboCategory = new ComboBox { Location = new Point(490, 14), Size = new Size(180, 28), DropDownStyle = ComboBoxStyle.DropDownList };
        btnGenerate = new Button { Text = "Generate", Size = new Size(90, 28), Location = new Point(680, 14), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnGenerate.FlatAppearance.BorderSize = 0; btnGenerate.Click += btnGenerate_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblCategory, cboCategory, btnGenerate });

        dgvReport = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvReport.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Product ID",    Name = "PID" },
            new DataGridViewTextBoxColumn { HeaderText = "Product Name",  Name = "PName" },
            new DataGridViewTextBoxColumn { HeaderText = "Category",      Name = "Cat" },
            new DataGridViewTextBoxColumn { HeaderText = "Quantity",      Name = "Qty" },
            new DataGridViewTextBoxColumn { HeaderText = "Reorder Level", Name = "Reorder" },
            new DataGridViewTextBoxColumn { HeaderText = "Unit Price",    Name = "UP" },
            new DataGridViewTextBoxColumn { HeaderText = "Stock Value",   Name = "SV" },
        });

        pnlFooter = new Panel { Dock = DockStyle.Bottom, Height = 36, BackColor = UITheme.SurfaceWhite };
        lblTotal  = new Label { Font = UITheme.FontHeading, ForeColor = UITheme.AccentGold, AutoSize = true, Location = new Point(12, 8) };
        pnlFooter.Controls.Add(lblTotal);

        Controls.AddRange(new Control[] { dgvReport, pnlFooter, pnlHeader });
        ResumeLayout(false);
    }
}
