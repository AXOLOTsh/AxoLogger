namespace AxoLogger {
    /// <summary>
    /// Represents the log severity level.
    /// </summary>
    public enum LogLevel { Info, Debug, Error, Warning }
    /// <summary>
    /// Represents the implementation of the simplest log.
    /// </summary>
    public class Log {
        /// <summary>
        /// Returns the log message.
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Returns the name of the log creator.
        /// </summary>
        public string Sender { get; private set; }
        /// <summary>
        /// Returns the log severity level.
        /// </summary>
        public LogLevel Level { get; private set; }
        /// <summary>
        /// Returns the time the log was created.
        /// </summary>
        public DateTime CreationTime { get; private set; }

        public Log() { }
        /// <param name="name">Log message.</param>
        /// <param name="sender">Name of the log creator.</param>
        /// <param name="level">Log severity level.</param>
        public Log(string name, string sender = "", LogLevel level = LogLevel.Info) {
            Message = name;
            Sender = sender;
            Level = level;

            CreationTime = DateTime.Now;
        }
        /// <returns>Full log message</returns>
        public override string ToString() => GetFullLogMessage();
        /// <returns>Full log message</returns>
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
