using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_api.Data.Models
{
    public class WCIModel
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public string Price_btc { get; set; }
        public string Price_usd { get; set; }
        public string Price_cny { get; set; }
        public string Price_eur { get; set; }
        public string Price_gbp { get; set; }
        public string Price_rur { get; set; }
        public string Volume_24h { get; set; }
        public string Timestamp { get; set; }
        public string Balance { get; set; }
        public string Balance_usd { get; set; }
        public string ChangeDay { get; set; }
        public string ChangeWeek { get; set; }
        public string MarketCap { get; set; }
        public string ImgSource { get; set; }
        public bool Active { get; set; }
    }
}
