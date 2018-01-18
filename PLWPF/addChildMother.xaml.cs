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
    /// Interaction logic for addChildMother.xaml
    /// </summary>
    public partial class addChildMother : Window
    {
        IBL bl;
        public Child tempc;
        Mother tmother;
        public addChildMother(Mother m)
        {
            bl = factoryBL.get_bl();
            tempc = new Child();
            tmother = m;
            InitializeComponent();
            DataContext = tempc;
        }

        private void started_DateDatePicker_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            tempc.BirthDate = started_DateDatePicker.SelectedDate.ToString();
            tempc.Age = DateTime.Today.Month - started_DateDatePicker.SelectedDate.Value.Month;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (tempc.ID_child > 0 && tempc.ID_Mother > 0)
            {
                    Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
        }
    }
}
