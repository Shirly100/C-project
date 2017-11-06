using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct Adress
    {
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {

            string result = "";
            result += Street + " ";
            result += HouseNumber + '\n';
            result += ZipCode + " ";
            result += City + '\n';
            result += Country;
            return result;

        }

    }
}
