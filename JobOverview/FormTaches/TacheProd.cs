﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class TacheProd:Tache
    {
        public int Numero { get; set; }
        public float DureePrevue { get; set; }
        public float DureeRestanteEstimee { get; set; }
        public string CodeModule { get; set; }
        public string CodeLogicielModule { get; set; }
        public float NumeroVersion { get; set; }
        public string CodeLogicielVersion { get; set; }
    }
}
