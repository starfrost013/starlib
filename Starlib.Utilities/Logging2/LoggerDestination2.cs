
namespace Starlib.Utilities
{
    /// <summary>
    /// LoggerDestination
    /// 
    /// Enumerates logging destinations
    /// </summary>
    [Flags]
    internal enum LoggerDestination2
    {
        Console = 0x1,

        File = 0x2,

        All = (Console | File),
    }
}
