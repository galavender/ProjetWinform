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
        //Déclaration des listes qui seront affichées dans les ComboBox ou le DataGridView
        public List<Personne> LstPersonnes { get; set; }
        public static List<TacheProd> LstTacheProd { get; set; } = new List<TacheProd>();
        public List<Version> LstVersion { get; set; } = new List<Version>();

        public FormTachesProduction()
        {
            InitializeComponent();

            //Branchement des différentes méthodes
            CbVersion.SelectedValueChanged += CbVersion_SelectedValueChanged;
            CbPersonne.SelectedValueChanged += CbVersion_SelectedValueChanged;
            DgvTacheProd.SelectionChanged += DgvTacheProd_SelectionChanged;
            BtnAjoutTache.Click += BtnAjoutTache_Click;
            BtnAjoutTache.Click += CbVersion_SelectedValueChanged;
            CheckBTermi.Click += CbVersion_SelectedValueChanged;
        }

        //Insertion de nouvelle(s) tache(s)
        private void BtnAjoutTache_Click(object sender, EventArgs e)
        {
            //Ouverture d'une fenetre d'insertion
            using (var form = new FormSaisieTache())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Insertion des nouvelles taches dans la liste LstTacheProd
                    foreach (var item in form.LstTacheProd)
                    {
                        LstTacheProd.Add(item);
                    }

                    //Insertion des nouvelles taches dans le base de données
                    DALTaches.InsertTache(form.LstTacheProd);
                }
            }
        }

        //Mise à jour de la description de la tache selectionnée dans le DataGridView
        private void DgvTacheProd_SelectionChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((TacheProd)DgvTacheProd.CurrentRow.DataBoundItem).Description))
                LblDescriptionTache.Text = ((TacheProd)DgvTacheProd.CurrentRow.DataBoundItem).Description;
            else
                LblDescriptionTache.Text = "Pas de descripttion pour cette tache";
        }

        //Chargement des données à afficher dans le DataGridView en fonction des éléments selectionner dans les ComboBox
        private void CbVersion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CbVersion.SelectedItem != null && CbPersonne !=null)
            {
                if (CheckBTermi.Checked)
                    DgvTacheProd.DataSource = LstTacheProd.Where(c => c.Login == ((Personne)CbPersonne.SelectedItem).Login && c.NumeroVersion == ((Version)CbVersion.SelectedItem).Numero && c.DureeRestanteEstimee == 0).ToList();

                else
                    DgvTacheProd.DataSource = LstTacheProd.Where(c => c.Login == ((Personne)CbPersonne.SelectedItem).Login && c.NumeroVersion == ((Version)CbVersion.SelectedItem).Numero && c.DureeRestanteEstimee != 0).ToList();

                //Selection des colonnes à ne pas afficher
                DgvTacheProd.Columns["CodeLogicielVersion"].Visible = false;
                DgvTacheProd.Columns["Description"].Visible = false;
                DgvTacheProd.Columns["IdTache"].Visible = false;
                DgvTacheProd.Columns["Annexe"].Visible = false;
            }
        }

        //Chargement des éléments dans les différentes ComboBox et appel des méthodes du DalTaches pour charger les listes
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
