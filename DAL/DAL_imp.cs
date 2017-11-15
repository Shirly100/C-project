using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class DAL_imp : Idal
    {
        #region Nanny functions
        public void addNanny(Nanny n)
        {
            int index = DataSource.Nannies.FindIndex(t => t.ID == n.ID);
            if (index != -1) throw new Exception("You are trying to add already-existing nanny");
            DataSource.Nannies.Add(n.NannyDeepClone());
        }
        public void removeNanny(Nanny n)
        {
            int index = DataSource.Nannies.FindIndex(t => t.ID == n.ID);
            if (index == -1) throw new Exception("this nanny is not exist");
            DataSource.Nannies.Remove(n);
        }
        public void updateNanny(Nanny n)
        {
            int index = DataSource.Nannies.FindIndex(t => t.ID == n.ID);
            if (index == -1) throw new Exception("You are trying to update non-existing nanny");
            DataSource.Nannies[index] = n;
        }
        public Nanny getNanny(long id)
        {
            int index = DataSource.Nannies.FindIndex(t => t.ID == id);
            if (index == -1) throw new Exception("this nanny is not exist");
            return DataSource.Nannies[index];
        }
        public List<Nanny> getNannyList() => DataSource.Nannies;
        #endregion
        #region Mother functions
        public void addMother(Mother m)
        {
            int index = DataSource.Mothers.FindIndex(t => t.ID == m.ID);
            if (index != -1) throw new Exception("You are trying to add already-existing mother");
            DataSource.Mothers.Add(m.MotherDeepClone());
        }
        public void removeMother(Mother m)
        {
            int index = DataSource.Mothers.FindIndex(t => t.ID == m.ID);
            if (index == -1) throw new Exception("this mother is not exist");
            DataSource.Mothers.Remove(m);
        }
        public void updateMother(Mother m)
        {
            int index = DataSource.Nannies.FindIndex(t => t.ID == m.ID);
            if (index == -1) throw new Exception("You are trying to update non-existing mother");
            DataSource.Mothers[index] = m;
        }
        public Mother getMother(long id)
        {
            int index = DataSource.Mothers.FindIndex(t => t.ID == id);
            if (index == -1) throw new Exception("this mother is not exist");
            return DataSource.Mothers[index];
        }
        public List<Mother> getMotherList() => DataSource.Mothers;

        public void addChildren(Child c)
        {
            bool flag = false;
            foreach (Mother item in DS.DataSource.Mothers)
            {
                if (item.ID == c.ID_Mother)
                {
                    item.myChildren.Add(c);
                    flag = true;
                    break;
                }
            }
            if (!flag) throw new Exception("You are  to add a child that is mother doesn't exist\n");
        }
        #endregion
        #region Child functions
        public void addChild(Child c)
        {
            bool flag = false;
            foreach (Child item in DS.DataSource.Children)
            {
                if (item.ID_child == c.ID_child)
                {
                    throw new Exception("You are trying to add already-existing child");
                }
            }
           foreach (Mother item1 in DS.DataSource.Mothers)
            {
                if (item1.ID == c.ID_Mother)
                {
                   item1.myChildren.Add(c);
                   flag = true;
                   break;
                 }
             }
            if (flag) DS.DataSource.Children.Add(c);
        }
        public void removeChild(Child c)
        {
            int index = DataSource.Children.FindIndex(t => t.ID_child == c.ID_child);
            if (index == -1) throw new Exception("this child is not exist");
            DataSource.Children.Remove(c);
        }
        public void updateChild(Child c)
        {
            int index = DataSource.Children.FindIndex(t => t.ID_child == c.ID_child);
            if (index == -1) throw new Exception("You are trying to update non-existing child");
            DataSource.Children[index] = c;
        }
        public Child getChild(long id)
        {
            int index = DataSource.Children.FindIndex(t => t.ID_child == id);
            if (index == -1) throw new Exception("this child is not exist");
            else return DataSource.Children[index];
        }
        public List<Child> getChildList(List<Mother> m)
        {
            List<Child> result = new List<Child>();
            foreach (Mother item1 in m)
            {
                foreach (Child i in item1.myChildren)
                    result.Add(i);
            }
            return result;
        }
        #endregion
        #region Contract functions
        public void addContract(Contract c)
        {
            foreach (var item in DS.DataSource.contracts)
            {
                if (item.ContractID == c.ContractID) throw new Exception("You are trying to add already-existing contract");
                DataSource.contracts.Add(c.ContractDeepClone());
                if (getNanny(c.ID_nanny).myChildren.IndexOf(getChild(c.ID_child)) == -1)
                    getNanny(c.ID_nanny).myChildren.Add(getChild(c.ID_child));
            }
        }
        public void removeContract(Contract c)
        {
            int index = DataSource.contracts.FindIndex(t => t.ContractID  == c.ContractID );
            if (index == -1) throw new Exception("this contract is not exist");
            DataSource.contracts.Remove(c);
        }
        public void updateContract(Contract c)
        {
            int index = DataSource.contracts.FindIndex(t => t.ContractID == c.ContractID );
            if (index == -1) throw new Exception("You are trying to update non-existing contract");
            DataSource.contracts[index] = c;
        }
        public List<Contract> getContractList() => DataSource.contracts;
        #endregion
        #region bank functions
        public List<BankAccount> getBanksAccountList()
        {
           List<BankAccount> accounts = new List<BankAccount>();
            BankAccount a = new BankAccount
            {
                BankNumber = 11,
                BankName = "Discount",
                BranchNumber = 516,
                BranchAddress = new Address
                {
                    HouseNumber = 5,
                    Floor = 1,
                    Street = "Derech Kedem",
                    City = "Maale Adumim",
                    ZipCode = "6111",
                    Country = "Israel"
                },
                AccountNumber=12345,
                Balance = 1000
            };
            accounts.Add(a);
            BankAccount b = new BankAccount
            {
                BankNumber = 11,
                BankName = "Discount",
                BranchNumber = 67,
                BranchAddress = new Address
                {
                    HouseNumber = 22,
                    Floor = 1,
                    Street = "Jafo",
                    City = "jerusalem",
                    ZipCode = "6565",
                    Country = "Israel"
                },
                AccountNumber = 145678,
                Balance = 1000             
            };
            accounts.Add(b);
            BankAccount c= new BankAccount
            {
                BankNumber = 12,
                BankName = "Bank Hpoalim",
                BranchNumber = 587,
                BranchAddress = new Address
                {
                    HouseNumber = 62,
                    Floor = 6,
                    Street = "Hashoshanim",
                    City = "Haifa",
                    ZipCode = "5678",
                    Country = "Israel"
                },
                AccountNumber = 876789,
                Balance = 1000
            };
            accounts.Add(c);
            BankAccount d = new BankAccount
            {
                BankNumber = 12,
                BankName = "Bank Hpoalim",
                BranchNumber = 705,
                BranchAddress = new Address
                {
                    HouseNumber = 76,
                    Floor = 1,
                    Street = "Herzel",
                    City = "Haifa",
                    ZipCode = "5678",
                    Country = "Israel"
                },
                AccountNumber = 8787,
                Balance =1000
            };
            accounts.Add(d);
            BankAccount e = new BankAccount
            {
                BankNumber = 12,
                BankName = "Leumi",
                BranchNumber = 98,
                BranchAddress = new Address
                {
                    HouseNumber = 76,
                    Floor = 1,
                    Street = "Havradim",
                    City = "Raanana",
                    ZipCode = "59878",
                    Country = "Israel"
                },
                AccountNumber = 4564321,
                Balance = 1000
            };
            accounts.Add(e);
            return accounts;
        }
    public List<string> getBanksNameList(List<BankAccount> a)
        {
            List<string> bank_names = new List<string>();
            foreach (var item in a)
                if (!bank_names.Contains(item.BankName))
                    bank_names.Add(item.BankName);
            return bank_names;
        }
        public List<int> getBanksBrancheList(List<BankAccount> a)
        {
            List<int> bank_branches = new List<int>();
            foreach (var item in a)
            {
                if (!bank_branches.Contains(item.BranchNumber))
                    bank_branches.Add(item.BranchNumber);
            }
            return bank_branches;
        }
        #endregion
    }
}



