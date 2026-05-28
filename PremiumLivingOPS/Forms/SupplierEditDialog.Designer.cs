namespace PremiumLivingOPS.Forms;

using PremiumLivingOPS.Helpers;
partial class SupplierEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblName, lblContact, lblPhone, lblEmail, lblAddress, lblStatus;
    private TextBox txtName, txtContact, txtPhone, txtEmail, txtAddress;
    private ComboBox cboStatus;
    private Button btnSave, btnCancel;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        SuspendLayout(); Text = "Supplier"; Size = new Size(520, 340); BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;
        int lx = 20, fx = 140, fw = 320;
        lblName    = new Label { Text = "Name:",           Location = new Point(lx, 20),  AutoSize = true };
        txtName    = new TextBox { Location = new Point(fx, 16),  Size = new Size(fw, 24) };
        lblContact = new Label { Text = "Contact Person:", Location = new Point(lx, 54),  AutoSize = true };
        txtContact = new TextBox { Location = new Point(fx, 50),  Size = new Size(fw, 24) };
        lblPhone   = new Label { Text = "Phone:",          Location = new Point(lx, 88),  AutoSize = true };
        txtPhone   = new TextBox { Location = new Point(fx, 84),  Size = new Size(fw, 24) };
        lblEmail   = new Label { Text = "Email:",          Location = new Point(lx, 122), AutoSize = true };
        txtEmail   = new TextBox { Location = new Point(fx, 118), Size = new Size(fw, 24) };
        lblAddress = new Label { Text = "Address:",        Location = new Point(lx, 156), AutoSize = true };
        txtAddress = new TextBox { Location = new Point(fx, 152), Size = new Size(fw, 40), Multiline = true };
        lblStatus  = new Label { Text = "Status:",         Location = new Point(lx, 206), AutoSize = true };
        cboStatus  = new ComboBox { Location = new Point(fx, 202), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboStatus.Items.AddRange(new object[] { "Active", "Inactive" }); cboStatus.SelectedIndex = 0;
        btnSave   = new Button { Text = "Save",   Location = new Point(320, 252), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(410, 252), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.AddRange(new Control[] { lblName, txtName, lblContact, txtContact, lblPhone, txtPhone, lblEmail, txtEmail, lblAddress, txtAddress, lblStatus, cboStatus, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
