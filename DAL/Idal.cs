using System.Collections.Generic;
using BE;


namespace DAL
{
    public interface Idal
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
        void removeContract(Contract c);
        void updateContract(Contract c);
        List<Contract> getContractList();
        #endregion

        
        #region BankAccount functions
        List<BankAccount> getBanksAccountList();
        List<string> getBanksNameList(List<BankAccount> a);
        List<int> getBanksBrancheList(List<BankAccount> a);
        #endregion

    }
}
