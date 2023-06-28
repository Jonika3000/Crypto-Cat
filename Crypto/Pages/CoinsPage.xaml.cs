using Crypto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для CoinsPage.xaml
    /// </summary>
    public partial class CoinsPage : Page
    {
        List<Coin> coins;
        public CoinsPage()
        {
            InitializeComponent();
            Task.Run(async () => await GetCoins()).Wait();
            SetList();
        }
        public void SetList()
        { 
            if(coins != null)
            foreach (var coin in coins)
            {
                CreateBorder(coin);
            }
        }
        public void CreateBorder(Coin coin)
        {
            if (coin.Name.Length > 15)
            {
                coin.Name = coin.Name.Substring(0, 15) + "...";
            }
            if (coin.Symbol.Length > 15)
            {
                coin.Symbol = coin.Symbol.Substring(0, 15) + "...";
            }
            Border border = Crypto.Helpers.CreateBorder.Create($"{coin.Name} ({coin.Symbol})", coin.Id);
            border.MouseLeftButtonDown += Border_MouseLeftButtonDown;  
            MainStackPanel.Children.Add(border);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            ((MainWindow)Application.Current.MainWindow).Container.Navigate(new CoinDetailsPage(border.Tag.ToString()));
        }
        public async Task GetCoins()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"https://api.coingecko.com/api/v3/coins/list";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        coins = JsonConvert.DeserializeObject<List<Coin>>(responseBody); 
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
