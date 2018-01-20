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
    /// Interaction logic for grouping.xaml
    /// </summary>
    public partial class grouping : Window
    {
        IBL bl;
        public grouping()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
        }

        private void GroupCont_Click(object sender, RoutedEventArgs e)
        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {
                UserControlContract uc = new UserControlContract();
                Console.WriteLine("in click");
                uc.Source = bl.Contracts_by_Children_Ages(order);
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupNan_Click(object sender, RoutedEventArgs e)
        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {
                UserControlNannyAddress uc = new UserControlNannyAddress();
                Console.WriteLine("in click");
                uc.Source = bl.Nannies_by_address(order);
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupNanAge_Click(object sender, RoutedEventArgs e)
        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {
                UserControlNanniesAge uc = new UserControlNanniesAge();
                Console.WriteLine("in click");
                uc.Source = bl.Nannies_by_Children_Ages(order);
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupNanNum_Click(object sender, RoutedEventArgs e)
        {
            bool order = false;
            if (this.checkBox.IsChecked == true)
            {
                order = true;
            }
            try
            {
                UserControlNanniesNum uc = new UserControlNanniesNum();
                Console.WriteLine("in click");
                uc.Source = bl.Nanny_by_num_children(order);
                this.page.Content = uc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
