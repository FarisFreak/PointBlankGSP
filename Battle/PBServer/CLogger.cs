using System;
using System.IO;
using System.Net;

namespace PBServer
{
    public class CLogger
    {
        private static CLogger _instance;

        private static bool cf = true;

        private string name = "Logs//" + DateTime.Now.ToString("HH-mm-ss-dd-MM-yyyy") + ".log";

        public CLogger()
        {
            this.form();
        }

        public void form()
        {
            bool flag = CLogger.cf && !Directory.Exists("Logs");
            if (flag)
            {
                Directory.CreateDirectory("Logs");
            }
        }

        public void error(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(this.name, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void extra_info(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(this.name, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void console(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(this.name, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void white(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void yellow(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void info(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(this.name, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void write(string text)
        {
            try
            {
                Console.ResetColor();
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(this.name, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + "> " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public static CLogger getInstance()
        {
            bool flag = CLogger._instance == null;
            if (flag)
            {
                CLogger._instance = new CLogger();
            }
            return CLogger._instance;
        }

        public void warning(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(this.name, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void black(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void debug(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void sendpacket(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void packet(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void blue(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void cyan(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void dark_blue(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void dark_cyan(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void dark_gray(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void dark_green(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void dark_magenta(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void dark_red(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void dark_yellow(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void gray(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void green(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void magenta(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public void red(string text)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
                bool flag = CLogger.cf;
                if (flag)
                {
                    FileStream fileStream = new FileStream(null, FileMode.Append);
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
                    streamWriter.Close();
                    fileStream.Close();
                }
                Console.ResetColor();
            }
            catch
            {
            }
        }

        public bool isConnectadURL(string url)
        {
            Uri requestUri = new Uri(url);
            WebRequest webRequest = WebRequest.Create(requestUri);
            bool result;
            try
            {
                webRequest.GetResponse().Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
