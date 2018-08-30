using IdentityModel.Client;
using System;
using System.Threading.Tasks;

namespace ClientExample
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MainAsync().GetAwaiter().GetResult();

        }


        private static async Task MainAsync()
        {
            // discover endpoints from the metadata by calling Auth server hosted on 5000 port
            var discoveryClient = await DiscoveryClient.GetAsync("https://coworkingidentity.azurewebsites.net");
            if (discoveryClient.IsError)
            {
                Console.WriteLine(discoveryClient.Error);
                return;
            }

            // request the token from the Auth server
            var tokenClient = new TokenClient(discoveryClient.TokenEndpoint, "client", "511536EF-F270-4058-80CA-1C89C192F69A");
            var response = await tokenClient.RequestClientCredentialsAsync("api1");

            if (response.IsError)
            {
                Console.WriteLine(response.Error);
                return;
            }

            Console.WriteLine(response.Json);

        }

    }
}
