using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using System.Text.Json;
using System.Threading.Tasks;
using Crypto.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Crypto.Pages;

namespace Crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool ServerStatus = true;
        public List<Coin> Coins = new List<Coin>();
        public MainWindow()
        {
            InitializeComponent();
            PingServer();
            Task.Run(async () => await GetAllCoins()).Wait();
            Container.Navigate(new HomePage());
        }
        private void Tg_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            { 
            }
            else
            {
                 
            }
        }
        private async Task GetAllCoins()
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
                        Coins = dataArray.ToObject<List<Coin>>();
                    }
                }
            }
            catch (Exception ex)
            { 
            }

        }
        private async void PingServer()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://api.coingecko.com/api/v3/ping");
                    ServerStatus = true;
                }
            }
            catch (Exception ex)
            {
                ServerStatus = false;
            } 

        }
        private void GetCoinsData()
        {

        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
    public class RootObject
    {
        [JsonProperty("data")]
        public List<Coin> Data { get; set; }
    }
}
