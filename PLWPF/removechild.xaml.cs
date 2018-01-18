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
    /// Interaction logic for removechild.xaml
    /// </summary>
    public partial class removechild : Window
    {
        IBL bl;
        Child c;
        public removechild()
        {
            bl = factoryBL.get_bl();
            c = new Child();
            InitializeComponent();
            ID_c.ItemsSource = bl.getChildListAlone();
            ID_c.DisplayMemberPath = "FirstName";
        }

        private void ID_c_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = (Child)ID_c.SelectedValue;   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.removeChild(c);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
