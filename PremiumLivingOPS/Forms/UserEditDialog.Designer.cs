namespace PremiumLivingOPS.Forms;

partial class UserEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblName, lblRole, lblEmail, lblPhone, lblPassword, lblStatus;
    private TextBox txtName, txtEmail, txtPhone, txtPassword;
    private ComboBox cboRole, cboStatus;
    private Button btnSave, btnCancel;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        SuspendLayout(); Text = "Staff Account"; Size = new Size(480, 340); BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;
        int lx = 20, fx = 130, fw = 300;
        lblName     = new Label { Text = "Name:",     Location = new Point(lx, 20),  AutoSize = true };
        txtName     = new TextBox { Location = new Point(fx, 16),  Size = new Size(fw, 24) };
        lblRole     = new Label { Text = "Role:",     Location = new Point(lx, 54),  AutoSize = true };
        cboRole     = new ComboBox { Location = new Point(fx, 50),  Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboRole.Items.AddRange(new object[] { "Admin", "Manager", "Sales", "Warehouse", "Logistics", "Finance", "Staff" }); cboRole.SelectedIndex = 6;
        lblEmail    = new Label { Text = "Email:",    Location = new Point(lx, 88),  AutoSize = true };
        txtEmail    = new TextBox { Location = new Point(fx, 84),  Size = new Size(fw, 24) };
        lblPhone    = new Label { Text = "Phone:",    Location = new Point(lx, 122), AutoSize = true };
        txtPhone    = new TextBox { Location = new Point(fx, 118), Size = new Size(fw, 24) };
        lblPassword = new Label { Text = "Password:", Location = new Point(lx, 156), AutoSize = true };
        txtPassword = new TextBox { Location = new Point(fx, 152), Size = new Size(fw, 24), PasswordChar = '*', PlaceholderText = "Leave blank to keep unchanged" };
        lblStatus   = new Label { Text = "Status:",   Location = new Point(lx, 190), AutoSize = true };
        cboStatus   = new ComboBox { Location = new Point(fx, 186), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboStatus.Items.AddRange(new object[] { "Active", "Inactive" }); cboStatus.SelectedIndex = 0;
        btnSave   = new Button { Text = "Save",   Location = new Point(260, 236), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(350, 236), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.AddRange(new Control[] { lblName, txtName, lblRole, cboRole, lblEmail, txtEmail, lblPhone, txtPhone, lblPassword, txtPassword, lblStatus, cboStatus, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
