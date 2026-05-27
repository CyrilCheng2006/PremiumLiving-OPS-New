namespace PremiumLivingOPS.Forms;

partial class PurchaseOrderEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblSupplier, lblExpected, lblStatus, lblRemarks;
    private ComboBox cboSupplier, cboStatus;
    private DateTimePicker dtpExpected;
    private TextBox txtRemarks;
    private Button btnSave, btnCancel;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        SuspendLayout();
        Text = "Purchase Order"; Size = new Size(500, 280); BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;
        int lx = 20, fx = 140, fw = 300;
        lblSupplier = new Label { Text = "Supplier:",      Location = new Point(lx, 20),  AutoSize = true };
        cboSupplier = new ComboBox { Location = new Point(fx, 16), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblExpected = new Label { Text = "Expected Date:", Location = new Point(lx, 54),  AutoSize = true };
        dtpExpected = new DateTimePicker { Location = new Point(fx, 50), Size = new Size(fw, 24), Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(14) };
        lblStatus   = new Label { Text = "Status:",        Location = new Point(lx, 88),  AutoSize = true };
        cboStatus   = new ComboBox { Location = new Point(fx, 84), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboStatus.Items.AddRange(new object[] { "Draft", "Submitted", "Approved", "Received", "Cancelled" }); cboStatus.SelectedIndex = 0;
        lblRemarks  = new Label { Text = "Remarks:",       Location = new Point(lx, 122), AutoSize = true };
        txtRemarks  = new TextBox { Location = new Point(fx, 118), Size = new Size(fw, 40), Multiline = true };
        btnSave   = new Button { Text = "Save",   Location = new Point(300, 176), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(390, 176), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.AddRange(new Control[] { lblSupplier, cboSupplier, lblExpected, dtpExpected, lblStatus, cboStatus, lblRemarks, txtRemarks, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
