using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using BE;
using DS;

namespace DAL
{
    public class DAL_XML_imp : Idal
    {
        static string ContractXml = @"ContractXml.xml";
        static string NannyXml = @"NannyXml.xml";
        static string MotherXml = @"MotherXml.xml";
        static string ChildXml = @"ChildXml.xml";
        static string BankAccountXml = @"BankAccountXml.xml";
        static string AddressXml = @"AddressXml.xml";
        static XElement contracts;
        static XElement nannies;
        static XElement mothers;
        static XElement children;
        static XElement bankAccounts;
        static XElement addresses;

        public DAL_XML_imp()
        {
            if (!File.Exists(ContractXml))
            {
                contracts = new XElement("contracts");
                contracts.Save(ContractXml);
            }
            else
            {
                try
                {
                    contracts = new XElement(XElement.Load(ContractXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(NannyXml))
            {
                nannies = new XElement("nannies");
                nannies.Save(NannyXml);
            }
            else
            {
                try
                {
                    nannies = new XElement(XElement.Load(NannyXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(MotherXml))
            {
                mothers = new XElement("mother");
                mothers.Save(MotherXml);
            }
            else
            {
                try
                {
                    mothers = new XElement(XElement.Load(MotherXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(ChildXml))
            {
                children = new XElement("children");
                children.Save(ChildXml);
            }
            else
            {
                try
                {
                    children = new XElement(XElement.Load(ChildXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(AddressXml))
            {
                addresses = new XElement("addresses");
                addresses.Save(AddressXml);
            }
            else
            {
                try
                {
                    addresses = new XElement(XElement.Load(AddressXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(BankAccountXml))
            {
                bankAccounts = new XElement("bankAccounts");
                bankAccounts.Save(BankAccountXml);
            }
            else
            {
                try
                {
                    bankAccounts = new XElement(XElement.Load(BankAccountXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
        }

        private int MaxContractID()
        {
            int result;
            var kayam = contracts.Elements().Any();

            if (!kayam)
            {
                result = 100000;
            }
            else
            {
                result = (from c in contracts.Elements()
                          select Int32.Parse(c.Element("ContractID").Value)).Max();
            }
            return result;
        }

        #region Build XElement
        XElement BuildXelementContract(Contract c)
        {
            XElement ContractID = new XElement("ContractID", (MaxContractID() + 1).ToString());
            XElement payment = new XElement("payment", c.payment);
            XElement distance = new XElement("distance", c.distance);
            XElement ID_nanny = new XElement("ID_nanny", c.ID_nanny);
            XElement ID_child = new XElement("ID_child", c.ID_child);
            XElement interview = new XElement("interview", c.interview);
            XElement signed_contract = new XElement("signed_contract", c.signed_contract);
            XElement Wages_per_hours = new XElement("Wages_per_hours", c.Wages_per_hours);
            XElement Wages_per_months = new XElement("Wages_per_months", c.Wages_per_months);
            XElement siblings = new XElement("siblings", c.siblings);
            XElement NumOfSiblings = new XElement("NumOfSiblings", c.NumOfSiblings);
            XElement WorkDays = new XElement("WorkDays",
                (from d in c.WorkDays
                   select new XElement("Day",
                   new XAttribute("Day", d.Key.ToString()),
                   new XElement("Start", d.Value.Key.ToString()),
                   new XElement("End", d.Value.Value.ToString())
                )
            ));
            XElement StartDate = new XElement("StartDate", c.StartDate);
            XElement EndDate = new XElement("EndDate", c.EndDate);
            XElement hours_Of_Employment = new XElement("hours_Of_Employment", c.hours_Of_Employment);
            XElement ID_mother = new XElement("ID_Mother", c.ID_mother);
            return new XElement("Contract", distance,payment, ContractID, ID_nanny, ID_child,
                interview, signed_contract, Wages_per_hours, Wages_per_months, 
                siblings, NumOfSiblings, WorkDays, StartDate, EndDate, hours_Of_Employment, ID_mother);
        }

        XElement BuildXelementNanny(Nanny n)
        {
            XElement ID = new XElement("ID", n.ID);
            XElement FirstName = new XElement("FirstName", n.FirstName);
            XElement LastName = new XElement("LastName", n.LastName);
            XElement Telephone = new XElement("Telephone", n.Telephone);
            XElement Pelephone = new XElement("Pelephone", n.Pelephone);
            XElement Address = new XElement("Address", BuildXelementAddress(n.Address));
            XElement BirthDate = new XElement("BirthDate", n.BirthDate);
            XElement Elevator = new XElement("Elevator", n.Elevator);
            XElement ExperienceYears = new XElement("ExperienceYears", n.ExperienceYears);
            XElement MaxNumOfChildren = new XElement("MaxNumOfChildren", n.MaxNumOfChildren);
            XElement MinAgeOfChild = new XElement("MinAgeOfChild", n.MinAgeOfChild);
            XElement MaxAgeOfChild = new XElement("MaxAgeOfChild", n.MaxAgeOfChild);
            XElement HourlyRate = new XElement("HourlyRate", n.HourlyRate);
            XElement MonthlyRate = new XElement("MonthlyRate", n.MonthlyRate);
            XElement myChildren = new XElement("myChildren", (from x in n.myChildren select BuildXelementChild(x)));
            XElement numOfChildren = new XElement("numOfChildren", n.numOfChildren);
            XElement WorkDays = new XElement("WorkDays",
                 (from d in n.WorkDays
                  select new XElement("Day",
                      new XAttribute("Day", d.Key.ToString()),
                      new XElement("Start", d.Value.Key.ToString()),
                      new XElement("End", d.Value.Value.ToString())  
                      )
                  ) );

            XElement Ministry_Vocations = new XElement("Ministry_Vocations", n.Ministry_Vocations);
            XElement Recommendations = new XElement("Recommendations", n.Recommendations);
            XElement BankAccount = new XElement("BankAccount", BuildXelementBankAccount(n.BankAccount));
            XElement Age = new XElement("Age", n.Age);
            return new XElement("Nanny", MaxAgeOfChild, MaxNumOfChildren,MinAgeOfChild, numOfChildren, myChildren, ID, FirstName, LastName, Telephone, Pelephone, Address, BirthDate, Elevator, Age, ExperienceYears, HourlyRate, MonthlyRate, WorkDays, Ministry_Vocations, Recommendations, BankAccount);
        }

        XElement BuildXelementMother(Mother m)
        {
            XElement ID = new XElement("ID", m.ID);
            XElement payment = new XElement("payment", m.payment);
            XElement Age = new XElement("Age", m.Age);
            XElement FirstName = new XElement("FirstName", m.FirstName);
            XElement LastName = new XElement("LastName", m.LastName);
            XElement Telephone = new XElement("Telephone", m.Telephone);
            XElement Pelephone = new XElement("Pelephone", m.Pelephone);
            XElement Address = new XElement("Address", BuildXelementAddress(m.Address));
            XElement WorkDays = new XElement("WorkDays",
                (from d in m.WorkDays
                 select new XElement("Day",
                 new XAttribute("Day", d.Key.ToString()),
                 new XElement("Start", d.Value.Key.ToString()),
                 new XElement("End", d.Value.Value.ToString())
              )
            ));
            XElement BankAccount = new XElement("BankAccount", BuildXelementBankAccount(m.BankAccount));
            XElement GoalAddress = new XElement("GoalAddress", BuildXelementAddress(m.GoalAddress));
            XElement Range = new XElement("Range", m.Range);
            XElement myChildren = new XElement("myChildren", (from x in m.myChildren select BuildXelementChild(x)));
            return new XElement("Mother", ID, payment, Age, FirstName, LastName, Telephone, Pelephone, Address, WorkDays, BankAccount, Range, GoalAddress, myChildren);
        }

        XElement BuildXelementChild(Child c)
        {
            XElement ID_child = new XElement("ID_child", c.ID_child);
            XElement ID_Mother = new XElement("ID_Mother", c.ID_Mother);
            XElement FirstName = new XElement("FirstName", c.FirstName);
            XElement BirthDate = new XElement("BirthDate", c.BirthDate);
            XElement SpecialNeeds = new XElement("SpecialNeeds", c.SpecialNeeds);
            XElement Allergies = new XElement("Allergies", c.Allergies);
            XElement allergies = new XElement("allergies", c.allergies);
            XElement Age = new XElement("Age", c.Age);
            return new XElement("Child", ID_child, ID_Mother, FirstName, Age, BirthDate, SpecialNeeds, Allergies, allergies);
        }

        XElement BuildXelementAddress(Address a)
        {
            XElement HouseNumber = new XElement("HouseNumber", a.HouseNumber);
            XElement City = new XElement("City", a.City);
            XElement Country = new XElement("Country", a.Country);
            XElement Floor = new XElement("Floor", a.Floor);
            XElement Street = new XElement("Street", a.Street);
            XElement ZipCode = new XElement("ZipCode", a.ZipCode);
            return new XElement("Address", Country, City, Floor, HouseNumber, ZipCode, Street);
        }

        XElement BuildXelementBankAccount(BankAccount b)
        {
            XElement AccountNumber = new XElement("AccountNumber", b.AccountNumber);
            XElement Balance = new XElement("Balance", b.Balance);
            XElement BankName = new XElement("BankName", b.BankName);
            XElement BankNumber = new XElement("BankNumber", b.BankNumber);
            XElement BranchAddress = new XElement("BranchAddress", BuildXelementAddress(b.BranchAddress));
            XElement BranchNumber = new XElement("BranchNumber", b.BranchNumber);
            return new XElement("BankAccount", AccountNumber, Balance, BankName, BankNumber, BranchAddress, BranchNumber);
        }
        #endregion

        #region Build Object
        Contract BuildContract(XElement xc)
        {
            Contract c = new Contract();
            c.ContractID = Convert.ToInt32(xc.Element("ContractID").Value);
            c.ID_mother = Convert.ToInt32(xc.Element("ID_Mother").Value);
            c.ID_child = Convert.ToInt32(xc.Element("ID_child").Value);
            c.ID_nanny = Convert.ToInt32(xc.Element("ID_nanny").Value);
            c.distance = Convert.ToInt32(xc.Element("distance").Value);
            c.interview = Convert.ToBoolean(xc.Element("interview").Value);
            c.signed_contract = Convert.ToBoolean(xc.Element("signed_contract").Value);
            c.Wages_per_hours = Convert.ToInt32(xc.Element("Wages_per_hours").Value);
            c.Wages_per_months = Convert.ToInt32(xc.Element("Wages_per_months").Value);
            c.StartDate = (xc.Element("StartDate").Value);
            c.EndDate = (xc.Element("EndDate").Value);
            c.hours_Of_Employment = Convert.ToInt32(xc.Element("hours_Of_Employment").Value);
            c.siblings = Convert.ToBoolean(xc.Element("siblings").Value);
            c.NumOfSiblings = Convert.ToInt32(xc.Element("NumOfSiblings").Value);
            c.payment = Convert.ToInt32(xc.Element("payment").Value);
            c.WorkDays = new Dictionary<Days, KeyValuePair<int, int>>();
            foreach (var e in xc.Element("WorkDays").Elements("Day"))
            {
                c.WorkDays[(BE.Days)Enum.Parse(typeof(BE.Days), e.Attribute("Day").Value)]
                    = new KeyValuePair<int, int>(Convert.ToInt32(e.Element("Start").Value), Convert.ToInt32(e.Element("End").Value));
            }

                return c;
        }

        Child BuildChild(XElement xc)
        {
            Child c = new Child();
            c.ID_child = Convert.ToInt32(xc.Element("ID_child").Value);
            c.ID_Mother = Convert.ToInt32(xc.Element("ID_Mother").Value);
            c.FirstName = xc.Element("FirstName").Value;
            c.Age = Convert.ToInt32(xc.Element("Age").Value);
            c.Allergies = Convert.ToBoolean(xc.Element("Allergies").Value);
            c.allergies = xc.Element("allergies").Value;
            c.SpecialNeeds = Convert.ToBoolean(xc.Element("SpecialNeeds").Value);
            c.BirthDate = xc.Element("BirthDate").Value;
            return c;
        }

        Mother BuildMother(XElement xm)
        {
            Mother m = new Mother();
            m.ID = Convert.ToInt32(xm.Element("ID").Value);
            m.FirstName = xm.Element("FirstName").Value;
            m.LastName = xm.Element("LastName").Value;
            m.Age = Convert.ToInt32(xm.Element("Age").Value);
            m.Telephone = xm.Element("Telephone").Value;
            m.Pelephone = xm.Element("Pelephone").Value;
            m.Range = Convert.ToInt32(xm.Element("Range").Value);
            m.payment = Convert.ToBoolean(xm.Element("payment").Value);
            m.Address = BuildAddress(xm.Element("Address").Element("Address"));
            m.BankAccount = BuildBankAccount(xm.Element("BankAccount").Element("BankAccount"));
            m.GoalAddress = BuildAddress(xm.Element("GoalAddress").Element("Address"));
            m.myChildren = new List<Child>();
            foreach (var e in xm.Element("myChildren").Elements("Child"))
            {
                m.myChildren.Add(BuildChild(e));
            }
            m.WorkDays = new Dictionary<Days, KeyValuePair<int, int>>();
            foreach (var e in xm.Element("WorkDays").Elements("Day"))
            {
                m.WorkDays[(BE.Days)Enum.Parse(typeof(BE.Days), e.Attribute("Day").Value)]
                    = new KeyValuePair<int, int>(Convert.ToInt32(e.Element("Start").Value), Convert.ToInt32(e.Element("End").Value));
            }
            return m;
        }

        Nanny BuildNanny(XElement xn)
        {
            Nanny n = new Nanny();
            n.ID = Convert.ToInt32(xn.Element("ID").Value);
            n.FirstName = xn.Element("FirstName").Value;
            n.LastName = xn.Element("LastName").Value;
            n.Age = Convert.ToInt32(xn.Element("Age").Value);
            n.Elevator = Convert.ToBoolean(xn.Element("Elevator").Value);
            n.ExperienceYears = Convert.ToInt32(xn.Element("ExperienceYears").Value);
            n.HourlyRate = Convert.ToInt32(xn.Element("HourlyRate").Value);
            n.MaxAgeOfChild = Convert.ToInt32(xn.Element("MaxAgeOfChild").Value);
            n.MaxNumOfChildren = Convert.ToInt32(xn.Element("MaxNumOfChildren").Value);
            n.MinAgeOfChild = Convert.ToInt32(xn.Element("MinAgeOfChild").Value);
            n.MonthlyRate = Convert.ToInt32(xn.Element("MonthlyRate").Value); 
            n.numOfChildren = Convert.ToInt32(xn.Element("numOfChildren").Value);
            n.Recommendations = xn.Element("Recommendations").Value;
            n.Ministry_Vocations = Convert.ToBoolean(xn.Element("Ministry_Vocations").Value);
            n.Telephone = xn.Element("Telephone").Value;
            n.Pelephone = xn.Element("Pelephone").Value;
            n.BirthDate = DateTime.Parse(xn.Element("BirthDate").Value);
            n.Address = BuildAddress(xn.Element("Address").Element("Address"));
            n.myChildren = new List<Child>();
            foreach (var e in xn.Element("myChildren").Elements("Child"))
            {
                n.myChildren.Add(BuildChild(e));
            }
            n.WorkDays = new Dictionary<Days, KeyValuePair<int, int>>();
            foreach (var e in xn.Element("WorkDays").Elements("Day"))
            {
                n.WorkDays[(BE.Days)Enum.Parse(typeof(BE.Days), e.Attribute("Day").Value)]
                    = new KeyValuePair<int, int>(Convert.ToInt32(e.Element("Start").Value), Convert.ToInt32(e.Element("End").Value));
            }
            n.BankAccount = BuildBankAccount(xn.Element("BankAccount").Element("BankAccount"));
            return n;
        }

        Address BuildAddress(XElement xa)
        {
            Address a = new Address();
            a.City = xa.Element("City").Value;
            a.Country = xa.Element("Country").Value;
            a.Street = xa.Element("Street").Value;
            a.ZipCode = xa.Element("ZipCode").Value;
            a.Floor = Convert.ToInt32(xa.Element("Floor").Value);
            a.HouseNumber = Convert.ToInt32(xa.Element("HouseNumber").Value);
            return a;
        }

        BankAccount BuildBankAccount(XElement xb)
        {
            BankAccount b = new BankAccount();
            b.BankName = xb.Element("BankName").Value;
            b.AccountNumber = Convert.ToInt32(xb.Element("AccountNumber").Value);
            b.BranchAddress = BuildAddress(xb.Element("BranchAddress").Element("Address"));
            b.Balance = Convert.ToInt32(xb.Element("Balance").Value);
            b.BankNumber = Convert.ToInt32(xb.Element("BankNumber").Value);
            b.BranchNumber = Convert.ToInt32(xb.Element("BranchNumber").Value);
            return b;
        }

        #endregion

        #region Nanny functions

        public void addNanny(Nanny n)
        {

            XElement temp = ((from e in nannies.Elements()
                              where Convert.ToInt64(e.Element("ID").Value) == n.ID
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("This Nanny already exist");
            nannies.Add(BuildXelementNanny(n));
            nannies.Save(NannyXml);
        }

        public Nanny getNanny(long id)
        {
            return BuildNanny((from e in nannies.Elements()
                                        where Convert.ToInt32(e.Element("ID").Value) == id
                                        select e).FirstOrDefault());
        }

        public void removeNanny(Nanny n)
        {

            XElement temp = ((from e in nannies.Elements()
                              where Convert.ToInt32(e.Element("ID").Value) == n.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This nanny does not exist");
            temp.Remove();
            nannies.Save(NannyXml);
        }

        public void updateNanny(Nanny n)
        {
            XElement temp = ((from e in nannies.Elements()
                              where Convert.ToInt32(e.Element("ID").Value) == n.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Nanny not exist");
            temp.ReplaceWith(BuildXelementNanny(n));
            nannies.Save(NannyXml);
        }

        public List<Nanny> getNannyList()
        {
            List<Nanny> listn = new List<Nanny>();
            var items = from temp in nannies.Elements()
                        select BuildNanny(temp);
            listn = items.ToList();
            Console.WriteLine(listn);
            return listn;
        }
        #endregion

        #region Mother functions

        public void addMother(Mother m)
        {

            XElement temp = ((from e in mothers.Elements()
                              where Convert.ToInt64(e.Element("ID").Value) == m.ID
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("This Mother already exist");
            mothers.Add(BuildXelementMother(m));
            mothers.Save(MotherXml);
        }

        public Mother getMother(long id)
        {
            return BuildMother((from e in mothers.Elements()
                               where Convert.ToInt32(e.Element("ID").Value) == id
                               select e).FirstOrDefault());

        }

        public void removeMother(Mother m)
        {

            XElement temp = ((from e in mothers.Elements()
                              where Convert.ToInt64(e.Element("ID").Value) == m.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Mother does not exist");
            temp.Remove();
            mothers.Save(MotherXml);
        }

        public void updateMother(Mother m)
        {
            XElement temp = ((from e in mothers.Elements()
                              where Convert.ToInt64(e.Element("ID").Value) == m.ID
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Mother not exist");
            temp.ReplaceWith(BuildXelementMother(m));
            mothers.Save(MotherXml);
        }

        public List<Mother> getMotherList()
        {
            List<Mother> listm = new List<Mother>();
            var items = from temp in mothers.Elements()
                        select BuildMother(temp);
            listm = items.ToList();
            Console.WriteLine(listm);

            return listm;
        }

        public void addChildren(Child c)
        {
            Mother m = new Mother();
            XElement temp = ((from e in mothers.Elements()
                              where Convert.ToInt64(e.Element("ID").Value) == c.ID_Mother
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Mother not exist");
            m = BuildMother(temp);
            m.myChildren.Add(c);
            temp.ReplaceWith(BuildXelementMother(m));
            mothers.Save(MotherXml);
        }
        #endregion

        #region Child functions

        public void addChild(Child c)
        {

            XElement temp = ((from e in children.Elements()
                              where Convert.ToInt64(e.Element("ID_child").Value) == c.ID_child
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("This Child already exist");
            addChildren(c);
            children.Add(BuildXelementChild(c));
            children.Save(ChildXml);
        }

        public Child getChild(long id)
        {
            return BuildChild((from e in children.Elements()
                               where Convert.ToInt64(e.Element("ID_child").Value) == id
                               select e).FirstOrDefault());
        }

        public void removeChild(Child c)
        {

            XElement temp = ((from e in children.Elements()
                              where Convert.ToInt64(e.Element("ID_child").Value) == c.ID_child
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Child does not exist");
            temp.Remove();
            children.Save(ChildXml);
        }

        public void updateChild(Child c)
        {
            XElement temp = ((from e in children.Elements()
                              where Convert.ToInt64(e.Element("ID_child").Value) == c.ID_child
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This Child not exist");
            temp.ReplaceWith(BuildXelementChild(c));
            children.Save(ChildXml);
        }

        public List<Child> getChildListAlone()
        {
            List<Child> listc = new List<Child>();
            var items = from temp in children.Elements()
                        select BuildChild(temp);
            listc = items.ToList();
            return listc;
        }

        public List<Child> getChildList(List<Mother> m)
        {
            List<Child> listc = new List<Child>();
            foreach (Mother t in m)
            {
                var items = from temp in children.Elements()
                            where Convert.ToInt64(temp.Element("ID_mother").Value) == t.ID
                            select BuildChild(temp);
                listc.Union(items.ToList());
            }
            return listc;
        }
        #endregion

        #region Contract function
        public Contract getContract(long number)
        {
            return BuildContract((from e in contracts.Elements()
                                        where Convert.ToInt64(e.Element("ContractID").Value) == number
                                        select e).FirstOrDefault());
        }
        public void addContract(Contract c)
        {

            XElement temp = ((from e in contracts.Elements()
                              where Convert.ToInt32(e.Element("ContractID").Value) == c.ContractID
                              select e).FirstOrDefault());
            if (temp != null)
                throw new Exception("This contract already exist");
            contracts.Add(BuildXelementContract(c));
            contracts.Save(ContractXml);
        }
        public void removeContract(Contract c)
        {

            XElement temp = (from e in contracts.Elements()
                             where Convert.ToInt64(e.Element("ContractID").Value) == c.ContractID
                             select e).FirstOrDefault();
            if (temp == null)
                throw new Exception("This contract does not exist");

            temp.Remove();
            contracts.Save(ContractXml);
        }
        public void updateContract(Contract c)
        {

            XElement temp = (from e in contracts.Elements()
                             where Convert.ToInt32(e.Element("ContractID").Value) == c.ContractID
                             select e).FirstOrDefault();
            Console.WriteLine(c.ContractID);
            Console.WriteLine(temp);

            if (temp == null)
                throw new Exception("This contract exist");

            temp.ReplaceWith(BuildXelementContract(c));
            contracts.Save(ContractXml);
        }

        public List<Contract> getContractList()
        {
            List<Contract> ListContract = new List<Contract>();
            var items = from temp in contracts.Elements()
                        select BuildContract(temp);
            ListContract = items.ToList();
            Console.WriteLine(ListContract);

            return ListContract;
        }

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

    }
}
