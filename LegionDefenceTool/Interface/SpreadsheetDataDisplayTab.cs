using LegionDefenceTool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegionDefenceTool.Interface
{
	public class SpreadsheetDataDisplayTab<T1, T2>
		where T1 : DataNode
		where T2 : DataTable
	{
		public delegate T2 AddSourceDelegate(string SpreadsheetId, string TabId);
		public delegate void RemoveSourceDelegate(T2 Sheet);
		public delegate List<T1> RetrieveDataDelegate();
		public delegate List<T2> RetrieveSourcesDelegate();

		// UI Elements
		public TreeView DataTreeView;
		public TreeView SourcesTreeView;
		public Button AddSourceButton;
		public Button UpdateButton;
		public Button RebuildButton;
		public TextBox SpreadsheetIDTextBox;
		public TextBox TabIDTextBox;
		public DataGridView DataView;

		// Delegates
		public AddSourceDelegate AddSourceFunc;
		public RemoveSourceDelegate RemoveSourceFunc;
		public RetrieveDataDelegate GetDataFunc;
		public RetrieveSourcesDelegate GetSourcesFunc;
		public Action OnPreRebuildFunc;

		// Data
		LegionDatabase Database;
		Dictionary<T1, TreeNode> DataNodes;
		Dictionary<T2, TreeNode> SourceNodes;

		public void Setup(LegionDatabase Database)
		{
			this.Database = Database;
			DataNodes = new Dictionary<T1, TreeNode>();
			SourceNodes = new Dictionary<T2, TreeNode>();

			DataTreeView.MouseDown += DataTreeView_MouseDown;
			SourcesTreeView.MouseDown += SourcesTreeView_MouseDown;

			AddSourceButton.Click += AddSourceButton_Click;
			UpdateButton.Click += UpdateButton_Click;
			RebuildButton.Click += RebuildButton_Click;

			ContextMenuStrip ContextMenu = new ContextMenuStrip();
			ContextMenu.Items.Add("Open").Click += SourcesTreeView_OnOpen;
			ContextMenu.Items.Add("Update").Click += SourcesTreeView_OnUpdate;
			ContextMenu.Items.Add("Remove").Click += SourcesTreeView_OnRemove;
			SourcesTreeView.ContextMenuStrip = ContextMenu;
        }

		public void Rebuild()
		{
			// Call rebuild function
			if(OnPreRebuildFunc != null)
			{
				OnPreRebuildFunc();
            }

			// Clear sources data
			SourcesTreeView.Nodes.Clear();
			SourceNodes.Clear();

			// Build sources tree
			foreach (T2 Source in GetSourcesFunc())
			{
				string NodeName = Source.GetSpreadsheetTitle();
				TreeNode Node = SourcesTreeView.Nodes.Add(NodeName);
				SourceNodes.Add(Source, Node);
			}

			// Clear data
			DataTreeView.Nodes.Clear();
			DataNodes.Clear();

			// Build data tree
			foreach (T1 DataNode in GetDataFunc())
			{
				bool AddToRoot = true;
				TreeNode Node;

				if (DataNode.GetParentID() != null)
				{
					// Node has a parent, show as a child
					foreach (var UnitNodePair in DataNodes)
					{
						if (UnitNodePair.Key.GetDisplayID() == DataNode.GetParentID())
						{
							Node = UnitNodePair.Value.Nodes.Add(DataNode.GetDisplayName());
							DataNodes.Add(DataNode, Node);
							AddToRoot = false;
                            break;
						}
					}
				}

				if (AddToRoot)
				{
					// Node has no parent, show in root
					Node = DataTreeView.Nodes.Add(DataNode.GetDisplayName());
					DataNodes.Add(DataNode, Node);
				}
			}
		}

		private void DataTreeView_MouseDown(object sender, MouseEventArgs e)
		{
			DataTreeView.SelectedNode = DataTreeView.GetNodeAt(e.X, e.Y);
			ShowDataViewForTree<T1>(DataTreeView, DataNodes);
        }

		private void SourcesTreeView_MouseDown(object sender, MouseEventArgs e)
		{
			SourcesTreeView.SelectedNode = SourcesTreeView.GetNodeAt(e.X, e.Y);
			ShowDataViewForTree<T2>(SourcesTreeView, SourceNodes);
		}

		private void ShowDataViewForTree<TX>(TreeView Tree, Dictionary<TX, TreeNode> Dict)
			where TX : DataNode
		{
			DataView.Rows.Clear();
			if (Tree.SelectedNode != null)
			{
				foreach (var UnitNodePair in Dict)
				{
					if (UnitNodePair.Value == Tree.SelectedNode)
					{
						UnitNodePair.Key.PopulateDataGrid(UnitNodePair.Key, DataView);
					}
				}
			}
		}

		private void AddSourceButton_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(SpreadsheetIDTextBox.Text))
			{
				string SpreadsheetId = SpreadsheetIDTextBox.Text;
				string TabId = string.IsNullOrWhiteSpace(TabIDTextBox.Text) ? "0" : TabIDTextBox.Text;
				AddSourceFunc(SpreadsheetId, TabId);

				SpreadsheetIDTextBox.Text = string.Empty;
				TabIDTextBox.Text = string.Empty;
				Rebuild();
			}
		}

		private void UpdateButton_Click(object sender, EventArgs e)
		{
			PerformUpdate();
        }

		public void PerformUpdate()
		{
			foreach (var Spreadsheet in GetSourcesFunc())
			{
				Spreadsheet?.Download();
			}
			Rebuild();
		}

		private void RebuildButton_Click(object sender, EventArgs e)
		{
			Rebuild();
		}

		private TX GetDataForNode<TX>(TreeView Tree, Dictionary<TX, TreeNode> Dict)
        {
			if (SourcesTreeView.SelectedNode != null)
			{
				foreach (var UnitNodePair in Dict)
				{
					if (UnitNodePair.Value == Tree.SelectedNode)
					{
						return UnitNodePair.Key;
                    }
				}
			}
			return default(TX);
		}

		private void SourcesTreeView_OnOpen(object sender, EventArgs e)
		{
			GetDataForNode(SourcesTreeView, SourceNodes)?.OpenInBrowser();
		}

		private void SourcesTreeView_OnUpdate(object sender, EventArgs e)
		{
			GetDataForNode(SourcesTreeView, SourceNodes)?.Download();
			Rebuild();
		}

		private void SourcesTreeView_OnRemove(object sender, EventArgs e)
		{
			RemoveSourceFunc(GetDataForNode(SourcesTreeView, SourceNodes));
			Rebuild();
		}

	}
}
