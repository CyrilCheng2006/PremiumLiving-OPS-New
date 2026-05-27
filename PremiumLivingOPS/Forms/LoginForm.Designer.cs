namespace PremiumLivingOPS.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel  pnlCard;
    private Label  lblTitle;
    private Label  lblSubtitle;
    private Label  lblStaffId;
    private Label  lblPassword;
    private TextBox txtStaffId;
    private TextBox txtPassword;
    private Button  btnLogin;
    private Label  lblError;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        pnlCard   = new Panel();
        lblTitle  = new Label();
        lblSubtitle = new Label();
        lblStaffId  = new Label();
        lblPassword = new Label();
        txtStaffId  = new TextBox();
        txtPassword = new TextBox();
        btnLogin    = new Button();
        lblError    = new Label();

        // ---- card panel ----
        pnlCard.BackColor = UITheme.PrimaryMid;
        pnlCard.BorderStyle = BorderStyle.None;
        pnlCard.Size = new Size(360, 420);
        pnlCard.Location = new Point(60, 70);
        pnlCard.Padding = new Padding(30);

        // ---- title ----
        lblTitle.Text      = "PremiumLiving";
        lblTitle.Font      = UITheme.FontTitle;
        lblTitle.ForeColor = UITheme.AccentGold;
        lblTitle.AutoSize  = true;
        lblTitle.Location  = new Point(30, 30);

        // ---- subtitle ----
        lblSubtitle.Text      = "Operations System";
        lblSubtitle.Font      = UITheme.FontBody;
        lblSubtitle.ForeColor = Color.LightGray;
        lblSubtitle.AutoSize  = true;
        lblSubtitle.Location  = new Point(30, 65);

        // ---- staff id label ----
        lblStaffId.Text      = "Staff ID";
        lblStaffId.Font      = UITheme.FontBody;
        lblStaffId.ForeColor = Color.LightGray;
        lblStaffId.AutoSize  = true;
        lblStaffId.Location  = new Point(30, 110);

        // ---- staff id input ----
        txtStaffId.Size      = new Size(300, 32);
        txtStaffId.Location  = new Point(30, 130);
        txtStaffId.Font      = UITheme.FontBody;
        txtStaffId.BackColor = ColorTranslator.FromHtml("#0f3460");
        txtStaffId.ForeColor = Color.White;
        txtStaffId.BorderStyle = BorderStyle.FixedSingle;

        // ---- password label ----
        lblPassword.Text      = "Password";
        lblPassword.Font      = UITheme.FontBody;
        lblPassword.ForeColor = Color.LightGray;
        lblPassword.AutoSize  = true;
        lblPassword.Location  = new Point(30, 180);

        // ---- password input ----
        txtPassword.Size         = new Size(300, 32);
        txtPassword.Location     = new Point(30, 200);
        txtPassword.Font         = UITheme.FontBody;
        txtPassword.BackColor    = ColorTranslator.FromHtml("#0f3460");
        txtPassword.ForeColor    = Color.White;
        txtPassword.BorderStyle  = BorderStyle.FixedSingle;
        txtPassword.PasswordChar = '•';

        // ---- login button ----
        btnLogin.Text      = "Sign In";
        btnLogin.Size      = new Size(300, 44);
        btnLogin.Location  = new Point(30, 260);
        btnLogin.Font      = UITheme.FontHeading;
        btnLogin.BackColor = UITheme.AccentGold;
        btnLogin.ForeColor = UITheme.PrimaryDark;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.Cursor    = Cursors.Hand;
        btnLogin.Click    += btnLogin_Click;

        // ---- error label ----
        lblError.Text      = "";
        lblError.Font      = UITheme.FontSmall;
        lblError.ForeColor = UITheme.Danger;
        lblError.AutoSize  = true;
        lblError.Location  = new Point(30, 315);

        // ---- assemble ----
        pnlCard.Controls.AddRange(new Control[]
            { lblTitle, lblSubtitle, lblStaffId, txtStaffId,
              lblPassword, txtPassword, btnLogin, lblError });
        this.Controls.Add(pnlCard);

        this.AcceptButton = btnLogin;
    }
}
