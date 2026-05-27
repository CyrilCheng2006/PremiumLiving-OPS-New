using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

public partial class PurchaseOrderEditDialog : Form
{
    private readonly string? _id;
    public PurchaseOrderEditDialog(string? id = null) { _id = id; InitializeComponent(); LoadSuppliers(); if (_id != null) LoadExisting(); }

    private void LoadSuppliers()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT SupplierID, SupplierName FROM Supplier ORDER BY SupplierName;", conn);
            using var r    = cmd.ExecuteReader();
            cboSupplier.Items.Clear();
            while (r.Read()) cboSupplier.Items.Add(new ComboItem(r.GetString(0), r.GetString(1)));
            cboSupplier.DisplayMember = "Name"; cboSupplier.ValueMember = "Id";
        } catch { }
    }

    private void LoadExisting()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT * FROM PurchaseOrder WHERE POID=@id;", conn);
            cmd.Parameters.AddWithValue("@id", _id);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return;
            foreach (ComboItem ci in cboSupplier.Items) if (ci.Id == r.GetString("SupplierID")) { cboSupplier.SelectedItem = ci; break; }
            dtpExpected.Value  = r.GetDateTime("ExpectedDate");
            cboStatus.SelectedItem = r["Status"]?.ToString();
            txtRemarks.Text    = r["Remarks"]?.ToString() ?? "";
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSave_Click(object s, EventArgs e)
    {
        if (cboSupplier.SelectedItem is not ComboItem sup) { MessageBox.Show("Select a supplier."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string pid = _id ?? $"PO-{DateTime.Now:yyyyMMddHHmmss}";
            if (_id == null)
            {
                string sql = "INSERT INTO PurchaseOrder (POID,SupplierID,StaffID,OrderDate,ExpectedDate,TotalAmount,Status,Remarks) VALUES (@id,@sid,@stf,CURDATE(),@exp,0,@st,@rem);";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", pid); cmd.Parameters.AddWithValue("@sid", sup.Id);
                cmd.Parameters.AddWithValue("@stf", SessionManager.CurrentStaff.StaffID);
                cmd.Parameters.AddWithValue("@exp", dtpExpected.Value.Date);
                cmd.Parameters.AddWithValue("@st", cboStatus.SelectedItem?.ToString() ?? "Draft");
                cmd.Parameters.AddWithValue("@rem", txtRemarks.Text); cmd.ExecuteNonQuery();
            }
            else
            {
                string sql = "UPDATE PurchaseOrder SET ExpectedDate=@exp, Status=@st, Remarks=@rem WHERE POID=@id;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", pid); cmd.Parameters.AddWithValue("@exp", dtpExpected.Value.Date);
                cmd.Parameters.AddWithValue("@st", cboStatus.SelectedItem?.ToString() ?? "Draft");
                cmd.Parameters.AddWithValue("@rem", txtRemarks.Text); cmd.ExecuteNonQuery();
            }
            DialogResult = DialogResult.OK;
        } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
