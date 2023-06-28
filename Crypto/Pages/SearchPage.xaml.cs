using Crypto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        List<Coin> coinList;
        List<Coin> resultList = new List<Coin>();
        public SearchPage()
        {
            InitializeComponent();
            CreateTextBlock("Wait Please");
            Task.Run(async () => await GetCoins()).Wait();
            MainStackPanel.Children.Clear();
        }

        private void SearchTermTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            MainStackPanel.Children.Clear();
            if (e.Key == Key.Enter)
            {  
                resultList = coinList.Where(c=>c.Id == SearchTermTextBox.Text || c.Symbol == SearchTermTextBox.Text
                || c.Name == SearchTermTextBox.Text).ToList();
                SearchTermTextBox.Text = String.Empty;
                if (resultList.Count == 0) {
                    CreateTextBlock("Nothing found");
                    return;
                }
                foreach (Coin coin in resultList)
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
               
            }
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            ((MainWindow)Application.Current.MainWindow).Container.Navigate(new CoinDetailsPage(border.Tag.ToString()));
        }
        private void CreateTextBlock(string text)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 24;
            textBlock.Foreground = (Brush)Application.Current.MainWindow.FindResource("Text");
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Text = text;
            MainStackPanel.Children.Add(textBlock);
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
                        coinList = JsonConvert.DeserializeObject<List<Coin>>(responseBody);
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
