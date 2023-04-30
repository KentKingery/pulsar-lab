using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PulsarLab.CLI.Classes
{
    internal class Tenant
    {
        public static async Task<List<string>> Tenants(string rootUrl)
        {
            List<string> tenants = new List<string>();

            using HttpClient client = new();

            var json = await client.GetFromJsonAsync<string[]>((rootUrl + "/tenants"));

            foreach (var tenant in json)
            {
                tenants.Add(tenant);
            }

            return tenants;
        }
    }
}
