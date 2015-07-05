using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace SimpleDepInj
{
    class Program
    {
        static string url = @"http://dou.ua";
        static void Main(string[] args)
        {
            NinjectModule module = new DepInjModule();
            IKernel kernel = new StandardKernel(module);

            // Get object from DI container.
            //
            var logger = kernel.Get<ILogger>();

            var webSite = new WebSite(url);

            while (true)
            {
                try
                {
                    if (webSite.IsAvailable())
                        logger.Log(String.Format("{0} - Web site works", DateTime.Now));
                    else
                        logger.Log(String.Format("{0} - Web site status code isn't ok", DateTime.Now));
                }
                catch (Exception e)
                {
                    logger.Log(String.Format("{0} - {1}", DateTime.Now, e.Message));
                }
               
                
                Thread.Sleep(1000);
            }
        }
    }
}
