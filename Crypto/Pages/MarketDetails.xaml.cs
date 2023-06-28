using Crypto.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarketDetails.xaml
    /// </summary>
    public partial class MarketDetails : Page
    {
        Market market;
        List<CoinOnMarkets> coinOnMarkets;
        public MarketDetails(Market market)
        {
            InitializeComponent();
            this.market = market; 
            Task.Run(async () => await GetDetail()).Wait();
            DataGridMarket.ItemsSource = coinOnMarkets;
            TradeCount.Text += " " + market.TradesCount24Hr;
            Price.Text += " " + market.PriceUsd;
            Symbol.Text += " " + market.BaseSymbol;
        }
        public async Task GetDetail()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"https://api.coincap.io/v2/assets/{market.BaseId}/markets";
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
