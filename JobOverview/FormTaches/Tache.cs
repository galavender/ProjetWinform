using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Tache
    {
        public Guid IdTache { get; set; }
        public string Libelle { get; set; }
        public bool Annexe { get; set; }
        public string CodeActivité { get; set; }
        public string Login { get; set; }
        public string Description { get; set; }
    }
}
