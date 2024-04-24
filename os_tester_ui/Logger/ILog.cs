using System;

namespace os_tester_ui.Logger
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 日志输出级别。
        /// 当<see cref="Log(LogLevel, object, string, Exception)"/>的类型，在该设置之内时，才会真正输出日志。
        /// </summary>
        LogLevel LogLevel { get; set; }

        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Log(LogLevel logLevel, object source, string message, Exception exception);
    }
}
