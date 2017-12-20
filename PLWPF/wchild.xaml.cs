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
    /// Interaction logic for wchild.xaml
    /// </summary>
    public partial class wchild : Window
    {
        public wchild()
        {
            InitializeComponent();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            addchild nex = new addchild();
            nex.ShowDialog();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            removechild nex1 = new removechild();
            nex1.ShowDialog();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            updatechild nex3 = new updatechild();
            nex3.ShowDialog();
        }

    }
}
