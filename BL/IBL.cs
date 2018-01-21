using System;
using System.Collections.Generic;
using System.Linq;
using BE;

namespace BL
{
    public interface IBL
    {
        void addChild(Child c);
        void addContract(Contract c);
        void addContract(Contract c, Mother m);
        void addMother(Mother m);
        void addNanny(Nanny n);
        int Age(DateTime birthday);
        IEnumerable<IGrouping<float, Nanny>> Ages_of_Children_with_Nanny(bool b = false);
        IEnumerable<Contract> all_contract_by_condition(Predicate<Contract> function = null);
        void check_child_age(Mother m);
        void check_mother_and_nanny(Contract c);
        List<Child> Children_without_Nanny(List<Child> c);
        void dist(Contract c);
        IEnumerable<IGrouping<float, Contract>> Distance_Nanny_and_Child(bool b = false);
        IEnumerable<IGrouping<int, Nanny>> Nanny_by_num_children(bool b = false);
        List<BankAccount> getBanksAccountList();
        List<int> getBanksBrancheList(List<BankAccount> a);
        List<string> getBanksNameList(List<BankAccount> a);
        Child getChild(long id);
        List<Child> getChildListAlone();
        List<Child> getChildList(List<Mother> m);
        List<Contract> getContractList();
        Mother getMother(long id);
        List<Mother> getMotherList();
        Nanny getNanny(long id);
        List<Nanny> getNannyList();
        IEnumerable<IGrouping<KeyValuePair<string, string>, Nanny>> Nannies_by_address(bool b = false);
        IEnumerable<IGrouping<int, Nanny>> Nannies_by_Children_Ages(bool b = false);
        IEnumerable<IGrouping<int, Contract>> Contracts_by_Children_Ages(bool b = false);
        List<Nanny> Nanny_For_Mother(Mother m);
        List<Nanny> Nanny_For_Mother_all(Mother m, bool range, bool voc);
        List<Nanny> Nanny_In_Range(Mother m);
        int num_of_contract_by_condition(Func<Contract, bool> function = null);
        void removeChild(Child c);
        void removeContract(Contract c);
        void removeMother(Mother m);
        void removeNanny(Nanny n);
        void salary(Contract c);
        void updateChild(Child c);
        void updateContract(Contract c);
        void updateMother(Mother m);
        void updateNanny(Nanny n);
        List<Nanny> Vocations_by_Ministry_of_Economy_and_Industry(List<Nanny> n);
        void monthlyPayment(Contract c);
        void setPayment(Contract c);
    }
}