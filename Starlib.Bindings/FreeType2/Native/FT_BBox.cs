using FT_Pos = System.IntPtr;

namespace Starlib.Bindings
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FT_BBox
    {
        public FT_Pos xMin, yMin;
        public FT_Pos xMax, yMax;
    }
}
