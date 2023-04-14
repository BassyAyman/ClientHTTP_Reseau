using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientHTTP
{
    internal class RequestManager
    {
        private Urls Urls;


        public RequestManager(Urls urls)
        {
            Urls = urls;
        }

        public async Task<Headers> doRequestGet(int index)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(Urls.getAUrls(index));
                if (response.IsSuccessStatusCode)
                {
                    return new Headers(response);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erreur HTTP : {ex.Message}");
                return null;
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Erreur Web : {ex.Message}");
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erreur d'E/S : {ex.Message}");
                return null;
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Erreur de socket : {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur inattendue : {ex.Message}");
                return null;
            }
            return null;
        }
    }
}
