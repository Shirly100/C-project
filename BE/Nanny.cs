using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : PersonDetails
    {
        public int minAge = int.MaxValue;
        public int numOfChildren { get; set; }
        public DateTime BirthDate { get; set; } 
        public bool Elevator { get; set; }
        public float ExperienceYears { get; set; }
        public int MaxNumOfChildren { get; set; }
        public float MinAgeOfChild { get; set; }
        public float MaxAgeOfChild { get; set; }
        public float HourlyRate { get; set; }
        public float MonthlyRate { get; set; }
        public Dictionary<Days, KeyValuePair<int, int>> WorkDays = new Dictionary<Days, KeyValuePair<int, int>>();//example: "Sun: 8:00-14:00"
        public bool Ministry_Of_Economy_and_Industry_Vactions { get; set; }
        public StringBuilder Recommendations { get; set; }
        public BankAccount BankAccount { get; set; }



        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("Date of birth: {0}\n", BirthDate);
            if (Elevator == true)
                result += "Elevator: YES\n";
            else
                result += "Elevator: No\n";
            result += string.Format("Years od experience: {0}\n", ExperienceYears);
            result+= string.Format("Maximun number of children: {0}\n", MaxNumOfChildren);
            result += string.Format("Age of children: {0}-{1}\n", MinAgeOfChild,MaxAgeOfChild);
            result += string.Format("Hourly rate: {0}\n", BirthDate);
            result += string.Format("Monthly rate: {0}\n", BirthDate);
            result += "days of work: /n";
            foreach (var item in WorkDays)
            {
                result += "Day: " + item.Key + "   \t";
                result += "Hours " + item.Value + '\n';
            }
            if (Ministry_Of_Education_Vactions == true)
                result += "Ministry Of Education vactions: YES\n";
            else
                result += "Ministry Of Education vactions: No\n";
            result += BankAccount.ToString();
            result += string.Format("Recommendations: {0}\n", Recommendations);
            return result;
        }


    }
}
