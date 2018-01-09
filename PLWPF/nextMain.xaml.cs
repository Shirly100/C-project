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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for nextMain.xaml
    /// </summary>
    public partial class nextMain : Window
    {
        IBL bl;
        public nextMain()
        {
            bl = factoryBL.get_bl();
            //init();
            InitializeComponent();
        }
        private void Contract(object sender, RoutedEventArgs e)
        {
            wcontract nex = new wcontract();
            nex.ShowDialog();
        }
        private void Nanny(object sender, RoutedEventArgs e)
        {
            wnanny nex1 = new wnanny();
            nex1.ShowDialog();
        }
        private void Mother(object sender, RoutedEventArgs e)
        {
            wmother nex2 = new wmother();
            nex2.ShowDialog();
        }
        private void Child(object sender, RoutedEventArgs e)
        {
            wchild nex3 = new wchild();
            nex3.ShowDialog();
        }


        //adding entities to database
        private void init()
        {
            Mother m = new Mother
            {
                Address = new Address { City = "Jerusalem", Street = "Beit Hadefus", HouseNumber = 7, Country = "Israel", Floor = 1, ZipCode = "zip" },
                ID = 123,
                FirstName = "Chany",
                LastName = "Cohen",
                Age = 25,
                Pelephone = "03455666",
                WorkDays = new Dictionary<BE.Days, KeyValuePair<int, int>>()
            {
                {BE.Days.Sun, new KeyValuePair<int, int>(12,14 )},
                {BE.Days.Mon, new KeyValuePair<int, int>(12,14 )},
                {BE.Days.Tue, new KeyValuePair<int, int>(12,14 )},
                {BE.Days.Wed, new KeyValuePair<int, int>(12,14 )}
             },
                Range = 50,
                BankAccount = new BankAccount { AccountNumber = 100, Balance = 10000, BankName = "Leumi", BankNumber = 22, BranchAddress = new Address { City = "Jerusalem", Street = "Beit Hadefus", HouseNumber = 7, Country = "Israel", Floor = 1, ZipCode = "zip" }, BranchNumber = 65 },

            };
            Mother mmm = new Mother
            {
                Address = new Address { City = "Jerusalem", Street = "Ben Tzvi", HouseNumber = 17, Country = "Israel", Floor = 1, ZipCode = "zip" },
                ID = 124,
                FirstName = "Shirly",
                LastName = "Cohen",
                Age = 29,
                Pelephone = "0345566456",
                WorkDays = new Dictionary<BE.Days, KeyValuePair<int, int>>()
            {
                {BE.Days.Sun, new KeyValuePair<int, int>(12,14 )},
                {BE.Days.Mon, new KeyValuePair<int, int>(12,14 )},
                {BE.Days.Tue, new KeyValuePair<int, int>(12,14 )},
                {BE.Days.Wed, new KeyValuePair<int, int>(12,14 )}
             },
                Range = 1000,
                BankAccount = new BankAccount { AccountNumber = 110, Balance = 10000, BankName = "Leumi", BankNumber = 22, BranchAddress = new Address { City = "Jerusalem", Street = "Beit Hadefus", HouseNumber = 7, Country = "Israel", Floor = 1, ZipCode = "zip" }, BranchNumber = 65 },

            };
            Nanny nanny = new Nanny
            {
                ID = 2243,
                FirstName = "rivi",
                LastName = "bar",
                Age = 20,
                BankAccount = new BankAccount { AccountNumber = 200, Balance = 10, BankName = "Leumi", BankNumber = 22, BranchAddress = new Address { City = "Jerusalem", Street = "Beit Hadefus", HouseNumber = 7, Country = "Israel", Floor = 1, ZipCode = "zip" }, BranchNumber = 65 },
                Address = new Address { City = "Jerusalem", Street = "Beit Hadefus", HouseNumber = 11, Country = "Israel", Floor = 1, ZipCode = "zip" },
                BirthDate = new DateTime(1995, 12, 26),
                ExperienceYears = 0,
                HourlyRate = 27,
                MaxNumOfChildren = 5,
                MinAgeOfChild = 2,
                MonthlyRate = 1000,
                Elevator = true,
                WorkDays = new Dictionary<BE.Days, KeyValuePair<int, int>>()
            {
                {BE.Days.Sun, new KeyValuePair<int, int>(8,14 )},
                {BE.Days.Mon, new KeyValuePair<int, int>(8,14 )},
                {BE.Days.Tue, new KeyValuePair<int, int>(8,14 )},
                {BE.Days.Wed, new KeyValuePair<int, int>(8,14 )}
             }
            };
            Nanny n = new Nanny
            {
                ID = 243,
                FirstName = "rivi2",
                LastName = "bar2",
                Age = 20,
                BankAccount = new BankAccount { AccountNumber = 200, Balance = 10, BankName = "Leumi", BankNumber = 22, BranchAddress = new Address { City = "Jerusalem", Street = "Beit Hadefus", HouseNumber = 7, Country = "Israel", Floor = 1, ZipCode = "zip" }, BranchNumber = 65 },
                Address = new Address { City = "Jerusalem", Street = "Beit Hadefus", HouseNumber = 11, Country = "Israel", Floor = 1, ZipCode = "zip" },
                BirthDate = new DateTime(1995, 12, 26),
                ExperienceYears = 0,
                HourlyRate = 27,
                MaxNumOfChildren = 5,
                MinAgeOfChild = 2,
                MonthlyRate = 1000,
                Elevator = true,
                WorkDays = new Dictionary<BE.Days, KeyValuePair<int, int>>()
            {
                {BE.Days.Sun, new KeyValuePair<int, int>(13,14 )},
                {BE.Days.Mon, new KeyValuePair<int, int>(13,14 )},
                {BE.Days.Tue, new KeyValuePair<int, int>(13,14 )},
                {BE.Days.Wed, new KeyValuePair<int, int>(13,14 )}
             }
            };
            Child ch = new Child
            {
                Age = 3.5F,
                Allergies = false,
                BirthDate = "01/08/2017",
                FirstName = "Leiky",
                ID_child = 1234,
                ID_Mother = 123,
                SpecialNeeds = true
            };

            Child chhh = new Child
            {
                Age = 3.5F,
                Allergies = false,
                BirthDate = "01/08/2017",
                FirstName = "Chany",
                ID_child = 1235,
                ID_Mother = 124,
                SpecialNeeds = true
            };
            Contract cccc = new Contract
            {
                ContractID = 100,
                ID_child = ch.ID_child,
                ID_nanny = n.ID,
                ID_mother = m.ID,
                StartDate = "15/11/2017"
            };
            Contract c = new Contract
            {
                ContractID = 100,
                ID_child = ch.ID_child,
                ID_nanny = n.ID,
                ID_mother = m.ID,
                StartDate = "15/10/2017"
            };
            factoryBL.get_bl().addMother(m);
            factoryBL.get_bl().addMother(mmm);
            factoryBL.get_bl().addNanny(nanny);
            factoryBL.get_bl().addNanny(n);
            factoryBL.get_bl().addChild(ch);
            factoryBL.get_bl().addChild(chhh);
            factoryBL.get_bl().addContract(cccc);
            factoryBL.get_bl().addContract(c);
        }
    }
}