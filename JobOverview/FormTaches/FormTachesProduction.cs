using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobOverview
{
    public partial class FormTachesProduction : Form
    {

        public List<Personne> LstPersonnes { get; set; }
        //public List<TacheProd> LstTacheProd { get; set; }
        public List<Version> LstVersion { get; set; } = new List<Version>();
        public FormTachesProduction()
        {
            InitializeComponent();

            CbVersion.SelectedValueChanged += CbVersion_SelectedValueChanged;
            CbPersonne.SelectedValueChanged += CbVersion_SelectedValueChanged;
        }

        private void CbVersion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CheckBTermi.Checked)
                DgvTacheProd.DataSource = MDIForm.LstTacheProd.Where(c => c.Login == (string)CbPersonne.SelectedValue && c.NumeroVersion == (float)CbVersion.SelectedValue && c.DureeRestanteEstimee == 0);

            else
                DgvTacheProd.DataSource = MDIForm.LstTacheProd.Where(c => c.Login == (string)CbPersonne.SelectedValue && c.NumeroVersion == (float)CbVersion.SelectedValue && c.DureeRestanteEstimee != 0);

        }

        protected override void OnLoad(EventArgs e)
        {
            LstPersonnes = DALTaches.GetPersonnes();
            foreach (var item in DALTaches.GetTacheProd())
            {
                MDIForm.LstTacheProd.Add(item);
            }
          
            LstVersion = DALTaches.GetVersion();

            CbPersonne.DataSource = LstPersonnes;
            CbVersion.DataSource = LstVersion;

            CbPersonne.DisplayMember = "Nom";
            CbPersonne.ValueMember = "Login";

            CbVersion.DisplayMember = "Numero";
            CbVersion.ValueMember = "Numero";

           
            base.OnLoad(e);
        }
    }
}
