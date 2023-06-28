using Crypto.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Crypto.Controls
{
    /// <summary>
    /// Логика взаимодействия для ListMarkets.xaml
    /// </summary>
    public partial class ListMarkets : UserControl
    {
        public ListMarkets(List<Market> marketList)
        {
            InitializeComponent();
            foreach (var coin in marketList)
            {
                DataInfoMarket info = new DataInfoMarket(coin);
                MainStackPanel.Children.Add(info);
            }

        }
    }
}
