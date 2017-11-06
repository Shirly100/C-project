using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;

namespace BL
{
    class IBL_imp: IBL
    {
        Idal mydal = FactoryDal.getDal();
        #region Nanny functions
        public void addNanny(Nanny n)
        {
            if (n.BirthDate.Year < 1900 || ((DateTime.Now.Year - n.BirthDate.Year) < 18))
            {
                throw new Exception("not aged enough");
            }
            
            mydal.addNanny(n);
        }
        public void removeNanny(Nanny n)
        {
            throw new NotImplementedException();
        }
        public void updateNanny(Nanny n)
        {
            throw new NotImplementedException();
        }
        public Nanny getNanny(long id)
        {
            throw new NotImplementedException();

        }
        public List<Nanny> getNannyList()
        {
            throw new NotImplementedException();

        }
        #endregion
        #region Mother functions
        public void addMother(Mother m)
        {
           
            mydal.addMother(m);
        }
        public void removeMother(Mother m)
        {
            mydal.removeMother(m);

        }
        public void updateMother(Mother m)
        {
            mydal.updateMother(m);

        }
        public Mother getMother(long id)
        {
            throw new NotImplementedException();
        }
        List<Mother> getMotherList()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Child functions
        public void addChild(Child c)
        {
            throw new NotImplementedException();
        }
        public void removeChild(Child c)
        {
            mydal.removeChild(c);
        }
        public void updateChild(Child c)
        {
            mydal.updateChild(c);
        }
        public Child getChild(long id)
        {
            throw new NotImplementedException();

        }
        public List<Child> getChildList(List<Mother> m)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region BankAccount functions
        public List<BankAccount> getBanksAccountList()
        {
            throw new NotImplementedException();
        }
        public List<string> getBanksNameList(List<BankAccount> a)
        {
             throw new NotImplementedException();
        }
        List<int> getBanksBrancheList(List<BankAccount> a)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Contract functions
        public void addContract(Contract c, List<Mother> m)
        {
            check_mother_and_nanny(c);
            checked_child_age(c,m);
            
        }

        public void checked_child_age(Contract c, List<Mother> m)
        {
            var v = mydal.getChildList( m).Where(t => t.ID_child == c.ID_child);
            if (v.Count() == 0)
                throw new Exception("the children is not existing in the system");
            float age = mydal.getChildList(m)[mydal.getChildList(m).FindIndex(t => t.ID_child == c.ID_child)].Age;
            if (age < 3)
            {
                throw new Exception("the child is too young");

            }
        }

        public void check_mother_and_nanny(Contract c)
        {
            var v = mydal.getMotherList().Where(t => t.ID == c.ID_mother);
            if (v.Count() == 0)
                throw new Exception("the mother is not existing in the system");
            var z = mydal.getNannyList().Where(t => t.ID == c.ID_nanny);
            if (z.Count() == 0)
                throw new Exception("the nanny id not existing in the system");
        }

        void removeContract(Contract c);//to do
        void updateContract(Contract c);//to do
        List<Contract> getContractList();//to do
        #endregion


        public static int Age( DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age;
        }
        List<Nanny> Nanny_For_Mother(Mother m)
        {
            List<Nanny> n = new List<Nanny>();
            char delimiter = '-';
            foreach (var item1 in m.WorkDays)
                foreach (var item2 in DS.DataSource.Nannies)
                    foreach (var item3 in item2.WorkDays)
                        if (item1.Key == item3.Key)
                        {
                            TimeSpan[] time = new TimeSpan[4];
                            int i = 0;
                            String[] motherTime = item1.Value.Split(delimiter);
                            String[] nannyTime = item3.Value.Split(delimiter);
                            foreach (var substring in motherTime)
                            {
                                time[i] = TimeSpan.Parse(substring);
                                i++;
                            }
                            foreach (var substring in nannyTime)
                            {
                                time[i] = TimeSpan.Parse(substring);
                                i++;
                            }
                            if (time[1] >= time[3] && time[2] <= time[4])
                                if(Age(item2.BirthDate)>18)
                                {
                                    n.Add(item2);
                                }


                        }
            return n;

        }


        List<Child> Children_without_Nanny(List<Child> c)
        {
            List<Child> noNanny = new List<Child>();
            foreach (var item1 in c)
                if (!(DS.DataSource.contracts.Any(contract => contract.ID_child == item1.ID_child)))
                {
                    noNanny.Add(item1);
                }
            return noNanny;
        }

        List<Nanny> Vactions_by_Ministry_of_Economy_and_Industry(List<Nanny> n)
        {
            List<Nanny> vactions = new List<Nanny>();
            foreach (var item in n)
                if (item.Ministry_Of_Economy_and_Industry_Vactions)
                    vactions.Add(item);
            return vactions;
        }
        /*public IEnumerable<Contract> all_contract_by_condition(Func<Contract, bool> function = null)??
        {
            IEnumerable<Contract> a = dal.getContractList().Where(t => (function(t)));
            return a;
        }*/
    }
}
