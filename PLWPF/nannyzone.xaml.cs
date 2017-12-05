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
    /// Interaction logic for nannyzone.xaml
    /// </summary>
    public partial class nannyzone : Window
    {
        private Nanny mo;
        IBL bl;
        public nannyzone()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
        }

        public nannyzone(Nanny mo)
        {
            this.mo = mo;
        }
    }
}
