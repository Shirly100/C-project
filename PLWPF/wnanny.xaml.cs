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
    /// Interaction logic for wnanny.xaml
    /// </summary>
    public partial class wnanny : Window
    {
        IBL bl;
        public wnanny()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            addnanny nex = new addnanny();
            nex.ShowDialog();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            removenanny nex1 = new removenanny();
            nex1.ShowDialog();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            updatenanny nex3 = new updatenanny();
            nex3.ShowDialog();
        }

        private void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    long s = Int64.Parse(tb.Text);
                    Nanny mo = bl.getNanny(s);
                    nannyzone nex3 = new nannyzone(mo);
                    nex3.ShowDialog();
                }
                catch (Exception exep)
                {
                    Console.WriteLine("not a valid id");
                    Console.WriteLine(exep.Message);
                }

            }
        }
    }
}
