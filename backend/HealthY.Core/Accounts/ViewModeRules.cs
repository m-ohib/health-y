namespace HealthY.Core.Accounts;

public static class ViewModeRules
{
    public const int SimpleViewSuggestedFromAge = 60;

    /// <summary>
    /// Forslag ved oprettelse: 60+ får Enkel visning, alle andre Udvidet (US 10).
    /// </summary>
    public static ViewMode Suggest(int? birthYear, int currentYear)
    {
        // TODO: Uden fødselsår: vælg en standard (Enkel er det sikre valg for målgruppen).
        // TODO: Alder = currentYear - birthYear. 60 eller ældre -> Simple, ellers Extended.
        // TIP: Test 59, 60 og null.
        throw new NotImplementedException();
    }
}
