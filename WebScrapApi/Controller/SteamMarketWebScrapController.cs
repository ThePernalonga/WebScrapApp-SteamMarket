using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebScrapApi.Model;

namespace WebScrapApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SteamMarketWebScrapController : ControllerBase
    {
        private readonly ILogger<SteamMarketWebScrapController> _logger;
        private string req_URL = "https://steamcommunity.com/market/priceoverview/?appid=730&currency=7&market_hash_name=";

        public SteamMarketWebScrapController(ILogger<SteamMarketWebScrapController> logger)
        {
            _logger = logger;
            //_steamMarketServico = steamMarketServico;
        }


        [HttpGet]
        [Route("obterSteamMarketPriceUnico")]
        public async Task<ItemModel> GetSteamMarketPriceSingle(string url)
        {
            Uri _uri = new Uri(url);
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
