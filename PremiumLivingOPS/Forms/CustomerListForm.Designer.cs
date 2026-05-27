using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

partial class CustomerListForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private TextBox txtSearch;
    private Button btnAdd, btnDelete;
    private DataGridView dgvCustomers;

    protected override void Dispose(bool disposing)
    { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        SuspendLayout();
        this.BackColor = UITheme.SurfaceGray;
        this.Padding   = new Padding(24);

        lblTitle = new Label { Text = "Customer List", Font = UITheme.FontTitle,
            ForeColor = UITheme.TextDark, AutoSize = true, Location = new Point(24,24) };

        txtSearch = new TextBox { PlaceholderText = "\uD83D\uDD0D  Search customers...",
            Size = new Size(320,32), Location = new Point(24,70), Font = UITheme.FontBody };
        txtSearch.TextChanged += txtSearch_TextChanged;

        btnAdd = new Button { Text = "+ Add Customer", Size = new Size(140,34),
            Location = new Point(360,68), BackColor = UITheme.AccentGold,
            ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Font = UITheme.FontBody, Cursor = Cursors.Hand };
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.Click += btnAdd_Click;

        btnDelete = new Button { Text = "Delete", Size = new Size(90,34),
            Location = new Point(510,68), BackColor = UITheme.Danger,
            ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = UITheme.FontBody, Cursor = Cursors.Hand };
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.Click += btnDelete_Click;

        dgvCustomers = new DataGridView
        {
            Location              = new Point(24,114),
            Size                  = new Size(1100,580),
            AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor       = UITheme.SurfaceWhite,
            BorderStyle           = BorderStyle.None,
            RowHeadersVisible     = false,
            SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
            ReadOnly              = true,
            AllowUserToAddRows    = false,
            Font                  = UITheme.FontBody
        };
        dgvCustomers.ColumnHeadersDefaultCellStyle.BackColor = UITheme.PrimaryDark;
        dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvCustomers.ColumnHeadersDefaultCellStyle.Font      = UITheme.FontBody;
        dgvCustomers.EnableHeadersVisualStyles = false;
        dgvCustomers.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText = "Customer ID",   Name = "colID" },
            new DataGridViewTextBoxColumn { HeaderText = "Name",          Name = "colName" },
            new DataGridViewTextBoxColumn { HeaderText = "Email",         Name = "colEmail" },
            new DataGridViewTextBoxColumn { HeaderText = "Phone",         Name = "colPhone" }
        );
        dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;

        this.Controls.AddRange(new Control[] { lblTitle, txtSearch, btnAdd, btnDelete, dgvCustomers });
        ResumeLayout(false);
    }
}
