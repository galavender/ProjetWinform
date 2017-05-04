namespace JobOverview
{
	partial class MDIForm
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.menuGeneral = new System.Windows.Forms.MenuStrip();
            this.MenuLogEtVers = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTache = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTacheProd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTachesAnnexes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTempsDeTravail = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuGeneral
            // 
            this.menuGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLogEtVers,
            this.MenuTache,
            this.MenuTempsDeTravail,
            this.importExportToolStripMenuItem,
            this.menuWindows});
            this.menuGeneral.Location = new System.Drawing.Point(0, 0);
            this.menuGeneral.Name = "menuGeneral";
            this.menuGeneral.Size = new System.Drawing.Size(787, 24);
            this.menuGeneral.TabIndex = 0;
            this.menuGeneral.Text = "menuStrip1";
            // 
            // MenuLogEtVers
            // 
            this.MenuLogEtVers.Name = "MenuLogEtVers";
            this.MenuLogEtVers.Size = new System.Drawing.Size(119, 20);
            this.MenuLogEtVers.Text = "Logiciels et version";
            // 
            // MenuTache
            // 
            this.MenuTache.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTacheProd,
            this.MenuTachesAnnexes});
            this.MenuTache.Name = "MenuTache";
            this.MenuTache.Size = new System.Drawing.Size(55, 20);
            this.MenuTache.Text = "Tâches";
            // 
            // MenuTacheProd
            // 
            this.MenuTacheProd.Name = "MenuTacheProd";
            this.MenuTacheProd.Size = new System.Drawing.Size(188, 22);
            this.MenuTacheProd.Text = "Tâches de production";
            // 
            // MenuTachesAnnexes
            // 
            this.MenuTachesAnnexes.Name = "MenuTachesAnnexes";
            this.MenuTachesAnnexes.Size = new System.Drawing.Size(188, 22);
            this.MenuTachesAnnexes.Text = "Tâches annexes";
            // 
            // MenuTempsDeTravail
            // 
            this.MenuTempsDeTravail.Name = "MenuTempsDeTravail";
            this.MenuTempsDeTravail.Size = new System.Drawing.Size(105, 20);
            this.MenuTempsDeTravail.Text = "Temps de travail";
            // 
            // menuWindows
            // 
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(63, 20);
            this.menuWindows.Text = "Fenêtres";
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuImport,
            this.MenuExport});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // MenuImport
            // 
            this.MenuImport.Name = "MenuImport";
            this.MenuImport.Size = new System.Drawing.Size(152, 22);
            this.MenuImport.Text = "Import";
            // 
            // MenuExport
            // 
            this.MenuExport.Name = "MenuExport";
            this.MenuExport.Size = new System.Drawing.Size(152, 22);
            this.MenuExport.Text = "Export";
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 514);
            this.Controls.Add(this.menuGeneral);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuGeneral;
            this.Name = "MDIForm";
            this.Text = "JobOverview";
            this.menuGeneral.ResumeLayout(false);
            this.menuGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuGeneral;
		private System.Windows.Forms.ToolStripMenuItem MenuLogEtVers;
		private System.Windows.Forms.ToolStripMenuItem menuWindows;
		private System.Windows.Forms.ToolStripMenuItem MenuTache;
        private System.Windows.Forms.ToolStripMenuItem MenuTacheProd;
        private System.Windows.Forms.ToolStripMenuItem MenuTachesAnnexes;
        private System.Windows.Forms.ToolStripMenuItem MenuTempsDeTravail;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuImport;
        private System.Windows.Forms.ToolStripMenuItem MenuExport;
    }
}

