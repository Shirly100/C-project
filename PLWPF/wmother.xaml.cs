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
        Mother mo;
        public wmother()
        {
            bl = factoryBL.get_bl();
            mo = new Mother();
            DataContext = mo;
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            addmother nex = new addmother();
            nex.ShowDialog();
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            removemother nex1 = new removemother();
            nex1.ShowDialog();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            updatemother nex3 = new updatemother();
            nex3.ShowDialog();
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }
    }
}
