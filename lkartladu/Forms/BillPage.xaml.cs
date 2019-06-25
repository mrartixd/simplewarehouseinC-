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
using Microsoft.Reporting.WinForms;

namespace lkartladu.Forms
{
    /// <summary>
    /// Interaction logic for BillPage.xaml
    /// </summary>
    public partial class BillPage : Window
    {

        MainWindow main = new MainWindow();
        SqlDataAdapter adpt = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public BillPage()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            main.con.Open();
            adpt = new SqlDataAdapter("SELECT * FROM [Inventuur] WHERE Id="+MainWindow.ID, main.con);
            dt = new DataTable();
            adpt.Fill(dt);
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pBillID", MainWindow.ID.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pDate", MainWindow.inv.Kuupaev.ToString("MM/dd/yyyy")),
            };
            ReportDataSource ds1 = new ReportDataSource("DataSet1", dt);
            _reportViewer.LocalReport.DataSources.Add(ds1);
            _reportViewer.LocalReport.ReportEmbeddedResource = "lkartladu.Bill.rdlc";
            _reportViewer.LocalReport.SetParameters(p);
            _reportViewer.RefreshReport();
        }
    }
}
