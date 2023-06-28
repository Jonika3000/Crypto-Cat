using Newtonsoft.Json;

namespace Crypto.Models
{
    public class CoinDetails:Coin
    { 
        [JsonProperty("links")]
        public CoinLinks Links { get; set; }
        [JsonProperty("image")]
        public CoinImage Image { get; set; }
        [JsonProperty("market_data")]
        public CoinMarketData MarketData { get; set; }
        [JsonProperty("twitter_screen_name")]
        public string Twitter { get; set; }
        [JsonProperty("facebook_username")]
        public string Facebook { get; set; }
    }
    public class CoinImage
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }
    public class CoinMarketData
    {
        [JsonProperty("current_price")]
        public CurrentPriceUsd CurrentPrice { get; set; }
    }

    public class CurrentPriceUsd
    {
        [JsonProperty("usd")]
        public string Usd { get; set; }
    }
    public class CoinLinks
    {
        [JsonProperty("homepage")]
        public string[] Homepage { get; set; }
    }
}
