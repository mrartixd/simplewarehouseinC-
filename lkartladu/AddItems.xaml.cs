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

namespace lkartladu
{
    /// <summary>
    /// Interaction logic for AddItems.xaml
    /// </summary>
    public partial class AddItems : Window
    {
        public AddItems()
        {
            InitializeComponent();
        }

        private void Clearitemsbtn_Click(object sender, RoutedEventArgs e)
        {
            nameitem.Clear();
            priceitem.Clear();
            firmaitem.Clear();
            priceitem.Clear();
            date.Clear();
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
