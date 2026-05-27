namespace PremiumLivingOPS.Forms;

partial class SysConfigForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader; private Label lblTitle; private Button btnSave; private DataGridView dgv;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        SuspendLayout(); BackColor = UITheme.SurfaceGray; Padding = new Padding(24);
        pnlHeader = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = UITheme.SurfaceGray };
        lblTitle  = new Label { Text = "⚙️ System Configuration", Font = UITheme.FontTitle, ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(0, 8) };
        btnSave   = new Button { Text = "Save Changes", Size = new Size(120, 28), Location = new Point(756, 14), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        pnlHeader.Controls.AddRange(new Control[] { lblTitle, btnSave });
        dgv = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.None, RowHeadersVisible = false, AllowUserToAddRows = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        dgv.Columns.AddRange(new DataGridViewColumn[] {
            new DataGridViewTextBoxColumn { HeaderText = "Key",         Name = "Key",   ReadOnly = true },
            new DataGridViewTextBoxColumn { HeaderText = "Value",       Name = "Value" },
            new DataGridViewTextBoxColumn { HeaderText = "Description", Name = "Desc",  ReadOnly = true },
        });
        Controls.AddRange(new Control[] { dgv, pnlHeader }); ResumeLayout(false);
    }
}
