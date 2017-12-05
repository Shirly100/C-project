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
using BE;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for wmother.xaml
    /// </summary>
    public partial class wmother : Window
    {
        IBL bl;
        public wmother()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            wcontract nex = new wcontract();
            nex.ShowDialog();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            wnanny nex1 = new wnanny();
            nex1.ShowDialog();
        }
        private void Show(object sender, RoutedEventArgs e)
        {
            wmother nex2 = new wmother();
            nex2.ShowDialog();
        }
        private void Update(object sender, RoutedEventArgs e)
        {
            wchild nex3 = new wchild();
            nex3.ShowDialog();
        }

        private void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    long s = Int64.Parse(tb.Text);
                    Mother mo = bl.getMother(s);
                    motherzone nex3 = new motherzone(mo);
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
