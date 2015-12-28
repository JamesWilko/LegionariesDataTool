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
			this.components = new System.ComponentModel.Container();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabLocalization = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.treeLocalizationSheets = new System.Windows.Forms.TreeView();
			this.contextLocalizationTree = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextLocalizationOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.contextLocalizationUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this.contextLocalizationHighlight = new System.Windows.Forms.ToolStripMenuItem();
			this.contextLocalizationRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonUpdateSpreadsheets = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonAddNewSpreadsheet = new System.Windows.Forms.Button();
			this.textBoxTabId = new System.Windows.Forms.TextBox();
			this.textBoxSpreadsheetId = new System.Windows.Forms.TextBox();
			this.dataGridLocalization = new System.Windows.Forms.DataGridView();
			this.columnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.columnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabUnits = new System.Windows.Forms.TabPage();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.legionDefenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lDToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportLocalizationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportUnitsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportHeroesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSkillsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportWavesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jamesWilkinsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tabControl1.SuspendLayout();
			this.tabLocalization.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.contextLocalizationTree.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridLocalization)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabLocalization);
			this.tabControl1.Controls.Add(this.tabUnits);
			this.tabControl1.Location = new System.Drawing.Point(12, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(884, 512);
			this.tabControl1.TabIndex = 0;
			// 
			// tabLocalization
			// 
			this.tabLocalization.Controls.Add(this.splitContainer1);
			this.tabLocalization.Location = new System.Drawing.Point(4, 22);
			this.tabLocalization.Name = "tabLocalization";
			this.tabLocalization.Padding = new System.Windows.Forms.Padding(3);
			this.tabLocalization.Size = new System.Drawing.Size(876, 486);
			this.tabLocalization.TabIndex = 0;
			this.tabLocalization.Text = "Localization";
			this.tabLocalization.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridLocalization);
			this.splitContainer1.Size = new System.Drawing.Size(870, 480);
			this.splitContainer1.SplitterDistance = 290;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.treeLocalizationSheets);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.panel1);
			this.splitContainer2.Size = new System.Drawing.Size(290, 480);
			this.splitContainer2.SplitterDistance = 310;
			this.splitContainer2.TabIndex = 0;
			// 
			// treeLocalizationSheets
			// 
			this.treeLocalizationSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeLocalizationSheets.ContextMenuStrip = this.contextLocalizationTree;
			this.treeLocalizationSheets.Location = new System.Drawing.Point(3, 3);
			this.treeLocalizationSheets.Name = "treeLocalizationSheets";
			this.treeLocalizationSheets.Size = new System.Drawing.Size(284, 304);
			this.treeLocalizationSheets.TabIndex = 0;
			// 
			// contextLocalizationTree
			// 
			this.contextLocalizationTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextLocalizationOpen,
            this.contextLocalizationUpdate,
            this.contextLocalizationHighlight,
            this.contextLocalizationRemove});
			this.contextLocalizationTree.Name = "contextLocalizationTree";
			this.contextLocalizationTree.Size = new System.Drawing.Size(125, 92);
			// 
			// contextLocalizationOpen
			// 
			this.contextLocalizationOpen.Name = "contextLocalizationOpen";
			this.contextLocalizationOpen.Size = new System.Drawing.Size(124, 22);
			this.contextLocalizationOpen.Text = "Open";
			this.contextLocalizationOpen.Click += new System.EventHandler(this.contextLocalizationOpen_Click);
			// 
			// contextLocalizationUpdate
			// 
			this.contextLocalizationUpdate.Name = "contextLocalizationUpdate";
			this.contextLocalizationUpdate.Size = new System.Drawing.Size(124, 22);
			this.contextLocalizationUpdate.Text = "Update";
			this.contextLocalizationUpdate.Click += new System.EventHandler(this.contextLocalizationUpdate_Click);
			// 
			// contextLocalizationHighlight
			// 
			this.contextLocalizationHighlight.Name = "contextLocalizationHighlight";
			this.contextLocalizationHighlight.Size = new System.Drawing.Size(124, 22);
			this.contextLocalizationHighlight.Text = "Highlight";
			this.contextLocalizationHighlight.Click += new System.EventHandler(this.contextLocalizationHighlight_Click);
			// 
			// contextLocalizationRemove
			// 
			this.contextLocalizationRemove.Name = "contextLocalizationRemove";
			this.contextLocalizationRemove.Size = new System.Drawing.Size(124, 22);
			this.contextLocalizationRemove.Text = "Remove";
			this.contextLocalizationRemove.Click += new System.EventHandler(this.contextLocalizationRemove_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.buttonUpdateSpreadsheets);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.buttonAddNewSpreadsheet);
			this.panel1.Controls.Add(this.textBoxTabId);
			this.panel1.Controls.Add(this.textBoxSpreadsheetId);
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(284, 160);
			this.panel1.TabIndex = 0;
			// 
			// buttonUpdateSpreadsheets
			// 
			this.buttonUpdateSpreadsheets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpdateSpreadsheets.Location = new System.Drawing.Point(6, 84);
			this.buttonUpdateSpreadsheets.Name = "buttonUpdateSpreadsheets";
			this.buttonUpdateSpreadsheets.Size = new System.Drawing.Size(275, 23);
			this.buttonUpdateSpreadsheets.TabIndex = 5;
			this.buttonUpdateSpreadsheets.Text = "Update Spreadsheets";
			this.buttonUpdateSpreadsheets.UseVisualStyleBackColor = true;
			this.buttonUpdateSpreadsheets.Click += new System.EventHandler(this.buttonUpdateSpreadsheets_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tab";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Spreadsheet";
			// 
			// buttonAddNewSpreadsheet
			// 
			this.buttonAddNewSpreadsheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewSpreadsheet.Location = new System.Drawing.Point(6, 55);
			this.buttonAddNewSpreadsheet.Name = "buttonAddNewSpreadsheet";
			this.buttonAddNewSpreadsheet.Size = new System.Drawing.Size(275, 23);
			this.buttonAddNewSpreadsheet.TabIndex = 2;
			this.buttonAddNewSpreadsheet.Text = "Add New Spreadsheet";
			this.buttonAddNewSpreadsheet.UseVisualStyleBackColor = true;
			this.buttonAddNewSpreadsheet.Click += new System.EventHandler(this.buttonAddNewSpreadsheet_Click);
			// 
			// textBoxTabId
			// 
			this.textBoxTabId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTabId.Location = new System.Drawing.Point(76, 29);
			this.textBoxTabId.Name = "textBoxTabId";
			this.textBoxTabId.Size = new System.Drawing.Size(205, 20);
			this.textBoxTabId.TabIndex = 1;
			// 
			// textBoxSpreadsheetId
			// 
			this.textBoxSpreadsheetId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSpreadsheetId.Location = new System.Drawing.Point(76, 3);
			this.textBoxSpreadsheetId.Name = "textBoxSpreadsheetId";
			this.textBoxSpreadsheetId.Size = new System.Drawing.Size(205, 20);
			this.textBoxSpreadsheetId.TabIndex = 0;
			// 
			// dataGridLocalization
			// 
			this.dataGridLocalization.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridLocalization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridLocalization.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnKey,
            this.columnText});
			this.dataGridLocalization.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridLocalization.Location = new System.Drawing.Point(0, 0);
			this.dataGridLocalization.Name = "dataGridLocalization";
			this.dataGridLocalization.Size = new System.Drawing.Size(576, 480);
			this.dataGridLocalization.TabIndex = 0;
			// 
			// columnKey
			// 
			this.columnKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.columnKey.FillWeight = 30F;
			this.columnKey.HeaderText = "Key";
			this.columnKey.Name = "columnKey";
			this.columnKey.ReadOnly = true;
			// 
			// columnText
			// 
			this.columnText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.columnText.FillWeight = 60F;
			this.columnText.HeaderText = "Text";
			this.columnText.Name = "columnText";
			this.columnText.ReadOnly = true;
			// 
			// tabUnits
			// 
			this.tabUnits.Location = new System.Drawing.Point(4, 22);
			this.tabUnits.Name = "tabUnits";
			this.tabUnits.Padding = new System.Windows.Forms.Padding(3);
			this.tabUnits.Size = new System.Drawing.Size(876, 486);
			this.tabUnits.TabIndex = 1;
			this.tabUnits.Text = "Units";
			this.tabUnits.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(908, 24);
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
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.exportSkillsFileToolStripMenuItem,
            this.exportWavesFileToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.exportToolStripMenuItem.Text = "Export";
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
			// legionDefenceToolStripMenuItem
			// 
			this.legionDefenceToolStripMenuItem.Name = "legionDefenceToolStripMenuItem";
			this.legionDefenceToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
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
			// exportLocalizationFileToolStripMenuItem
			// 
			this.exportLocalizationFileToolStripMenuItem.Name = "exportLocalizationFileToolStripMenuItem";
			this.exportLocalizationFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportLocalizationFileToolStripMenuItem.Text = "Export Localization File";
			// 
			// exportUnitsFileToolStripMenuItem
			// 
			this.exportUnitsFileToolStripMenuItem.Name = "exportUnitsFileToolStripMenuItem";
			this.exportUnitsFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportUnitsFileToolStripMenuItem.Text = "Export Units File";
			// 
			// exportHeroesFileToolStripMenuItem
			// 
			this.exportHeroesFileToolStripMenuItem.Name = "exportHeroesFileToolStripMenuItem";
			this.exportHeroesFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportHeroesFileToolStripMenuItem.Text = "Export Heroes File";
			// 
			// exportSkillsFileToolStripMenuItem
			// 
			this.exportSkillsFileToolStripMenuItem.Name = "exportSkillsFileToolStripMenuItem";
			this.exportSkillsFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportSkillsFileToolStripMenuItem.Text = "Export Skills File";
			// 
			// exportWavesFileToolStripMenuItem
			// 
			this.exportWavesFileToolStripMenuItem.Name = "exportWavesFileToolStripMenuItem";
			this.exportWavesFileToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportWavesFileToolStripMenuItem.Text = "Export Waves File";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
			// 
			// exportAllToolStripMenuItem
			// 
			this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
			this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.exportAllToolStripMenuItem.Text = "Export All";
			// 
			// jamesWilkinsonToolStripMenuItem
			// 
			this.jamesWilkinsonToolStripMenuItem.Name = "jamesWilkinsonToolStripMenuItem";
			this.jamesWilkinsonToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.jamesWilkinsonToolStripMenuItem.Text = "James Wilkinson";
			this.jamesWilkinsonToolStripMenuItem.Click += new System.EventHandler(this.jamesWilkinsonToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 551);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.Text = "Legion Defence Tool";
			this.tabControl1.ResumeLayout(false);
			this.tabLocalization.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.contextLocalizationTree.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridLocalization)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabLocalization;
		private System.Windows.Forms.TabPage tabUnits;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.TreeView treeLocalizationSheets;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonAddNewSpreadsheet;
		private System.Windows.Forms.TextBox textBoxTabId;
		private System.Windows.Forms.TextBox textBoxSpreadsheetId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonUpdateSpreadsheets;
		private System.Windows.Forms.ContextMenuStrip contextLocalizationTree;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationUpdate;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationRemove;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationOpen;
		private System.Windows.Forms.ToolStripMenuItem contextLocalizationHighlight;
		private System.Windows.Forms.DataGridView dataGridLocalization;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnKey;
		private System.Windows.Forms.DataGridViewTextBoxColumn columnText;
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
		private System.Windows.Forms.ToolStripMenuItem exportSkillsFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportWavesFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem legionDefenceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lDToolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jamesWilkinsonToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}

