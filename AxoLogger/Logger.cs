using Spectre.Console;

namespace AxoLogger {
    /// <summary>
    /// Log creation event delegate
    /// </summary>
    /// <param name="log">Created log</param>
    public delegate void onLogDelegate(Log log);
    /// <summary>
    /// Represents Logger
    /// </summary>
    public class Logger {
        /// <summary>
        /// Event triggered when a log is created
        /// </summary>
        public event onLogDelegate onLog;
        /// <summary>
        /// Returns the name of the log creator, automatically assigned to logs when used unless otherwise specified.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Returns a list of logs
        /// </summary>
        public IReadOnlyList<Log> Logs => _logs;
        private List<Log> _logs = new List<Log>();

        public Logger() { }
        /// <param name="name">Name of the log creator, automatically assigned to logs when used unless otherwise specified.</param>
        /// <param name="useDefaultLogger">If true assigns the onLoad event to the default event handler.</param>
        public Logger(string name, bool useDefaultLogger = true) {
            Name = name;
            if (useDefaultLogger) {
                onLog += DefaultLogger;
            }
        }

        /// <summary>
        /// Creates a log.
        /// </summary>
        /// <param name="message">Log message.</param>
        /// <param name="level">Log severity level.</param>
        /// <param name="sender">Name of the log creator.</param>
        public void Log(string message, LogLevel level = LogLevel.Info, string sender = "") {
            if (sender == "")
                sender = Name;
            Log(new Log(message, sender, level));
        }
        /// <summary>
        /// Creates a log.
        /// </summary>
        /// <param name="log">Log.</param>
        public void Log(Log log) => onLog.Invoke(log);

        public static void DefaultLogger(Log log) {
            AnsiConsole.MarkupLine(log.GetFullLogMessage());
        }
    }
}
