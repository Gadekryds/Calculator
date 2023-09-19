using System.Globalization;

namespace Calculator;

public static class ApplicationSetup
{
    public static void SetupApplication()
    {
        // Disregarding current system language
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
    }

    public static string TranslateCulturalDifference(string input)
    {
        return input.Replace(",", ".");
    }
}
