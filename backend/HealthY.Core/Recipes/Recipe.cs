namespace HealthY.Core.Recipes;

/// <summary>
/// En ret fra den faste liste på ca. 30 (US 11). Ingen kalorietal eller diætråd.
/// </summary>
public class Recipe
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    /// <summary>2–3 linjer om, hvorfor retten er sund.</summary>
    public string WhyHealthy { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;
}
