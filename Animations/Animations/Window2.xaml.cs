using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Animations
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public Window2()
        {
            InitializeComponent();
        }
        PagePaths pagePaths;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            pagePaths = new PagePaths();
            this.Content = pagePaths;
            this.PreviewKeyDown += Window2_PreviewKeyDown;
        }

        private void Window2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            pagePaths.falaSerial.write("Z"); //shut off leds
            Application.Current.Shutdown(0);
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
