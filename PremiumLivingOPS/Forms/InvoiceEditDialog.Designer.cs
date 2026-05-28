namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class InvoiceEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblCustomer, lblOrder, lblBilling, lblShipping, lblPayStatus, lblComments;
    private ComboBox cboCustomer, cboOrder, cboPayStatus;
    private TextBox txtBillingAddr, txtShippingAddr, txtComments;
    private Button btnSave, btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        Text = "Invoice"; Size = new Size(620, 420);
        BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;

        int lx = 20, fx = 160, fw = 400;
        lblCustomer  = new Label { Text = "Customer:",       Location = new Point(lx, 20),  AutoSize = true };
        cboCustomer  = new ComboBox { Location = new Point(fx, 16),  Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblOrder     = new Label { Text = "Order ID:",       Location = new Point(lx, 54),  AutoSize = true };
        cboOrder     = new ComboBox { Location = new Point(fx, 50),  Size = new Size(fw, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblBilling   = new Label { Text = "Billing Address:",Location = new Point(lx, 88),  AutoSize = true };
        txtBillingAddr = new TextBox { Location = new Point(fx, 84), Size = new Size(fw, 40), Multiline = true };
        lblShipping  = new Label { Text = "Shipping Address:",Location = new Point(lx, 138), AutoSize = true };
        txtShippingAddr = new TextBox { Location = new Point(fx, 134), Size = new Size(fw, 40), Multiline = true };
        lblPayStatus = new Label { Text = "Payment Status:", Location = new Point(lx, 188), AutoSize = true };
        cboPayStatus = new ComboBox { Location = new Point(fx, 184), Size = new Size(200, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        cboPayStatus.Items.AddRange(new object[] { "Unpaid", "Partial", "Paid" });
        cboPayStatus.SelectedIndex = 0;
        lblComments  = new Label { Text = "Comments:",       Location = new Point(lx, 222), AutoSize = true };
        txtComments  = new TextBox { Location = new Point(fx, 218), Size = new Size(fw, 60), Multiline = true };

        btnSave = new Button { Text = "Save", Location = new Point(430, 296), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(520, 296), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };

        Controls.AddRange(new Control[] { lblCustomer, cboCustomer, lblOrder, cboOrder, lblBilling, txtBillingAddr,
            lblShipping, txtShippingAddr, lblPayStatus, cboPayStatus, lblComments, txtComments, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
