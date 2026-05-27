using PremiumLivingOPS.Models;

namespace PremiumLivingOPS.Helpers;

public static class SessionManager
{
    public static Staff? CurrentStaff { get; set; }

    public static bool IsLoggedIn => CurrentStaff != null;

    public static void Logout() => CurrentStaff = null;

    public static bool HasRole(params string[] roles) =>
        CurrentStaff != null && roles.Contains(CurrentStaff.StaffRole);

    public static bool HasDept(params string[] depts) =>
        CurrentStaff != null && depts.Contains(CurrentStaff.Department);
}
