using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sample.Core.Log
{
    public class CustomLogger : ILogger
    {
        private class LogItem
        {
            internal string Msg { get; set; }
            internal LogTypeEnum LogType { get; set; }
        }

        private enum LogTypeEnum
        {
            Info,
            Warning,
            Fatal,
            Error
        }

        private static System.Collections.Concurrent.ConcurrentQueue<LogItem> QueueMsgs = new System.Collections.Concurrent.ConcurrentQueue<LogItem>();

        static CustomLogger()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, typeof(CustomLogger).Name);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<string> dirs = typeof(LogTypeEnum).GetEnumNames().ToList();
            dirs.Select(x => Path.Combine(path, x)).ToList().ForEach(x =>
            {
                if (!Directory.Exists(x))
                {
                    Directory.CreateDirectory(x);
                }
            });
            Task.Factory.StartNew(() =>
            {
                if (QueueMsgs.Any())
                {
                    LogItem item;
                    QueueMsgs.TryDequeue(out item);
                    if (item != null)
                    {
                        string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                        string logPath = Path.Combine(path, item.LogType.ToString(), fileName);
                        File.AppendAllText(logPath, item.Msg);
                    }
                }
                else
                {
                    Task.Delay(TimeSpan.FromSeconds(10)).Wait();
                }
            }, TaskCreationOptions.LongRunning);
        }

        private static string LogTemplate(string msg, Exception exp = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"----------{0}------------ \r\n", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
            sb.AppendFormat(@"当前异常消息：{0}", msg);
            if (exp != null)
            {
                sb.AppendFormat(@"当前内部异常消息:{0},当前堆栈信息：{1}", exp.Message ?? string.Empty, exp.StackTrace ?? string.Empty);
            }
            sb.AppendLine("----------------------------------------");
            sb.AppendLine();
            return sb.ToString();
        }

        public void Error(string message)
        {
            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Error,
                Msg = LogTemplate(message)
            });
        }

        public void Error(string message, Exception innerException)
        {
            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Error,
                Msg = LogTemplate(message, innerException)
            });
        }

        public void Fatal(string message)
        {
            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Fatal,
                Msg = LogTemplate(message)
            });
        }

        public void Fatal(string message, Exception innerException)
        {
            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Fatal,
                Msg = LogTemplate(message, innerException)
            });
        }

        public void Info(string message)
        {
            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Info,
                Msg = LogTemplate(message)
            });
        }

        public void Info(string message, Exception innerException)
        {
            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Info,
                Msg = LogTemplate(message, innerException)
            });
        }

        public void Warning(string message)
        {
            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Warning,
                Msg = LogTemplate(message)
            });
        }

        public void Warning(string message, Exception innerException)
        {

            QueueMsgs.Enqueue(new LogItem()
            {
                LogType = LogTypeEnum.Warning,
                Msg = LogTemplate(message, innerException)
            });
        }
    }
}
