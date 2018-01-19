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

        private void address_Click(object sender, RoutedEventArgs e)
        {
            var w = new winAddress();
            bool? addre = w.ShowDialog();
            if (addre != false)
            {
                temp_m.Address = w.ad;
            }
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            addChildMother w2 = new addChildMother(temp_m);
            bool? really = w2.ShowDialog();
            if (really != false)
            {
                temp_m.myChildren.Add(w2.tempc);
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

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (temp_m.ID > 0 && temp_m.FirstName.Length>1 && temp_m.LastName.Length > 1)
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
            else
            {
                MessageBox.Show("Please fill all feilds correctly");
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
