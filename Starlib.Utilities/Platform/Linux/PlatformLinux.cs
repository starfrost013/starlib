
namespace Starlib.Utilities
{
    internal static partial class PlatformLinux
    {
        [SupportedOSPlatform("linux")]
        [SupportedOSPlatform("freebsd")] // also on freebsd
        [DllImport("libc", EntryPoint = "sysinfo")]
        [return: MarshalAs(UnmanagedType.I4)]
        internal static extern int sysinfo(out SysInfo sysinfo);
    }

    // libc sysinfo 
    internal struct SysInfo 
    {
        internal long uptime;             /* Seconds since boot */
        internal long[] loads = new long[3];  /* 1, 5, and 15 minute load averages */
        internal long totalram;  /* Total usable main memory size */
        internal long freeram;   /* Available memory size */
        internal long sharedram; /* Amount of shared memory */
        internal long bufferram; /* Memory used by buffers */
        internal long totalswap; /* Total swap space size */
        internal long freeswap;  /* swap space still available */
        internal short procs;    /* Number of current processes */
        internal long totalhigh; /* Total high memory size */
        internal  long freehigh;  /* Available high memory size */
        internal int mem_unit;   /* Memory unit size in bytes */
        internal char[] _f = new char[20 - 2 * sizeof(long) - sizeof(int)]; /* Padding for libc5 */

        public SysInfo() { }
    };
}
