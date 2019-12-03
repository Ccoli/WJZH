using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ProjectLog
{
    public class ProjectTraceListener : TraceListener
    {
        public string FilePath { get; private set; }
        private string categoryInfix = "";

        public ProjectTraceListener(string filePath)
        {
            if (filePath == null || filePath.Length == 0)
            {
                filePath = @"log\error.log";
            }
            FilePath = Path.GetFullPath(filePath);
            string dir = Path.GetDirectoryName(FilePath);
            if (dir.Length > 0)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }

        protected string GetFilePath()
        {
            string fileName = Path.GetFileNameWithoutExtension(FilePath);
            if (categoryInfix != null && categoryInfix != "")
            {
                fileName += "_" + categoryInfix;
            }
            fileName += DateTime.Now.ToString("_yyyy_MM_dd");
            fileName += Path.GetExtension(FilePath);
            return Path.Combine(Path.GetDirectoryName(FilePath), fileName);
        }

        public override void Write(string message)
        {
            File.AppendAllText(GetFilePath(), message);
        }

        public override void WriteLine(string message)
        {
            string content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss    ") + message + Environment.NewLine;
            File.AppendAllText(GetFilePath(), content);
        }

        public override void Write(object o, string category)
        {
            categoryInfix = category;

            string message = string.Empty;
            if (!string.IsNullOrEmpty(category))
            {
                message = category + ":";
            }

            if (o is Exception)//如果参数对象o是与Exception类兼容,输出异常消息+堆栈,否则输出o.ToString()
            {
                var ex = (Exception)o;
                message += ex.Message + Environment.NewLine;
                message += ex.StackTrace;
            }
            else if (null != o)
            {
                message += o.ToString();
            }

            WriteLine(message);

            categoryInfix = "";
        }

        public override void WriteLine(string message, string category)
        {
            categoryInfix = category;
            if (!string.IsNullOrEmpty(category))
            {
                message = category + ":" + message;
            }
            WriteLine(message);
            categoryInfix = "";
        }
    }
}
