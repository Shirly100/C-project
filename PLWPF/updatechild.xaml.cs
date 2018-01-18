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
    /// Interaction logic for updatechild.xaml
    /// </summary>
    public partial class updatechild : Window
    {
        IBL bl;
        Child c;
        public updatechild()
        {
            bl = factoryBL.get_bl();
            c = new Child();
            InitializeComponent();
            id_choise.ItemsSource = bl.getChildListAlone();
            id_choise.DisplayMemberPath = "FirstName";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = ((Child)id_choise.SelectedValue);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.FirstName = name.Text;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            c.SpecialNeeds = true;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            c.Allergies = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateChild(c);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void started_DateDatePicker_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            c.BirthDate = started_DateDatePicker.SelectedDate.ToString();
            c.Age = DateTime.Today.Month - started_DateDatePicker.SelectedDate.Value.Month;
        }
    }
}
