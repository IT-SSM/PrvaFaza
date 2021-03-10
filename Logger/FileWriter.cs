using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQLModifications.Logger
{
    public class FileWriter
    {
        public string Filepath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".log";
        private Object locker = new Object();
        
        public async Task WriteToFile(string text)
        {
            //MaxLength(Filepath);
            int timeOut = 1000;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (true)
            {
                try
                {
                    string timestamp = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss.fff");
                    //Wait for resource to be free
                    lock (locker)
                    {
                        using (FileStream file = new FileStream(Filepath, FileMode.Append, FileAccess.Write, FileShare.Read))
                        using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                        {
                            writer.Write(timestamp + " : " + text + "\n");
                        }
                    }
                    break;
                }
                catch
                {
                    //File not available, conflict with other class instances or application
                }
                if (stopwatch.ElapsedMilliseconds > timeOut)
                {
                    //Give up.
                    break;
                }
                //Wait and Retry
                await Task.Delay(5);
            }
            stopwatch.Stop();
        }

        public bool MaxLength(string fileName)
        {
            double len = new FileInfo(fileName).Length;
            if ((len / 1024) >= 5000)
            {
                DateTime time = DateTime.Now;
                string format = "ddMMHHmmss";
                string fileNameNew = fileName.Substring(0, fileName.Length - 4) + "_" + time.ToString(format) + ".txt";
                File.Move(fileName, fileNameNew);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
