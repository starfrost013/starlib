﻿namespace Starlib.Bindings
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Bitmap
    {
        public UInt32 rows;
        public UInt32 width;
        public Int32 pitch;
        public nint buffer;
        public UInt16 num_grays;
        public FT_Pixel_Mode pixel_mode;
        public Byte palette_mode;
        public nint palette;
    }
}
