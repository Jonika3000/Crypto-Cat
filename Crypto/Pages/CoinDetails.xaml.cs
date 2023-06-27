using Crypto.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для CoinDetails.xaml
    /// </summary>
    public partial class CoinDetails : Page
    {
        Coin coin;
        List<CoinOnMarkets> coinOnMarkets;
        public CoinDetails(Coin coin)
        {
            InitializeComponent();
            this.coin = coin;
            GetDetail();
        }
        public async Task GetDetail()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"https://api.coincap.io/v2/assets/{coin.BaseId}/markets";
                    HttpResponseMessage response = await client.GetAsync(url); 
                    response.EnsureSuccessStatusCode(); 
                    using (HttpContent content = response.Content)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject responseObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        JArray dataArray = responseObject["data"] as JArray;
                        coinOnMarkets = dataArray.ToObject<List<CoinOnMarkets>>();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
