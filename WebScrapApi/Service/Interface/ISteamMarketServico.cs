using WebScrapApi.Model;

namespace WebScrapApi.Service.Interface
{
    public interface ISteamMarketServico
    {
        public Task<ItemModel> GetSteamMarketPriceSingle(string url);
    }
}
