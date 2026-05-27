using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Complaint list – mirrors complaint-list.html</summary>
public partial class ComplaintListForm : Form
{
    public ComplaintListForm()
    {
        InitializeComponent();
        LoadComplaints();
    }

    private void LoadComplaints(string search = "")
    {
        dgvComplaints.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT c.ComplaintID, cu.CustomerName, c.ProductSerial,
                                  c.ComplaintDate, c.Status, c.PreferredResolution
                           FROM Complaint c JOIN Customer cu ON c.CustomerID = cu.CustomerID
                           WHERE c.ComplaintID LIKE @s OR cu.CustomerName LIKE @s
                           ORDER BY c.ComplaintDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r = cmd.ExecuteReader();
            while (r.Read())
                dgvComplaints.Rows.Add(r["ComplaintID"], r["CustomerName"], r["ProductSerial"],
                                       r["ComplaintDate"], r["Status"], r["PreferredResolution"]);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "DB Error"); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadComplaints(txtSearch.Text.Trim());
    private void btnNew_Click(object s, EventArgs e)
    {
        using var dlg = new ComplaintNewForm();
        if (dlg.ShowDialog() == DialogResult.OK) LoadComplaints();
    }
    private void dgvComplaints_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgvComplaints.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new ComplaintNewForm(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadComplaints();
    }
}
