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
            motherc.ItemsSource = from m in bl.getMotherList()
                              select String.Concat(m.FirstName, ' ', m.LastName);
        }

        private void motherc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = (Mother)motherc.SelectedItem;
        }

        private void firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            m.FirstName = firstname.Text;
        }

        private void LasrName_TextChanged(object sender, TextChangedEventArgs e)
        {
            m.LastName = LasrName.Text;
        }

        private void Telephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            m.Pelephone = Telephone.Text;
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
            addchild w2 = new addchild();
            w2.ShowDialog();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            m.Range = (float)slider.Value;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //m = (Mother)motherc.SelectedItem;
                
                bl.updateMother(m);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
