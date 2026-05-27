using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

partial class NewOrderForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle, lblCustomer, lblContact, lblShipAddr, lblBillAddr, lblDelivery, lblStatus, lblProduct, lblQty;
    private TextBox txtOrderId, txtContact, txtShipAddr, txtBillAddr;
    private ComboBox cmbCustomer, cmbStatus, cmbProduct;
    private DateTimePicker dtDelivery;
    private NumericUpDown nudQty;
    private Button btnAddLine, btnSave, btnCancel;
    private DataGridView dgvLines;

    protected override void Dispose(bool d) { if (d && components!=null) components.Dispose(); base.Dispose(d); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        this.Size  = new Size(920, 680);
        this.FormBorderStyle = FormBorderStyle.Sizable;
        this.StartPosition   = FormStartPosition.CenterParent;
        this.BackColor       = UITheme.SurfaceWhite;
        SuspendLayout();

        lblTitle    = new Label { Text="New Order", Font=UITheme.FontTitle, ForeColor=UITheme.TextDark, AutoSize=true, Location=new Point(24,16) };
        txtOrderId  = new TextBox { Location=new Point(24,60), Size=new Size(200,24), PlaceholderText="Auto-generated", Enabled=false };

        lblCustomer = new Label { Text="Customer", AutoSize=true, Location=new Point(24,96) };
        cmbCustomer = new ComboBox { Location=new Point(24,116), Size=new Size(280,28), DropDownStyle=ComboBoxStyle.DropDownList };

        lblContact  = new Label { Text="Contact Name", AutoSize=true, Location=new Point(320,96) };
        txtContact  = new TextBox { Location=new Point(320,116), Size=new Size(240,24) };

        lblDelivery = new Label { Text="Delivery Date", AutoSize=true, Location=new Point(576,96) };
        dtDelivery  = new DateTimePicker { Location=new Point(576,116), Size=new Size(200,24), Format=DateTimePickerFormat.Short };

        lblShipAddr = new Label { Text="Shipping Address", AutoSize=true, Location=new Point(24,154) };
        txtShipAddr = new TextBox { Location=new Point(24,174), Size=new Size(360,24) };

        lblBillAddr = new Label { Text="Billing Address", AutoSize=true, Location=new Point(400,154) };
        txtBillAddr = new TextBox { Location=new Point(400,174), Size=new Size(360,24) };

        lblStatus   = new Label { Text="Status", AutoSize=true, Location=new Point(24,210) };
        cmbStatus   = new ComboBox { Location=new Point(24,230), Size=new Size(180,28), DropDownStyle=ComboBoxStyle.DropDownList };
        cmbStatus.Items.AddRange(new object[]{"Pending","Processing","Partially Delivered","Delivered","Completed","Cancelled"});
        cmbStatus.SelectedIndex = 0;

        // Order lines
        lblProduct  = new Label { Text="Product", AutoSize=true, Location=new Point(24,278) };
        cmbProduct  = new ComboBox { Location=new Point(24,298), Size=new Size(320,28), DropDownStyle=ComboBoxStyle.DropDownList };
        lblQty      = new Label { Text="Qty", AutoSize=true, Location=new Point(356,278) };
        nudQty      = new NumericUpDown { Location=new Point(356,298), Size=new Size(80,28), Minimum=1, Maximum=9999 };
        btnAddLine  = new Button { Text="Add Line", Location=new Point(448,296), Size=new Size(100,32),
            BackColor=UITheme.Info, ForeColor=Color.White, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
        btnAddLine.FlatAppearance.BorderSize=0;
        btnAddLine.Click += btnAddLine_Click;

        dgvLines = new DataGridView {
            Location=new Point(24,340), Size=new Size(860,240),
            AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor=UITheme.SurfaceGray, BorderStyle=BorderStyle.None,
            RowHeadersVisible=false, AllowUserToAddRows=false, Font=UITheme.FontBody };
        dgvLines.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText="Item ID" },
            new DataGridViewTextBoxColumn { HeaderText="Item Name" },
            new DataGridViewTextBoxColumn { HeaderText="Qty" },
            new DataGridViewTextBoxColumn { HeaderText="Unit Price" });

        btnSave   = new Button { Text="Save Order", Location=new Point(24,596), Size=new Size(120,36),
            BackColor=UITheme.AccentGold, ForeColor=UITheme.PrimaryDark, FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
        btnSave.FlatAppearance.BorderSize=0;
        btnSave.Click += btnSave_Click;

        btnCancel = new Button { Text="Cancel", Location=new Point(156,596), Size=new Size(90,36),
            FlatStyle=FlatStyle.Flat, Cursor=Cursors.Hand };
        btnCancel.Click += btnCancel_Click;

        this.Controls.AddRange(new Control[]{ lblTitle, txtOrderId, lblCustomer, cmbCustomer,
            lblContact, txtContact, lblDelivery, dtDelivery, lblShipAddr, txtShipAddr,
            lblBillAddr, txtBillAddr, lblStatus, cmbStatus,
            lblProduct, cmbProduct, lblQty, nudQty, btnAddLine, dgvLines,
            btnSave, btnCancel });
        this.AcceptButton  = btnSave;
        this.CancelButton  = btnCancel;
        ResumeLayout(false);
    }
}
