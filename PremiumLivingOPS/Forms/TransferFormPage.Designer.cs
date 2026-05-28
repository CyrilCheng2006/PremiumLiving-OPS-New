namespace PremiumLivingOPS.Forms;

using PremiumLivingOPS.Helpers;
partial class TransferFormPage
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader, pnlForm;
    private Label lblTitle, lblProduct, lblQty, lblFrom, lblTo, lblRemarks;
    private ComboBox cboProduct;
    private NumericUpDown numQty;
    private TextBox txtFrom, txtTo, txtRemarks;
    private Button btnSubmit;
    private DataGridView dgvTransfers;

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
        lblTitle  = new Label { Text = "🔄 Transfer Form", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        pnlHeader.Controls.Add(lblTitle);

        pnlForm = new Panel { Location = new Point(0, 64), Size = new Size(900, 80), BackColor = UITheme.SurfaceWhite };
        int lx = 8, fy = 14;
        lblProduct = new Label { Text = "Product:",   Location = new Point(lx, fy + 4), AutoSize = true };
        cboProduct = new ComboBox { Location = new Point(70, fy), Size = new Size(220, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblQty     = new Label { Text = "Qty:",       Location = new Point(302, fy + 4), AutoSize = true };
        numQty     = new NumericUpDown { Location = new Point(330, fy), Size = new Size(70, 24), Minimum = 1, Maximum = 99999, Value = 1 };
        lblFrom    = new Label { Text = "From:",      Location = new Point(414, fy + 4), AutoSize = true };
        txtFrom    = new TextBox { Location = new Point(454, fy), Size = new Size(120, 24), PlaceholderText = "Location" };
        lblTo      = new Label { Text = "To:",        Location = new Point(588, fy + 4), AutoSize = true };
        txtTo      = new TextBox { Location = new Point(608, fy), Size = new Size(120, 24), PlaceholderText = "Location" };
        btnSubmit  = new Button { Text = "Submit",    Location = new Point(744, fy), Size = new Size(80, 28), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSubmit.FlatAppearance.BorderSize = 0; btnSubmit.Click += btnSubmit_Click;
        lblRemarks = new Label { Text = "Remarks:",   Location = new Point(lx, fy + 34), AutoSize = true };
        txtRemarks = new TextBox { Location = new Point(70, fy + 30), Size = new Size(660, 24), PlaceholderText = "Optional" };
        pnlForm.Controls.AddRange(new Control[] { lblProduct, cboProduct, lblQty, numQty, lblFrom, txtFrom, lblTo, txtTo, btnSubmit, lblRemarks, txtRemarks });

        var lblHistory = new Label { Text = "Transfer History", Font = UITheme.FontHeading, Location = new Point(0, 156), AutoSize = true };
        dgvTransfers = new DataGridView
        {
            Location = new Point(0, 180), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            Size = new Size(900, 380), BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvTransfers.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Transfer ID",  Name = "TID" },
            new DataGridViewTextBoxColumn { HeaderText = "Product",      Name = "Product" },
            new DataGridViewTextBoxColumn { HeaderText = "Qty",          Name = "Qty" },
            new DataGridViewTextBoxColumn { HeaderText = "From",         Name = "From" },
            new DataGridViewTextBoxColumn { HeaderText = "To",           Name = "To" },
            new DataGridViewTextBoxColumn { HeaderText = "Date",         Name = "Date" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",       Name = "Status" },
        });
        Controls.AddRange(new Control[] { pnlHeader, pnlForm, lblHistory, dgvTransfers });
        ResumeLayout(false);
    }
}
