using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public float distance { get; set; }
        private static int ContractNumber = 10000000;
        private int contractID;
        public int ContractID
        {
            get { return contractID; }
            set
            {
                ContractNumber++;
                contractID = ContractNumber;
            }
        }
        public long ID_nanny { get; set; }
        public long ID_child { get; set; }
        public long ID_mother { get; set; }
        public bool interview { get; set; }
        public bool signed_contract { get; set; }
        public float Wages_per_hours { get; set; }
        public float Wages_per_months { get; set; }
        public float payment { get; set; } 
        public bool siblings { get; set; }
        public int NumOfSiblings { get; set; }//if there are siblings,how many
        public Dictionary<Days, string> WorkDays = new Dictionary<Days, string>();//example: "Sun: 8:00-14:00"
        public string StartDate { get; set; }//in form: 23/12/2017
        public string EndDate { get; set; }
        public float hours_Of_Employment { get; set; }

        public override string ToString()
        {

            string result = "";
            result += string.Format("Number of contract: {0}\n", ContractID);
            result += string.Format("ID of nanny: {0}\n", ID_nanny);
            result += string.Format("ID of mother: {0}\n", ID_mother);
            result += string.Format("ID of child: {0}\n", ID_child);
            if (interview == true)
                result += string.Format("Interview: Yes\n");
            else
                result += string.Format("Interview: No\n");
            if (signed_contract == true)
                result += string.Format("Signed contract: Yes\n");
            else
                result += string.Format("Signed contract: No\n");
            if (siblings == true)
                result += string.Format("Other siblings with the nanny: Yes.   Number of siblings: {0}\n", NumOfSiblings);
            else
                result += string.Format("Other siblings with the nanny: No\n");


            result += string.Format("Wages per hours: {0}\n", Wages_per_hours);
            result += string.Format("Wages per months: {0}\n", Wages_per_months);

            result += "Days and hours of employment:\n";

            foreach (var item in WorkDays)
            {
                result += "Day: " + item.Key + "   \t";
                result += "Hours " + item.Value + '\n';
            }

            result += string.Format("Start date: {0}\n", StartDate);
            result += string.Format("End date: {0}\n", EndDate);
            result += string.Format("Hours of employment:: {0}\n", hours_Of_Employment);
            result += "distance" + distance;
            return result;

        }
    }
}
