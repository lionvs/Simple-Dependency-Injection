using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDepInj
{
    public class WebSite
    {
        private string url;
        private ILogger loger;

        public WebSite(ILogger logger)
        {
            this.loger = logger;
        }
        public WebSite(string url)
        {
            this.url = url;
        }
        public bool IsAvailable()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
