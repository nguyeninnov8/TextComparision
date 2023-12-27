namespace TextComparision;

/// <summary>
/// This is used for Coloring Word Status
/// </summary>

public enum ColoringEnum
{
    /// <summary>
    /// This value is used when a revised word is correct 
    /// </summary>
    Correction,

    /// <summary>
    /// This value is used when a word is added
    /// </summary>
    Added,

    /// <summary>
    /// This value is used when a word is deleted
    /// </summary>
    Deleted
}

public static class CColoringExtensions
{
    /// <summary>
    /// Error message when there is not color that match the required color
    /// </summary>
    private const string ErrorMessage = "Invalid CColoring value.";

    public static string GetColor(ColoringEnum cColoring)
    {
        switch (cColoring)
        {
            case ColoringEnum.Correction:
                return "green";
            case ColoringEnum.Added:
                return "red";
            case ColoringEnum.Deleted:
                return "grey";
            default:
                throw new ArgumentException(ErrorMessage);
        }
    }
}