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
                InitializeComponent();
                mystuff = new Dictionary<BE.Days, KeyValuePair<int, int>>();
                mystuff.Add(BE.Days.Sun, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Mon, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Tue, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Wed, new KeyValuePair<int, int>(0, 0));
                mystuff.Add(BE.Days.Thu, new KeyValuePair<int, int>(0, 0));
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.checkSunday.IsChecked == true)
            {
                mystuff[BE.Days.Sun] = new KeyValuePair<int, int>(Int32.Parse(startSunday.Text), Int32.Parse(endSunday.Text));
            }
            if (this.checkMonday.IsChecked == true)
            {
                mystuff[BE.Days.Mon] = new KeyValuePair<int, int>(Int32.Parse(startMonday.Text), Int32.Parse(endMonday.Text));
            }
            if (this.checkTuesday.IsChecked == true)
            {
                mystuff[BE.Days.Tue] = new KeyValuePair<int, int>(Int32.Parse(startTuesday.Text), Int32.Parse(endTuesday.Text));
            }
            if (this.checkWednesday.IsChecked == true)
            {
                mystuff[BE.Days.Wed] = new KeyValuePair<int, int>(Int32.Parse(startWednesday.Text), Int32.Parse(endWednesday.Text));
            }
            if (this.checkThursday.IsChecked == true)
            {
                mystuff[BE.Days.Thu] = new KeyValuePair<int, int>(Int32.Parse(startThursday.Text), Int32.Parse(endThursday.Text));
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
