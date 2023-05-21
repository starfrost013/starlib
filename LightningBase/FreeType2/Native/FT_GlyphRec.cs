﻿namespace Starlib.Base
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_GlyphRec
    {
        public FT_LibraryRec* library;
        public nint clazz;
        public FT_Glyph_Format format;
        public FT_Vector advance;
    }
}
