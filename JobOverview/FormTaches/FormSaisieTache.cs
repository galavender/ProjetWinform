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
    public partial class FormSaisieTache : Form
    {
        private List<string> LstCodeActivité { get; set; }
        private List<Logiciel> LstLogiciel { get; set; }
        private List<Personne> LstPersonne { get; set; }
        public List<TacheProd> LstTacheProd { get; set; } = new List<TacheProd>();

        public FormSaisieTache()
        {
            InitializeComponent();
            CbLogiciel.SelectedValueChanged += CbLogiciel_SelectedValueChanged;
            BtnAjouter.Click += BtnAjouter_Click;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            var tacheproduction = new TacheProd();
            tacheproduction.Annexe = false;
            tacheproduction.CodeActivité = (string)CbActivité.SelectedValue;
            tacheproduction.CodeLogicielModule = (string)CbLogiciel.SelectedValue;
            tacheproduction.CodeLogicielVersion = (string)CbLogiciel.SelectedValue;
            tacheproduction.CodeModule = (string)CbModule.SelectedValue;
            tacheproduction.Description = TbDescription.Text;
            tacheproduction.DureePrevue = float.Parse(TbDuréePrévue.Text);
            tacheproduction.DureeRestanteEstimee = float.Parse(TbDuréePrévue.Text);
            tacheproduction.IdTache = Guid.NewGuid();
            tacheproduction.Libelle = TbLibelle.Text;
            tacheproduction.Login = (string)CbPersonne.SelectedValue;
            tacheproduction.NumeroVersion = float.Parse(CbVersion.SelectedValue.ToString());

            LstTacheProd.Add(tacheproduction);
        }

        private void CbLogiciel_SelectedValueChanged(object sender, EventArgs e)
        {
            CbModule.DataSource = LstLogiciel.Where(c => c.Code == (string)CbLogiciel.SelectedValue).Select(c => c.LstModule).FirstOrDefault().Select(c=>c.Code).ToList();
            CbVersion.DataSource = LstLogiciel.Where(c => c.Code == (string)CbLogiciel.SelectedValue).Select(c => c.LstVersion).FirstOrDefault().Select(c => c.Numero).ToList();
        }

        protected override void OnLoad(EventArgs e)
        {
            LstCodeActivité = DALTaches.GetCodeActivité();
            LstLogiciel = DALLogiciel.GetLogicielFromDataReader();
            LstPersonne = DALTaches.GetPersonnes();
            CbPersonne.DataSource = LstPersonne.Select(c=>c.Login).ToList();
            CbLogiciel.DataSource = LstLogiciel.Select(c => c.Code).ToList();
            CbActivité.DataSource = LstCodeActivité;
            base.OnLoad(e);
        }
    }
}
