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
        private Dictionary<string, int> contentTypeOccurrences;
        private List<long> contentLengthListInBytes;
        public Statistics()
        {
            serverOccurrences = new Dictionary<string, int>();
            ageListInSeconds = new List<double>();
            contentTypeOccurrences = new Dictionary<string, int>();
            contentLengthListInBytes = new List<long>();
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
            double age = headers.getAgeAsSeconds();
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

        public void UpdateChoisenStatistics(Headers headers)
        {
            string server = headers.Server;
            if (serverOccurrences.ContainsKey(server))
            {
                serverOccurrences[server]++;
            }
            else
            {
                serverOccurrences.Add(server, 1);
            }

            string contentType = headers.ContentType;
            if (contentTypeOccurrences.ContainsKey(contentType))
            {
                contentTypeOccurrences[contentType]++;
            }
            else
            {
                contentTypeOccurrences.Add(contentType, 1);
            }

            long contentLength = headers.ContentLength;
            if (contentLength > 0)
            {
                contentLengthListInBytes.Add(contentLength);
            }
        }

        public string GetChoisedStatisticsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Server Statistics:");
            foreach (var kvp in serverOccurrences)
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value}");
            }

            sb.AppendLine("\nContent Type Statistics:");
            foreach (var kvp in contentTypeOccurrences)
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value}");
            }

            sb.AppendLine("\nContent Length Statistics:");
            if (contentLengthListInBytes.Count > 0)
            {
                long averageContentLength = (long)contentLengthListInBytes.Average();
                long maxContentLength = contentLengthListInBytes.Max();
                long minContentLength = contentLengthListInBytes.Min();
                sb.AppendLine($"Average content length: {averageContentLength} bytes");
                sb.AppendLine($"Maximum content length: {maxContentLength} bytes");
                sb.AppendLine($"Minimum content length: {minContentLength} bytes");
            }
            else
            {
                sb.AppendLine("No content length information available.");
            }

            return sb.ToString();
        }

    }
}
