using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientHTTP
{
    internal class Headers
    {
        public int Age { get; set; }
        //public string Vary { get; set; }
        //public string XCache { get; set; }
        //public string CacheControl { get; set; }
        //public string ETag { get; set; }
        public string Server { get; set; }


        public Headers(HttpResponseMessage response)
        {
            if (response.Headers.Contains("Age"))
            {
                if (int.TryParse(response.Headers.GetValues("Age").FirstOrDefault(), out int age))
                {
                    Age = age;
                }
            }

            //Vary = response.Headers.GetValues("Vary").FirstOrDefault();
            //XCache = response.Headers.GetValues("X-Cache").FirstOrDefault();
            //CacheControl = response.Headers.CacheControl?.ToString();
            //ETag = response.Headers.GetValues("ETag").FirstOrDefault();
            Server = response.Headers.Server?.ToString();
        }

        public int getAgeAsHours()
        {
            return Age / 3600;
        }

        public int getAgeAsSecondes()
        {
            return Age;
        }

        public string getServer()
        {
            return Server;
        }
    }
}
