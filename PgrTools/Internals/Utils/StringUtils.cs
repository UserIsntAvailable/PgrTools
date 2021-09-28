using System.Globalization;
using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace
namespace PgrTools.Internals
{
    internal static class StringUtils
    {
        private static readonly Regex UrlHexRegex = new("%(.{2})", RegexOptions.Compiled);

        /// <summary>
        /// Replaces all hex values (%.{2}) with their char value.
        /// </summary>
        /// <param name="hexString">The string to work with</param>
        /// <returns>The new string with the hex values replaced.</returns>
        public static string UrlHexToStr(string hexString)
        {
            return UrlHexRegex.Replace(
                hexString,
                match => ((char) int.Parse(match.Groups[1].Value, NumberStyles.HexNumber)).ToString()
            );
        }
    }
}
