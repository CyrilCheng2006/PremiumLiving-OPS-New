namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class ReturnEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblOrder, lblReason, lblResolution;
    private ComboBox cboOrder, cboResolution;
    private TextBox txtReason;
    private Button btnSave, btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        Text = "New Return Request"; Size = new Size(480, 240);
        BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;
        int lx = 20, fx = 150, fw = 280;
        lblOrder      = new Label { Text = "Order ID:",   Location = new Point(lx, 20),  AutoSize = true };
        cboOrder      = new ComboBox { Location = new Point(fx, 16), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblReason     = new Label { Text = "Reason:",     Location = new Point(lx, 54),  AutoSize = true };
        txtReason     = new TextBox { Location = new Point(fx, 50), Size = new Size(fw, 40), Multiline = true };
        lblResolution = new Label { Text = "Resolution:", Location = new Point(lx, 104), AutoSize = true };
        cboResolution = new ComboBox { Location = new Point(fx, 100), Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboResolution.Items.AddRange(new object[] { "Refund", "Replacement", "Repair", "Return" });
        cboResolution.SelectedIndex = 0;
        btnSave   = new Button { Text = "Save",   Location = new Point(260, 148), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(350, 148), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.AddRange(new Control[] { lblOrder, cboOrder, lblReason, txtReason, lblResolution, cboResolution, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
