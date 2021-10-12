namespace PgrTools
{
    public static class Delegates
    {
        /// <remarks>In the pgr configuration, <paramref name="hexString"/> format is %(.{2})</remarks>
        public delegate string HexToString(string hexString);
    }
}
