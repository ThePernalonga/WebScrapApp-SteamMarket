using Microsoft.AspNetCore.Mvc;
using WebScrapApi.Model;
using WebScrapApi.Service.Interface;

namespace WebScrapApi.Controller
{
    [Produces("application/json")]
    [Route("api/")]
    public class SteamMarketWebScrapController : ControllerBase
    {
        private readonly ISteamMarketServico _steamMarketServico;

        public SteamMarketWebScrapController(ISteamMarketServico steamMarketServico)
        {
            _steamMarketServico = steamMarketServico;
        }

        [HttpGet]
        [Route("obterSteamMarketPriceUnico")]
        public async Task<IActionResult> GetSteamMarketPriceSingle([FromHeader] string url) {
            return (IActionResult)await _steamMarketServico.GetSteamMarketPriceSingle(url);
        }

    }
}
