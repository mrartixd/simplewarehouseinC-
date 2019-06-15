using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddItems.xaml
    /// </summary>
    public partial class AddItems : Window
    {

        MainWindow main = new MainWindow();

        public AddItems()
        {
            InitializeComponent();

            for (int i = 0; i <= 10; i++)
            {
                kaubanimi.Items.Add(i);
            }
        }

        private void Clearitemsbtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Additembtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                main.con.Open();
                main.cmd = new SqlCommand("INSERT INTO [Inventuur] (Kuupaev,Toode,Kood,Kaub,KaubKood,TK,OstuHind,HindTK,Summa,PuhasKasum,Omakasutus,JaatTK,JaakSumma,MuugiSumma) VALUES (@Kuupaev,@Toode,@Kood,@Kaub,@KaubKood,@TK,@OstuHind,@HindTK,@Summa,@PuhasKasum,@Omakasutus,@JaatTK,@JaakSumma,@MuugiSumma)", main.con);
                main.cmd.Parameters.AddWithValue("@Kuupaev", kuupaev.Text);
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
                //add clear textblock and messagebox or somethning else
                main.ShowData();
                main.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error insert into!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.con.Close();
        }
    }
}
