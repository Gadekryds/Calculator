using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator;

public static class ConsoleUIHelpers
{
    public static void InsertHeader(string text, char paddingChar = '-')
    {
        Console.WriteLine();
        int width = Console.WindowWidth;
        int totalPadding = width - text.Length;

        if (totalPadding >= 0)
        {
            int leftPadding = totalPadding / 2;
            int rightPadding = totalPadding - leftPadding;

            string paddedText = new string(paddingChar, leftPadding -1) + " " + text + " " + new string(paddingChar, rightPadding -1);

            Console.WriteLine(paddedText);
        }
        else
        {
            Console.WriteLine(text);
        }
    }
}
