using Crypto.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExchangeDetailPage.xaml
    /// </summary>
    public partial class ExchangeDetailPage : Page
    {
        Exchange exchange;
        public ExchangeDetailPage(Exchange exchange)
        {
            InitializeComponent();
            this.exchange = exchange;
            SetData();
        }
        private void SetData()
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(exchange.Image);
            logo.EndInit();
            ImageExc.Source = logo;
            NameExc.Text = exchange.Name;
            YearExc.Text = exchange.YearEstablished;
            CountryExc.Text = exchange.Country;
            if(exchange.Description == string.Empty)
            {
                DescriptionExc.Text = "Description is empty, sorry";
            }
            else
            DescriptionExc.Text = exchange.Description;
            TrustExc.Text = "Trust score is " + exchange.TrustScore;
        }
        private void WebSiteButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = exchange.Url,
                UseShellExecute = true
            }); 
        }
    }
}
