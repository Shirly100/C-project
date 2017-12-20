using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class factoryBL
    {
        static IBL FactoryBl = null;
        public static IBL get_bl()
        {
            if (FactoryBl == null)
                FactoryBl = new IBL_imp();

            return FactoryBl;
        }

    }
}
