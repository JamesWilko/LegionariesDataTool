using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegionDefenceTool.Data
{
	public class LegionAbility : DataNode
	{
		public string AbilityID;
		public string AbilityFile;
		public Dictionary<string, string> AbilityValues;

		#region DataNode

		public override string GetDisplayID()
		{
			return $"{AbilityID}";
		}

		public override string GetDisplayName()
		{
			return $"{AbilityID}";
		}

		public override string GetParentID()
		{
			// No nesting
			return null;
		}

		#endregion

		public override void PopulateDataGrid(object Obj, DataGridView DataGrid)
		{
			// Populate default data
			base.PopulateDataGrid(Obj, DataGrid);

			// Show ability values from dictionary
			foreach(var kvp in AbilityValues)
			{
				DataGrid.Rows.Add(kvp.Key, kvp.Value);
			}
		}

		public override string ToString()
		{
			return $"[LegionAbility (ID: {AbilityID})]";
        }

	}
}
