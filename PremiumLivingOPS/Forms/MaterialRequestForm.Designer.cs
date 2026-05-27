namespace PremiumLivingOPS.Forms;

partial class MaterialRequestForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader, pnlForm;
    private Label lblTitle, lblMaterial, lblQty, lblRequired, lblUrgency, lblRemarks;
    private ComboBox cboMaterial, cboUrgency;
    private NumericUpDown numQty;
    private DateTimePicker dtpRequired;
    private TextBox txtSearch, txtRemarks;
    private Button btnSubmit, btnSearch;
    private DataGridView dgvRequests;

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
        lblTitle  = new Label { Text = "🧱 Material Request", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search…", Size = new Size(200, 28), Location = new Point(500, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(708, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch });

        pnlForm = new Panel { Location = new Point(0, 64), Size = new Size(900, 90), BackColor = UITheme.SurfaceWhite };
        int fy = 12;
        lblMaterial = new Label { Text = "Material:",      Location = new Point(8, fy + 4),  AutoSize = true };
        cboMaterial = new ComboBox { Location = new Point(75, fy),  Size = new Size(200, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblQty      = new Label { Text = "Qty:",           Location = new Point(288, fy + 4), AutoSize = true };
        numQty      = new NumericUpDown { Location = new Point(316, fy), Size = new Size(80, 24), Minimum = 1, Maximum = 999999, Value = 1 };
        lblRequired = new Label { Text = "Required Date:", Location = new Point(410, fy + 4), AutoSize = true };
        dtpRequired = new DateTimePicker { Location = new Point(510, fy), Size = new Size(160, 24), Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(7) };
        lblUrgency  = new Label { Text = "Urgency:",       Location = new Point(684, fy + 4), AutoSize = true };
        cboUrgency  = new ComboBox { Location = new Point(742, fy), Size = new Size(100, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboUrgency.Items.AddRange(new object[] { "Low", "Normal", "High" }); cboUrgency.SelectedIndex = 1;
        lblRemarks  = new Label { Text = "Remarks:",       Location = new Point(8, fy + 36), AutoSize = true };
        txtRemarks  = new TextBox { Location = new Point(75, fy + 32), Size = new Size(680, 24), PlaceholderText = "Optional" };
        btnSubmit   = new Button { Text = "Submit",        Location = new Point(768, fy + 30), Size = new Size(80, 28), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSubmit.FlatAppearance.BorderSize = 0; btnSubmit.Click += btnSubmit_Click;
        pnlForm.Controls.AddRange(new Control[] { lblMaterial, cboMaterial, lblQty, numQty, lblRequired, dtpRequired, lblUrgency, cboUrgency, lblRemarks, txtRemarks, btnSubmit });

        var lblHistory = new Label { Text = "Request History", Font = UITheme.FontHeading, Location = new Point(0, 166), AutoSize = true };
        dgvRequests = new DataGridView
        {
            Location = new Point(0, 190), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            Size = new Size(900, 370), BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvRequests.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Request ID",   Name = "RID" },
            new DataGridViewTextBoxColumn { HeaderText = "Material",     Name = "Material" },
            new DataGridViewTextBoxColumn { HeaderText = "Qty",          Name = "Qty" },
            new DataGridViewTextBoxColumn { HeaderText = "Request Date", Name = "ReqDate" },
            new DataGridViewTextBoxColumn { HeaderText = "Required By",  Name = "ReqBy" },
            new DataGridViewTextBoxColumn { HeaderText = "Urgency",      Name = "Urgency" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",       Name = "Status" },
        });
        Controls.AddRange(new Control[] { pnlHeader, pnlForm, lblHistory, dgvRequests });
        ResumeLayout(false);
    }
}
