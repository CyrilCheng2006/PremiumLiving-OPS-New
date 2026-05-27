using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

partial class CustomerEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblID, lblName, lblEmail, lblPhone;
    private TextBox txtID, txtName, txtEmail, txtPhone;
    private Button btnSave, btnCancel;

    protected override void Dispose(bool disposing)
    { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components  = new System.ComponentModel.Container();
        this.Size   = new Size(420, 320);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
        this.BackColor  = UITheme.SurfaceWhite;

        lblID    = new Label { Text = "Customer ID", Location = new Point(20,20), AutoSize=true };
        txtID    = new TextBox { Location = new Point(20,40),  Size = new Size(360,24) };
        lblName  = new Label { Text = "Name",        Location = new Point(20,76), AutoSize=true };
        txtName  = new TextBox { Location = new Point(20,96),  Size = new Size(360,24) };
        lblEmail = new Label { Text = "Email",       Location = new Point(20,130), AutoSize=true };
        txtEmail = new TextBox { Location = new Point(20,150), Size = new Size(360,24) };
        lblPhone = new Label { Text = "Phone",       Location = new Point(20,184), AutoSize=true };
        txtPhone = new TextBox { Location = new Point(20,204), Size = new Size(360,24) };

        btnSave = new Button { Text = "Save", Location = new Point(20,248),
            Size = new Size(100,32), BackColor = UITheme.AccentGold,
            ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.Click += btnSave_Click;

        btnCancel = new Button { Text = "Cancel", Location = new Point(132,248),
            Size = new Size(100,32), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += btnCancel_Click;

        this.Controls.AddRange(new Control[]
            { lblID, txtID, lblName, txtName, lblEmail, txtEmail, lblPhone, txtPhone, btnSave, btnCancel });
        this.AcceptButton = btnSave;
        this.CancelButton = btnCancel;
    }
}
