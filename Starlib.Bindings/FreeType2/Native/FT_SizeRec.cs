﻿namespace Starlib.Bindings
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_SizeRec
    {
        public FT_FaceRec* face;
        public FT_Generic generic;
        public FT_Size_Metrics metrics;
        public nint @internal;
    }
}
