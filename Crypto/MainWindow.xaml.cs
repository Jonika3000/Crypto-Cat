using Crypto.Helpers;
using Crypto.Pages;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;

namespace Crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool ServerStatus = true;

        public MainWindow()
        {
            InitializeComponent();
            SetTheme();
            PingServer();
            if (ServerStatus)
            {
                if (CheckForInternetConnection())
                    Container.Navigate(new HomePage());
                else
                    Container.Navigate(new NoInternetConnectionPage());
            }
            else
            {
                MessageBox.Show("Server not responding", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private static bool CheckForInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") =>
                        "http://www.aparat.com",
                    { Name: var n } when n.StartsWith("zh") =>
                        "http://www.baidu.com",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
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
        private void SetTheme()
        { 
            if (File.Exists("theme.json"))
            {
                string json = File.ReadAllText("theme.json");
                ThemeInfo themeInfo = JsonConvert.DeserializeObject<ThemeInfo>(json);
                if (themeInfo.Theme == "Dark")
                {
                    AppTheme.ChangeTheme(new Uri("/Themes/Dark.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    AppTheme.ChangeTheme(new Uri("/Themes/Light.xaml", UriKind.RelativeOrAbsolute));
                }
            } 
            else
            {
                AppTheme.ChangeTheme(new Uri("/Themes/Dark.xaml", UriKind.RelativeOrAbsolute));
                ThemeInfo NewthemeInfo = new ThemeInfo
                {
                    Theme = "Dark"
                };
                string json = JsonConvert.SerializeObject(NewthemeInfo);
                File.WriteAllText("Theme.json", json);
            }
          
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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Container.Navigate(new HomePage());
        }

        private void ExchangesButton_Click(object sender, RoutedEventArgs e)
        {
            Container.Navigate(new ExchangesPage());
        }

        private void CoinsButton_Click(object sender, RoutedEventArgs e)
        {
            Container.Navigate(new CoinsPage());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Container.Navigate(new SearchPage());
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Container.Navigate(new SettingsPage());
        }
    }
    
}
