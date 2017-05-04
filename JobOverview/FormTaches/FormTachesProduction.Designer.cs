namespace JobOverview
{
    partial class FormTachesProduction
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
            this.CbPersonne = new System.Windows.Forms.ComboBox();
            this.CbVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckBTermi = new System.Windows.Forms.CheckBox();
            this.DgvTacheProd = new System.Windows.Forms.DataGridView();
            this.LblDescriptionTache = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTacheProd)).BeginInit();
            this.SuspendLayout();
            // 
            // CbPersonne
            // 
            this.CbPersonne.FormattingEnabled = true;
            this.CbPersonne.Location = new System.Drawing.Point(36, 33);
            this.CbPersonne.Name = "CbPersonne";
            this.CbPersonne.Size = new System.Drawing.Size(121, 21);
            this.CbPersonne.TabIndex = 0;
            // 
            // CbVersion
            // 
            this.CbVersion.FormattingEnabled = true;
            this.CbVersion.Location = new System.Drawing.Point(199, 33);
            this.CbVersion.Name = "CbVersion";
            this.CbVersion.Size = new System.Drawing.Size(121, 21);
            this.CbVersion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Personnes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Version";
            // 
            // CheckBTermi
            // 
            this.CheckBTermi.AutoSize = true;
            this.CheckBTermi.Location = new System.Drawing.Point(360, 35);
            this.CheckBTermi.Name = "CheckBTermi";
            this.CheckBTermi.Size = new System.Drawing.Size(110, 17);
            this.CheckBTermi.TabIndex = 5;
            this.CheckBTermi.Text = "Tâches terminées";
            this.CheckBTermi.UseVisualStyleBackColor = true;
            // 
            // DgvTacheProd
            // 
            this.DgvTacheProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTacheProd.Location = new System.Drawing.Point(36, 101);
            this.DgvTacheProd.Name = "DgvTacheProd";
            this.DgvTacheProd.Size = new System.Drawing.Size(406, 368);
            this.DgvTacheProd.TabIndex = 6;
            // 
            // LblDescriptionTache
            // 
            this.LblDescriptionTache.AutoSize = true;
            this.LblDescriptionTache.Location = new System.Drawing.Point(488, 101);
            this.LblDescriptionTache.MaximumSize = new System.Drawing.Size(200, 0);
            this.LblDescriptionTache.Name = "LblDescriptionTache";
            this.LblDescriptionTache.Size = new System.Drawing.Size(93, 13);
            this.LblDescriptionTache.TabIndex = 7;
            this.LblDescriptionTache.Text = "Description tâche ";
            // 
            // FormTachesProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 514);
            this.Controls.Add(this.LblDescriptionTache);
            this.Controls.Add(this.DgvTacheProd);
            this.Controls.Add(this.CheckBTermi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbVersion);
            this.Controls.Add(this.CbPersonne);
            this.Name = "FormTachesProduction";
            this.Text = "FormTachesProduction";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTacheProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbPersonne;
        private System.Windows.Forms.ComboBox CbVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckBTermi;
        private System.Windows.Forms.DataGridView DgvTacheProd;
        private System.Windows.Forms.Label LblDescriptionTache;
    }
}