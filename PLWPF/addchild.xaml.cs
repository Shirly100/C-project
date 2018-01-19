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
    /// Interaction logic for addchild.xaml
    /// </summary>
    public partial class addchild : Window
    {
        IBL bl;
        Child tempc;
        Mother m;
        public addchild()
        {
            bl = factoryBL.get_bl();
            tempc = new Child();
            m = new Mother();
            InitializeComponent();
            DataContext = tempc;
            child_combo.ItemsSource = bl.getMotherList();
            child_combo.DisplayMemberPath = "str";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = ((Mother)child_combo.SelectedItem);
            tempc.ID_Mother = m.ID;
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
                try
                {
                    bl.addChild(tempc);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
        }
    }
}
