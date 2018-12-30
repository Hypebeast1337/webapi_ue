using System;
using System.Collections.Generic;
using System.Net;
using Crypto_api.Data.Models;
using Newtonsoft.Json;
using System.Dynamic;
using System.Linq;

namespace Crypto_api.Services
{
    public class ExchangeService
    {
        public enum Markets { WCI, CMCG, CMCT }

        public string GetConnectionJSON(Markets market)
        {
            using (WebClient wc = new WebClient())
            {
                switch (market)
                {
                    case Markets.WCI: return wc.DownloadString(Properties.Settings.Default.URL_WCI);
                    case Markets.CMCG: return wc.DownloadString(Properties.Settings.Default.URL_CMCG);
                    case Markets.CMCT: return wc.DownloadString(Properties.Settings.Default.URL_CMCT);
                    default: return string.Empty;
                }
            }
        }

        public string GetAllCoins()
        {
            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject<WCIMarketsModel>(GetConnectionJSON(Markets.WCI)));
        }

        public string GetCoin(string symbol)
        {
            List<CMCTModel> cmctCoins = JsonConvert.DeserializeObject<List<CMCTModel>>(GetConnectionJSON(Markets.CMCT));

            return JsonConvert.SerializeObject(cmctCoins.Where(o => o.symbol == symbol.ToUpper()));
        }

        public string GetMVPCoins(string timeframe, int count)
        {
            List<CMCTModel> mvpCoins = JsonConvert.DeserializeObject<List<CMCTModel>>(GetConnectionJSON(Markets.CMCT));

            if (timeframe == "hour")
                mvpCoins = mvpCoins.OrderBy(o => o.percent_change_1h).ToList();
            if (timeframe == "day")
                mvpCoins = mvpCoins.OrderBy(o => o.percent_change_24h).ToList();
            if (timeframe == "week")
                mvpCoins = mvpCoins.OrderBy(o => o.percent_change_7d).ToList();

            return JsonConvert.SerializeObject(mvpCoins.ToList().Take(count));
        }

        public string GetMarketDetails(string key)
        {
            dynamic market = JsonConvert.DeserializeAnonymousType(GetConnectionJSON(Markets.CMCG), new ExpandoObject());

            foreach (var property in (IDictionary<string, Object>)market)
            {
                switch (property.Key)
                {
                    case "total_market_cap_usd":
                    case "total_24h_volume_usd":
                    case "active_currencies":
                    case "bitcoin_percentage_of_market_cap":
                        return property.Value.ToString();
                    default: return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}
