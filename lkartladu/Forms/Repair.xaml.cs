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

namespace lkartladu.Forms
{
    /// <summary>
    /// Interaction logic for Repair.xaml
    /// </summary>
    public partial class Repair : Window
    {
        string seadetext;
        string laadijatext;
        string casetext;
        string complect;
        public Repair()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(chkseade.IsChecked == true)
            {
                complect = "seade: on \n";
            }
            else if (chkseade.IsChecked == false)
            {
                complect = "seade: ei ole \n";
            }
            if(chklaadija.IsChecked == true)
            {
                complect += "laadija: on \n";
            }
            else if (chklaadija.IsChecked == false)
            {
                complect += "laadija: ei ole \n";
            }
            if (chkkarp.IsChecked == true)
            {
                complect += "karp või kott: on \n";
            }
            else if (chkkarp.IsChecked == false)
            {
                complect += "karp või kott: ei ole \n";
            }
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pActNumber", DateTime.Now.ToString("ddMMyyHHmm")),
                new Microsoft.Reporting.WinForms.ReportParameter("pKlient", klient.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("pPhone", telefone.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("pDevice", seadme.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("pProblem", rike.Text),
                new Microsoft.Reporting.WinForms.ReportParameter("pComplect", complect + muu.Text),
            };
            _repairReport.LocalReport.ReportEmbeddedResource = "lkartladu.RepairReport.rdlc";
            _repairReport.LocalReport.SetParameters(p);
            _repairReport.RefreshReport();
        }
    }
}
