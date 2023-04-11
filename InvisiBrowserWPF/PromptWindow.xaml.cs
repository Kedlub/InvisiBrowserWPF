using MicaWPF.Controls;
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
using System.Windows.Shapes;

namespace InvisiBrowserWPF
{
    /// <summary>
    /// Interakční logika pro PromptWindow.xaml
    /// </summary>
    public partial class PromptWindow : MicaWindow
    {
        public PromptWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Check if Width and Height are numbers
            if (!int.TryParse(WidthBox.Text, out int width))
            {
                MessageBox.Show("Width must be a number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(HeightBox.Text, out int height))
            {
                MessageBox.Show("Height must be a number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            BrowserWindow browserWindow = new BrowserWindow(UrlBox.Text);
            browserWindow.Owner = this;
            browserWindow.Width = width;
            browserWindow.Height = height;
            browserWindow.Show();
            Hide();
        }
    }
}
