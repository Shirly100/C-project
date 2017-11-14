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
            Mother m = new Mother();
            myibl.addMother(m);
        }
    }
}
