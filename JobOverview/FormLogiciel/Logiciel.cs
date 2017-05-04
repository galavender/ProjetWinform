using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Logiciel
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string CodeFilière { get; set; }
        public List<Module> LstModule { get; set; }
        public List<Version> LstVersion { get; set; }
    }
}
