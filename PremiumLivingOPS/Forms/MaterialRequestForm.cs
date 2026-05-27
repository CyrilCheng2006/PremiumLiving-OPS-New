using MySql.Data.MySqlClient;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS.Forms;

/// <summary>Raw Material Request – mirrors material-request.html</summary>
public partial class MaterialRequestForm : Form
{
    public MaterialRequestForm()
    {
        InitializeComponent();
        LoadMaterials();
        LoadRequests();
    }

    private void LoadMaterials()
    {
        try
        {
            using var conn = DBHelper.GetConnection();
            using var cmd  = new MySqlCommand("SELECT MaterialID, MaterialName FROM RawMaterial ORDER BY MaterialName;", conn);
            using var r    = cmd.ExecuteReader();
            cboMaterial.Items.Clear();
            while (r.Read()) cboMaterial.Items.Add(new ComboItem(r.GetString(0), r.GetString(1)));
            cboMaterial.DisplayMember = "Name"; cboMaterial.ValueMember = "Id";
        }
        catch { }
    }

    private void LoadRequests(string search = "")
    {
        dgvRequests.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = @"SELECT mr.RequestID, rm.MaterialName, mr.Quantity,
                                  mr.RequestDate, mr.RequiredDate, mr.UrgencyLevel, mr.Status
                           FROM MaterialRequest mr
                           JOIN RawMaterial rm ON mr.MaterialID = rm.MaterialID
                           WHERE mr.RequestID LIKE @s OR rm.MaterialName LIKE @s
                           ORDER BY mr.RequestDate DESC;";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@s", $"%{search}%");
            using var r   = cmd.ExecuteReader();
            while (r.Read())
            {
                int rowIdx = dgvRequests.Rows.Add(
                    r["RequestID"], r["MaterialName"], r["Quantity"],
                    r["RequestDate"], r["RequiredDate"], r["UrgencyLevel"], r["Status"]);
                string urgency = r["UrgencyLevel"]?.ToString() ?? "";
                if (urgency == "High") dgvRequests.Rows[rowIdx].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                else if (urgency == "Medium") dgvRequests.Rows[rowIdx].DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void btnSearch_Click(object s, EventArgs e) => LoadRequests(txtSearch.Text.Trim());

    private void btnSubmit_Click(object s, EventArgs e)
    {
        if (cboMaterial.SelectedItem is not ComboItem ci) { MessageBox.Show("Select a material."); return; }
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            string rid = $"MR-{DateTime.Now:yyyyMMddHHmmss}";
            string sql = "INSERT INTO MaterialRequest (RequestID,MaterialID,StaffID,Quantity,RequestDate,RequiredDate,UrgencyLevel,Status,Remarks) " +
                         "VALUES (@rid,@mid,@sid,@qty,CURDATE(),@rqd,@urg,'Pending',@rem);";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@rid", rid);
            cmd.Parameters.AddWithValue("@mid", ci.Id);
            cmd.Parameters.AddWithValue("@sid", SessionManager.CurrentStaff!.StaffID);
            cmd.Parameters.AddWithValue("@qty", (int)numQty.Value);
            cmd.Parameters.AddWithValue("@rqd", dtpRequired.Value.Date);
            cmd.Parameters.AddWithValue("@urg", cboUrgency.SelectedItem?.ToString() ?? "Normal");
            cmd.Parameters.AddWithValue("@rem", txtRemarks.Text.Trim());
            cmd.ExecuteNonQuery();
            LoadRequests();
            MessageBox.Show($"Request {rid} submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            numQty.Value = 1; txtRemarks.Clear();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
}
