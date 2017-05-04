using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobOverview.FormLogiciel
{
    public partial class FormLogicielEtVersion : Form
    {
        List<Logiciel> LstLogiciel;

        public FormLogicielEtVersion()
        {
            InitializeComponent();
            BtnVersionPlus.Click += BtnVersionPlus_Click;
            CbLog.SelectedIndexChanged += CbLog_SelectedIndexChanged;
        }

        private void BtnVersionPlus_Click(object sender, EventArgs e)
        {
            using (var form = new FormModaleAjoutVersion())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                   

                }
            }
        }

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
