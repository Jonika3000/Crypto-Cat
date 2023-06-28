namespace Crypto.Models
{
    class CoinOnMarkets
    {
        public string ExchangeId { get; set; }
        public string BaseId { get; set; }
        public string QuoteId { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string VolumePercent { get; set; }
    }
     
}
