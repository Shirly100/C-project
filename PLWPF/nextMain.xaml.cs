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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for nextMain.xaml
    /// </summary>
    public partial class nextMain : Window
    {
        IBL bl;
        public nextMain()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
        }
        private void Contract(object sender, RoutedEventArgs e)
        {
            wcontract nex = new wcontract();
            nex.ShowDialog();
        }
        private void Nanny(object sender, RoutedEventArgs e)
        {
            wnanny nex1 = new wnanny();
            nex1.ShowDialog();
        }
        private void Mother(object sender, RoutedEventArgs e)
        {
            wmother nex2 = new wmother();
            nex2.ShowDialog();
        }
        private void Child(object sender, RoutedEventArgs e)
        {
            wchild nex3 = new wchild();
            nex3.ShowDialog();
        }

    }
}
