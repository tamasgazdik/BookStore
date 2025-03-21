using System.Reflection;

namespace BookStore.Application
{
    internal static class AssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
