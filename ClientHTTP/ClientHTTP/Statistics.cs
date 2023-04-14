using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientHTTP
{
    internal class Statistics
    {
        private Dictionary<string, int> serverOccurrences;
        private List<double> ageListInSeconds;

        public Statistics()
        {
            serverOccurrences = new Dictionary<string, int>();
            ageListInSeconds = new List<double>();
        }

        public void UpdateStatistics(Headers headers)
        {
            string server = headers.getServer();
            if (serverOccurrences.ContainsKey(server))
            {
                serverOccurrences[server]++;
            }
            else
            {
                serverOccurrences.Add(server, 1);
            }
        }

        public string GetStatisticsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Server Statistics:");
            foreach (var kvp in serverOccurrences)
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value}");
            }
            return sb.ToString();
        }

        public void updateAgeStatistics(Headers headers)
        {
            double age = headers.getAgeAsSecondes();
            if (age >= 0)
            {
                ageListInSeconds.Add(age);
            }
        }

        public string getAgeStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Age statistics:");
            if (ageListInSeconds.Count > 0)
            {
                double averageAgeInSeconds = ageListInSeconds.Average();
                double standardDeviationInSeconds = Math.Sqrt(ageListInSeconds.Average(v => Math.Pow(v - averageAgeInSeconds, 2)));
                double averageAgeInHours = averageAgeInSeconds / 3600;
                double standardDeviationInHours = standardDeviationInSeconds / 3600;
                sb.AppendLine("Age Moyen des pages de WIKI: " + averageAgeInHours.ToString("0.##") + " hours");
                sb.AppendLine("Ecart type entre elles: " + standardDeviationInHours.ToString("0.##") + " hours");
            }
            else
            {
                sb.AppendLine("No age information available.");
            }
            return sb.ToString();
        }
    }
}
