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
using System.ComponentModel;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for chooseNanny.xaml
    /// </summary>
    public partial class chooseNanny : Window, INotifyPropertyChanged
    {
        IBL bl;
        public Nanny n;
        public long nID;
        Mother m;
        public chooseNanny(Mother mom)
        {
            m = mom;
            n = new Nanny();
            bl = factoryBL.get_bl();
            IsChecked = false;
            DataContext = this;
            InitializeComponent();
            nannies.ItemsSource = bl.getNannyList();
            nannies.DisplayMemberPath = "str";
        }
        private Boolean _IsChecked;

        //Bind this to your checkbox
        public Boolean IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked != value)
                {
                    _IsChecked = value;
                    OnPropertyChanged("IsChecked");  // To notify when the property is changed
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void age_Checked(object sender, RoutedEventArgs e)
        {
            IsChecked = !IsChecked;
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            n = (Nanny)nannies.SelectedItem;
            nID = n.ID;
            Console.WriteLine(nID);
            this.Close();
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            bool? voc = vocations.IsChecked;
            bool? ran = range.IsChecked;
            bool ran1 = false;
            bool voc1 = false;
            if (voc != false)
                voc1 = true;
            if (ran != false)
                ran1 = true;
            nannies.ItemsSource = bl.Nanny_For_Mother_all(m, ran1, voc1);
        }
    }
}
