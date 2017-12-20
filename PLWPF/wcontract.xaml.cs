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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for wcontract.xaml
    /// </summary>
    public partial class wcontract : Window
    {
        public wcontract()
        {
            InitializeComponent();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            addcontract nex = new addcontract();
            nex.ShowDialog();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            removecontract nex1 = new removecontract();
            nex1.ShowDialog();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            updatecontract nex3 = new updatecontract();
            nex3.ShowDialog();
        }

    }
}
