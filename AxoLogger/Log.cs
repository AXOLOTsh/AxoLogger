namespace AxoLogger {
    public enum LogLevel { Info, Debug, Error, Warning }
    public class Log {
        public string Message { get; private set; }
        public string Sender { get; private set; }
        public LogLevel Level { get; private set; }
        public DateTime CreationTime { get; private set; }

        public Log() { }
        public Log(string log, string sender = "", LogLevel level = LogLevel.Info) {
            Message = log;
            Sender = sender;
            Level = level;

            CreationTime = DateTime.Now;
        }

        public override string ToString() => GetFullLogMessage();

        public string GetFullLogMessage() => $"[green]{CreationTime}[/] - {GetLogLevelString()} [gray]{GetSender()}:[/] {Message}";

        private string GetSender() {
            if (Sender != "")
                return $"({Sender})";
            return "";
        }
        private string GetLogLevelString() => GetLogLevelColorString(GetLogLevelName());
        private string GetLogLevelColorString(string content) => $"[{GetLogLevelColor()}][[{content}]][/]";
        private string GetLogLevelColor() {
            switch (Level) {
                case LogLevel.Info: return "blue";
                case LogLevel.Debug: return "fuchsia";
                case LogLevel.Error: return "red";
                case LogLevel.Warning: return "yellow";
            }
            return "";
        }
        private string GetLogLevelName() {
            switch (Level) {
                case LogLevel.Info: return "Info";
                case LogLevel.Debug: return "Debug";
                case LogLevel.Error: return "Error";
                case LogLevel.Warning: return "Warning";
            }
            return "Unknown";
        }
    }
}
