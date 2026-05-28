namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class ProductEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblName, lblCategory, lblPrice, lblStock, lblReorder, lblStatus, lblDesc;
    private TextBox txtName, txtCategory, txtDescription;
    private NumericUpDown numPrice, numStock, numReorder;
    private ComboBox cboStatus;
    private Button btnSave, btnCancel;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        SuspendLayout(); Text = "Product"; Size = new Size(520, 380); BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;
        int lx = 20, fx = 140, fw = 320;
        lblName     = new Label { Text = "Name:",          Location = new Point(lx, 20),  AutoSize = true };
        txtName     = new TextBox { Location = new Point(fx, 16),  Size = new Size(fw, 24) };
        lblCategory = new Label { Text = "Category:",      Location = new Point(lx, 54),  AutoSize = true };
        txtCategory = new TextBox { Location = new Point(fx, 50),  Size = new Size(fw, 24) };
        lblPrice    = new Label { Text = "Unit Price:",    Location = new Point(lx, 88),  AutoSize = true };
        numPrice    = new NumericUpDown { Location = new Point(fx, 84),  Size = new Size(fw, 24), DecimalPlaces = 2, Maximum = 9999999, Minimum = 0 };
        lblStock    = new Label { Text = "Stock Qty:",     Location = new Point(lx, 122), AutoSize = true };
        numStock    = new NumericUpDown { Location = new Point(fx, 118), Size = new Size(fw, 24), Maximum = 999999, Minimum = 0 };
        lblReorder  = new Label { Text = "Reorder Level:", Location = new Point(lx, 156), AutoSize = true };
        numReorder  = new NumericUpDown { Location = new Point(fx, 152), Size = new Size(fw, 24), Maximum = 999999, Minimum = 0 };
        lblStatus   = new Label { Text = "Status:",        Location = new Point(lx, 190), AutoSize = true };
        cboStatus   = new ComboBox { Location = new Point(fx, 186), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboStatus.Items.AddRange(new object[] { "Active", "Inactive", "Discontinued" }); cboStatus.SelectedIndex = 0;
        lblDesc     = new Label { Text = "Description:",   Location = new Point(lx, 224), AutoSize = true };
        txtDescription = new TextBox { Location = new Point(fx, 220), Size = new Size(fw, 50), Multiline = true };
        btnSave   = new Button { Text = "Save",   Location = new Point(320, 286), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(410, 286), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.AddRange(new Control[] { lblName, txtName, lblCategory, txtCategory, lblPrice, numPrice, lblStock, numStock, lblReorder, numReorder, lblStatus, cboStatus, lblDesc, txtDescription, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
