using System.Web.Http;

namespace Crypto_api.Controllers
{
    public class MarketController : ApiController
    {
        Services.ExchangeService _exchange = new Services.ExchangeService();
        
        // GET api/market/5
        [Route("Api/Market/{key}")]
        public string Get(string key)
        {
            return _exchange.GetMarketDetails(key);
        }
    }
}