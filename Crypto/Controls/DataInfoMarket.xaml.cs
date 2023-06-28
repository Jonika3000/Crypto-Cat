using Crypto.Models;
using Crypto.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Crypto.Controls
{
    /// <summary>
    /// Логика взаимодействия для DataInfoMarket.xaml
    /// </summary>
    public partial class DataInfoMarket : UserControl
    {
        public Market market;
        public DataInfoMarket(Market market)
        {
            InitializeComponent();
            SymbolCoin.Text = market.BaseSymbol;
            TradeCountCoin.Text = market.TradesCount24Hr;
            PriceCoin.Text = market.PriceUsd;
            if (PriceCoin.Text.Length > 10)
            {
                PriceCoin.Text = PriceCoin.Text.Substring(0, 10);
                PriceCoin.Text += "...";
            }
            this.market = market;
        }
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Container.Navigate(new MarketDetails(market));
        }

    }
}
