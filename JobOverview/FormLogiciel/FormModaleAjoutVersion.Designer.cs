namespace JobOverview.FormLogiciel
{
    partial class FormModaleAjoutVersion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbNumero = new System.Windows.Forms.TextBox();
            this.TbMillesime = new System.Windows.Forms.TextBox();
            this.DtpDateOuverture = new System.Windows.Forms.DateTimePicker();
            this.DtpDateSortiePrevue = new System.Windows.Forms.DateTimePicker();
            this.DtpDateSortieReelle = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbNumero
            // 
            this.TbNumero.Location = new System.Drawing.Point(157, 35);
            this.TbNumero.Name = "TbNumero";
            this.TbNumero.Size = new System.Drawing.Size(100, 20);
            this.TbNumero.TabIndex = 0;
            // 
            // TbMillesime
            // 
            this.TbMillesime.Location = new System.Drawing.Point(157, 70);
            this.TbMillesime.Name = "TbMillesime";
            this.TbMillesime.Size = new System.Drawing.Size(100, 20);
            this.TbMillesime.TabIndex = 1;
            // 
            // DtpDateOuverture
            // 
            this.DtpDateOuverture.Location = new System.Drawing.Point(157, 105);
            this.DtpDateOuverture.Name = "DtpDateOuverture";
            this.DtpDateOuverture.Size = new System.Drawing.Size(200, 20);
            this.DtpDateOuverture.TabIndex = 2;
            // 
            // DtpDateSortiePrevue
            // 
            this.DtpDateSortiePrevue.Location = new System.Drawing.Point(157, 140);
            this.DtpDateSortiePrevue.Name = "DtpDateSortiePrevue";
            this.DtpDateSortiePrevue.Size = new System.Drawing.Size(200, 20);
            this.DtpDateSortiePrevue.TabIndex = 3;
            // 
            // DtpDateSortieReelle
            // 
            this.DtpDateSortieReelle.Location = new System.Drawing.Point(157, 175);
            this.DtpDateSortieReelle.Name = "DtpDateSortieReelle";
            this.DtpDateSortieReelle.Size = new System.Drawing.Size(200, 20);
            this.DtpDateSortieReelle.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Numero de version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Millesime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date d\'ouverture";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date de sortie prévue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Date de sortie réelle";
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Location = new System.Drawing.Point(68, 221);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 10;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // BtnAnnuler
            // 
            this.BtnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAnnuler.Location = new System.Drawing.Point(182, 221);
            this.BtnAnnuler.Name = "BtnAnnuler";
            this.BtnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.BtnAnnuler.TabIndex = 11;
            this.BtnAnnuler.Text = "Annuler";
            this.BtnAnnuler.UseVisualStyleBackColor = true;
            // 
            // FormModaleAjoutVersion
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnAnnuler;
            this.ClientSize = new System.Drawing.Size(384, 274);
            this.ControlBox = false;
            this.Controls.Add(this.BtnAnnuler);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpDateSortieReelle);
            this.Controls.Add(this.DtpDateSortiePrevue);
            this.Controls.Add(this.DtpDateOuverture);
            this.Controls.Add(this.TbMillesime);
            this.Controls.Add(this.TbNumero);
            this.Name = "FormModaleAjoutVersion";
            this.Text = "FormModaleAjoutVersion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbNumero;
        private System.Windows.Forms.TextBox TbMillesime;
        private System.Windows.Forms.DateTimePicker DtpDateOuverture;
        private System.Windows.Forms.DateTimePicker DtpDateSortiePrevue;
        private System.Windows.Forms.DateTimePicker DtpDateSortieReelle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnAnnuler;
    }
}