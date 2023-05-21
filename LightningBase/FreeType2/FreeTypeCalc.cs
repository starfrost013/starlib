﻿namespace Starlib.Bindings
{
    /// <summary>
    /// Contains utility methods for converting FreeType2 data types to CLR data types, and vice versa.
    /// </summary>
    public static class FreeTypeCalc
    {
        /// <summary>
        /// Converts a <see cref="System.Int32"/> value to FreeType2 26.6 fixed point value.
        /// </summary>
        /// <param name="x">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static Int32 Int32ToF26Dot6(Int32 x) { return x * 64; }

        /// <summary>
        /// Converts a FreeType 26.6 fixed point value to a <see cref="System.Int32"/> value.
        /// </summary>
        /// <param name="x">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static Int32 F26Dot6ToInt32(Int32 x) { return x / 64; }

        /// <summary>
        /// Converts a FreeType 26.6 fixed point value to a <see cref="System.Int32"/> value.
        /// </summary>
        /// <param name="x">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static Int32 F26Dot6ToInt32(Int64 x) { return (Int32)(x / 64L); }
    }
}
