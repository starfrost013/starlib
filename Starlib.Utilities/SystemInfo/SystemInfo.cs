namespace Starlib.Utilities
{
    [RequiresPreviewFeatures]
    /// <summary>
    /// SystemInfo
    /// 
    /// Defines system information.
    /// </summary>
    public static class SystemInfo
    {
        /// <summary>
        /// The total amount of system RAM in KiB.
        /// </summary>
        public static long SystemRam { get; private set; }

        /// <summary>
        /// CPU information.
        /// </summary>
        public static SystemInfoCpu Cpu { get; private set; }

        /// <summary>
        /// Operating system version information
        /// </summary>
        public static SystemInfoOperatingSystem CurOperatingSystem { get; private set; }

        static SystemInfo()
        {
            Cpu = new SystemInfoCpu();  
        }

        /// <summary>
        /// Acquires information about the engine Lightning is running on.
        /// </summary>
        public static void Load()
        {
            // cannot put in static constructor as this depends on SDL being initialised.
            // Initialise CPU info
            Cpu.GetInfo();

            long sysMemoryKiB;


            // detect various windows versions
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // detect each version of windows
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 1, 7600, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win7;
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 2, 9200, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win8;
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 3, 9600, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win81;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 10240, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win10TH1;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 10586, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win10TH2;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 14393, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win10RS1;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 15063, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win10RS2;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 16299, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win10RS3;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17134, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win10RS4;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win10RS5;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 18362, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1019H1;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 18363, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1019H2;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1020H1;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19042, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1020H2;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19043, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1021H1;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19044, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1021H2;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19045, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1022H2;
                // special case - was never released (but probably at least 1 person using it) so we use first compiled build (19480), 19480-19645 are valid
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19480, 0)) CurOperatingSystem = SystemInfoOperatingSystem.WinManganese;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 20348, 0)) CurOperatingSystem = SystemInfoOperatingSystem.WinIron;
                // earliest publicly available version
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 21996, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win11;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 22621, 0)) CurOperatingSystem = SystemInfoOperatingSystem.Win1122H2;
                // moving target so use earliest known build
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 25054, 0)) CurOperatingSystem = SystemInfoOperatingSystem.WinCopper;
                if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 25240, 0)) CurOperatingSystem = SystemInfoOperatingSystem.WinZinc;

                if (!PlatformWindows.GetPhysicallyInstalledSystemMemory(out sysMemoryKiB))
                {
                    // can't determine memory
                    Logger.LogError($"FAIL -- GetPhysicallyInstalledSystemMemory FAILED on win32 (error code {Marshal.GetLastWin32Error()}!)", 2000, LoggerSeverity.FatalError);
                }
                else
                {
                    SystemRam = sysMemoryKiB;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (OperatingSystem.IsMacOSVersionAtLeast(10, 13, 0)) CurOperatingSystem = SystemInfoOperatingSystem.MacOS1013;
                if (OperatingSystem.IsMacOSVersionAtLeast(10, 14, 0)) CurOperatingSystem = SystemInfoOperatingSystem.MacOS1014;
                if (OperatingSystem.IsMacOSVersionAtLeast(10, 15, 0)) CurOperatingSystem = SystemInfoOperatingSystem.MacOS1015;
                if (OperatingSystem.IsMacOSVersionAtLeast(11, 0, 0)) CurOperatingSystem = SystemInfoOperatingSystem.MacOS11;
                if (OperatingSystem.IsMacOSVersionAtLeast(12, 0, 0)) CurOperatingSystem = SystemInfoOperatingSystem.MacOS12;
                if (OperatingSystem.IsMacOSVersionAtLeast(13, 0, 0)) CurOperatingSystem = SystemInfoOperatingSystem.MacOS13;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) 
            {
                // detect all linuxes
                CurOperatingSystem = SystemInfoOperatingSystem.Linux;

                SysInfo sysinfo = new();

                if (PlatformLinux.sysinfo(out sysinfo) != 0)
                {
                    Logger.LogError($"FAIL -- sysinfo FAILED on linux (error code {Marshal.GetLastWin32Error()}!)", 2002, LoggerSeverity.FatalError);
                }
                else
                {
                    SystemRam = sysinfo.totalram;
                }
            }
            else
            {
                Logger.LogError($"FreeBSD or unknown unsupported platform ({RuntimeInformation.OSDescription})", 2001, LoggerSeverity.FatalError);
            }

            Logger.Log($"Total system RAM (KiB) = {SystemRam}");
            Logger.Log($"Operating system = {CurOperatingSystem}");
        }
    }
}
