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
    /// Interaction logic for EditItems.xaml
    /// </summary>
    public partial class EditItems : Window
    {
        public EditItems()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kuupaev.Text = MainWindow.inv.Kuupaev;
            toodenimi.Text = MainWindow.inv.Toode;
            kood.Text = MainWindow.inv.Kood;
            kaubanimi.Text = MainWindow.inv.Kaub;
            kaubakood.Text = MainWindow.inv.KaubKood;
            tk.Text = MainWindow.inv.Tk;
            ostuhind.Text = MainWindow.inv.OstuHind;
            hindtk.Text = MainWindow.inv.HindTK;
            omakastus.Text = MainWindow.inv.Omakasutus;
            summa.Text = MainWindow.inv.Summa;
            puhaskasum.Text = MainWindow.inv.PuhasKasum;
            jaaktk.Text = MainWindow.inv.JaatTK;
            jaaksumma.Text = MainWindow.inv.JaakSumma;
            muugisumma.Text = MainWindow.inv.MuugSumma;
        }
    }
}
