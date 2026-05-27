namespace PremiumLivingOPS.Forms;

partial class ReplySlipForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle, lblDNId, lblReceivedBy, lblRemarks, lblSearch;
    private TextBox txtSearch, txtDNId, txtReceivedBy, txtRemarks;
    private Button btnSearch, btnRecord;
    private DataGridView dgvSlips;

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
        lblTitle  = new Label { Text = "📝 Reply Slips", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        pnlHeader.Controls.Add(lblTitle);

        var pnlRec = new Panel { Location = new Point(0, 64), Size = new Size(900, 48), BackColor = UITheme.SurfaceWhite };
        lblDNId       = new Label { Text = "Delivery Note ID:", Location = new Point(8, 14), AutoSize = true };
        txtDNId       = new TextBox { Location = new Point(130, 10), Size = new Size(160, 24), PlaceholderText = "DN-xxxxxxxx" };
        lblReceivedBy = new Label { Text = "Received By:",     Location = new Point(308, 14), AutoSize = true };
        txtReceivedBy = new TextBox { Location = new Point(400, 10), Size = new Size(160, 24) };
        lblRemarks    = new Label { Text = "Remarks:",         Location = new Point(576, 14), AutoSize = true };
        txtRemarks    = new TextBox { Location = new Point(636, 10), Size = new Size(140, 24) };
        btnRecord     = new Button { Text = "Record", Location = new Point(792, 10), Size = new Size(80, 26), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnRecord.FlatAppearance.BorderSize = 0; btnRecord.Click += btnRecord_Click;
        pnlRec.Controls.AddRange(new Control[] { lblDNId, txtDNId, lblReceivedBy, txtReceivedBy, lblRemarks, txtRemarks, btnRecord });

        var pnlSearch = new Panel { Location = new Point(0, 120), Size = new Size(900, 36) };
        lblSearch = new Label { Text = "Search:", Location = new Point(0, 6), AutoSize = true };
        txtSearch = new TextBox { Location = new Point(60, 2), Size = new Size(240, 28), PlaceholderText = "Slip ID or Customer…" };
        btnSearch = new Button { Text = "Search", Location = new Point(308, 2), Size = new Size(80, 28), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        pnlSearch.Controls.AddRange(new Control[] { lblSearch, txtSearch, btnSearch });

        dgvSlips = new DataGridView
        {
            Location = new Point(0, 164), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            Size = new Size(900, 380), BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvSlips.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Reply Slip ID",  Name = "RSID" },
            new DataGridViewTextBoxColumn { HeaderText = "Delivery Note",  Name = "DNID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",       Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Signed Date",    Name = "Signed" },
            new DataGridViewTextBoxColumn { HeaderText = "Received By",    Name = "RecBy" },
            new DataGridViewTextBoxColumn { HeaderText = "Remarks",        Name = "Remarks" },
        });
        Controls.AddRange(new Control[] { pnlHeader, pnlRec, pnlSearch, dgvSlips });
        ResumeLayout(false);
    }
}
