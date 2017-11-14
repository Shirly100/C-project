using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother : PersonDetails
    {
        public List<Child> myChildren = new List<Child>();
        public int Range { get; set; }
        public Address GoalAddress { get; set; }
        public Dictionary<Days, KeyValuePair<int, int>> WorkDays = new Dictionary<Days, KeyValuePair<int, int>>();//example: "Sun: 8:00-14:00"
        public override string ToString()
        {
            string Result=base.ToString();
            Result += (GoalAddress.Street != null) ? "Required location: " + GoalAddress + "\n" : "";
            Result += "Required days: /n";
            foreach (var item in WorkDays)
            {
                Result += "Day: " + item.Key + "   \t";
                Result += "Hours: " + item.Value + '\n';
            }
            return Result;
        }
    }
}
