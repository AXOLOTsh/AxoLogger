using Spectre.Console;

namespace AxoLogger {
    public delegate void onLogDelegate(Log log);
    public class Logger {
        public event onLogDelegate onLog;
        public string Name { get; private set; }
        public IReadOnlyList<Log> Logs => _logs;
        private List<Log> _logs = new List<Log>();

        public Logger() { }
        public Logger(string name, bool useDefaultLogger = true) {
            Name = name;
            if (useDefaultLogger) {
                onLog += DefaultLogger;
            }
        }

        public Log Log(string message, LogLevel level = LogLevel.Info) {
            var log = new Log(message, Name, level);
            Log(log);
            return log;
        }
        public void Log(Log log) => onLog.Invoke(log);

        public static void DefaultLogger(Log log) {
            AnsiConsole.MarkupLine(log.GetFullLogMessage());
        }
    }
}
