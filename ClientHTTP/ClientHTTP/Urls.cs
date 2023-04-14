using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClientHTTP
{
    internal class Urls
    {
        private List<string> _urls = new List<string>();

        string urlPattern = @"^https?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$"; // pour verifier que le format et valide dans le fichier txt

        public void initialisationQuestion1()
        {
            _urls.Clear();
            try
            {
                string filePath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../ListeServeurModifiable.txt");
                using (StreamReader sr = new StreamReader(filePath1))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if(Regex.IsMatch(line, urlPattern))
                        {
                            _urls.Add(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la lecture du fichier d'URLs : " + e.Message);
            }
        }

        public void initialisationQuestion2Exemple1()
        {
            _urls.Clear();
            try
            {
                string filePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../ListePageWiki.txt");
                using (StreamReader sr = new StreamReader(filePath2))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (Regex.IsMatch(line, urlPattern))
                        {
                            _urls.Add(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la lecture du fichier d'URLs : " + e.Message);
            }
        }

        public List<string> getUrls()
        {
            return _urls;
        }

        public string getAUrls(int index)
        {
            return _urls[index];
        }
    }
}
