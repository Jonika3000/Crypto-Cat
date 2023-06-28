using Crypto.Helpers;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Crypto.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            SetCheakBox();
        }

        private void GitHubButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Jonika3000",
                UseShellExecute = true
            });
        }
        private void SetCheakBox()
        {
            if (File.Exists("theme.json"))
            {
                string json = File.ReadAllText("theme.json");
                ThemeInfo themeInfo = JsonConvert.DeserializeObject<ThemeInfo>(json);
                if (themeInfo.Theme == "Dark")
                {
                    CheakBoxTheme.IsChecked = true; 
                }
                else
                {
                    CheakBoxTheme.IsChecked = false; 
                }
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("/Themes/Dark.xaml",UriKind.RelativeOrAbsolute));
            ThemeInfo themeInfo = new ThemeInfo
            {
                Theme = "Dark"  
            }; 
            string json = JsonConvert.SerializeObject(themeInfo); 
            File.WriteAllText("Theme.json", json);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AppTheme.ChangeTheme(new Uri("/Themes/Light.xaml", UriKind.RelativeOrAbsolute));
            ThemeInfo themeInfo = new ThemeInfo
            {
                Theme = "Light"
            };
            string json = JsonConvert.SerializeObject(themeInfo);
            File.WriteAllText("Theme.json", json);
        }
    }
}
