using Crypto.Models;
using Crypto.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Crypto.Controls
{
    /// <summary>
    /// Логика взаимодействия для DataInfo.xaml
    /// </summary>
    public partial class DataInfo : UserControl
    {
        public Coin coin;
        public DataInfo(Coin coin)
        {
            InitializeComponent();
            SymbolCoin.Text = coin.BaseSymbol;   
            TradeCountCoin.Text = coin.TradesCount24Hr;
            PriceCoin.Text = coin.PriceUsd;
            if (PriceCoin.Text.Length > 10)
            {
                PriceCoin.Text = PriceCoin.Text.Substring(0, 10);
                PriceCoin.Text += "...";
            }
            this.coin = coin;
        } 
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Container.Navigate(new CoinDetails(coin));
        }
    }
}
