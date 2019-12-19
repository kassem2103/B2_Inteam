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

namespace WPFUI.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();


        }


        private void GridBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); // Macht dass sich das Fenster bewegen kann
        }

        //Zum Maximieren des Fensters
        public void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Zum minimieren des Fensters
        public void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
             WindowState = WindowState.Minimized;
        }


    }
}
