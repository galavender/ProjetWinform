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
        public static List<TacheProd> LstTacheProd { get; set; } = new List<TacheProd>();
        public static List<TacheProd> LstTacheProdInsert { get; set; } = new List<TacheProd>();
        public List<Version> LstVersion { get; set; } = new List<Version>();
        public FormTachesProduction()
        {
            InitializeComponent();

            CbVersion.SelectedValueChanged += CbVersion_SelectedValueChanged;
            CbPersonne.SelectedValueChanged += CbVersion_SelectedValueChanged;
            DgvTacheProd.SelectionChanged += DgvTacheProd_SelectionChanged;
            BtnAjoutTache.Click += BtnAjoutTache_Click;
            BtnAjoutTache.Click += CbVersion_SelectedValueChanged;
            CheckBTermi.Click += CbVersion_SelectedValueChanged;
        }

        private void BtnAjoutTache_Click(object sender, EventArgs e)
        {
            using (var form = new FormSaisieTache())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    foreach (var item in form.LstTacheProd)
                    {
                        LstTacheProd.Add(item);
                        LstTacheProdInsert.Add(item);
                    }
                    DALTaches.InsertTache(LstTacheProdInsert);
                    LstTacheProdInsert.Clear();
                }
            }
        }

        private void DgvTacheProd_SelectionChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((TacheProd)DgvTacheProd.CurrentRow.DataBoundItem).Description))
                LblDescriptionTache.Text = ((TacheProd)DgvTacheProd.CurrentRow.DataBoundItem).Description;
            else
                LblDescriptionTache.Text = "Pas de descripttion pour cette tache";
        }

        private void CbVersion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CheckBTermi.Checked)
            {
                List<TacheProd> lst = LstTacheProd.Where(c => c.Login == ((Personne)CbPersonne.SelectedItem).Login && c.NumeroVersion == ((Version)CbVersion.SelectedItem).Numero && c.DureeRestanteEstimee == 0).ToList();
                DgvTacheProd.DataSource = lst;
            }
            else
            {
                List<TacheProd> lst =LstTacheProd.Where(c => c.Login == ((Personne)CbPersonne.SelectedItem).Login && c.NumeroVersion == ((Version)CbVersion.SelectedItem).Numero && c.DureeRestanteEstimee != 0).ToList();
                DgvTacheProd.DataSource = lst;
            }
            DgvTacheProd.Columns["CodeLogicielVersion"].Visible = false;
            DgvTacheProd.Columns["Description"].Visible = false;
            DgvTacheProd.Columns["IdTache"].Visible = false;
            DgvTacheProd.Columns["Annexe"].Visible = false;


        }

        protected override void OnLoad(EventArgs e)
        {
            LstPersonnes = DALTaches.GetPersonnes();
            foreach (var item in DALTaches.GetTacheProd())
            {
                LstTacheProd.Add(item);
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
