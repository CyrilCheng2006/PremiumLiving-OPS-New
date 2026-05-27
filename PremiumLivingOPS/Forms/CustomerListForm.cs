using PremiumLivingOPS.Helpers;
using PremiumLivingOPS.Models;
using MySql.Data.MySqlClient;

namespace PremiumLivingOPS.Forms;

public partial class CustomerListForm : Form
{
    public CustomerListForm()
    {
        InitializeComponent();
        LoadCustomers();
    }

    private void LoadCustomers(string search = "")
    {
        dgvCustomers.Rows.Clear();
        try
        {
            using var conn = DBHelper.GetConnection();
            string sql = "SELECT CustomerID, CustomerName, EmailAddress, PhoneNumber FROM Customer";
            if (!string.IsNullOrEmpty(search))
                sql += " WHERE CustomerName LIKE @s OR CustomerID LIKE @s OR EmailAddress LIKE @s";
            sql += " ORDER BY CustomerName;";

            using var cmd = new MySqlCommand(sql, conn);
            if (!string.IsNullOrEmpty(search))
                cmd.Parameters.AddWithValue("@s", $"%{search}%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                dgvCustomers.Rows.Add(
                    reader["CustomerID"],
                    reader["CustomerName"],
                    reader["EmailAddress"],
                    reader["PhoneNumber"]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtSearch_TextChanged(object s, EventArgs e) => LoadCustomers(txtSearch.Text);

    private void btnAdd_Click(object s, EventArgs e)
    {
        using var dlg = new CustomerEditDialog();
        if (dlg.ShowDialog() == DialogResult.OK) LoadCustomers();
    }

    private void dgvCustomers_CellDoubleClick(object s, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        string id = dgvCustomers.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
        using var dlg = new CustomerEditDialog(id);
        if (dlg.ShowDialog() == DialogResult.OK) LoadCustomers();
    }

    private void btnDelete_Click(object s, EventArgs e)
    {
        if (dgvCustomers.CurrentRow == null) return;
        string id = dgvCustomers.CurrentRow.Cells[0].Value?.ToString() ?? "";
        if (MessageBox.Show($"Delete customer {id}?", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        try
        {
            using var conn = DBHelper.GetConnection();
            DBHelper.SetCurrentStaff(conn, SessionManager.CurrentStaff!.StaffID);
            using var cmd = new MySqlCommand("DELETE FROM Customer WHERE CustomerID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            LoadCustomers();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
