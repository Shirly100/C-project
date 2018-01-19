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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for grouping.xaml
    /// </summary>
    public partial class grouping : Window
    {
        IBL bl;
        public grouping()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
        }

        private void GroupCont_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserControlContract uc = new UserControlContract();
                Console.WriteLine("in click");
                uc.Source = bl.Contracts_by_Children_Ages();
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
