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
    /// Interaction logic for winBank.xaml
    /// </summary>
    public partial class winBank : Window
    {
        List<string> Banks = new List<string> {"Leumi","Hapoalim","Discount","Massad"};
        List<string> branches = new List<string> {"Jerusalem","Bnei Brak","Tzfat","Tel Aviv" };
        IBL bl;
        public BankAccount ba;
        public winBank()
        {
            bl = factoryBL.get_bl();
            ba = new BankAccount();
            InitializeComponent();
            bank.ItemsSource = Banks;
            bran.ItemsSource = branches;
            DataContext = ba;
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            if (ba.AccountNumber >0 && ba.BankNumber >0 && ba.BranchNumber >0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
        }
    }
}
