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
    /// Interaction logic for removenanny.xaml
    /// </summary>
    public partial class removenanny : Window
    {
        IBL bl;
        Nanny n;
        public removenanny()
        {
            bl = factoryBL.get_bl();
            n = new Nanny();
            InitializeComponent();
            choose.ItemsSource = bl.getNannyList();
            choose.DisplayMemberPath = "str";
        }

        private void choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            n = (Nanny)choose.SelectedItem;
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.removeNanny(n);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
