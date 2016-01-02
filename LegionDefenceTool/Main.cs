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

namespace LegionDefenceTool
{
	public partial class Main : Form
	{
		LegionDatabase Database;
		DotaData DotaDatabase;

		Dictionary<LocalizationDataTable, TreeNode> LocalizationNodes;
		LocalizationDataTable HighlightedLocalizationSpreadsheet;

		Dictionary<UnitDataTable, TreeNode> UnitSourceNodes;
		Dictionary<LegionUnit, TreeNode> UnitNodes;

		public Main()
		{
			InitializeComponent();
			Database = new LegionDatabase();
			Database = Database.Load() ?? Database;

			DotaDatabase = new DotaData();
			DotaDatabase.Load();

			LocalizationNodes = new Dictionary<LocalizationDataTable, TreeNode>();
			UnitSourceNodes = new Dictionary<UnitDataTable, TreeNode>();
			UnitNodes = new Dictionary<LegionUnit, TreeNode>();

			treeLocalizationSheets.MouseDown += TreeLocalizationSheets_MouseDown;
			treeUnits.MouseDown += TreeUnits_MouseDown;

			Rebuild();
        }

		#region Rebuild Interface

		public void Rebuild()
		{
			RebuildLocalizationUI();
			RebuildUnitsUI();
			RebuildSelectedUnitUI();
        }

		public void RebuildLocalizationUI()
		{
			treeLocalizationSheets.Nodes.Clear();
			LocalizationNodes.Clear();

			// Build Tree
			foreach (LocalizationDataTable Sheet in Database.LocalizationDataTables)
			{
				string NodeName = Sheet.GetSpreadsheetTitle();
				TreeNode Node = treeLocalizationSheets.Nodes.Add(NodeName);
				LocalizationNodes.Add(Sheet, Node);
            }

			// Build Table
			dataGridLocalization.Rows.Clear();
            foreach (LocalizationDataTable Sheet in Database.LocalizationDataTables)
			{
				if (Sheet.Keys != null)
				{
					bool bHighlightSheet = HighlightedLocalizationSpreadsheet != null && HighlightedLocalizationSpreadsheet == Sheet;
					for (int i = 0; i < Sheet.Keys.Count; ++i)
					{
						bool bHighlightError = string.IsNullOrWhiteSpace(Sheet.English[i]);
						int RowIndex = dataGridLocalization.Rows.Add(Sheet.Keys[i], Sheet.English[i]);
						DataGridViewCellStyle Style = new DataGridViewCellStyle();
						if (bHighlightSheet && !bHighlightError)
						{
							Style.BackColor = Color.PaleGoldenrod;
						}
						else if (bHighlightError && !bHighlightSheet)
						{
							Style.BackColor = Color.IndianRed;
						}
						else if (bHighlightError && bHighlightSheet)
						{
							Style.BackColor = Color.DarkRed;
						}
						dataGridLocalization.Rows[RowIndex].DefaultCellStyle = Style;
					}
				}
			}
        }

		public void RebuildUnitsUI()
		{
			// Build sources tree
			treeUnitDataSources.Nodes.Clear();
			UnitSourceNodes.Clear();
			foreach (UnitDataTable Sheet in Database.UnitDataTables)
			{
				string NodeName = Sheet.GetSpreadsheetTitle();
				TreeNode Node = treeUnitDataSources.Nodes.Add(NodeName);
				UnitSourceNodes.Add(Sheet, Node);
			}

			// Build units tree
			treeUnits.Nodes.Clear();
			UnitNodes.Clear();
			Database.RebuildUnitCache();
			foreach (LegionUnit Unit in Database.LegionUnits)
			{
				string NodeName = $"{Unit.UnitName}";
				if (Unit.ParentUnit == null)
				{
					// Unit is not an upgrade, show in root
					TreeNode Node = treeUnits.Nodes.Add(NodeName);
					UnitNodes.Add(Unit, Node);
				}
				else
				{
					// Unit is an upgrade, show as a child
					foreach (var UnitNodePair in UnitNodes)
					{
						if (UnitNodePair.Key.UnitName == Unit.ParentUnit?.UnitName)
						{
							TreeNode Node = UnitNodePair.Value.Nodes.Add(NodeName);
							UnitNodes.Add(Unit, Node);
							break;
						}
					}
				}
			}
		}

		public void RebuildSelectedUnitUI()
		{
			dataGridUnitInfo.Rows.Clear();

			if (treeUnits.SelectedNode != null)
			{
				foreach (var UnitNodePair in UnitNodes)
				{
					if (UnitNodePair.Value == treeUnits.SelectedNode)
					{
						UnitNodePair.Key.PopulateDataGrid(dataGridUnitInfo);
					}
				}
			}
		}

		#endregion

		#region Utils

		LocalizationDataTable GetSpreadsheetForLocalizationNode()
		{
			if (treeLocalizationSheets.SelectedNode != null)
			{
				TreeNode Node = treeLocalizationSheets.SelectedNode;
				foreach (var SheetNodePair in LocalizationNodes)
				{
					if (SheetNodePair.Value == Node)
					{
						return SheetNodePair.Key;
					}
				}
			}
			return null;
		}

		#endregion

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

		#region Localization Tab Events

		private void TreeLocalizationSheets_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				treeLocalizationSheets.SelectedNode = treeLocalizationSheets.GetNodeAt(e.X, e.Y);
			}
		}

		private void buttonAddNewSpreadsheet_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBoxSpreadsheetId.Text))
			{
				string SpreadsheetId = textBoxSpreadsheetId.Text;
				string TabId = string.IsNullOrWhiteSpace(textBoxTabId.Text) ? "0" : textBoxTabId.Text;
				Database?.AddNewLocalizationSheet(SpreadsheetId, TabId);

				textBoxSpreadsheetId.Text = string.Empty;
				textBoxTabId.Text = string.Empty;
				Rebuild();
            }
		}

		private void buttonUpdateSpreadsheets_Click(object sender, EventArgs e)
		{
			foreach (var Spreadsheet in Database.LocalizationDataTables)
			{
				Spreadsheet?.Download();
			}
			Rebuild();
		}

		private void contextLocalizationOpen_Click(object sender, EventArgs e)
		{
			GetSpreadsheetForLocalizationNode()?.OpenInBrowser();
        }

		private void contextLocalizationUpdate_Click(object sender, EventArgs e)
		{
			GetSpreadsheetForLocalizationNode()?.Download();
			Rebuild();
		}

		private void contextLocalizationHighlight_Click(object sender, EventArgs e)
		{
			LocalizationDataTable Sheet = GetSpreadsheetForLocalizationNode();
			if(Sheet != HighlightedLocalizationSpreadsheet)
			{
				HighlightedLocalizationSpreadsheet = Sheet;
			}
			else
			{
				HighlightedLocalizationSpreadsheet = null;
            }
			Rebuild();
		}

		private void contextLocalizationRemove_Click(object sender, EventArgs e)
		{
			Data.DataTable Sheet = GetSpreadsheetForLocalizationNode();
			if(Sheet != null)
			{
				Database?.RemoveLocalizationSheet(Sheet);
				Rebuild();
			}
        }

		#endregion

		#region Unit Tab Events

		private void TreeUnits_MouseDown(object sender, MouseEventArgs e)
		{
			treeUnits.SelectedNode = treeUnits.GetNodeAt(e.X, e.Y);
			RebuildSelectedUnitUI();
        }

		private void buttonAddUnitSpreadsheet_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textUnitSpreadsheetId.Text))
			{
				string SpreadsheetId = textUnitSpreadsheetId.Text;
				string TabId = string.IsNullOrWhiteSpace(textUnitTabId.Text) ? "0" : textUnitTabId.Text;
				Database?.AddNewUnitSheet(SpreadsheetId, TabId);

				textUnitSpreadsheetId.Text = string.Empty;
				textUnitTabId.Text = string.Empty;
				Rebuild();
			}
		}

		private void buttonUpdateUnits_Click(object sender, EventArgs e)
		{
			foreach (var Spreadsheet in Database.UnitDataTables)
			{
				Spreadsheet?.Download();
			}
			Rebuild();
		}

		private void buttonRebuildUnitTrees_Click(object sender, EventArgs e)
		{
			Rebuild();
		}

		#endregion

		private void exportLocalizationFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LocalizationFileGenerator Generator = new LocalizationFileGenerator();
			Generator.Generate(Database);
        }

		private void exportUnitsFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UnitFileGenerator Generator = new UnitFileGenerator();
			Generator.Generate(Database);
        }
	}
}
