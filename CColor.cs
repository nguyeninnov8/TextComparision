public enum CColoring
{
    CORRECTION,
    ADDED,
    DELETED
}

public static class CColoringExtensions
{
    public static string GetColor(this CColoring cColoring)
    {
        switch (cColoring)
        {
            case CColoring.CORRECTION:
                return "green";
            case CColoring.ADDED:
                return "red";
            case CColoring.DELETED:
                return "grey";
            default:
                throw new ArgumentException("Invalid CColoring value.");
        }
    }
}