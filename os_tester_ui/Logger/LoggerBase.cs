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

    /// <summary>
    /// 日志类型。
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 更为详细的步骤型日志输出
        /// </summary>
        Trace = 0,

        /// <summary>
        /// 调试信息日志
        /// </summary>
        Debug = 1,

        /// <summary>
        /// 消息类日志输出
        /// </summary>
        Info = 2,

        /// <summary>
        /// 警告类日志输出
        /// </summary>
        Warning = 3,

        /// <summary>
        /// 错误类日志输出
        /// </summary>
        Error = 4,

        /// <summary>
        /// 不可控中断类日输出
        /// </summary>
        Critical = 5,

        /// <summary>
        /// 不使用日志类输出
        /// </summary>
        None = 6,
    }
}
