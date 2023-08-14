using System.Runtime.CompilerServices;

namespace Tests
{
    internal static class Extensions
    {
        internal static string IgnoreIrrelevantChars(this string caller)
        {
            return caller.Replace("\n", "").Trim();
        }
    }
}
