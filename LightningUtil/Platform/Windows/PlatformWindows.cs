
namespace Starlib.Utilities
{
    internal static partial class PlatformWindows
    {
        [SupportedOSPlatform("windows")]
        [LibraryImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static partial bool GetPhysicallyInstalledSystemMemory(out long sysMemory);
    }
}
