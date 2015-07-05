using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDepInj
{
    public class FileLogger:ILogger
    {
        private string file;
        public FileLogger(string filePath)
        {
            file = filePath;
        }
        public void Log(string message)
        {
            using (var stream = new StreamWriter(file, true))
            {
                stream.WriteLine(message);
            }
        }
    }
}
