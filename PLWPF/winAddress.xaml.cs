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
        }

        private void address_Click(object sender, RoutedEventArgs e)
        {
            ad.Country = state.Text;
            ad.City = city.Text;
            ad.Street = street.Text;
            ad.ZipCode = zip.Text;
            ad.Floor = Convert.ToInt32(floor.Text);
            ad.HouseNumber = Convert.ToInt32(num.Text);
            this.Close();
        }
    }
}
