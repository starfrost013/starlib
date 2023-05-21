﻿namespace Starlib.Bindings
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public unsafe delegate void FT_Generic_Finalizer(nint @object);
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Generic
    {
        public nint data;
        public nint finalizer;
    }
}
