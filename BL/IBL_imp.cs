using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using DAL;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi;

namespace BL
{
    class IBL_imp : IBL
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
        public List<Mother> getMotherList()
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
        public List<int> getBanksBrancheList(List<BankAccount> a)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Contract functions
        public void salary(Contract c)
        {
            float hourly = getNanny(c.ID_nanny).HourlyRate;
            float monthly = getNanny(c.ID_nanny).MonthlyRate;
            int numOfChildren = getMother(c.ID_mother).myChildren.Count();
            c.Wages_per_hours = (hourly / 100) * (100 - numOfChildren * 2);
            c.Wages_per_months = (monthly / 100) * (100 - numOfChildren * 2);
        }
        public void addContract(Contract c)
        {
            addContract(c, mydal.getMother(c.ID_mother));
        }

        public void addContract(Contract c,Mother m)
        {
            try
            {
                check_mother_and_nanny(c);
                check_child_age(m);
                if (getNanny(c.ID_nanny).numOfChildren >= getNanny(c.ID_nanny).MaxNumOfChildren)
                    throw new Exception("Nanny have reached the maximum number of children alowed");
                getNanny(c.ID_nanny).numOfChildren += 1;
                salary(c);
                dist(c);
                mydal.addContract(c);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void dist(Contract c)
        {
            string ad = mydal.getMother(c.ID_mother).Address.ToAddress();
            string nan = mydal.getNanny(c.ID_nanny).Address.ToAddress();
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = ad,
                Destination = nan
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            c.distance = leg.Distance.Value;
        }

        public void check_child_age(Mother m)
        {
            var v = m.myChildren;
            if (v.Count() == 0)
                throw new Exception("the children is not existing in the system");
            foreach (Child ch in v)
            {
                if (ch.Age < 3)
                {
                    throw new Exception("the child is too young");
                }
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

        public void removeContract(Contract c)
        { }
        public void updateContract(Contract c)
        { }
        public List<Contract> getContractList() => DataSource.contracts;
        #endregion

        public List<Nanny> Nanny_In_Range(Mother m)
        {
            List<Nanny> ans = new List<Nanny>();
            string ad = m.Address.ToAddress();
            foreach (Nanny n in DataSource.Nannies)
            {
                string nan = n.Address.ToAddress();
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = TravelMode.Walking,
                    Origin = ad,
                    Destination = nan
                };
                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                Leg leg = route.Legs.First();
                if (leg.Distance.Value <= m.Range) ans.Add(n);
            }
            return ans;
        }

        public int Age( DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age;
        }
        public List<Nanny> Nanny_For_Mother(Mother m)
        {
            List<Nanny> n = new List<Nanny>();
            foreach (var item1 in DS.DataSource.Nannies)
            {
                bool flag = true;
                foreach (var d in m.WorkDays)
                {
                    if (item1.WorkDays.ContainsKey(d.Key))
                    {
                        if (!((d.Value.Key >= item1.WorkDays[d.Key].Key) && (d.Value.Value <= item1.WorkDays[d.Key].Value)))
                        {
                            flag = false;
                            break;
                        }
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    n.Add(item1);
            }
            return n;

        }


        public List<Child> Children_without_Nanny(List<Child> c)
        {
            List<Child> noNanny = new List<Child>();
            foreach (var item1 in c)
                if (!(DS.DataSource.contracts.Any(contract => contract.ID_child == item1.ID_child)))
                {
                    noNanny.Add(item1);
                }
            return noNanny;
        }

        public List<Nanny> Vactions_by_Ministry_of_Economy_and_Industry(List<Nanny> n)
        {
            List<Nanny> vactions = new List<Nanny>();
            foreach (var item in n)
                if (item.Ministry_Of_Economy_and_Industry_Vactions)
                    vactions.Add(item);
            return vactions;
        }
        public IEnumerable<Contract> all_contract_by_condition(Func<Contract, bool> function = null)
        {
            IEnumerable<Contract> a = mydal.getContractList().Where(t => (function(t)));
            return a;
        }


        
        public int num_of_contract_by_condition(Func<Contract, bool> function = null)
        {
            IEnumerable<Contract> a = mydal.getContractList().Where(t => (function(t)));
            return a.Count();
        }


        public IEnumerable<IGrouping<int, Nanny>> Nannies_by_Children_Ages(bool b = false)
        {
            var temp = mydal.getNannyList().GroupBy(a => a.minAge);
            if(b)
            {
                temp.OrderBy(c => c.Key);
            }
            return temp; 
        }
        public IEnumerable<IGrouping<string, Nanny>> Nannies_by_address(bool b = false)
        {
            var temp = mydal.getNannyList().GroupBy(a => a.Address.City);
            if (b)
            {
                temp.OrderBy(c => c.Key);
            }
            return temp;
        }
        public IEnumerable<IGrouping<float, Nanny>> Ages_of_Children_with_Nanny(bool b = false)
        {
            var temp = mydal.getNannyList().GroupBy(a => a.MinAgeOfChild);
            if (b)
            {
                temp.OrderBy(c => c.Key);
            }
            return temp;
        }
        public IEnumerable<IGrouping<int, Contract>> Distance_Nanny_and_Child(bool b = false)
        {
            var temp = mydal.getContractList().GroupBy(a => a.distance);
            if (b)
            {
                temp.OrderBy(c => c.Key);
            }
            return temp;
        }
    }
}
