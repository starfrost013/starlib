﻿namespace Starlib.Base
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_ListRec
    {
        public nint head;
        public nint tail;
    }
}
