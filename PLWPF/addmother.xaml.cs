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
    ///Interaction logic for addmother.xaml
    /// </summary>
    public partial class addmother : Window
    {
        IBL bl;
        Mother temp_m;
        public addmother()
        {
            bl = factoryBL.get_bl();
            temp_m = new Mother();
            DataContext = temp_m;
            InitializeComponent();
        }

        private void firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp_m.FirstName = firstname.Text;
        }

        private void LasrName_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp_m.LastName = LasrName.Text;
        }

        private void id_TextChanged(object sender, TextChangedEventArgs e)
        {
            string i = id.Text;
            temp_m.ID = (long)Convert.ToDouble(i);
        }

        private void Telephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            temp_m.Pelephone = Telephone.Text;
        }

        private void address_Click(object sender, RoutedEventArgs e)
        {
            winAddress w = new winAddress();
            bool? addre = w.ShowDialog();
            if (addre != false)
            {
                temp_m.Address = w.ad;
            }
        }

        private void bank_Click(object sender, RoutedEventArgs e)
        {
            winBank w1 = new winBank();
            bool? ban = w1.ShowDialog();
            if (ban != false)
            {
                temp_m.BankAccount = w1.ba;
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
            temp_m.Range = (float)slider.Value;
        }

        private void b_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addMother(temp_m);
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
                temp_m.WorkDays = editSchedule.MyDictionary;
            }
            
        }
    }
}
