using MySql.Data.MySqlClient;

namespace PremiumLivingOPS.Helpers;

public static class DBHelper
{
    private const string ConnectionString =
        "Server=127.0.0.1;Port=3306;Database=PremiumLivingFurniture;" +
        "Uid=root;Pwd=root;CharSet=utf8mb4;SslMode=none;";

    public static MySqlConnection GetConnection()
    {
        var conn = new MySqlConnection(ConnectionString);
        conn.Open();
        return conn;
    }

    /// <summary>Sets @current_staff_id session variable so DB triggers log correctly.</summary>
    public static void SetCurrentStaff(MySqlConnection conn, string staffId)
    {
        using var cmd = new MySqlCommand($"SET @current_staff_id = '{staffId}';", conn);
        cmd.ExecuteNonQuery();
    }
}
