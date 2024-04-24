using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace os_tester_ui.Logger
{
    public static class LoggerExtensions
    {
        #region 日志

        /// <summary>
        /// 输出中断日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        public static void Critical(this ILog logger, string msg)
        {
            logger.Log(LogLevel.Critical, null, msg, null);
        }

        /// <summary>
        /// 输出调试日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        public static void Debug(this ILog logger, string msg)
        {
            logger.Log(LogLevel.Debug, null, msg, null);
        }

        /// <summary>
        /// 输出错误日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        public static void Error(this ILog logger, string msg)
        {
            logger.Log(LogLevel.Error, null, msg, null);
        }

        /// <summary>
        /// 输出错误日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="source"></param>
        /// <param name="msg"></param>
        public static void Error(this ILog logger, object source, string msg)
        {
            logger.Log(LogLevel.Error, source, msg, null);
        }

        /// <summary>
        /// 输出异常日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="ex"></param>
        public static void Exception(this ILog logger, Exception ex)
        {
            logger.Log(LogLevel.Error, null, ex.Message, ex);
        }

        /// <summary>
        /// 输出异常日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="source"></param>
        /// <param name="ex"></param>
        public static void Exception(this ILog logger, object source, Exception ex)
        {
            logger.Log(LogLevel.Error, source, ex.Message, ex);
        }

        /// <summary>
        /// 输出异常日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="source"></param>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Exception(this ILog logger, object source, string msg, Exception ex)
        {
            logger.Log(LogLevel.Error, source, msg, ex);
        }

        /// <summary>
        /// 输出消息日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        public static void Info(this ILog logger, string msg)
        {
            logger.Log(LogLevel.Info, null, msg, null);
        }

        /// <summary>
        /// 输出消息日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="source"></param>
        /// <param name="msg"></param>
        public static void Info(this ILog logger, object source, string msg)
        {
            logger.Log(LogLevel.Info, source, msg, null);
        }

        /// <summary>
        /// 输出详细日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        public static void Trace(this ILog logger, string msg)
        {
            logger.Log(LogLevel.Trace, null, msg, null);
        }

        /// <summary>
        /// 输出警示日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="msg"></param>
        public static void Warning(this ILog logger, string msg)
        {
            logger.Log(LogLevel.Warning, null, msg, null);
        }

        /// <summary>
        /// 输出警示日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="source"></param>
        /// <param name="msg"></param>
        public static void Warning(this ILog logger, object source, string msg)
        {
            logger.Log(LogLevel.Warning, source, msg, null);
        }

        #endregion 日志
    }
}
