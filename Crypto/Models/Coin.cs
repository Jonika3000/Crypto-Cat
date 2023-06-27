using Newtonsoft.Json;
using System;

namespace Crypto.Models
{
    public class Coin
    {
        [JsonProperty("exchangeId")]
        public string ExchangeId { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("baseSymbol")]
        public string BaseSymbol { get; set; }

        [JsonProperty("baseId")]
        public string BaseId { get; set; }

        [JsonProperty("quoteSymbol")]
        public string QuoteSymbol { get; set; }

        [JsonProperty("quoteId")]
        public string QuoteId { get; set; }

        [JsonProperty("priceQuote")]
        public string PriceQuote { get; set; }

        [JsonProperty("priceUsd")]
        public string PriceUsd { get; set; }

        [JsonProperty("volumeUsd24Hr")]
        public string VolumeUsd24Hr { get; set; }

        [JsonProperty("percentExchangeVolume")]
        public string PercentExchangeVolume { get; set; }

        [JsonProperty("tradesCount24Hr")]
        public string TradesCount24Hr { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        public DateTime GetUpdatedDateTime()
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(Updated).DateTime;
        }
    } 
}
