namespace PremiumLivingOPS.Forms;

partial class DeliveryNoteForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle, lblShipId, lblNotes, lblSearch;
    private TextBox txtSearch, txtShipmentId, txtNotes;
    private Button btnSearch, btnGenerate;
    private DataGridView dgvNotes;

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
        lblTitle  = new Label { Text = "📃 Delivery Notes", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        pnlHeader.Controls.Add(lblTitle);

        var pnlGen = new Panel { Location = new Point(0, 64), Size = new Size(900, 48), BackColor = UITheme.SurfaceWhite };
        pnlGen.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, pnlGen.ClientRectangle, UITheme.BorderGray, ButtonBorderStyle.Solid);
        lblShipId  = new Label { Text = "Shipment ID:", Location = new Point(8,  14), AutoSize = true };
        txtShipmentId = new TextBox { Location = new Point(100, 10), Size = new Size(180, 24), PlaceholderText = "SH-xxxxxxxx" };
        lblNotes   = new Label { Text = "Notes:",       Location = new Point(300, 14), AutoSize = true };
        txtNotes   = new TextBox { Location = new Point(352, 10), Size = new Size(300, 24), PlaceholderText = "Optional notes" };
        btnGenerate = new Button { Text = "Generate", Location = new Point(664, 10), Size = new Size(90, 26), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnGenerate.FlatAppearance.BorderSize = 0; btnGenerate.Click += btnGenerate_Click;
        pnlGen.Controls.AddRange(new Control[] { lblShipId, txtShipmentId, lblNotes, txtNotes, btnGenerate });

        var pnlSearch = new Panel { Location = new Point(0, 120), Size = new Size(900, 36) };
        lblSearch = new Label { Text = "Search:", Location = new Point(0, 6), AutoSize = true };
        txtSearch = new TextBox { Location = new Point(60, 2), Size = new Size(240, 28), PlaceholderText = "Note ID or Customer…" };
        btnSearch = new Button { Text = "Search", Location = new Point(308, 2), Size = new Size(80, 28), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        pnlSearch.Controls.AddRange(new Control[] { lblSearch, txtSearch, btnSearch });

        dgvNotes = new DataGridView
        {
            Location = new Point(0, 164), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            Size = new Size(900, 400), BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvNotes.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Note ID",      Name = "DNID" },
            new DataGridViewTextBoxColumn { HeaderText = "Shipment ID",  Name = "SID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",     Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Issue Date",   Name = "Date" },
            new DataGridViewTextBoxColumn { HeaderText = "Address",      Name = "Address" },
            new DataGridViewTextBoxColumn { HeaderText = "Notes",        Name = "Notes" },
        });
        Controls.AddRange(new Control[] { pnlHeader, pnlGen, pnlSearch, dgvNotes });
        ResumeLayout(false);
    }
}
