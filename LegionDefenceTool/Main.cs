using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LegionDefenceTool.Data;
using LegionDefenceTool.Generators;
using LegionDefenceTool.Interface;
using System.IO;

namespace LegionDefenceTool
{
	public partial class Main : Form
	{
		LegionDatabase Database;
		DotaData DotaDatabase;

		SpreadsheetDataDisplayTab<LocalizedLanguage, LocalizationDataTable> LocalizationTab;
		SpreadsheetDataDisplayTab<LegionUnit, UnitDataTable> UnitsTab;
		SpreadsheetDataDisplayTab<LegionHero, HeroDataTable> HeroesTab;
		SpreadsheetDataDisplayTab<LegionAbility, AbilityDataTable> AbilitiesTab;

		public Main()
		{
			InitializeComponent();
			Database = new LegionDatabase();
			Database = Database.Load() ?? Database;
			Database.Setup();

			DotaDatabase = new DotaData();
			DotaDatabase.Load();

			// Localization Tab
			LocalizationTab = new SpreadsheetDataDisplayTab<LocalizedLanguage, LocalizationDataTable>();
			LocalizationTab.DataTreeView = spreadsheetDisplayLocalization.treeData;
			LocalizationTab.SourcesTreeView = spreadsheetDisplayLocalization.treeDataSources;
			LocalizationTab.AddSourceButton = spreadsheetDisplayLocalization.buttonAddSpreadsheet;
			LocalizationTab.UpdateButton = spreadsheetDisplayLocalization.buttonUpdateSpreadsheets;
			LocalizationTab.RebuildButton = spreadsheetDisplayLocalization.buttonRebuildTrees;
			LocalizationTab.SpreadsheetIDTextBox = spreadsheetDisplayLocalization.textSpreadsheetId;
			LocalizationTab.TabIDTextBox = spreadsheetDisplayLocalization.textTabId;
			LocalizationTab.DataView = spreadsheetDisplayLocalization.dataGridInfo;
			LocalizationTab.AddSourceFunc = Database.AddNewLocalizationSheet;
			LocalizationTab.RemoveSourceFunc = Database.RemoveLocalizationSheet;
			LocalizationTab.GetDataFunc = Database.GetLocalizationLanguages;
			LocalizationTab.GetSourcesFunc = Database.GetLocalizationSheets;
			LocalizationTab.OnPreRebuildFunc = Database.RebuildLanguageCache;
			LocalizationTab.Setup(Database);
			LocalizationTab.Rebuild();

			// Units Tab
			UnitsTab = new SpreadsheetDataDisplayTab<LegionUnit, UnitDataTable>();
			UnitsTab.DataTreeView = spreadsheetDisplayUnits.treeData;
			UnitsTab.SourcesTreeView = spreadsheetDisplayUnits.treeDataSources;
			UnitsTab.AddSourceButton = spreadsheetDisplayUnits.buttonAddSpreadsheet;
			UnitsTab.UpdateButton = spreadsheetDisplayUnits.buttonUpdateSpreadsheets;
			UnitsTab.RebuildButton = spreadsheetDisplayUnits.buttonRebuildTrees;
			UnitsTab.SpreadsheetIDTextBox = spreadsheetDisplayUnits.textSpreadsheetId;
			UnitsTab.TabIDTextBox = spreadsheetDisplayUnits.textTabId;
			UnitsTab.DataView = spreadsheetDisplayUnits.dataGridInfo;
			UnitsTab.AddSourceFunc = Database.AddNewUnitSheet;
			UnitsTab.RemoveSourceFunc = Database.RemoveUnitSheet;
			UnitsTab.GetDataFunc = Database.GetUnits;
			UnitsTab.GetSourcesFunc = Database.GetUnitSheets;
			UnitsTab.OnPreRebuildFunc = Database.RebuildUnitCache;
			UnitsTab.Setup(Database);
			UnitsTab.Rebuild();

			// Heroes Tab
			HeroesTab = new SpreadsheetDataDisplayTab<LegionHero, HeroDataTable>();
			HeroesTab.DataTreeView = spreadsheetDisplayHeroes.treeData;
			HeroesTab.SourcesTreeView = spreadsheetDisplayHeroes.treeDataSources;
			HeroesTab.AddSourceButton = spreadsheetDisplayHeroes.buttonAddSpreadsheet;
			HeroesTab.UpdateButton = spreadsheetDisplayHeroes.buttonUpdateSpreadsheets;
			HeroesTab.RebuildButton = spreadsheetDisplayHeroes.buttonRebuildTrees;
			HeroesTab.SpreadsheetIDTextBox = spreadsheetDisplayHeroes.textSpreadsheetId;
			HeroesTab.TabIDTextBox = spreadsheetDisplayHeroes.textTabId;
			HeroesTab.DataView = spreadsheetDisplayHeroes.dataGridInfo;
			HeroesTab.AddSourceFunc = Database.AddNewHeroSheet;
			HeroesTab.RemoveSourceFunc = Database.RemoveHeroSheet;
			HeroesTab.GetDataFunc = Database.GetHeroes;
			HeroesTab.GetSourcesFunc = Database.GetHeroSheets;
			HeroesTab.OnPreRebuildFunc = Database.RebuildHeroCache;
			HeroesTab.Setup(Database);
			HeroesTab.Rebuild();

			// Abilities Tab
			AbilitiesTab = new SpreadsheetDataDisplayTab<LegionAbility, AbilityDataTable>();
			AbilitiesTab.DataTreeView = spreadsheetDisplayAbilities.treeData;
			AbilitiesTab.SourcesTreeView = spreadsheetDisplayAbilities.treeDataSources;
			AbilitiesTab.AddSourceButton = spreadsheetDisplayAbilities.buttonAddSpreadsheet;
			AbilitiesTab.UpdateButton = spreadsheetDisplayAbilities.buttonUpdateSpreadsheets;
			AbilitiesTab.RebuildButton = spreadsheetDisplayAbilities.buttonRebuildTrees;
			AbilitiesTab.SpreadsheetIDTextBox = spreadsheetDisplayAbilities.textSpreadsheetId;
			AbilitiesTab.TabIDTextBox = spreadsheetDisplayAbilities.textTabId;
			AbilitiesTab.DataView = spreadsheetDisplayAbilities.dataGridInfo;
			AbilitiesTab.AddSourceFunc = Database.AddNewAbilitySheet;
			AbilitiesTab.RemoveSourceFunc = Database.RemoveAbilitySheet;
			AbilitiesTab.GetDataFunc = Database.GetAbilities;
			AbilitiesTab.GetSourcesFunc = Database.GetAbilitySheets;
			AbilitiesTab.OnPreRebuildFunc = Database.RebuildAbilityCache;
			AbilitiesTab.Setup(Database);
			AbilitiesTab.Rebuild();
		}

		#region Menu Items

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Database = Database.Load() ?? Database;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Database?.Save();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Database?.Save();
			Application.Exit();
		}

		private void jamesWilkinsonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Constants.JAMES_WILKO_GITHUB);
		}

		private void legionDefenceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(Constants.LEGION_DEFENCE_GITHUB);
		}

		private void lDToolToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		#endregion

		private void exportLocalizationFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LocalizationFileGenerator Generator = new LocalizationFileGenerator();
			Generator.Generate(Database);
			Console.WriteLine("Localization Generation Finished");
		}

		private void exportUnitsFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UnitFileGenerator Generator = new UnitFileGenerator();
			Generator.Generate(Database);
			Console.WriteLine("Unit Generation Finished");
		}

		private void exportHeroesFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HeroFileGenerator Generator = new HeroFileGenerator();
			Generator.Generate(Database);
			Console.WriteLine("Heroes Generation Finished");
		}

		private void exportAbilitiesFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AbilityFileGenerator Generator = new AbilityFileGenerator();
			Generator.Generate(Database);
			Console.WriteLine("Ability Generation Finished");
        }

		private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Clean output
			cleanOutputFolderToolStripMenuItem_Click(sender, e);

			// Generate all
			exportUnitsFileToolStripMenuItem_Click(sender, e);
			exportHeroesFileToolStripMenuItem_Click(sender, e);
			exportAbilitiesFileToolStripMenuItem_Click(sender, e);
			exportLocalizationFileToolStripMenuItem_Click(sender, e);

			MessageBox.Show("Complete Generation Finished");
		}

		private void cleanOutputFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Directory.Exists("output/"))
			{
				Directory.Delete("output/", true);
			}
			Directory.CreateDirectory("output/");
			Console.WriteLine("Output Directory Cleaned");
		}

		private void updateAllSpreadsheetsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LocalizationTab.PerformUpdate();
			UnitsTab.PerformUpdate();
			HeroesTab.PerformUpdate();
			AbilitiesTab.PerformUpdate();

			MessageBox.Show("All Spreadsheets Updated");
        }
	}
}
