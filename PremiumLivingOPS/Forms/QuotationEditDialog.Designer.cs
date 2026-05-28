namespace PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;
partial class QuotationEditDialog
{
    private System.ComponentModel.IContainer components = null;
    private Label lblCustomer, lblValidUntil, lblComments, lblProduct, lblQty;
    private ComboBox cboCustomer, cboProduct;
    private DateTimePicker dtpValidUntil;
    private TextBox txtComments;
    private NumericUpDown numQty;
    private Button btnAddLine, btnSave, btnCancel;
    private DataGridView dgvLines;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        Text = "Quotation"; Size = new Size(700, 560);
        BackColor = UITheme.SurfaceGray; StartPosition = FormStartPosition.CenterParent;

        lblCustomer  = new Label { Text = "Customer:",   Location = new Point(20, 20),  AutoSize = true };
        cboCustomer  = new ComboBox { Location = new Point(110, 16), Size = new Size(220, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblValidUntil = new Label { Text = "Valid Until:", Location = new Point(350, 20), AutoSize = true };
        dtpValidUntil = new DateTimePicker { Location = new Point(440, 16), Size = new Size(180, 24), Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(30) };

        lblProduct = new Label { Text = "Product:", Location = new Point(20, 56), AutoSize = true };
        cboProduct = new ComboBox { Location = new Point(110, 52), Size = new Size(300, 24), DropDownStyle = ComboBoxStyle.DropDownList };
        lblQty = new Label { Text = "Qty:", Location = new Point(420, 56), AutoSize = true };
        numQty = new NumericUpDown { Location = new Point(450, 52), Size = new Size(60, 24), Minimum = 1, Maximum = 9999, Value = 1 };
        btnAddLine = new Button { Text = "+ Add Line", Location = new Point(524, 52), Size = new Size(90, 26), BackColor = UITheme.PrimaryMid, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnAddLine.FlatAppearance.BorderSize = 0;
        btnAddLine.Click += btnAddLine_Click;

        dgvLines = new DataGridView
        {
            Location = new Point(20, 88), Size = new Size(640, 300),
            BackgroundColor = UITheme.SurfaceWhite, BorderStyle = BorderStyle.FixedSingle,
            RowHeadersVisible = false, AllowUserToAddRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        dgvLines.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { HeaderText="Product ID", Name="PID", ReadOnly=true },
            new DataGridViewTextBoxColumn { HeaderText="Product",    Name="PName", ReadOnly=true },
            new DataGridViewTextBoxColumn { HeaderText="Qty",        Name="Qty" },
            new DataGridViewTextBoxColumn { HeaderText="Unit Price", Name="UP", ReadOnly=true },
        });

        lblComments = new Label { Text = "Comments:", Location = new Point(20, 400), AutoSize = true };
        txtComments = new TextBox { Location = new Point(110, 396), Size = new Size(550, 40), Multiline = true };

        btnSave = new Button { Text = "Save", Location = new Point(490, 448), Size = new Size(80, 30), BackColor = UITheme.AccentGold, ForeColor = UITheme.PrimaryDark, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnSave.FlatAppearance.BorderSize = 0; btnSave.Click += btnSave_Click;
        btnCancel = new Button { Text = "Cancel", Location = new Point(580, 448), Size = new Size(80, 30), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };

        Controls.AddRange(new Control[] { lblCustomer, cboCustomer, lblValidUntil, dtpValidUntil,
            lblProduct, cboProduct, lblQty, numQty, btnAddLine, dgvLines,
            lblComments, txtComments, btnSave, btnCancel });
        ResumeLayout(false);
    }
}
