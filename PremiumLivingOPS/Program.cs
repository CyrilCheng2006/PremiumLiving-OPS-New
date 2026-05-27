using PremiumLivingOPS.Forms;
using PremiumLivingOPS.Helpers;

namespace PremiumLivingOPS;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }
}
