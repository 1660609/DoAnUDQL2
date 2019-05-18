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

namespace TabMenu
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    GridMain.Background = Brushes.Aquamarine;
                    GridInfoAd.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    GridMain.Background = Brushes.Beige;
                    GridInfoAd.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    GridMain.Background = Brushes.CadetBlue;
                    GridInfoAd.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    GridMain.Background = Brushes.DarkBlue;
                    GridInfoAd.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    GridMain.Background = Brushes.Firebrick;
                    GridInfoAd.Visibility = Visibility.Collapsed;
                    break;
                case 5:
                    GridInfoAd.Visibility = Visibility.Visible;


                    break;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Login wd = new Login();
            wd.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonManager_Click(object sender, RoutedEventArgs e)
        {

        }


     
    
    }
}
