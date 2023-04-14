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
        public string Server { get; set; }
        public string ContentType { get; set; }
        public string ContentEncoding { get; set; }
        public long ContentLength { get; set; }

        public Headers(HttpResponseMessage response)
        {
            if (response.Headers.Contains("Age"))
            {
                if (int.TryParse(response.Headers.GetValues("Age").FirstOrDefault(), out int age))
                {
                    Age = age;
                }
            }

            Server = response.Headers.Server?.ToString();
            ContentType = response.Content.Headers.ContentType?.ToString();
            ContentEncoding = response.Content.Headers.ContentEncoding?.ToString();
            ContentLength = response.Content.Headers.ContentLength.GetValueOrDefault();
            
        }

        public int getAgeAsHours()
        {
            return Age / 3600;
        }

        public int getAgeAsSeconds()
        {
            return Age;
        }

        public string getServer()
        {
            return Server;
        }

        public string getContentType()
        {
            return ContentType;
        }

        public string getContentEncoding()
        {
            return ContentEncoding;
        }

        public long getContentLength()
        {
            return ContentLength;
        }

    }

}
