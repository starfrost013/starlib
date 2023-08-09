
namespace Starlib.Utilities
{
    internal static class Logger2
    {
        internal static LoggerSettings2 Settings { get; set; }

        private static TextWriter Writer { get; set; }

        static Logger2()
        {
            Settings = new();
        }
    }
}
