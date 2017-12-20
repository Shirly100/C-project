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
    /// Interaction logic for removemother.xaml
    /// </summary>
    public partial class removemother : Window
    {
        IBL bl;
        Mother m;
        public removemother()
        {
            bl = factoryBL.get_bl();
            m = new Mother();
            InitializeComponent();
            choose.ItemsSource = bl.getMotherList();
        }

        private void choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = (Mother)choose.SelectedItem;
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.removeMother(m);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
