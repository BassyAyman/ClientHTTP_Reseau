using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClientHTTP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            string urlBase = "http://localhost:9000/";
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(urlBase);

            listener.Start();
            Console.WriteLine($"Serveur en écoute sur {urlBase}");

            Urls urls = new Urls();
            Statistics stats = new Statistics();
            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                // Récupération de l'URL demandée par le client
                string requestedUrl = request.Url.LocalPath.ToLower();

                // Traitement de la requête en fonction de l'URL demandée
                string responseString = "";
                if (requestedUrl == "/question1")
                {
                    urls.initialisationQuestion1();
                    RequestManager req = new RequestManager(urls);
                    int taille = urls.getUrls().Count();


                    for (int i = 0; i < taille; i++)
                    {
                        Console.WriteLine("Requete en cours vers lui : " + urls.getUrls()[i]);
                        Headers headers = await req.doRequestGet(i);
                        if (headers == null) continue;
                        stats.UpdateStatistics(headers);
                        Console.WriteLine(" ok on est bon");
                    }
                    Console.WriteLine(stats.GetStatisticsString());

                    responseString = stats.GetStatisticsString();
                }
                else if (requestedUrl == "/question2")
                {
                    urls.initialisationQuestion2Exemple1();
                    RequestManager req = new RequestManager(urls);
                    int taille2 = urls.getUrls().Count();

                    for (int i = 0; i < taille2; i++)
                    {
                        Console.WriteLine("Requete en cours vers lui : " + urls.getUrls()[i]);
                        Headers headers = await req.doRequestGet(i);
                        if (headers == null) continue;
                        stats.updateAgeStatistics(headers);
                        Console.WriteLine(" ok on est bon");
                    }
                    Console.WriteLine(stats.getAgeStatistics());

                    responseString = stats.getAgeStatistics();
                }
                else
                {
                    responseString = "Page non trouvée";
                }

                // Envoi de la réponse au client
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();

                Console.WriteLine("Requete fini ...");
                /*Console.WriteLine("Appuyez sur la touche 'q' pour quitter...");
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Q);*/
            }             
        }       
    }
}
