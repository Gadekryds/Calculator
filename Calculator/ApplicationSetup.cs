using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
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
}
