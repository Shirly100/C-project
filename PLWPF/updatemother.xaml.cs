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
    /// Interaction logic for updatemother.xaml
    /// </summary>
    public partial class updatemother : Window
    {
        IBL bl;
        Mother m;
        public updatemother()
        {
            bl = factoryBL.get_bl();
            m = new Mother();
            DataContext = m;
            InitializeComponent();
            motherc.ItemsSource = bl.getMotherList();
            motherc.DisplayMemberPath = "str";
        }

        private void address_Click(object sender, RoutedEventArgs e)
        {
            winAddress w = new winAddress();
            bool? addre = w.ShowDialog();
            if (addre != false)
            {
                m.Address = w.ad;
            }
        }

        private void bank_Click(object sender, RoutedEventArgs e)
        {
            winBank w1 = new winBank();
            bool? ban = w1.ShowDialog();
            if (ban != false)
            {
                m.BankAccount = w1.ba;
            }
        }

        //maybe make a specified window
        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            addChildMother w2 = new addChildMother(m);
            bool? really = w2.ShowDialog();
            if (really != false)
            {
                m.myChildren.Add(w2.tempc);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (m.ID > 0 && m.FirstName.Length > 1 && m.LastName.Length > 1)
            {
                try
            {               
                bl.updateMother(m);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
            else
            {
                MessageBox.Show("Please fill all feilds correctly");
            }
        }

        private void motherc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m.ID = ((Mother)motherc.SelectedValue).ID;
        }
    }
}
