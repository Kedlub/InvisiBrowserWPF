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
            BrowserWindow browserWindow = new BrowserWindow(UrlBox.Text);
            browserWindow.Show();
            Hide();
        }
    }
}
