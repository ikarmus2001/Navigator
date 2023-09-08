using System.Runtime.CompilerServices;

namespace LeafletAPI_Tests
{
    internal static class Extensions
    {
        internal static string IgnoreIrrelevantChars(this string caller)
        {
            return caller.Trim();
        }
    }
}
