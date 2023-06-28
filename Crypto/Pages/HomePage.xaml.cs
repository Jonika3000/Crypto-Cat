using Crypto.Controls;
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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        List<Market> marketList;
        public HomePage()
        {
            InitializeComponent();
            Task.Run(async () => await GetAllMarkets()).Wait();
            GridLeft.Children.Add(new ListMarkets(marketList));
        }
        private async Task GetAllMarkets()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(@"https://api.coincap.io/v2/markets");

                    response.EnsureSuccessStatusCode();

                    using (HttpContent content = response.Content)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject responseObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        JArray dataArray = responseObject["data"] as JArray;
                        marketList = dataArray.ToObject<List<Market>>();
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
