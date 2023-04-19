using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace WebScrapApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string req_URL = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=7&market_hash_name=";
            var lines = File.ReadAllLines("C:\\Users\\dede-\\source\\repos\\WebScrapApp\\WebScrapApp\\Links.txt");
            decimal total = 0;

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var line in lines)
                {
                    var item = line.Split(" ");
                    var amount = Convert.ToInt32(item[0]);
                    var type = item[1];
                    string std_URL = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=7&market_hash_name=" + type;

                    HttpResponseMessage response = await httpClient.GetAsync(std_URL);
                    string jsonString = await response.Content.ReadAsStringAsync();

                    Item? data = JsonConvert.DeserializeObject<Item>(jsonString);

                    total += (decimal.Parse(Regex.Replace(data.lowest_price, @"[^\d.]", "")) * amount) / 100;

                    Console.WriteLine("Total: R$" + (decimal.Parse(Regex.Replace(data.lowest_price, @"[^\d.]", "")) * amount) / 100 + "\tAmout: " + amount + "\tValue: " + data.lowest_price + "\t" + type);
                }

            }
            Console.WriteLine("Total: R$" + total);
        }
    }
}