using PulsarLab.CLI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using PulsarLab.CLI.Classes;

namespace PulsarLab.CLI
{
    public class Pulsar
    {
        private static string _rootUrl = "http://192.168.86.20:8080/admin/v2";

        public static async void ListBrokers()
        {
            var brokers = await Broker.Brokers(_rootUrl);

            if (brokers.Count == 0)
            {
                Console.WriteLine("\nNo brokers available\n");
            }
            else
            {
                Console.WriteLine("Brokers:");
                foreach (var broker in brokers)
                {
                    Console.WriteLine("   " + broker);
                }
                Console.WriteLine();
            }

        }

        public static async void ListTenants()
        {
            var tenants = await Tenant.Tenants(_rootUrl);

            if (tenants.Count == 0)
            {
                Console.WriteLine("\nNo tenants available\n");
            }
            else
            {
                Console.WriteLine("Tenants:");
                foreach (var tenant in tenants.OrderBy( t => t ))
                {
                    Console.WriteLine("   " + tenant);
                }
                Console.WriteLine();
            }
        }
    }
}
