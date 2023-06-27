using Crypto.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Crypto.Controls
{
    /// <summary>
    /// Логика взаимодействия для ListCoins.xaml
    /// </summary>

    public partial class ListCoins : UserControl
    {
        public ListCoins(List<Coin> Coins)
        {
            InitializeComponent();
            foreach (var coin in Coins)
            {
                DataInfo info = new DataInfo(coin);
                MainStackPanel.Children.Add(info);
            }

        }
    }
}
