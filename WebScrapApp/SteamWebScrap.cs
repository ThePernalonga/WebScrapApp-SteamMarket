using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapApp
{
    public class SteamWebScrap
    {
        public static string req_URL = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=7&market_hash_name=";
        public static void GetItemLoja()
        {
            var lines = File.ReadAllLines("C:\\Users\\dede-\\source\\repos\\WebScrapApp\\WebScrapApp\\Links.txt");
            HtmlWeb web = new HtmlWeb();

            foreach (string line in lines)
            {
                var htmlDoc = web.Load("https://steamcommunity.com/market/priceoverview/?appid=730&currency=7&market_hash_name=Chroma%20Case");
                
                Console.WriteLine("Name: " + htmlDoc);
            }
        }

        public static async Task RetriveJSON()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=7&market_hash_name=Chroma%20Case";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                string jsonString = await response.Content.ReadAsStringAsync();

                Item data = JsonConvert.DeserializeObject<Item>(jsonString);

                Console.WriteLine("Value: " + data.lowest_price);
                Console.WriteLine("Amout: " + data.volume);
            }
        }
    }
}
