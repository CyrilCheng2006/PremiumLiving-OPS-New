namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class ScheduleDeliveryForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblTitle, lblPending, lblScheduled, lblDate, lblDriver;
    private DataGridView dgvPending, dgvScheduled;
    private DateTimePicker dtpSchedule;
    private TextBox txtDriver;
    private Button btnSchedule;

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
        lblTitle  = new Label { Text = "🚚 Schedule Delivery", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        pnlHeader.Controls.Add(lblTitle);

        lblPending = new Label { Text = "Orders Ready for Scheduling", Font = UITheme.FontHeading, Location = new Point(0, 64), AutoSize = true };
        dgvPending = new DataGridView
        {
            Location = new Point(0, 90), Size = new Size(900, 180),
            BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect, MultiSelect = false
        };
        dgvPending.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Order ID",    Name = "OID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",    Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Del. Date",   Name = "DelDate" },
            new DataGridViewTextBoxColumn { HeaderText = "Address",     Name = "Address" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",      Name = "Status" },
        });

        lblDate   = new Label { Text = "Schedule Date:", Location = new Point(0, 282), AutoSize = true };
        dtpSchedule = new DateTimePicker { Location = new Point(120, 278), Size = new Size(180, 24), Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(1) };
        lblDriver = new Label { Text = "Driver Name:",  Location = new Point(320, 282), AutoSize = true };
        txtDriver = new TextBox { Location = new Point(420, 278), Size = new Size(200, 24), PlaceholderText = "Driver name" };
        btnSchedule = new Button
        {
            Text = "Schedule", Location = new Point(636, 276), Size = new Size(100, 30),
            BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
        };
        btnSchedule.FlatAppearance.BorderSize = 0;
        btnSchedule.Click += btnSchedule_Click;

        lblScheduled = new Label { Text = "Scheduled Deliveries", Font = UITheme.FontHeading, Location = new Point(0, 320), AutoSize = true };
        dgvScheduled = new DataGridView
        {
            Location = new Point(0, 346), Size = new Size(900, 200),
            BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle,
            RowHeadersVisible = false, AllowUserToAddRows = false, ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvScheduled.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText = "Shipment ID",  Name = "SID" },
            new DataGridViewTextBoxColumn { HeaderText = "Order ID",     Name = "OID" },
            new DataGridViewTextBoxColumn { HeaderText = "Customer",     Name = "Customer" },
            new DataGridViewTextBoxColumn { HeaderText = "Scheduled",    Name = "Date" },
            new DataGridViewTextBoxColumn { HeaderText = "Status",       Name = "Status" },
            new DataGridViewTextBoxColumn { HeaderText = "Driver",       Name = "Driver" },
        });

        Controls.AddRange(new Control[] { pnlHeader, lblPending, dgvPending, lblDate, dtpSchedule, lblDriver, txtDriver, btnSchedule, lblScheduled, dgvScheduled });
        ResumeLayout(false);
    }
}
