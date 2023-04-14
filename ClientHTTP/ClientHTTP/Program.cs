using System;
using System.Collections.Generic;
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
            Urls urls = new Urls();
            urls.initialisationQuestion1();
            RequestManager req = new RequestManager(urls);
            int taille = urls.getUrls().Count();
            Statistics stats = new Statistics();
            
                
            for (int i = 0; i < taille ; i++)
            {
                Console.WriteLine("Requete en cours vers lui : "+urls.getUrls()[i]);
                Headers headers = await req.doRequestGet(i);
                if (headers == null) continue;
                stats.UpdateStatistics(headers);
                Console.WriteLine(" ok on est bon");
            }
            Console.WriteLine(stats.GetStatisticsString());
            

            Console.WriteLine(" QUESTION 2 LA ");

            urls.initialisationQuestion2Exemple2();
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

            Console.WriteLine("Appuyez sur la touche 'q' pour quitter...");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Q);
        }       
    }
}
