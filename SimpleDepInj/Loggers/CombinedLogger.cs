using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDepInj
{
    public class CombinedLogger:ILogger
    {
        private List<ILogger> listLoggers;

        public CombinedLogger(string filePath)
        {
            listLoggers = new List<ILogger>();
            listLoggers.Add(new ConsoleLogger());
            listLoggers.Add(new FileLogger(filePath));
        }
        public void Log(string message)
        {
            foreach (var logger in listLoggers)
            {
                logger.Log(message);
            }
        }
    }
}
