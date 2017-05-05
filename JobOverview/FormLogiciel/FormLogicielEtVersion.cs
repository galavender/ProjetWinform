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
    public partial class FormLogicielEtVersion : Form
    {
        List<Logiciel> LstLogiciel;

        public FormLogicielEtVersion()
        {
            InitializeComponent();
            BtnVersionPlus.Click += BtnVersionPlus_Click;
            BtnSupprimerVersion.Click += BtnSupprimerVersion_Click;
            CbLog.SelectedIndexChanged += CbLog_SelectedIndexChanged;
        }

        //Tente desupprimer la version et ouvre une fenetre de dialogue si une erreur survient
        private void BtnSupprimerVersion_Click(object sender, EventArgs e)
        {
            if (DgvVersion.CurrentRow!=null)
            {
                try
                {
                    DALLogiciel.SupprimerVersion(((Version)DgvVersion.CurrentRow.DataBoundItem).Numero, ((string)CbLog.SelectedItem));
                    LstLogiciel.Where(c => c.Code == (string)CbLog.SelectedItem).Select(c => c.LstVersion).FirstOrDefault().Remove((Version)DgvVersion.CurrentRow.DataBoundItem);
                    DgvVersion.DataSource = LstLogiciel.Where(c => c.Code == (string)CbLog.SelectedItem).Select(c => c.LstVersion).FirstOrDefault().ToList();
                }
                catch
                {
                    MessageBox.Show("Imposible de supprimer la version\nElle est référencé par une tache de production ou une realease", "Erreur de suppression",MessageBoxButtons.OK);
                }
            }
        }

        //Tente d'insérer une version, renvoi un message d'erreur si c'est impossible
        private void BtnVersionPlus_Click(object sender, EventArgs e)
        {
            using (var form = new FormModaleAjoutVersion())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                   if(!LstLogiciel.Where(c=>c.Code==(string)CbLog.SelectedItem).Select(c=>c.LstVersion).FirstOrDefault().Select(c=>c.Numero).Contains(form.version.Numero) 
                        && form.version.Millesime!=0
                        && form.version.DateOuverture !=  DateTime.Parse("01/01/1753")
                        && form.version.DateSortiePrévue != DateTime.Parse("01/01/1753"))
                    {
                        LstLogiciel.Where(c => c.Code == (string)CbLog.SelectedItem).Select(c => c.LstVersion).FirstOrDefault().Add(form.version);
                        DgvVersion.DataSource = LstLogiciel.Where(c => c.Code == (string)CbLog.SelectedItem).Select(c => c.LstVersion).FirstOrDefault().ToList();
                        DALLogiciel.InsertVersion(form.version, ((string)CbLog.SelectedItem));
                    }
                   else
                        MessageBox.Show("Imposible d'insére la version\nSoit elle existe déjà, soit elle est imcomplète", "Erreur d'insertion", MessageBoxButtons.OK);

                }
            }
        }

        //Mise à jour des DataGridView module et version
        private void CbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgvModule.DataSource = LstLogiciel.Where(c => c.Code == (string)CbLog.SelectedItem).Select(c => c.LstModule).FirstOrDefault().ToList();
            DgvVersion.DataSource = LstLogiciel.Where(c => c.Code == (string)CbLog.SelectedItem).Select(c => c.LstVersion).FirstOrDefault().ToList();
        }

        protected override void OnLoad(EventArgs e)
        {
            LstLogiciel = DALLogiciel.GetLogicielFromDataReader();
            CbLog.DataSource = LstLogiciel.Select(c=>c.Code).ToList();
            base.OnLoad(e);
        }
    }
}
