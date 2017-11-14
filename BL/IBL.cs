using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Elevation.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.StaticMaps;
using GoogleMapsApi.StaticMaps.Entities;
using BE;

namespace BL
{
    public interface IBL
    {
        #region Nanny functions
        void addNanny(Nanny n);
        void removeNanny(Nanny n);
        void updateNanny(Nanny n);
        Nanny getNanny(long id);
        List<Nanny> getNannyList();
        #endregion

        #region Mother functions
        void addMother(Mother m);
        void removeMother(Mother m);
        void updateMother(Mother m);
        Mother getMother(long id);
        List<Mother> getMotherList();
        #endregion

        #region Child functions
        void addChild(Child c);
        void removeChild(Child c);
        void updateChild(Child c);
        Child getChild(long id);
        List<Child> getChildList(List<Mother> m);
        #endregion

        #region Contract functions
        void addContract(Contract c);
        void addContract(Contract c, Mother m);
        void removeContract(Contract c);
        void updateContract(Contract c);
        List<Contract> getContractList();
        #endregion


        #region BankAccount functions
        List<BankAccount> getBanksAccountList();
        List<string> getBanksNameList(List<BankAccount> a);
        List<int> getBanksBrancheList(List<BankAccount> a);
        #endregion


        void check_mother_and_nanny(Contract c);
        void check_child_age(Mother m);
        void dist(Contract c);
        List<Nanny> Nanny_For_Mother(Mother m);//DONE
        List<Nanny> Nanny_In_Range(Mother m);//how we know if the nanny is in the right range of the goal adress of the mother?? TO DO
        List<Child> Children_without_Nanny(List<Child> c);//DONE
        void salary(Contract c);
        List<Nanny> Vactions_by_Ministry_of_Economy_and_Industry(List<Nanny> n);//DONE
        IEnumerable<Contract> all_contract_by_condition(Func<Contract, bool> function = null);//DONE
        int num_of_contract_by_condition(Func<Contract, bool> function = null);//DONE
        IEnumerable<IGrouping<int, Nanny>> Nannies_by_Children_Ages(bool b = false);//TO DO
        IEnumerable<IGrouping<string, Nanny>> Nannies_by_address(bool b = false);//TO DO
        IEnumerable<IGrouping<float, Nanny>> Ages_of_Children_with_Nanny(bool b = false);//TO DO
        IEnumerable<IGrouping<int, Contract>> Distance_Nanny_and_Child(bool b = false);//TO DO

        int Age(DateTime birthday);//DONE

        //ADD MORE FUNCTION ACCORDING TO THE INSTRUCTIONS



    }
}
