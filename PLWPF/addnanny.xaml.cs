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
    /// Interaction logic for addnanny.xaml
    /// </summary>
    public partial class addnanny : Window
    {
        IBL bl;
        Nanny temp_n;
        List<int> nums = new List<int> {1,2,3,4,5,6,7,8,9,10};
        public addnanny()
        {
            bl = factoryBL.get_bl();
            temp_n = new Nanny();
            DataContext = temp_n;
            InitializeComponent();
            exper.ItemsSource = nums ;
            num_child.ItemsSource = nums;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (temp_n.ID >1 && temp_n.FirstName.Length >1 && temp_n.LastName.Length >1)
            {
                try
                {
                    bl.addNanny(temp_n);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields correctly");
            }
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

        private void hours_Click(object sender, RoutedEventArgs e)
        {
            EditScheduale editSchedule = new EditScheduale();
            bool? result = editSchedule.ShowDialog();
            if (result != false)
            {
                temp_n.WorkDays = editSchedule.MyDictionary;
            }
        }

    }
}
