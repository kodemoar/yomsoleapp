using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YomsoleApp.Utils
{
    /// <summary>
    /// Text coloring utility.
    /// </summary>
    public static class Rainbow
    {
        private static ConsoleColor defColorForeground = Console.ForegroundColor;
        private static ConsoleColor defColorBackground = Console.BackgroundColor;

        /// <summary>
        /// Write colored strings to the output stream (with default background color).
        /// </summary>
        /// <param name="colorForeground">The text color.</param>
        /// <param name="text">The text to print.</param>
        public static void WriteColor(ConsoleColor colorForeground, object text)
        {
            WriteColor(colorForeground, defColorBackground, text);
        }
        /// <summary>
        /// Write colored strings to the output stream.
        /// </summary>
        /// <param name="colorForeground">The text color.</param>
        /// /// <param name="colorBackground">The background color.</param>
        /// <param name="text">The text to print.</param>
        public static void WriteColor(ConsoleColor colorForeground, ConsoleColor colorBackground, object text)
        {
            if (colorForeground != defColorForeground)
            {
                Console.ForegroundColor = colorForeground;
            }

            if (colorBackground != defColorBackground)
            {
                Console.BackgroundColor = colorBackground;
            }

            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Write colored, linefeed-appended strings to the output stream (with default background color).
        /// </summary>
        /// <param name="colorForeground">The text color.</param>
        /// <param name="text">The text to print.</param>
        public static void WriteLineColor(ConsoleColor colorForeground, object text)
        {
            WriteLineColor(colorForeground, defColorBackground, text);
        }
        /// <summary>
        /// Write colored, linefeed-appended strings to the output stream.
        /// </summary>
        /// <param name="colorForeground">The text color.</param>
        /// <param name="text">The text to print.</param>
        public static void WriteLineColor(ConsoleColor colorForeground, ConsoleColor colorBackground, object text)
        {
            WriteColor(colorForeground, colorBackground, $"{text}\n");
        }
    }
}
