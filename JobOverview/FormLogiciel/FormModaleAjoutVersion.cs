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
    public partial class FormModaleAjoutVersion : Form
    {
        public Version version { get; set; }
        public FormModaleAjoutVersion()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult==DialogResult.OK)
            {
                if (TbNumero.Text != "")
                    version.Numero = float.Parse(TbNumero.Text);
                if (TbMillesime.Text != "")
                    version.Millesime = Int16.Parse(TbMillesime.Text);
               
            }
            base.OnClosing(e);
        }
    }
}
