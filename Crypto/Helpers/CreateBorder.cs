using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Crypto.Helpers
{
    public static class CreateBorder
    {
       public static Border Create(string text, string tag)
        {
            var bc = new BrushConverter();
            Style borderStyle = new Style();
            borderStyle.Setters.Add(new Setter(Border.BackgroundProperty, (Brush)Application.Current.MainWindow.FindResource("MainBackground"))); 
            Trigger mouseOverTrigger = new Trigger()
            {
                Property = Border.IsMouseOverProperty,
                Value = true
            };
            mouseOverTrigger.Setters.Add(new Setter(Border.BackgroundProperty, (Brush)Application.Current.MainWindow.FindResource("MainBackgroundGray"))); 
            borderStyle.Triggers.Add(mouseOverTrigger);
            Border border = new Border();
            border.Width = 400; 
            border.CornerRadius = new CornerRadius(20);
            border.Cursor = Cursors.Hand;
            border.Tag = tag; 
            border.Margin = new Thickness(10);
            border.Height = 50;
            border.Style = borderStyle;
            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 24;
            textBlock.Foreground = (Brush)Application.Current.MainWindow.FindResource("Text");
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center; 
            textBlock.Text = text;
            border.Child = textBlock;
            return border;
        }
    }
}
