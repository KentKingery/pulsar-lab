using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PulsarLab.CLI.Classes
{
    internal class Broker
    {
        public static async Task<List<string>> Brokers(string rootUrl)
        {
            List<string> brokers = new List<string>();

            using HttpClient client = new();

            var json = await client.GetFromJsonAsync<string[]>((rootUrl + "/brokers"));

            foreach (var broker in json)
            {
                brokers.Add(broker);
            }

            return brokers;
        }
    }
}
