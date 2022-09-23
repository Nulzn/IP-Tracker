using System;
using System.Net.Http;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;


namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<IP-TRACKER/>");

            Console.Write("ENTER TARGET IP: ");
            string ipAdress = Console.ReadLine();


            Console.WriteLine("\n");

            using(var client = new HttpClient())
            {
                var endpoint = new Uri($"http://ip-api.com/json/{ipAdress}");
                var result = client.GetAsync(endpoint).Result;
                var data = result.Content.ReadAsStringAsync().Result;
                dynamic jsonData = JObject.Parse(data);
                

                Console.WriteLine($"Country: {jsonData.country}");
                Console.WriteLine($"City: {jsonData.city}");
                Console.WriteLine($"Zip: {jsonData.zip}");
                Console.WriteLine($"LAT: {jsonData.lat} | LON: {jsonData.lon}");
                Console.WriteLine($"ISP: {jsonData.isp}");
            }

            
        }
    }
}