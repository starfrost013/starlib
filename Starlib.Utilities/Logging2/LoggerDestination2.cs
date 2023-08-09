
namespace Starlib.Utilities
{
    /// <summary>
    /// LoggerDestination
    /// 
    /// Enumerates logging destinations
    /// </summary>
    [Flags]
    public enum LoggerDestination2
    {
        Console = 0x1,

        File = 0x2,

        All = (Console | File),
    }
}
