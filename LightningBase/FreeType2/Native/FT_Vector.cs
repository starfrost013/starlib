namespace Starlib.Base
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FT_Vector
    {
        public nint x;
        public nint y;
    }
}
