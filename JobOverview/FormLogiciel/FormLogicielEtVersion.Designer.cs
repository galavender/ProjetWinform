namespace JobOverview
{
    partial class FormLogicielEtVersion
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
            this.CbLog = new System.Windows.Forms.ComboBox();
            this.LbLComboBox = new System.Windows.Forms.Label();
            this.DgvModule = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvVersion = new System.Windows.Forms.DataGridView();
            this.BtnVersionPlus = new System.Windows.Forms.Button();
            this.BtnSupprimerVersion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // CbLog
            // 
            this.CbLog.FormattingEnabled = true;
            this.CbLog.Location = new System.Drawing.Point(24, 25);
            this.CbLog.Name = "CbLog";
            this.CbLog.Size = new System.Drawing.Size(113, 21);
            this.CbLog.TabIndex = 0;
            // 
            // LbLComboBox
            // 
            this.LbLComboBox.AutoSize = true;
            this.LbLComboBox.Location = new System.Drawing.Point(21, 9);
            this.LbLComboBox.Name = "LbLComboBox";
            this.LbLComboBox.Size = new System.Drawing.Size(116, 13);
            this.LbLComboBox.TabIndex = 1;
            this.LbLComboBox.Text = "Selectionner un logiciel";
            // 
            // DgvModule
            // 
            this.DgvModule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvModule.Location = new System.Drawing.Point(24, 82);
            this.DgvModule.Name = "DgvModule";
            this.DgvModule.Size = new System.Drawing.Size(597, 219);
            this.DgvModule.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Module";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Version";
            // 
            // DgvVersion
            // 
            this.DgvVersion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvVersion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVersion.Location = new System.Drawing.Point(24, 339);
            this.DgvVersion.Name = "DgvVersion";
            this.DgvVersion.Size = new System.Drawing.Size(597, 127);
            this.DgvVersion.TabIndex = 5;
            // 
            // BtnVersionPlus
            // 
            this.BtnVersionPlus.Location = new System.Drawing.Point(627, 339);
            this.BtnVersionPlus.Name = "BtnVersionPlus";
            this.BtnVersionPlus.Size = new System.Drawing.Size(119, 23);
            this.BtnVersionPlus.TabIndex = 6;
            this.BtnVersionPlus.Text = "Ajouter version";
            this.BtnVersionPlus.UseVisualStyleBackColor = true;
            // 
            // BtnSupprimerVersion
            // 
            this.BtnSupprimerVersion.Location = new System.Drawing.Point(627, 368);
            this.BtnSupprimerVersion.Name = "BtnSupprimerVersion";
            this.BtnSupprimerVersion.Size = new System.Drawing.Size(119, 23);
            this.BtnSupprimerVersion.TabIndex = 7;
            this.BtnSupprimerVersion.Text = "Supprimer version";
            this.BtnSupprimerVersion.UseVisualStyleBackColor = true;
            // 
            // FormLogicielEtVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 514);
            this.Controls.Add(this.BtnSupprimerVersion);
            this.Controls.Add(this.BtnVersionPlus);
            this.Controls.Add(this.DgvVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvModule);
            this.Controls.Add(this.LbLComboBox);
            this.Controls.Add(this.CbLog);
            this.Name = "FormLogicielEtVersion";
            this.Text = "Logiciel Et Version";
            ((System.ComponentModel.ISupportInitialize)(this.DgvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVersion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbLog;
        private System.Windows.Forms.Label LbLComboBox;
        private System.Windows.Forms.DataGridView DgvModule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvVersion;
        private System.Windows.Forms.Button BtnVersionPlus;
        private System.Windows.Forms.Button BtnSupprimerVersion;
    }
}