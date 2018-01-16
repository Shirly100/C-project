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
    /// Interaction logic for updatenanny.xaml
    /// </summary>
    public partial class updatenanny : Window
    {
        IBL bl;
        Nanny temp_n;
        List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public updatenanny()
        {
            bl = factoryBL.get_bl();
            temp_n = new Nanny();
            DataContext = temp_n;
            InitializeComponent();
            exper.ItemsSource = nums;
            num_child.ItemsSource = nums;
            motherc.ItemsSource =  from m in bl.getNannyList() 
                                  select String.Concat(m.FirstName, ' ', m.LastName);
        }

        private void firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp_n.FirstName = firstname.Text;
        }

        private void LasrName_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp_n.LastName = LasrName.Text;
        }

        private void Telephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp_n.Pelephone = Telephone.Text;
        }

        private void address_Click(object sender, RoutedEventArgs e)
        {
            winAddress w = new winAddress();
            bool? addre = w.ShowDialog();
            if (addre != false)
            {
                temp_n.Address = w.ad;
            }
        }

        private void bank_Click(object sender, RoutedEventArgs e)
        {
            winBank w1 = new winBank();
            bool? ban = w1.ShowDialog();
            if (ban != false)
            {
                temp_n.BankAccount = w1.ba;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateNanny(temp_n);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hours_Click(object sender, RoutedEventArgs e)
        {

            EditScheduale editSchedule = new EditScheduale();
            bool? result = editSchedule.ShowDialog();
            if (result != false)
            {
                temp_n.WorkDays = editSchedule.MyDictionary;
            }

        }


        private void elevate_Checked(object sender, RoutedEventArgs e)
        {
            temp_n.Elevator = true;
        }

        private void exper_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_n.ExperienceYears = Convert.ToInt32(exper.SelectedValue);
        }

        private void num_child_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_n.MaxNumOfChildren = (int)num_child.SelectedItem;
        }

        private void motherc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_n = (Nanny)motherc.SelectedItem;
        }
    }
}
