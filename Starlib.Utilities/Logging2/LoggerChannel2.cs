
namespace Starlib.Utilities
{
    [Flags]
    /// <summary>
    /// LoggerChannel
    /// 
    /// Enumerates logging channels.
    /// </summary>
    public enum LoggerChannel2
    {
        Message = 0x1,

        Warning = 0x2,

        Error = 0x4,

        Fatal = 0x8,

        Debug = 0x10,

        AllNoRelease = (Message | Warning | Error | Fatal),

        All = (Message | Warning | Error | Fatal | Debug),
    }
}
