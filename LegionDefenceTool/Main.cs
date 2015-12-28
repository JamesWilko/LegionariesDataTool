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

namespace LegionDefenceTool
{
	public partial class Main : Form
	{
		LegionDatabase Database;

		Dictionary<LocalizationDataTable, TreeNode> LocalizationNodes;
		LocalizationDataTable HighlightedSpreadsheet;

		public Main()
		{
			InitializeComponent();
			Database = new LegionDatabase();
			Database = Database.Load() ?? Database;

			LocalizationNodes = new Dictionary<LocalizationDataTable, TreeNode>();

			treeLocalizationSheets.MouseDown += TreeLocalizationSheets_MouseDown;

			Rebuild();
        }

		#region Rebuild Interface

		public void Rebuild()
		{
			RebuildLocalizationUI();
        }

		public void RebuildLocalizationUI()
		{
			treeLocalizationSheets.Nodes.Clear();
			LocalizationNodes.Clear();

			// Build Tree
			foreach (LocalizationDataTable Sheet in Database.LocalizationSpreadsheets)
			{
				string NodeName = Sheet.GetSpreadsheetTitle();
				TreeNode Node = treeLocalizationSheets.Nodes.Add(NodeName);
				LocalizationNodes.Add(Sheet, Node);
            }

			// Build Table
			dataGridLocalization.Rows.Clear();
            foreach (LocalizationDataTable Sheet in Database.LocalizationSpreadsheets)
			{
				if (Sheet.Keys != null)
				{
					bool bHighlightSheet = HighlightedSpreadsheet != null && HighlightedSpreadsheet == Sheet;
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
				var sheet = Database?.AddNewLocalizationSheet(SpreadsheetId, TabId);

				textBoxSpreadsheetId.Text = string.Empty;
				textBoxTabId.Text = string.Empty;
				Rebuild();
            }
		}

		private void buttonUpdateSpreadsheets_Click(object sender, EventArgs e)
		{
			foreach (var Spreadsheet in Database.LocalizationSpreadsheets)
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
			if(Sheet != HighlightedSpreadsheet)
			{
				HighlightedSpreadsheet = Sheet;
			}
			else
			{
				HighlightedSpreadsheet = null;
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

	}
}
