﻿namespace Starlib.Utilities
{
    /// <summary>
    /// SystemInfoCpu
    /// 
    /// Provides CPU information.
    /// </summary>
    public class SystemInfoCpu
    {
        /// <summary>
        /// Number of hardware threads on this CPU.
        /// </summary>
        public int Threads { get; private set; }

        /// <summary>
        /// The name of this CPU.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Processor architecture of this CPU
        /// </summary>
        public Architecture SystemArchitecture { get; private set; }

        /// <summary>
        /// Processor architecture of the engine.
        /// This may differ on Windows 11 and Rosetta2 for example
        /// (or if the engine ever has a wasm version)
        /// </summary>
        public Architecture ProcessArchitecture { get; private set; }

        /// <summary>
        /// Processor capabilities. See <see cref="SystemInfoCpuCapabilities"/>.
        /// </summary>
        public SystemInfoCpuCapabilities Capabilities { get; private set; }

        private readonly StringBuilder StringBuilder = new StringBuilder();

        public SystemInfoCpu()
        {
            Name = "Unidentified";
        }

        [RequiresPreviewFeatures]
        /// <summary>
        /// Acquires CPU information
        /// </summary>
        internal void GetInfo()
        {
            Logger.Log("Acquiring CPU information...");
            Threads = Environment.ProcessorCount;
            Logger.Log($"Number of hardware threads = {Threads}");

            // get process architecture and system architecture
            SystemArchitecture = RuntimeInformation.OSArchitecture;
            ProcessArchitecture = RuntimeInformation.ProcessArchitecture;

            Logger.Log($"{ProcessArchitecture} engine, running on {SystemArchitecture} system");

            // processor specific stuff

            if (ProcessArchitecture == Architecture.X64)
            {
                Logger.Log($"Using x86 CPU, so using CPUID intrinsics to get CPU name...");

                // -2147483648 = 0x8000000
                // for some reason this API uses an int, it should use uint 
                ValueTuple<int, int, int, int> regs = X86Base.CpuId(-2147483648, 0);

                if ((uint)regs.Item1 < 0x80000004) // CPUID Processor Brand Identification supported
                {
                    Name = "***NOT AVAILABLE - X86 CPU TOO OLD***";
                }
                else
                {
                    // 0x80000002-0x80000004
                    // Processor Brand Identification
                    ValueTuple<int, int, int, int> cpuNamePart1 = X86Base.CpuId(-2147483646, 0);
                    ValueTuple<int, int, int, int> cpuNamePart2 = X86Base.CpuId(-2147483645, 0);
                    ValueTuple<int, int, int, int> cpuNamePart3 = X86Base.CpuId(-2147483644, 0);

                    // copy to string
                    // default tostring not sufficient for our needs

                    // and this is a valuetuple so...

                    StringBuilder.Append((char)(cpuNamePart1.Item1 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item1 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item1 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item1 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart1.Item2 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item2 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item2 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item2 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart1.Item3 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item3 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item3 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item3 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart1.Item4 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item4 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item4 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart1.Item4 >> 24) & 0xFF));

                    StringBuilder.Append((char)(cpuNamePart2.Item1 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item1 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item1 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item1 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart2.Item2 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item2 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item2 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item2 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart2.Item3 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item3 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item3 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item3 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart2.Item4 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item4 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item4 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart2.Item4 >> 24) & 0xFF));

                    StringBuilder.Append((char)(cpuNamePart3.Item1 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item1 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item1 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item1 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart3.Item2 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item2 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item2 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item2 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart3.Item3 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item3 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item3 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item3 >> 24) & 0xFF));
                    StringBuilder.Append((char)(cpuNamePart3.Item4 & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item4 >> 8) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item4 >> 16) & 0xFF));
                    StringBuilder.Append((char)((cpuNamePart3.Item4 >> 24) & 0xFF));

                    Name = StringBuilder.ToString();

                    if (Sse.IsSupported) Capabilities |= SystemInfoCpuCapabilities.SSE;
                    if (Sse2.IsSupported) Capabilities |= SystemInfoCpuCapabilities.SSE2;
                    if (Sse3.IsSupported) Capabilities |= SystemInfoCpuCapabilities.SSE3;
                    if (Ssse3.IsSupported) Capabilities |= SystemInfoCpuCapabilities.SSSE3;
                    if (Sse41.IsSupported) Capabilities |= SystemInfoCpuCapabilities.SSE41;
                    if (Sse42.IsSupported) Capabilities |= SystemInfoCpuCapabilities.SSE42;
                    if (Avx.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX;
                    if (Avx2.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX2;
                    if (Fma.IsSupported) Capabilities |= SystemInfoCpuCapabilities.FMA;
                    if (Bmi1.IsSupported) Capabilities |= SystemInfoCpuCapabilities.BMI1;
                    if (Bmi2.IsSupported) Capabilities |= SystemInfoCpuCapabilities.BMI2;
                    if (Lzcnt.IsSupported) Capabilities |= SystemInfoCpuCapabilities.LZCNT;
                    if (Popcnt.IsSupported) Capabilities |= SystemInfoCpuCapabilities.POPCNT;
                    if (Pclmulqdq.IsSupported) Capabilities |= SystemInfoCpuCapabilities.PCLMULQDQ;
                    if (System.Runtime.Intrinsics.X86.Aes.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AES;

#if NET8_0_OR_GREATER
                    if (Avx512F.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX512F;
                    // just check once for these, if BW isn't supported BW-VL won't be
                    if (Avx512F.VL.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX512VL;
                    if (Avx512BW.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX512BW;
                    if (Avx512CD.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX512CD;
                    if (Avx512DQ.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX512DQ;
                    if (Avx512Vbmi.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX512Vbmi;
#endif

                    if (AvxVnni.IsSupported) Capabilities |= SystemInfoCpuCapabilities.AVX512VNNI;
                }
            }
            else
            {
                Name = "***NOT AVAILABLE ON ARM CPUs (no CPU ID capability in .NET for ARM)***";

                if (AdvSimd.IsSupported) Capabilities |= SystemInfoCpuCapabilities.ARMSIMD;
                if (Crc32.IsSupported) Capabilities |= SystemInfoCpuCapabilities.ARMCRC32;
                if (Sha1.IsSupported) Capabilities |= SystemInfoCpuCapabilities.ARMSHA1;
                if (Sha256.IsSupported) Capabilities |= SystemInfoCpuCapabilities.ARMSHA256;
                if (System.Runtime.Intrinsics.Arm.Aes.IsSupported) Capabilities |= SystemInfoCpuCapabilities.ARMAES;
                if (Dp.IsSupported) Capabilities |= SystemInfoCpuCapabilities.ARMDP;
                if (Rdm.IsSupported) Capabilities |= SystemInfoCpuCapabilities.ARMRDM;
            }

            // filter out /0 characters (as CPUID puts C terminated strings into registers)
            Name = Name.Replace("\0", "");
            Name = Name.Trim();

            Logger.Log($"CPU Name: {Name}");
            Logger.Log("CPU Capabilities: ");
            Logger.Log(Capabilities.ToString());
        }
    }
}
