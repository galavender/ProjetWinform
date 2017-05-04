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
    public partial class FormModaleAjoutVersion : Form
    {
        public Version version { get; set; } = new Version();
        public FormModaleAjoutVersion()
        {
            InitializeComponent();

            version.DateOuverture = DateTime.Parse("01/01/1753");
            version.DateSortiePrévue = DateTime.Parse("01/01/1753");
            version.DateSortieRéelle = DateTime.Parse("01/01/1753");


            DtpDateOuverture.ValueChanged += (object sender, EventArgs e)=> { version.DateOuverture = DtpDateOuverture.Value; };
            DtpDateSortiePrevue.ValueChanged += (object sender, EventArgs e) => { version.DateSortiePrévue = DtpDateSortiePrevue.Value; };
            DtpDateSortieReelle.ValueChanged += (object sender, EventArgs e) => { version.DateSortieRéelle = DtpDateSortieReelle.Value; };
        }

        protected override void OnClosing(CancelEventArgs e)
        {

            if (this.DialogResult==DialogResult.OK)
            {
                float f;
                if (TbNumero.Text != "" && float.TryParse(TbNumero.Text,out f))
                    version.Numero = f;
                Int16 i;
                if (TbMillesime.Text != "" && Int16.TryParse(TbMillesime.Text, out i))
                    version.Millesime = i;

            }

            base.OnClosing(e);
        }
    }
}
