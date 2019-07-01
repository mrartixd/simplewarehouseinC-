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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using lkartladu.Forms;

namespace lkartladu
{
    public partial class MainWindow : Window
    {
        //SQL Connection with SQLCommand
        public SqlCommand cmd;
        public readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["lkartladu.Properties.Settings.LaduConnectionString"].ConnectionString);
        public static SqlDataAdapter adpt;
        public static DataTable dt;
        public static Inventuur inv = new Inventuur();
        public static string ID;
         

        public MainWindow()
        {
            InitializeComponent();
            ShowData();
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

        public void ShowData()
        {
            try
            {
                con.Open();
                adpt = new SqlDataAdapter("SELECT * FROM [Inventuur]", con);
                dt = new DataTable();
                adpt.Fill(dt);
                rawdata.ItemsSource = dt.DefaultView;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error reading table!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Rawdata_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.Column.Header.ToString()== "dd")
            {
                e.Cancel = true;
            }
        }

        private void Rawdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            edititembtn.IsEnabled = true;
            deleteitem.IsEnabled = true;
            printbtn.IsEnabled = true;
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if(row_selected != null)
            {
                ID = row_selected["Id"].ToString();
                inv.Kuupaev = Convert.ToDateTime(row_selected["Kuupaev"].ToString());
                inv.Toode = row_selected["Toode"].ToString();
                inv.Kood = row_selected["Kood"].ToString();
                inv.Kaub = row_selected["Kaub"].ToString();
                inv.KaubKood = row_selected["KaubKood"].ToString();
                inv.Tk = row_selected["TK"].ToString();
                inv.OstuHind = row_selected["OstuHind"].ToString();
                inv.HindTK = row_selected["HindTK"].ToString();
                inv.Summa = row_selected["Summa"].ToString();
                inv.Omakasutus = row_selected["Omakasutus"].ToString();
                inv.PuhasKasum = row_selected["PuhasKasum"].ToString();
                inv.JaatTK = row_selected["JaatTK"].ToString();
                inv.JaakSumma = row_selected["JaakSumma"].ToString();
                inv.MuugSumma = row_selected["MuugiSumma"].ToString();
            }
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ShowData();
        }

        private void Deleteitem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm DELETE row", "Do you want delete?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM [Inventuur] WHERE Id=" + ID + "", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ShowData();
                    //add clear textblock and messagebox or somethning else
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error insert into!", MessageBoxButton.OK, MessageBoxImage.Error);
                    con.Close();
                }
            }
            else
            {
                return;
            }
           
        }

        private void Settingsbtn_Click(object sender, RoutedEventArgs e)
        {
            Settings winsettings = new Settings();
            winsettings.Show();
        }

        private void Rawdata_LostFocus(object sender, RoutedEventArgs e)
        {
            //edititembtn.IsEnabled = false;
            //deleteitem.IsEnabled = false;
        }

        private void Printbtn_Click(object sender, RoutedEventArgs e)
        {
            BillPage billPage = new BillPage();
            billPage.Show();
        }

        private void Repairitembtn_Click(object sender, RoutedEventArgs e)
        {
            Repair repair = new Repair();
            repair.Show();
        }
    }
}
