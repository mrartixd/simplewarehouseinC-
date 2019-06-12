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
using System.Data.Sql;

namespace lkartladu
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Aboutbnt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("LKart OÜ Ladu Version 0.01b","About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Additembtn_Click(object sender, RoutedEventArgs e)
        {
            AddItems winadditems = new AddItems();
            winadditems.Show();
        }

        private void Edititembtn_Click(object sender, RoutedEventArgs e)
        {
            EditItems wineditItems = new EditItems();
            wineditItems.Show();
        }

        private void Sellitembtn_Click(object sender, RoutedEventArgs e)
        {
            SellItem winsellitem = new SellItem();
            winsellitem.Show();
        }

        private void Setingsbtn_Click(object sender, RoutedEventArgs e)
        {
            Settings winsettings = new Settings();
            winsettings.Show();
        }
    }
}
