using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        MainWindow main = new MainWindow();
        public EditItems()
        {
            InitializeComponent();

            for (int i = 0; i <= 10; i++)
            {
                kaubanimi.Items.Add(i);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kuupaev.Text = MainWindow.inv.Kuupaev.ToString("dd.mm.yyyy");
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

        private void Updtitembtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                main.con.Open();
                main.cmd = new SqlCommand("UPDATE [Inventuur] SET Kuupaev = @Kuupaev,Toode = @Toode,Kood = @Kood,Kaub = @Kaub,KaubKood = @KaubKood,TK = @TK,OstuHind = @OstuHind,HindTK = @HindTK,Summa = @Summa,PuhasKasum = @PuhasKasum,Omakasutus = @Omakasutus,JaatTK = @JaatTK,JaakSumma = @JaakSumma,MuugiSumma = @MuugiSumma WHERE Id = " + MainWindow.ID+"", main.con);
                main.cmd.Parameters.AddWithValue("@Kuupaev", Convert.ToDateTime(kuupaev.Text));
                main.cmd.Parameters.AddWithValue("@Toode", toodenimi.Text);
                main.cmd.Parameters.AddWithValue("@Kood", kood.Text);
                main.cmd.Parameters.AddWithValue("@Kaub", kaubanimi.SelectedValue);
                main.cmd.Parameters.AddWithValue("@KaubKood", kaubakood.Text);
                main.cmd.Parameters.AddWithValue("@TK", Convert.ToInt32(tk.Text));
                main.cmd.Parameters.AddWithValue("@OstuHind", Convert.ToInt32(ostuhind.Text));
                main.cmd.Parameters.AddWithValue("@HindTK", Convert.ToInt32(hindtk.Text));
                main.cmd.Parameters.AddWithValue("@Summa", Convert.ToInt32(tk.Text) * Convert.ToInt32(hindtk.Text));
                main.cmd.Parameters.AddWithValue("@PuhasKasum", Convert.ToInt32(puhaskasum.Text));
                main.cmd.Parameters.AddWithValue("@Omakasutus", Convert.ToInt32(omakastus.Text));
                main.cmd.Parameters.AddWithValue("@JaatTK", Convert.ToInt32(jaaktk.Text));
                main.cmd.Parameters.AddWithValue("@JaakSumma", Convert.ToInt32(hindtk.Text) * Convert.ToInt32(jaaktk.Text));
                main.cmd.Parameters.AddWithValue("@MuugiSumma", Convert.ToInt32(muugisumma.Text));
                main.cmd.ExecuteNonQuery();
                main.con.Close();
                //add clear textblock and messagebox or somethning else

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error insert into!", MessageBoxButton.OK, MessageBoxImage.Error);
                main.con.Close();
            }
        }

        private void Clearitemsbtn_Click(object sender, RoutedEventArgs e)
        {
            kuupaev.Text = System.DateTime.Now.ToString();
            toodenimi.Clear();
            kood.Clear();
            kaubanimi.SelectedValue = "0";
            kaubakood.Clear();
            tk.Clear();
            ostuhind.Clear();
            hindtk.Clear();
            summa.Text = "0";
            puhaskasum.Clear();
            omakastus.Clear();
            jaaktk.Clear();
            jaaksumma.Text = "0";
            muugisumma.Clear();
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(toodenimi.Text) && string.IsNullOrWhiteSpace(kood.Text))
            {
                this.Close();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you want cancel?", "Cancel edit", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    //main.con.Close();
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            
        }
    }
}
