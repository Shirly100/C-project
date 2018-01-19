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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for EditScheduale.xaml
    /// </summary>
    public partial class EditScheduale : Window
    {

            private Dictionary<BE.Days, KeyValuePair<int, int>> mystuff;

            public Dictionary<BE.Days, KeyValuePair<int, int>> MyDictionary
            {
                get { return mystuff; }
            }


            public EditScheduale()
            {  
                mystuff = new Dictionary<BE.Days, KeyValuePair<int, int>>();
                mystuff.Add(BE.Days.Sun, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Mon, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Tue, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Wed, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Thu, new KeyValuePair<int, int>(0, 0));
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.checkSunday.IsChecked == true)
                {
                    mystuff[BE.Days.Sun] = new KeyValuePair<int, int>(isInt(startSunday.Text), isInt(endSunday.Text));
                }
                if (this.checkMonday.IsChecked == true)
                {
                    mystuff[BE.Days.Mon] = new KeyValuePair<int, int>(isInt(startMonday.Text), isInt(endMonday.Text));
                }
                if (this.checkTuesday.IsChecked == true)
                {
                    mystuff[BE.Days.Tue] = new KeyValuePair<int, int>(isInt(startTuesday.Text), isInt(endTuesday.Text));
                }
                if (this.checkWednesday.IsChecked == true)
                {
                    mystuff[BE.Days.Wed] = new KeyValuePair<int, int>(isInt(startWednesday.Text), isInt(endWednesday.Text));
                }
                if (this.checkThursday.IsChecked == true)
                {
                    mystuff[BE.Days.Thu] = new KeyValuePair<int, int>(isInt(startThursday.Text), isInt(endThursday.Text));
                }
                this.DialogResult = true;
                this.Close();
            }
            catch(Exception xe)
            {
                MessageBox.Show("Please fill all fields correctly \n Only int accepted (HH/MM)");
            }
        }

        private int isInt(string s)
        {
            int res = 0;
            bool isSuccess = int.TryParse(s,out res);
            if (!isSuccess || s.Length != 4)
                throw new Exception("Not int");
            return res;
        }
    }
}
