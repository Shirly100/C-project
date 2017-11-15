using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
using DAL;


namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL myibl = factoryBL.get_bl();
            Mother m = new Mother { FirstName = "rivka" };
            Console.WriteLine(m.ToString());
            myibl.addMother(m);
            List<Mother> mm = myibl.getMotherList();
            foreach (Mother mo in mm)
            {
                Console.WriteLine("first");
                Console.WriteLine(mo.ToString());
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
