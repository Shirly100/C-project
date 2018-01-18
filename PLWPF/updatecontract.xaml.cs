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
    /// Interaction logic for updatecontract.xaml
    /// </summary>
    public partial class updatecontract : Window
    {
        IBL bl;
        Contract temp_con;
        public updatecontract()
        {
            bl = factoryBL.get_bl();
            InitializeComponent();
            temp_con = new Contract();
            choose.ItemsSource = bl.getContractList();
            choose.DisplayMemberPath = "ContractID";
            DataContext = temp_con;
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((DateTime)started_WorkingDatePicker.SelectedDate) > ((DateTime)end_WorkingDatePicker.SelectedDate))
                {
                    started_WorkingDatePicker.BorderBrush = Brushes.Red;
                    end_WorkingDatePicker.BorderBrush = Brushes.Red;
                    throw new Exception("INCORRECT DATES");
                }

                else if ((started_WorkingDatePicker.SelectedDate) > (DateTime.Now))
                {
                    started_WorkingDatePicker.BorderBrush = Brushes.Red;
                    throw new Exception("INCORRECT DATE");
                }
                
                bl.updateContract(temp_con);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void started_WorkingDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_con.StartDate = ((DateTime)started_WorkingDatePicker.SelectedDate).ToLongDateString();
        }

        private void end_WorkingDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_con.EndDate = ((DateTime)end_WorkingDatePicker.SelectedDate).ToLongDateString();
        }

        private void choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp_con = (Contract)choose.SelectedItem;
        }
    }
}
