using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
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

namespace Calculator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush(Colors.LightGray);
        }
        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush() {Color = Color.FromRgb(240,240,240)};   
        }
        private void BorderBlue_MouseLeave(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush() { Color = Color.FromRgb(0, 91, 158) };
        }
        
        private void BorderBlue_MouseMove(object sender, MouseEventArgs e)
        {
            Border? border = sender as Border;
            border!.Background = new SolidColorBrush() { Color = Color.FromRgb(115, 147, 179) };
        }
    }
}
