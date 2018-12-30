using System.Web.Http;

namespace Crypto_api.Controllers
{
    public class CoinController : ApiController
    {
        Services.ExchangeService _exchange = new Services.ExchangeService();

        // GET api/coin
        public string Get()
        {
            return _exchange.GetAllCoins();
        }

        // GET api/coin/powr
        [Route("Api/Coin/{symbol}")]
        public string Get(string symbol)
        {
            return _exchange.GetCoin(symbol);
        }

        // GET api/coin/day/5
        [Route("Api/Coin/{timeframe}/{count}")]
        public string Get(string timeframe, int count)
        {
            return _exchange.GetMVPCoins(timeframe, count);
        }
    }
}
