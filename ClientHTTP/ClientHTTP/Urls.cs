using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientHTTP
{
    internal class Urls
    {
        private List<string> _urls = new List<string>();

        public void initialisationQuestion1()
        {
            _urls.Clear();
            _urls.Add("https://www.example.com");
            _urls.Add("https://www.gutenberg.org");
            _urls.Add("https://www.reddit.com");
            _urls.Add("https://www.pastebin.com");
            _urls.Add("https://www.phoronix.com");
            _urls.Add("http://www.tigli.fr");
            _urls.Add("https://www.gearbest.com");
            _urls.Add("https://www.lingoda.com");
        }

        public void initialisationQuestion2Exemple1()
        {
            _urls.Clear();
            _urls.Add("https://fr.wikipedia.org/wiki/Histoire_de_France");
            _urls.Add("https://fr.wikipedia.org/wiki/Albert_Einstein");
            _urls.Add("https://fr.wikipedia.org/wiki/Londres");
            _urls.Add("https://fr.wikipedia.org/wiki/Barack_Obama");
            _urls.Add("https://fr.wikipedia.org/wiki/Impressionnisme");
            _urls.Add("https://fr.wikipedia.org/wiki/Albert_Camus");
            _urls.Add("https://fr.wikipedia.org/wiki/Zone_51");
            _urls.Add("https://fr.wikipedia.org/wiki/Juifs");
            _urls.Add("https://fr.wikipedia.org/wiki/Apprentissage_automatique");
            _urls.Add("https://fr.wikipedia.org/wiki/Aviation");
        }
        
        public void initialisationQuestion2Exemple2()
        {
            _urls.Clear();
            _urls.Add("https://ent.unice.fr/uPortal/tag.c843fa75d4b78bcd.render.userLayoutRootNode.uP?uP_sparam=focusedTabID&focusedTabID=115&uP_sparam=mode&mode=view");
            /*_urls.Add("https://fr.wikipedia.org/wiki/Albert_Einstein");
            _urls.Add("https://fr.wikipedia.org/wiki/Londres");
            _urls.Add("https://fr.wikipedia.org/wiki/Barack_Obama");
            _urls.Add("https://fr.wikipedia.org/wiki/Impressionnisme");
            _urls.Add("https://fr.wikipedia.org/wiki/Albert_Camus");
            _urls.Add("https://fr.wikipedia.org/wiki/Zone_51");
            _urls.Add("https://fr.wikipedia.org/wiki/Juifs");
            _urls.Add("https://fr.wikipedia.org/wiki/Apprentissage_automatique");
            _urls.Add("https://fr.wikipedia.org/wiki/Aviation");*/
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
