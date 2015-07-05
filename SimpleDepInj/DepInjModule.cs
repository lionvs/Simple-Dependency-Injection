using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace SimpleDepInj
{
    public class DepInjModule : NinjectModule
    {
        public override void Load()
        {
            // Get this from an external file.
            //
            const string logFile = @"LogFile.txt";

            //Bind<ILogger>().To<ConsoleLogger>();
            //Bind<ILogger>().To<FileLogger>().WithConstructorArgument("filePath", logFile);
            Bind<ILogger>().To<CombinedLogger>().WithConstructorArgument("filePath", logFile);
        }
    }
}
