namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class TrackShipmentForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnSearch, btnMarkDelivered;
    private DataGridView dgvShipments;

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
        lblTitle  = new Label { Text = "📦 Track Shipment", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        txtSearch = new TextBox { PlaceholderText = "Search Shipment / Order / Customer…", Size = new Size(280, 28), Location = new Point(420, 14) };
        btnSearch = new Button { Text = "Search", Size = new Size(80, 28), Location = new Point(708, 14), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSearch.FlatAppearance.BorderSize = 0; btnSearch.Click += btnSearch_Click;
        btnMarkDelivered = new Button { Text = "Mark Delivered", Size = new Size(120, 28), Location = new Point(796, 14), BackColor = UITheme.Success, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnMarkDelivered.FlatAppearance.BorderSize = 0; btnMarkDelivered.Click += btnMarkDelivered_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnSearch, btnMarkDelivered });
        dgvShipments = new DataGridView
        {
            Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false
        };
        dgvShipments.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Shipment ID",    Name = "SID" },
            new DataGridViewTextBoxColumn { HeaderText = "Order ID",       Name = "OID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",       Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Scheduled Date", Name = "Scheduled" },
            new DataGridViewTextBoxColumn { HeaderText = "Delivered Date", Name = "Delivered" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",         Name = "Status" },
            new DataGridViewTextBoxColumn { HeaderText = "Driver",         Name = "Driver" },
        });
        Controls.AddRange(new Control[] { dgvShipments, pnlHeader });
        ResumeLayout(false);
    }
}
