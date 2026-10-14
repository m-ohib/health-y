namespace HealthY.Core.Common;

/// <summary>
/// Kastes af services, når input bryder en forretningsregel (fx minutter uden for 1–600).
/// </summary>
// TIP: Api'et oversætter denne exception til 400 Bad Request med beskeden.
//      Beskeden vises direkte til brugeren, så skriv den i enkelt dansk uden fagord.
public class ValidationException(string message) : Exception(message);
