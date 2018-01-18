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
    /// Interaction logic for winAddress.xaml
    /// </summary>
    public partial class winAddress : Window
    {
        IBL bl;
        public Address ad;
        public winAddress()
        {
            bl = factoryBL.get_bl();
            ad = new Address();
            InitializeComponent();
            DataContext = ad;
        }

        private void address_Click(object sender, RoutedEventArgs e)
        {
            if (ad.City.Length >1 && ad.HouseNumber >0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
        }
    }
}
