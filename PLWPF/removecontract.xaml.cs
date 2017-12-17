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
    /// Interaction logic for removecontract.xaml
    /// </summary>
    public partial class removecontract : Window
    {
        IBL bl;
        Contract c;
        public removecontract()
        {
            bl = factoryBL.get_bl();
            c = new Contract();
            InitializeComponent();
            choose.ItemsSource = bl.getContractList();
        }

        private void choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = (Contract)choose.SelectedItem;
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.removeContract(c);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
