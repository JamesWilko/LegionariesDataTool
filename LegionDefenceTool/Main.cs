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

		Dictionary<LocalizationDataSpreadsheet, TreeNode> LocalizationNodes;
		LocalizationDataSpreadsheet HighlightedSpreadsheet;

		public Main()
		{
			InitializeComponent();
			Database = new LegionDatabase();
			LocalizationNodes = new Dictionary<LocalizationDataSpreadsheet, TreeNode>();

			treeLocalizationSheets.MouseDown += TreeLocalizationSheets_MouseDown;
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
			foreach (LocalizationDataSpreadsheet Sheet in Database.LocalizationSpreadsheets)
			{
				string NodeName = Sheet.GetSpreadsheetTitle();
				TreeNode Node = treeLocalizationSheets.Nodes.Add(NodeName);
				LocalizationNodes.Add(Sheet, Node);
            }

			// Build Table
			dataGridLocalization.Rows.Clear();
            foreach (LocalizationDataSpreadsheet Sheet in Database.LocalizationSpreadsheets)
			{
				bool bHighlightSheet = HighlightedSpreadsheet != null && HighlightedSpreadsheet == Sheet;
				foreach (var LocPair in Sheet.LocalizationKeys)
				{
					bool bHighlightError = string.IsNullOrWhiteSpace(LocPair.Value);
                    int RowIndex = dataGridLocalization.Rows.Add(LocPair.Key, LocPair.Value);
					DataGridViewCellStyle Style = new DataGridViewCellStyle();
					if(bHighlightSheet && !bHighlightError)
					{
						Style.BackColor = Color.PaleGoldenrod;
					}
					else if(bHighlightError && !bHighlightSheet)
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

		#endregion

		#region Utils

		LocalizationDataSpreadsheet GetSpreadsheetForLocalizationNode()
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
				var sheet = Database.AddNewLocalizationSheet(SpreadsheetId, TabId);

				textBoxSpreadsheetId.Text = string.Empty;
				textBoxTabId.Text = string.Empty;
				Rebuild();
            }
		}

		private void buttonUpdateSpreadsheets_Click(object sender, EventArgs e)
		{
			foreach (var Spreadsheet in Database.LocalizationSpreadsheets)
			{
				Spreadsheet.Download();
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
			LocalizationDataSpreadsheet Sheet = GetSpreadsheetForLocalizationNode();
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
			DataSpreadsheet Sheet = GetSpreadsheetForLocalizationNode();
			if(Sheet != null)
			{
				Database.RemoveLocalizationSheet(Sheet);
				Rebuild();
			}
        }

		#endregion

	}
}
