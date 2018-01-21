using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE 
{
    public class Child
    {

        public long ID_child { get; set; }
        public long ID_Mother { get; set; }
        public string FirstName { get; set; }
        public string BirthDate { get; set; } //format: DD/MM/YY
        public bool SpecialNeeds { get; set; }
        public bool Allergies { get; set; }
        public string allergies { get; set; }
        public int Age { get; set; }//in months

        public override string ToString()
        {
            string result = "";
            result += string.Format("Name of child: {0}\n", FirstName);
            result += string.Format("Age: {0}\n", Age);
            result += string.Format("Date of birth: {0}\n", BirthDate);
            result += string.Format("ID of child: {0}\n", ID_child);
            result += string.Format("ID of parent: {0}\n", ID_Mother);
            if (SpecialNeeds == true)
                result += "SpecialNeeds: YES\n";
            else
                result += "SpecialNeeds: No\n";
            if (Allergies == true)
                result += string.Format("There is allergies: {0}\n", allergies);
            else 
                result += "No allergies.";
            return result;
        }

    }
}
