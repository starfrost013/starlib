namespace Starlib.Utilities
{
    [Flags]
    /// <summary>
    /// SystemInfoCpuCapabilities
    /// 
    /// Enumerates CPU capabilities.
    /// </summary>
    public enum SystemInfoCpuCapabilities 
    {
        // MMX, 3DNow, RDTSC: CPUs with these can't hope to run our apps

        /// <summary>
        /// x86/64: This system supports the SSE instruction set.
        /// </summary>
        SSE = 0x1,

        /// <summary>
        /// x86/64: This system supports the SSE2 instruction set.
        /// </summary>
        SSE2 = 0x2,

        /// <summary>
        /// x86/64: This system supports the SSE3 instruction set.
        /// </summary>
        SSE3 = 0x4,

        /// <summary>
        /// x86/64: This system supports the SSSE3 instruction set.
        /// </summary>
        SSSE3 = 0x8,

        /// <summary>
        /// x86/64: This system supports the SSE4 & SSE4.1 instruction set.
        /// </summary>
        SSE41 = 0x10,

        /// <summary>
        /// x86/64: This system supports the SSE4.2 instruction set.
        /// </summary>
        SSE42 = 0x20,

        /// <summary>
        /// x86/64: This system supports the AVX instruction set.
        /// </summary>
        AVX = 0x40,

        /// <summary>
        /// x86/64: This system supports the FMA instruction set.
        /// </summary>
        FMA = 0x80,

        /// <summary>
        /// x86/64: This system supports the AVX2 instruction set.
        /// </summary>
        AVX2 = 0x100,

        /// <summary>
        /// x86/64: This system supports the BMI1 instruction set.
        /// </summary>
        BMI1 = 0x200,

        /// <summary>
        /// x86/64: This system supports the BMI2 instruction set.
        /// </summary>
        BMI2 = 0x400,

        /// <summary>
        /// x86/64: This system supports the POPCNT instruction.
        /// </summary>
        POPCNT = 0x800,

        /// <summary>
        /// x86/64: This system supports the PCLMULQDQ instruction.
        /// </summary>
        PCLMULQDQ = 0x1000,

        /// <summary>
        /// x86/64: This system supports the PCLMULQDQ instruction.
        /// </summary>
        LZCNT = 0x2000,

        /// <summary>
        /// x86/64: This system supports the Intel AES instruction set.
        /// </summary>
        AES = 0x4000,

        /// <summary>
        /// ARM64: This system supports ARM SIMD instructions.
        /// </summary>
        ARMSIMD = 0x8000,

        /// <summary>
        /// ARM64: This system supports ARM CRC32 instructions.
        /// </summary>
        ARMCRC32 = 0x10000,

        /// <summary>
        /// ARM64: This system supports ARM SHA1 instructions.
        /// </summary>
        ARMSHA1 = 0x20000,

        /// <summary>
        /// ARM64: This system supports ARM SHA256 instructions.
        /// </summary>
        ARMSHA256 = 0x40000,

        /// <summary>
        /// ARM64: This system supports ARM AES instructions.
        /// </summary>
        ARMAES = 0x80000,

        /// <summary>
        /// ARM64: This system supports ARM dot product instructions.
        /// </summary>
        ARMDP = 0x100000,

        /// <summary>
        /// ARM64: This system supports ARM RDM product instructions.
        /// </summary>
        ARMRDM = 0x200000,

#if NET8_0_OR_GREATER

        /// <summary>
        /// x86/64: This system supports the AVX512 F (Foundation) instruction set.
        /// </summary>
        AVX512_F = 0x400000,
        
        /// <summary>
        /// x86/64: This system supports the AVX512 VL (Vector Length) instruction set.
        /// </summary>
        AVX512_VL = 0x800000,

        /// <summary>
        /// x86/64: This system supports the AVX512 BW (Byte and Word) instruction set.
        /// </summary>
        AVX51BW = 0x1000000,

        /// <summary>
        /// x86/64: This system supports the AVX512 CD (Conflict Detection) instruction set.
        /// </summary>
        AVX512CD = 0x2000000,

        /// <summary>
        /// x86/64: This system supports the AVX512 DQ (Doubleword and Quadword) instruction set.
        /// </summary>
        AVX512DQ = 0x4000000,

        /// <summary>
        /// x86/64: This system supports the AVX512 VBMI (vector byte manipulation instructions) instruction set.
        /// </summary>
        AVX512VBMI = 0x8000000,

#endif

        /// <summary>
        /// x86/64: This system supports the AVX512 VNNI (Vector Neural Network Extensions) instruction set.
        /// </summary>
        AVX512VNNI = 0x10000000,
    }
}
