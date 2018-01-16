using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct BankAccount
    {
       
        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public int BranchNumber { get; set; }

        public Address BranchAddress { get; set; }
        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public void add(double s)
        {
            if (s < 0 && Balance + s < 0) throw new Exception("mother doesn't have enough money");
            Balance += s;
        }
        public override string ToString()
        {
            string Result = "Bank Accont details:\n";
            Result += "---------------------\n";
            Result += string.Format("Bank {0}, number {1}\n", BankName, BankNumber);
            //Result += "Branch Address:\n" + BranchAddress.ToString();
            Result += "Branch number:\n" + BranchNumber;
            Result += string.Format("Account Number: {0}\n", AccountNumber);
            return Result;

        }
    }
}
