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
                contracts = new XElement("Contracts");
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
                nannies = new XElement("Nannies");
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
                mothers = new XElement("Mother");
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
                children = new XElement("Spacializations");
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
                addresses = new XElement("Addresses");
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
        }

        #region Build XElement
        XElement BuildXelementContract(Contract c)
        {
            XElement ContractID = new XElement("ContractID", c.ContractID);
            XElement ID_nanny = new XElement("ID_nanny", c.ID_nanny);
            XElement ID_child = new XElement("ID_child", c.ID_child);
            XElement interview = new XElement("Interview", c.interview);
            XElement signed_contract = new XElement("Signed", c.signed_contract);
            XElement Wages_per_hours = new XElement("Hours", c.Wages_per_hours);
            XElement Wages_per_months = new XElement("Monthly", c.Wages_per_months);
            XElement siblings = new XElement("Siblings", c.siblings);
            XElement NumOfSiblings = new XElement("NumofSibling", c.NumOfSiblings);
            XElement WorkDays = new XElement("WorkDays", c.WorkDays);
            XElement StartDate = new XElement("StartDate", c.StartDate);
            XElement EndDate = new XElement("EndDate", c.EndDate);
            XElement hours_Of_Employment = new XElement("EmploymentHours", c.hours_Of_Employment);
            XElement ID_mother = new XElement("ID_Mother", c.ID_mother);
            return new XElement("Contract", ContractID, ID_nanny, ID_child, interview, signed_contract, Wages_per_hours, Wages_per_months, siblings, NumOfSiblings, WorkDays, StartDate, EndDate, hours_Of_Employment, ID_mother);
        }

        XElement BuildXelementNanny(Nanny n)
        {
            XElement ID = new XElement("ID", n.ID);
            XElement FirstName = new XElement("FirstName", n.FirstName);
            XElement LastName = new XElement("LastName", n.LastName);
            XElement Telephone = new XElement("Telephone", n.Telephone);
            XElement Pelephone = new XElement("Pelephone", n.Pelephone);
            XElement Address = new XElement("Address", n.Address);
            XElement BirthDate = new XElement("BirthDate", n.BirthDate);
            XElement Elevator = new XElement("Elevator", n.Elevator);
            XElement ExperienceYears = new XElement("ExperienceYears", n.ExperienceYears);
            XElement MaxNumOfChildren = new XElement("MaxNumOfChildren", n.MaxNumOfChildren);
            XElement MinAgeOfChild = new XElement("MinAgeOfChild", n.MinAgeOfChild);
            XElement MaxAgeOfChild = new XElement("MaxAgeOfChild", n.MaxAgeOfChild);
            XElement HourlyRate = new XElement("HourlyRate", n.HourlyRate);
            XElement MonthlyRate = new XElement("MonthlyRate", n.MonthlyRate);

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
            XElement BankAccount = new XElement("BankAccount", n.BankAccount);
            XElement Age = new XElement("Age", n.Age);
            return new XElement("Nanny", ID, FirstName, LastName, Telephone, Pelephone, Address, BirthDate, Elevator, Age, ExperienceYears, MaxAgeOfChild, MaxNumOfChildren, HourlyRate, MonthlyRate, WorkDays, Ministry_Vocations, Recommendations, BankAccount);
        }

        XElement BuildXelementMother(Mother m)
        {
            XElement ID = new XElement("ID", m.ID);
            XElement FirstName = new XElement("FirstName", m.FirstName);
            XElement LastName = new XElement("LastName", m.LastName);
            XElement Telephone = new XElement("Telephone", m.Telephone);
            XElement Pelephone = new XElement("Pelephone", m.Pelephone);
            XElement Address = new XElement("Address", m.Address);
            XElement WorkDays = new XElement("WorkDays", m.WorkDays);
            XElement BankAccount = new XElement("BankAccount", m.BankAccount);
            XElement GoalAddress = new XElement("GoalAddress", m.GoalAddress);
            XElement Range = new XElement("Range", m.Range);
            XElement myChildren = new XElement("myChildren", m.myChildren);
            return new XElement("Mother", ID, FirstName, LastName, Telephone, Pelephone, Address, WorkDays, BankAccount, Range, myChildren);
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

        #endregion

        #region Build Object
        Contract BuildContract(XElement xc)
        {
            Contract c = new Contract();
            c.ContractID = Convert.ToInt32(xc.Element("ContractID").Value);
            c.ID_mother = Convert.ToInt32(xc.Element("ID_Mother").Value);
            c.ID_nanny = Convert.ToInt32(xc.Element("ID_Nanny").Value);
            c.interview = Convert.ToBoolean(xc.Element("IsInterviewed").Value);
            c.signed_contract = Convert.ToBoolean(xc.Element("Signed").Value);
            c.Wages_per_hours = Convert.ToInt32(xc.Element("Hours").Value);
            c.Wages_per_months = Convert.ToInt32(xc.Element("Monthly").Value);
            c.StartDate = (xc.Element("StartDate").Value);
            c.EndDate = (xc.Element("Final").Value);
            c.hours_Of_Employment = Convert.ToInt32(xc.Element("EmploymentHours").Value);
            c.siblings = Convert.ToBoolean(xc.Element("Siblings").Value);
            c.NumOfSiblings = Convert.ToInt32(xc.Element("NumofSibling").Value);
            //Dictionary < Days, string>  x = { (BE.Days)Enum.Parse(typeof(BE.Days), xc.Element("WorkDays").Value),xc.Element("WorkDays").Value};

            //c.WorkDays = Dictionary<Days, string>{ (BE.Days)Enum.Parse(typeof(BE.Days), xc.Element("WorkDays").Value),xc.Element("WorkDays").Value};
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
            Address a = new Address(); //.... complete all complicated ones
            m.Address = a;
            //m.WorkDays
            return m;
        }

        Nanny BuildNanny(XElement xn)
        {
            Nanny n = new Nanny();
            n.ID = Convert.ToInt32(xn.Element("ID").Value);
            n.FirstName = xn.Element("FirstName").Value;
            n.LastName = xn.Element("LastName").Value;
            n.Age = Convert.ToInt32(xn.Element("Age").Value);
            n.Telephone = xn.Element("Telephone").Value;
            n.Pelephone = xn.Element("Pelephone").Value;
            //n.BirthDate = 

            Address a = new Address(); //.... complete all complicated ones
            n.Address = a;
            //m.WorkDays
            return n;
        }


        #endregion

    }
}
