using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Module
    {
        public string Code { get; set; }
        //public string CodeLogiciel { get; set; }
        public string Libellé { get; set; }
        public string CodeModuleParent { get; set; }
        public string CodeLogicielParent { get; set; }
    }
}
