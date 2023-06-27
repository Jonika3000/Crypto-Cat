using Crypto.Controls;
using Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        List<Coin> coinList = ((MainWindow)Application.Current.MainWindow).Coins.Take(10).ToList();
        public HomePage()
        {
            InitializeComponent();
            GridLeft.Children.Add(new ListCoins(coinList));
        }
    }
}
