using System;
using System.IO;
using System.Text;

namespace os_tester_ui.Logger
{
    public class FileLogger : LoggerBase, IDisposable
    {
        private readonly object m_lock = new object();
        private readonly string m_rootPath;
        private bool m_disposedValue;
        private FileStream m_fileStream;
        private StreamWriter m_streamWriter;
        private int m_maxSize = 1024 * 1024;

        public int MaxSize
        {
            get { return m_maxSize; }
            set { m_maxSize = value; }
        }

        public FileLogger(string rootPath = "logs")
        {
            if (rootPath == null)
            {
                throw new ArgumentNullException("rootPath");
            }
            this.m_rootPath = rootPath;
        }

        ~FileLogger()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposedValue)
            {
                if (disposing)
                {
                    if (m_streamWriter != null)
                    {
                        m_streamWriter.Dispose();
                        m_streamWriter = null;
                    }
                    if (m_fileStream != null)
                    {
                        m_fileStream.Dispose();
                        m_fileStream = null;
                    }
                }
                m_disposedValue = true;
            }
        }

        protected override void WriteLog(LogLevel logLevel, object source, string message, Exception exception)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff"));
            stringBuilder.Append(" | ");
            stringBuilder.Append(logLevel.ToString());
            stringBuilder.Append(" | ");
            stringBuilder.Append(message);

            if (exception != null)
            {
                stringBuilder.Append(" | ");
                stringBuilder.Append("【异常消息】：" + exception.Message);
                stringBuilder.Append("【堆栈】：" + (exception == null ? "未知" : exception.StackTrace));
            }
            stringBuilder.AppendLine();

            Print(stringBuilder.ToString());
        }

        private void Print(string logString)
        {
            try
            {
                lock (m_lock)
                {
                    if (m_streamWriter == null)
                    {
                        var dir = Path.Combine(m_rootPath, DateTime.Now.ToString("[yyyy-MM-dd]"));
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var count = 0;
                        string path = null;
                        while (true)
                        {
                            path = Path.Combine(dir, count.ToString("0000") + ".log");
                            if (!File.Exists(path))
                            {
                                m_fileStream = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
                                m_streamWriter = new StreamWriter(m_fileStream, Encoding.UTF8);
                                break;
                            }
                            count++;
                        }
                    }
                    m_streamWriter.Write(logString);
                    m_streamWriter.Flush();
                    if (m_fileStream.Length > MaxSize)
                    {
                        m_streamWriter.Dispose();
                        m_fileStream.Dispose();
                        m_streamWriter = null;
                        m_fileStream = null;
                    }
                }
            }
            catch
            {
                if (m_streamWriter != null)
                {
                    m_streamWriter.Dispose();
                    m_streamWriter = null;
                }
                if (m_fileStream != null)
                {
                    m_fileStream.Dispose();
                    m_fileStream = null;
                }
            }
        }
    }
}
