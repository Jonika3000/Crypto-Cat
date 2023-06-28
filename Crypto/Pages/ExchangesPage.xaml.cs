using Crypto.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExchangesPage.xaml
    /// </summary>
    public partial class ExchangesPage : Page
    {
        List<Exchange> exchanges;
        public ExchangesPage()
        {
            InitializeComponent();
            Task.Run(async () => await GetExchanges()).Wait(); 
            foreach(var exchange in exchanges)
            {
                CreateBorder(exchange);
            }
        }
        public void CreateBorder(Exchange exchange)
        {
            Border border = Crypto.Helpers.CreateBorder.Create(exchange.Name, exchange.Id); 
            border.MouseLeftButtonDown += Border_MouseLeftButtonDown;   
            MainStackPanel.Children.Add(border);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            ((MainWindow)Application.Current.MainWindow).Container.Navigate(new ExchangeDetailPage(
                exchanges.Where(e => e.Id == border.Tag).First()));
        } 
        public async Task GetExchanges()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"https://api.coingecko.com/api/v3/exchanges";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<JObject> responseObjects = JsonConvert.DeserializeObject<List<JObject>>(responseBody);
                        exchanges = responseObjects.Select(obj => obj.ToObject<Exchange>()).ToList();
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
