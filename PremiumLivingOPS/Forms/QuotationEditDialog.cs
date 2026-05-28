using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Create / edit a single quotation.</summary>
public partial class QuotationEditDialog : Form
{
    private readonly string? _quotationId;
    public QuotationEditDialog(string? id = null)
    {
        _quotationId = id;
        InitializeComponent();
        LoadCustomers();
        LoadProducts();
        if (_quotationId != null) LoadExisting();
    }

    private void LoadCustomers()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT CustomerID, CustomerName FROM Customer ORDER BY CustomerName;", conn);
            using var r    = cmd.ExecuteReader();
            cboCustomer.Items.Clear();
            while (r.Read()) cboCustomer.Items.Add(new ComboItem(r.GetString(0), r.GetString(1)));
        }
        catch { }
    }

    private void LoadProducts()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT ProductID, ProductName, UnitPrice FROM Product ORDER BY ProductName;", conn);
            using var r    = cmd.ExecuteReader();
            cboProduct.Items.Clear();
            while (r.Read()) cboProduct.Items.Add(new ComboItem(r.GetString(0), $"{r.GetString(1)} (HK${r.GetDecimal(2):N2})"));
        }
        catch { }
    }

    private void LoadExisting()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = "SELECT * FROM Quotation WHERE QuotationID = @id;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", _quotationId);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            foreach (ComboItem ci in cboCustomer.Items)
                if (ci.Id == r.GetString("CustomerID")) { cboCustomer.SelectedItem = ci; break; }
            dtpValidUntil.Value = r.GetDateTime("ValidUntil");
            txtComments.Text    = r["OtherComments"]?.ToString() ?? "";
            r.Close();
            string lineSql = "SELECT ql.ProductID, p.ProductName, ql.Quantity, ql.UnitPrice " +
                             "FROM QuotationLine ql JOIN Product p ON ql.ProductID=p.ProductID " +
                             "WHERE ql.QuotationID = @id;";
            using var cmd2 = new MySqlCommand(lineSql, conn);
            cmd2.Parameters.AddWithValue("@id", _quotationId);
            using var r2 = cmd2.ExecuteReader();
            while (r2.Read())
                dgvLines.Rows.Add(r2["ProductID"], r2["ProductName"], r2["Quantity"], $"HK${r2["UnitPrice"]:N2}");
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnAddLine_Click(object s, EventArgs e)
    {
        if (cboProduct.SelectedItem is not ComboItem ci) return;
        int qty = (int)numQty.Value;
        dgvLines.Rows.Add(ci.Id, ci.Name, qty, "");
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (cboCustomer.SelectedItem is not ComboItem cust) { MessageBox.Show("Select a customer."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string qid = _quotationId ?? $"QT-{DateTime.Now:yyyyMMddHHmmss}";
            if (_quotationId == null)
            {
                string ins = "INSERT INTO Quotation (QuotationID,CustomerID,StaffID,QuotationDate,ValidUntil,TotalAmount,Status,OtherComments) " +
                             "VALUES (@qid,@cid,@sid,CURDATE(),@vu,0,'Draft',@cmt);";
                using var cmd = new MySqlCommand(ins, conn);
                cmd.Parameters.AddWithValue("@qid", qid);
                cmd.Parameters.AddWithValue("@cid", cust.Id);
                cmd.Parameters.AddWithValue("@sid", SessionManager.CurrentStaff.StaffID);
                cmd.Parameters.AddWithValue("@vu",  dtpValidUntil.Value.Date);
                cmd.Parameters.AddWithValue("@cmt", txtComments.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                string upd = "UPDATE Quotation SET CustomerID=@cid, ValidUntil=@vu, OtherComments=@cmt WHERE QuotationID=@qid;";
                using var cmd = new MySqlCommand(upd, conn);
                cmd.Parameters.AddWithValue("@qid", qid); cmd.Parameters.AddWithValue("@cid", cust.Id);
                cmd.Parameters.AddWithValue("@vu", dtpValidUntil.Value.Date); cmd.Parameters.AddWithValue("@cmt", txtComments.Text);
                cmd.ExecuteNonQuery();
                using var del = new MySqlCommand("DELETE FROM QuotationLine WHERE QuotationID=@qid;", conn);
                del.Parameters.AddWithValue("@qid", qid); del.ExecuteNonQuery();
            }
            decimal total = 0m;
            foreach (DataGridViewRow row in dgvLines.Rows)
            {
                if (row.IsNewRow) continue;
                string pid = row.Cells[0].Value?.ToString() ?? ""; int qty = Convert.ToInt32(row.Cells[2].Value);
                using var pcmd = new MySqlCommand("SELECT UnitPrice FROM Product WHERE ProductID=@pid;", conn);
                pcmd.Parameters.AddWithValue("@pid", pid);
                decimal up = Convert.ToDecimal(pcmd.ExecuteScalar() ?? 0);
                total += up * qty;
                string insl = "INSERT INTO QuotationLine (QuotationLineID,QuotationID,ProductID,Quantity,UnitPrice) VALUES (UUID(),@qid,@pid,@qty,@up);";
                using var lcmd = new MySqlCommand(insl, conn);
                lcmd.Parameters.AddWithValue("@qid", qid); lcmd.Parameters.AddWithValue("@pid", pid);
                lcmd.Parameters.AddWithValue("@qty", qty); lcmd.Parameters.AddWithValue("@up", up);
                lcmd.ExecuteNonQuery();
            }
            using var updt = new MySqlCommand("UPDATE Quotation SET TotalAmount=@t WHERE QuotationID=@qid;", conn);
            updt.Parameters.AddWithValue("@t", total); updt.Parameters.AddWithValue("@qid", qid);
            updt.ExecuteNonQuery();
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
