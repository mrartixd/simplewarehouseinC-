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
        SqlCommand cmd;
        const string connecttodb = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\artix\source\repos\simplewarehouseinC-\lkartladu\Ladu.mdf;Integrated Security=True;";
        readonly SqlConnection con = new SqlConnection(connecttodb);


        public AddItems()
        {
            InitializeComponent();

            for (int i = 0; i <= 10; i++)
            {
                kaubanimi.Items.Add(i);
            }

            con.Open();

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
            cmd = new SqlCommand("INSERT INTO [Inventuur] (Kuupaev,Toode,Kood,Kaub,KaubKood,TK,OstuHind,HindTK,Summa,PuhasKasum,JaatTK,JaakSumma,MuugiSumma) VALUES (@Kuupaev,@Toode,@Kood,@Kaub,@KaubKood,@TK,@OstuHind,@HindTK,@Summa,@PuhasKasum,@JaatTK,@JaakSumma,@MuugiSumma)", con);
            cmd.Parameters.AddWithValue("@Kuupaev", DateTime.Now);
            cmd.Parameters.AddWithValue("@Toode", toodenimi.Text);
            cmd.Parameters.AddWithValue("@Kood", kood.Text);
            cmd.Parameters.AddWithValue("@Kaub", kaubanimi.SelectedValue);
            cmd.Parameters.AddWithValue("@KaubKood", kaubakood.Text);
            cmd.Parameters.AddWithValue("@TK", Convert.ToInt32(tk.Text));
            cmd.Parameters.AddWithValue("@OstuHind", Convert.ToInt32(ostuhind.Text));
            cmd.Parameters.AddWithValue("@HindTK", Convert.ToInt32(hindtk.Text));
            cmd.Parameters.AddWithValue("@Summa", Convert.ToInt32(tk.Text) * Convert.ToInt32(hindtk.Text));
            cmd.Parameters.AddWithValue("@PuhasKasum", Convert.ToInt32(puhaskasum.Text));
            cmd.Parameters.AddWithValue("@JaatTK", Convert.ToInt32(jaaktk.Text));
            cmd.Parameters.AddWithValue("@JaakSumma", Convert.ToInt32(hindtk.Text) * Convert.ToInt32(jaaktk.Text));
            cmd.Parameters.AddWithValue("@MuugiSumma", Convert.ToInt32(muugisumma.Text));
            cmd.ExecuteNonQuery();
           
        }
    }
}
