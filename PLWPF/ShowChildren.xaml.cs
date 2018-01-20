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
    /// Interaction logic for ShowChildren.xaml
    /// </summary>
    public partial class ShowChildren : Window
    {
        IBL bl;
        public ShowChildren()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
            this.listView.ItemsSource = bl.getChildListAlone();
            
        }
    }
}
