namespace PremiumLivingOPS.Forms;

partial class ComplaintNewForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblCustomer, lblOrder, lblSerial, lblDesc, lblResolution, lblStatus, lblContact;
    private ComboBox cboCustomer, cboOrder, cboResolution, cboStatus;
    private TextBox txtSerial, txtDesc, txtContact;
    private Button btnSave, btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        Text = "Complaint Record"; Size = new Size(600, 440);
        BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;
        int lx = 20, fx = 160, fw = 380;
        lblCustomer  = new Label { Text = "Customer:",      Location = new Point(lx, 20),  AutoSize = true };
        cboCustomer  = new ComboBox { Location = new Point(fx, 16),  Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblOrder     = new Label { Text = "Order ID:",      Location = new Point(lx, 54),  AutoSize = true };
        cboOrder     = new ComboBox { Location = new Point(fx, 50),  Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblSerial    = new Label { Text = "Product Serial:",Location = new Point(lx, 88),  AutoSize = true };
        txtSerial    = new TextBox { Location = new Point(fx, 84),  Size = new Size(fw, 24) };
        lblDesc      = new Label { Text = "Description:",   Location = new Point(lx, 122), AutoSize = true };
        txtDesc      = new TextBox { Location = new Point(fx, 118), Size = new Size(fw, 60), Multiline = true };
        lblResolution= new Label { Text = "Resolution:",    Location = new Point(lx, 192), AutoSize = true };
        cboResolution= new ComboBox { Location = new Point(fx, 188), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboResolution.Items.AddRange(new object[] { "Refund", "Replacement", "Return", "Repair", "Other" });
        cboResolution.SelectedIndex = 0;
        lblStatus    = new Label { Text = "Status:",        Location = new Point(lx, 226), AutoSize = true };
        cboStatus    = new ComboBox { Location = new Point(fx, 222), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboStatus.Items.AddRange(new object[] { "Open", "In Progress", "Resolved", "Closed" });
        cboStatus.SelectedIndex = 0;
        lblContact   = new Label { Text = "Contact Info:",  Location = new Point(lx, 260), AutoSize = true };
        txtContact   = new TextBox { Location = new Point(fx, 256), Size = new Size(fw, 24) };

        btnSave   = new Button { Text = "Save",   Location = new Point(390, 302), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(480, 302), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };

        Controls.AddRange(new Control[] { lblCustomer, cboCustomer, lblOrder, cboOrder, lblSerial, txtSerial,
            lblDesc, txtDesc, lblResolution, cboResolution, lblStatus, cboStatus, lblContact, txtContact, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
