namespace LegionDefenceTool
{
	partial class Main
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabUnits = new System.Windows.Forms.TabPage();
			this.tabHeroes = new System.Windows.Forms.TabPage();
			this.tabLocalization = new System.Windows.Forms.TabPage();
			this.contextLocalizationOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.contextLocalizationUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this.contextLocalizationHighlight = new System.Windows.Forms.ToolStripMenuItem();
			this.contextLocalizationRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exportLocalizationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportUnitsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportHeroesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAbilitiesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportWavesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jamesWilkinsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.legionDefenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lDToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.spreadsheetDisplayUnits = new LegionDefenceTool.Interface.SpreadsheetDataDisplay();
			this.spreadsheetDisplayHeroes = new LegionDefenceTool.Interface.SpreadsheetDataDisplay();
			this.spreadsheetDisplayLocalization = new LegionDefenceTool.Interface.SpreadsheetDataDisplay();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cleanOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabUnits.SuspendLayout();
			this.tabHeroes.SuspendLayout();
			this.tabLocalization.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabUnits);
			this.tabControl1.Controls.Add(this.tabHeroes);
			this.tabControl1.Controls.Add(this.tabLocalization);
			this.tabControl1.Location = new System.Drawing.Point(12, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1071, 666);
			this.tabControl1.TabIndex = 0;
			// 
			// tabUnits
			// 
			this.tabUnits.Controls.Add(this.spreadsheetDisplayUnits);
			this.tabUnits.Location = new System.Drawing.Point(4, 22);
			this.tabUnits.Name = "tabUnits";
			this.tabUnits.Padding = new System.Windows.Forms.Padding(3);
			this.tabUnits.Size = new System.Drawing.Size(1063, 640);
			this.tabUnits.TabIndex = 1;
			this.tabUnits.Text = "Units";
			this.tabUnits.UseVisualStyleBackColor = true;
			// 
			// tabHeroes
			// 
			this.tabHeroes.Controls.Add(this.spreadsheetDisplayHeroes);
			this.tabHeroes.Location = new System.Drawing.Point(4, 22);
			this.tabHeroes.Name = "tabHeroes";
			this.tabHeroes.Size = new System.Drawing.Size(1063, 640);
			this.tabHeroes.TabIndex = 2;
			this.tabHeroes.Text = "Heroes";
			this.tabHeroes.UseVisualStyleBackColor = true;
			// 
			// tabLocalization
			// 
			this.tabLocalization.Controls.Add(this.spreadsheetDisplayLocalization);
			this.tabLocalization.Location = new System.Drawing.Point(4, 22);
			this.tabLocalization.Name = "tabLocalization";
			this.tabLocalization.Padding = new System.Windows.Forms.Padding(3);
			this.tabLocalization.Size = new System.Drawing.Size(1063, 640);
			this.tabLocalization.TabIndex = 3;
			this.tabLocalization.Text = "Localization";
			this.tabLocalization.UseVisualStyleBackColor = true;
			// 
			// contextLocalizationOpen
			// 
			this.contextLocalizationOpen.Name = "contextLocalizationOpen";
			this.contextLocalizationOpen.Size = new System.Drawing.Size(32, 19);
			// 
			// contextLocalizationUpdate
			// 
			this.contextLocalizationUpdate.Name = "contextLocalizationUpdate";
			this.contextLocalizationUpdate.Size = new System.Drawing.Size(32, 19);
			// 
			// contextLocalizationHighlight
			// 
			this.contextLocalizationHighlight.Name = "contextLocalizationHighlight";
			this.contextLocalizationHighlight.Size = new System.Drawing.Size(32, 19);
			// 
			// contextLocalizationRemove
			// 
			this.contextLocalizationRemove.Name = "contextLocalizationRemove";
			this.contextLocalizationRemove.Size = new System.Drawing.Size(32, 19);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(233, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportLocalizationFileToolStripMenuItem,
            this.exportUnitsFileToolStripMenuItem,
            this.exportHeroesFileToolStripMenuItem,
            this.exportAbilitiesFileToolStripMenuItem,
            this.exportWavesFileToolStripMenuItem,
            this.toolStripSeparator3,
            this.cleanOutputFolderToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// exportAllToolStripMenuItem
			// 
			this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
			this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportAllToolStripMenuItem.Text = "Export All";
			this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
			// 
			// exportLocalizationFileToolStripMenuItem
			// 
			this.exportLocalizationFileToolStripMenuItem.Name = "exportLocalizationFileToolStripMenuItem";
			this.exportLocalizationFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportLocalizationFileToolStripMenuItem.Text = "Export Localization File";
			this.exportLocalizationFileToolStripMenuItem.Click += new System.EventHandler(this.exportLocalizationFileToolStripMenuItem_Click);
			// 
			// exportUnitsFileToolStripMenuItem
			// 
			this.exportUnitsFileToolStripMenuItem.Name = "exportUnitsFileToolStripMenuItem";
			this.exportUnitsFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportUnitsFileToolStripMenuItem.Text = "Export Units File";
			this.exportUnitsFileToolStripMenuItem.Click += new System.EventHandler(this.exportUnitsFileToolStripMenuItem_Click);
			// 
			// exportHeroesFileToolStripMenuItem
			// 
			this.exportHeroesFileToolStripMenuItem.Name = "exportHeroesFileToolStripMenuItem";
			this.exportHeroesFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportHeroesFileToolStripMenuItem.Text = "Export Heroes File";
			this.exportHeroesFileToolStripMenuItem.Click += new System.EventHandler(this.exportHeroesFileToolStripMenuItem_Click);
			// 
			// exportAbilitiesFileToolStripMenuItem
			// 
			this.exportAbilitiesFileToolStripMenuItem.Name = "exportAbilitiesFileToolStripMenuItem";
			this.exportAbilitiesFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportAbilitiesFileToolStripMenuItem.Text = "Export Abilities File";
			this.exportAbilitiesFileToolStripMenuItem.Click += new System.EventHandler(this.exportAbilitiesFileToolStripMenuItem_Click);
			// 
			// exportWavesFileToolStripMenuItem
			// 
			this.exportWavesFileToolStripMenuItem.Name = "exportWavesFileToolStripMenuItem";
			this.exportWavesFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportWavesFileToolStripMenuItem.Text = "Export Waves File";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.gitHubToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// gitHubToolStripMenuItem
			// 
			this.gitHubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jamesWilkinsonToolStripMenuItem,
            this.legionDefenceToolStripMenuItem,
            this.lDToolToolStripMenuItem});
			this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
			this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.gitHubToolStripMenuItem.Text = "GitHub";
			// 
			// jamesWilkinsonToolStripMenuItem
			// 
			this.jamesWilkinsonToolStripMenuItem.Name = "jamesWilkinsonToolStripMenuItem";
			this.jamesWilkinsonToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.jamesWilkinsonToolStripMenuItem.Text = "James Wilkinson";
			this.jamesWilkinsonToolStripMenuItem.Click += new System.EventHandler(this.jamesWilkinsonToolStripMenuItem_Click);
			// 
			// legionDefenceToolStripMenuItem
			// 
			this.legionDefenceToolStripMenuItem.Name = "legionDefenceToolStripMenuItem";
			this.legionDefenceToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.legionDefenceToolStripMenuItem.Text = "Legion Defence";
			this.legionDefenceToolStripMenuItem.Click += new System.EventHandler(this.legionDefenceToolStripMenuItem_Click);
			// 
			// lDToolToolStripMenuItem
			// 
			this.lDToolToolStripMenuItem.Name = "lDToolToolStripMenuItem";
			this.lDToolToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.lDToolToolStripMenuItem.Text = "Legion Defence Tool";
			this.lDToolToolStripMenuItem.Click += new System.EventHandler(this.lDToolToolStripMenuItem_Click);
			// 
			// spreadsheetDisplayUnits
			// 
			this.spreadsheetDisplayUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.spreadsheetDisplayUnits.Location = new System.Drawing.Point(3, 3);
			this.spreadsheetDisplayUnits.Name = "spreadsheetDisplayUnits";
			this.spreadsheetDisplayUnits.Size = new System.Drawing.Size(1057, 634);
			this.spreadsheetDisplayUnits.TabIndex = 0;
			// 
			// spreadsheetDisplayHeroes
			// 
			this.spreadsheetDisplayHeroes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.spreadsheetDisplayHeroes.Location = new System.Drawing.Point(3, 3);
			this.spreadsheetDisplayHeroes.Name = "spreadsheetDisplayHeroes";
			this.spreadsheetDisplayHeroes.Size = new System.Drawing.Size(1057, 634);
			this.spreadsheetDisplayHeroes.TabIndex = 0;
			// 
			// spreadsheetDisplayLocalization
			// 
			this.spreadsheetDisplayLocalization.Location = new System.Drawing.Point(3, 3);
			this.spreadsheetDisplayLocalization.Name = "spreadsheetDisplayLocalization";
			this.spreadsheetDisplayLocalization.Size = new System.Drawing.Size(1057, 634);
			this.spreadsheetDisplayLocalization.TabIndex = 0;
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
			// 
			// cleanOutputFolderToolStripMenuItem
			// 
			this.cleanOutputFolderToolStripMenuItem.Name = "cleanOutputFolderToolStripMenuItem";
			this.cleanOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.cleanOutputFolderToolStripMenuItem.Text = "Clean Output Folder";
			this.cleanOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.cleanOutputFolderToolStripMenuItem_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1095, 705);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.Text = "Legion Defence Tool";
			this.tabControl1.ResumeLayout(false);
			this.tabUnits.ResumeLayout(false);
			this.tabHeroes.ResumeLayout(false);
			this.tabLocalization.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabUnits;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationUpdate;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationRemove;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationOpen;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationHighlight;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exportLocalizationFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportUnitsFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportHeroesFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportAbilitiesFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportWavesFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem legionDefenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lDToolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jamesWilkinsonToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabPage tabHeroes;
		private Interface.SpreadsheetDataDisplay spreadsheetDisplayHeroes;
		private Interface.SpreadsheetDataDisplay spreadsheetDisplayUnits;
		private System.Windows.Forms.TabPage tabLocalization;
		private Interface.SpreadsheetDataDisplay spreadsheetDisplayLocalization;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem cleanOutputFolderToolStripMenuItem;
	}
}

