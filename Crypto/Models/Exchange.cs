using Newtonsoft.Json;

namespace Crypto.Models
{
    public class Exchange
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("year_established")]
        public string YearEstablished { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("has_trading_incentive")]
        public string HasTradingIncentive { get; set; }
        [JsonProperty("trust_score")]
        public string TrustScore { get; set; }
        [JsonProperty("trust_score_rank")]
        public string TrustScoreRank { get; set; }
        [JsonProperty("trade_volume_24h_btc")]
        public string TradeVolume24hBtc { get; set; }
        [JsonProperty("trade_volume_24h_btc_normalized")]
        public string TradeVolume24hBtcNormalized { get; set; }
    }
}
