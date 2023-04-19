using Newtonsoft.Json;
using System.Text.RegularExpressions;
using WebScrapApi.Model;
using WebScrapApi.Service.Interface;

namespace WebScrapApi.Service
{
    public class SteamMarketServico : ISteamMarketServico
    {
        private string req_URL = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=7&market_hash_name=";
        public async Task<ItemModel> GetSteamMarketPriceSingle(string url) {
            Uri _uri= new Uri(url);
            var std_URL = req_URL + _uri.Segments.LastOrDefault().ToString();
            decimal total = 0;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(std_URL);
                string jsonString = await response.Content.ReadAsStringAsync();

                ItemModel? data = JsonConvert.DeserializeObject<ItemModel>(jsonString);

                return data;
                
            }
        }
    }
}
