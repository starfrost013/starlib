﻿namespace Starlib.Bindings
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_CharMapRec
    {
        public FT_FaceRec* face;
        public FT_Encoding encoding;
        public ushort platform_id;
        public ushort encoding_id;
    }
}
