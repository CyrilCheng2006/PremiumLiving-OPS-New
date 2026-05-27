using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

partial class OrderListForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private TextBox txtSearch;
    private ComboBox cmbStatus;
    private Button btnNewOrder;
    private DataGridView dgvOrders;

    protected override void Dispose(bool d) { if (d && components!=null) components.Dispose(); base.Dispose(d); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        SuspendLayout();
        this.BackColor = UITheme.SurfaceGray;
        this.Padding   = new Padding(24);

        lblTitle = new Label { Text="Order List", Font=UITheme.FontTitle,
            ForeColor=UITheme.TextDark, AutoSize=true, Location=new Point(24,24) };

        txtSearch = new TextBox { PlaceholderText="\uD83D\uDD0D  Search orders...",
            Size=new Size(280,32), Location=new Point(24,70), Font=UITheme.FontBody };
        txtSearch.TextChanged += txtSearch_TextChanged;

        cmbStatus = new ComboBox { Size=new Size(160,32), Location=new Point(316,70),
            DropDownStyle=ComboBoxStyle.DropDownList, Font=UITheme.FontBody };
        cmbStatus.Items.AddRange(new object[]{"All","Pending","Processing",
            "Partially Delivered","Delivered","Completed","Cancelled"});
        cmbStatus.SelectedIndex = 0;
        cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;

        btnNewOrder = new Button { Text="+ New Order", Size=new Size(130,34),
            Location=new Point(492,68), BackColor=UITheme.AccentGold,
            ForeColor=UITheme.PrimaryDark, FlatStyle=FlatStyle.Flat, Font=UITheme.FontBody, Cursor=Cursors.Hand };
        btnNewOrder.FlatAppearance.BorderSize=0;
        btnNewOrder.Click += btnNewOrder_Click;

        dgvOrders = new DataGridView {
            Location=new Point(24,114), Size=new Size(1100,580),
            AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor=UITheme.SurfaceWhite, BorderStyle=BorderStyle.None,
            RowHeadersVisible=false, SelectionMode=DataGridViewSelectionMode.FullRowSelect,
            ReadOnly=true, AllowUserToAddRows=false, Font=UITheme.FontBody };
        dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = UITheme.PrimaryDark;
        dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvOrders.ColumnHeadersDefaultCellStyle.Font      = UITheme.FontBody;
        dgvOrders.EnableHeadersVisualStyles = false;
        dgvOrders.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText="Order ID" },
            new DataGridViewTextBoxColumn { HeaderText="Customer" },
            new DataGridViewTextBoxColumn { HeaderText="Order Date" },
            new DataGridViewTextBoxColumn { HeaderText="Delivery Date" },
            new DataGridViewTextBoxColumn { HeaderText="Total" },
            new DataGridViewTextBoxColumn { HeaderText="Status" },
            new DataGridViewTextBoxColumn { HeaderText="Contact" });
        dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;

        this.Controls.AddRange(new Control[]{ lblTitle, txtSearch, cmbStatus, btnNewOrder, dgvOrders });
        ResumeLayout(false);
    }
}
