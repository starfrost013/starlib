﻿using FT_Fixed = System.IntPtr;
using FT_Pos = System.IntPtr;

namespace Starlib.Bindings
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_GlyphSlotRec
    {
        public nint library;
        public FT_FaceRec* face;
        public FT_GlyphSlotRec* next;
        public uint reserved;
        public FT_Generic generic;

        public FT_Glyph_Metrics metrics;
        public FT_Fixed linearHoriAdvance;
        public FT_Fixed linearVertAdvance;
        public FT_Vector advance;

        public FT_Glyph_Format format;

        public FT_Bitmap bitmap;
        public int bitmap_left;
        public int bitmap_top;

        public FT_Outline outline;

        public uint num_subglyphs;
        public FT_SubGlyphRec* subglyphs;

        public nint control_data;
        public FT_Fixed control_len;

        public FT_Pos lsb_delta;
        public FT_Pos rsb_delta;

        public nint other;

        public nint @internal;
    }
}
