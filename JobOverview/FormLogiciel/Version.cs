using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Version
    {
        public float Numero { get; set; }
        public int Millesime { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateSortiePrévue { get; set; }
        public DateTime DateSortieRéelle { get; set; }
        public int DerniereRelease { get; set; }
    }
}
