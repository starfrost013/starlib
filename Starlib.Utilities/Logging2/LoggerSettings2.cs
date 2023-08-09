
namespace Starlib.Utilities
{
    /// <summary>
    /// LoggerSettings
    /// 
    /// Holds logger settings.
    /// </summary>
    public class LoggerSettings2
    {
        public LoggerChannel2 EnabledChannels { get; set; }

        public LoggerDestination2 Destinations { get; set; }

        public bool KeepOldLogs { get; set; }

        public string LogDateFormat { get; set; }

        #region Defaults

        private const string DEFAULT_LOG_DATE_FORMAT = "yyyy-MM-dd hh:MM:ss";

        #endregion

        public LoggerSettings2()
        {
            LogDateFormat = DEFAULT_LOG_DATE_FORMAT;    
        }
    }
}
