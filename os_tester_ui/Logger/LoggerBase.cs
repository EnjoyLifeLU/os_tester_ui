using System;

namespace os_tester_ui.Logger
{
    /// <summary>
    /// 日志基类
    /// </summary>
    public abstract class LoggerBase : ILog
    {
        private LogLevel logLevel = LogLevel.Debug;

        /// <inheritdoc/>
        public LogLevel LogLevel
        {
            get { return logLevel; }
            set { logLevel = value; }
        }

        /// <inheritdoc/>
        public void Log(LogLevel logLevel, object source, string message, Exception exception)
        {
            if (logLevel < this.LogLevel)
            {
                return;
            }
            this.WriteLog(logLevel, source, message, exception);
        }

        /// <summary>
        /// 筛选日志后输出
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        protected abstract void WriteLog(LogLevel logLevel, object source, string message, Exception exception);
    }
}
