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
            child_combo.ItemsSource = from m in bl.getMotherList()
                                      select String.Concat(m.FirstName,' ',m.LastName);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempc.FirstName = (name.Text);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string c = id.Text;
            tempc.ID_child = (long)Convert.ToDouble(c);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = ((Mother)child_combo.SelectedItem);
            tempc.ID_Mother = m.ID;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tempc.SpecialNeeds = true;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            tempc.Allergies = true;
        }

        private void started_DateDatePicker_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            tempc.BirthDate = started_DateDatePicker.SelectedDate.ToString();
            tempc.Age = DateTime.Today.Month - started_DateDatePicker.SelectedDate.Value.Month;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
    }
}
