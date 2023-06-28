using Newtonsoft.Json;

namespace Crypto.Models
{
    public class Coin
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
