using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace TutorHelper.View
{
    /// <summary>
    /// Interaction logic for Groups.xaml
    /// </summary>
    public partial class Groups : UserControl
    {
        public Groups()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //PrintDialog pd = new PrintDialog();
            // if (pd.ShowDialog() == true)
            // {
            //     IDocumentPaginatorSource idp = docReport;
            //    pd.PrintDocument(idp.DocumentPaginator, "Report");
            // }

            PrintDialog pDialog = new PrintDialog();
            var printers = new LocalPrintServer().GetPrintQueues();
            var selectedPrinter = printers.FirstOrDefault(p => p.Name == "Microsoft Print to PDF");
            if (selectedPrinter == null)
            {
                MessageBox.Show("Printer not found!");
                return;
            }
            
            pDialog.PrintQueue = selectedPrinter;

            pDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;

            IDocumentPaginatorSource idp = docReport;
            pDialog.PrintDocument(idp.DocumentPaginator, "Report");


        }
    }
}
