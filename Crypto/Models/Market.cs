using Newtonsoft.Json;
using System;

namespace Crypto.Models
{
    public class Market
    {
        [JsonProperty("ExchangeId")]
        public string ExchangeId { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("BaseSymbol")]
        public string BaseSymbol { get; set; }

        [JsonProperty("BaseId")]
        public string BaseId { get; set; }

        [JsonProperty("QuoteSymbol")]
        public string QuoteSymbol { get; set; }

        [JsonProperty("QuoteId")]
        public string QuoteId { get; set; }

        [JsonProperty("priceQuote")]
        public string PriceQuote { get; set; }

        [JsonProperty("PriceUsd")]
        public string PriceUsd { get; set; }

        [JsonProperty("VolumeUsd24Hr")]
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
