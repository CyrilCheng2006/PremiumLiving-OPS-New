namespace PremiumLivingOPS.Helpers;


/// <summary>Centralised colour + font tokens mirroring the HTML prototype.</summary>
public static class UITheme
{
    // Colours
    public static readonly Color PrimaryDark  = ColorTranslator.FromHtml("#1a1a2e");
    public static readonly Color PrimaryMid   = ColorTranslator.FromHtml("#16213e");
    public static readonly Color AccentGold   = ColorTranslator.FromHtml("#c9a84c");
    public static readonly Color AccentGoldHover = ColorTranslator.FromHtml("#e0c068");
    public static readonly Color SurfaceWhite = Color.White;
    public static readonly Color SurfaceGray  = ColorTranslator.FromHtml("#f8f9fa");
    public static readonly Color BorderGray   = ColorTranslator.FromHtml("#dee2e6");
    public static readonly Color TextDark     = ColorTranslator.FromHtml("#212529");
    public static readonly Color TextMuted    = ColorTranslator.FromHtml("#6c757d");
    public static readonly Color Success      = ColorTranslator.FromHtml("#28a745");
    public static readonly Color Warning      = ColorTranslator.FromHtml("#ffc107");
    public static readonly Color Danger       = ColorTranslator.FromHtml("#dc3545");
    public static readonly Color Info         = ColorTranslator.FromHtml("#17a2b8");

    // Fonts
    public static readonly Font FontTitle    = new("Segoe UI", 18f, FontStyle.Bold);
    public static readonly Font FontHeading  = new("Segoe UI", 12f, FontStyle.Bold);
    public static readonly Font FontBody     = new("Segoe UI",  9f);
    public static readonly Font FontSmall    = new("Segoe UI",  8f);
    public static readonly Font FontNav      = new("Segoe UI", 10f, FontStyle.Bold);

    /// <summary>Apply gold hover effect to a nav Button.</summary>
    public static void NavHover(Button btn, bool enter)
    {
        btn.BackColor = enter ? AccentGold : Color.Transparent;
        btn.ForeColor = enter ? PrimaryDark : Color.White;
    }
}
