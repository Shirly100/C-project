using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal static class Be_Extensions
    {
        internal static Child ChildDeepClone(this Child c)
        {
            return new Child
            {
                ID_child = c.ID_child,
                ID_Mother = c.ID_Mother,
                FirstName = c.FirstName,
                BirthDate = c.BirthDate,
                SpecialNeeds = c.SpecialNeeds,
                Allergies = c.Allergies,
                allergies = c.allergies,
                Age = c.Age,
            };
        }




        internal static Mother MotherDeepClone(this Mother m)
        {
            return new Mother
            {
                ID = m.ID,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Telephone = m.Telephone,
                Pelephone = m.Pelephone,
                Address = m.Address,
                GoalAddress = m.GoalAddress,
                WorkDays = m.WorkDays

            };
        }



        internal static Nanny NannyDeepClone(this Nanny n)
        {
            return new Nanny
            {
                ID = n.ID,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Telephone = n.Telephone,
                Pelephone = n.Pelephone,
                Address = n.Address,
                BirthDate = n.BirthDate,
                Elevator = n.Elevator,
                ExperienceYears = n.ExperienceYears,
                MaxNumOfChildren = n.MaxNumOfChildren,
                MinAgeOfChild = n.MinAgeOfChild,
                MaxAgeOfChild = n.MaxAgeOfChild,
                HourlyRate = n.HourlyRate,
                MonthlyRate = n.MonthlyRate,
                WorkDays = n.WorkDays,
                Ministry_Vocations = n.Ministry_Vocations,
                Recommendations = n.Recommendations,
                BankAccount = n.BankAccount
            };
        }
        internal static Contract ContractDeepClone(this Contract c)
        {
            return new Contract
            {
                ContractID = c.ContractID,
                ID_nanny = c.ID_nanny,
                ID_child = c.ID_child,
                interview = c.interview,
                signed_contract = c.signed_contract,
                Wages_per_hours = c.Wages_per_hours,
                Wages_per_months = c.Wages_per_months,
                siblings = c.siblings,
                NumOfSiblings = c.NumOfSiblings,
                WorkDays = c.WorkDays,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                hours_Of_Employment = c.hours_Of_Employment,
                ID_mother = c.ID_mother

            };
        }
    }

    
}
