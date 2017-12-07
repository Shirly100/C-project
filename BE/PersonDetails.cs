using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BE
{
    public class PersonDetails
    {
      
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Pelephone { get; set; }
        public Address Address { get; set; }
        public BankAccount BankAccount { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {

            string result = "";
            result += LastName + " " + FirstName + '\n';
            result += string.Format("ID: {0}\n", ID);
            result += string.Format("Telephone: {0}\n", Telephone);
            result += string.Format("Pelephone: {0}\n", Pelephone);
            result += Address.ToString();
            return result;

            

        }
    }
}
