namespace PremiumLivingOPS.Helpers;

/// <summary>
/// Generic ComboBox item that holds an Id/Name pair.
/// Used in dropdowns where the display text differs from the stored value.
/// </summary>
public record ComboItem(string Id, string Name)
{
    public override string ToString() => Name;
}
