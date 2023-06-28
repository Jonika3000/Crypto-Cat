using Crypto.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для CoinDetailsPage.xaml
    /// </summary>
    public partial class CoinDetailsPage : Page
    {
        CoinDetails coin;
        string CoinId;
        public CoinDetailsPage(string CoinId)
        {
            InitializeComponent();
            this.CoinId = CoinId;
            Task.Run(async () => await GetCoinDetail()).Wait();
            SetData();
        }
        private void SetData()
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(coin.Image.Large);
            logo.EndInit();
            ImageCoin.Source = logo;
            NameCoin.Text = coin.Name;
            SymbolCoin.Text = coin.Symbol;
            PriceCoin.Text = coin.MarketData.CurrentPrice.Usd + "$"; 
            if(coin.Facebook == string.Empty)
            {
                WebSiteFacebookButton.Visibility = Visibility.Hidden;
            }
            if (coin.Twitter == string.Empty)
            {
                WebSiteTwitterButton.Visibility = Visibility.Hidden;
            }
        }
        private async Task GetCoinDetail()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"https://api.coingecko.com/api/v3/coins/{CoinId}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    using (HttpContent content = response.Content)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        coin = JsonConvert.DeserializeObject<CoinDetails>(responseBody); 
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var link in coin.Links.Homepage)
            {
                if(link != string.Empty)
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = link,
                        UseShellExecute = true
                    });
                } 
            } 
        }

        private void WebSiteTwitterButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var link in coin.Links.Homepage)
            {
                if (link != string.Empty)
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = $"https://twitter.com/{coin.Twitter}",
                        UseShellExecute = true
                    });
                }
            }
        }

        private void WebSiteFacebookButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var link in coin.Links.Homepage)
            {
                if (link != string.Empty)
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = $"https://www.facebook.com/{coin.Facebook}",
                        UseShellExecute = true
                    });
                }
            }
        }
    }
}
