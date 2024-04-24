using System;

namespace os_tester_ui.Logger
{
    /// <summary>
    /// 控制台日志记录器
    /// </summary>
    public class ConsoleLogger : LoggerBase
    {
        static ConsoleLogger()
        {
            Default = new ConsoleLogger();
        }

        private readonly ConsoleColor m_consoleBackgroundColor;
        private readonly ConsoleColor m_consoleForegroundColor;

        public ConsoleLogger()
        {
            this.m_consoleForegroundColor = Console.ForegroundColor;
            this.m_consoleBackgroundColor = Console.BackgroundColor;
        }

        /// <summary>
        /// 默认的实例
        /// </summary>
        public static ConsoleLogger Default { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        protected override void WriteLog(LogLevel logLevel, object source, string message, Exception exception)
        {
            lock (typeof(ConsoleLogger))
            {
                Console.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff"));
                Console.Write(" | ");
                switch (logLevel)
                {
                    case LogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case LogLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    case LogLevel.Info:
                    default:
                        Console.ForegroundColor = this.m_consoleForegroundColor;
                        break;
                }
                Console.Write(logLevel.ToString());
                Console.ForegroundColor = this.m_consoleForegroundColor;
                Console.Write(" | ");
                Console.Write(message);

                if (exception != null)
                {
                    Console.Write(" | ");
                    Console.Write("【异常消息】：" + exception.Message);
                    Console.Write("【堆栈】：" + (exception == null ? "未知" : exception.StackTrace));
                }
                Console.WriteLine();

                Console.ForegroundColor = this.m_consoleForegroundColor;
                Console.BackgroundColor = this.m_consoleBackgroundColor;
            }
        }
    }
}
