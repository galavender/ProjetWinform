using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Travail
    {
        public Guid IdTache { get; set; }
        public DateTime DateTravail { get; set;}
        public float Heures { get; set; }
        public float TauxProductivite { get; set; }
    }
}
