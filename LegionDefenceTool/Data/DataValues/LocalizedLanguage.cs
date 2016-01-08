using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class LocalizedLanguage : DataNode
	{
		public string LanguageId;
		[Generators.GeneratorIgnore]
		public DataTable ParentDataTable;

		public List<string> Keys;
		public List<string> Values;

		public LocalizedLanguage()
		{
			Keys = new List<string>();
			Values = new List<string>();
        }

		public bool Merge(LocalizedLanguage Lang)
		{
			if (LanguageId == Lang.LanguageId)
			{
				Keys.Concat(Lang.Keys);
				Values.Concat(Lang.Values);
				return true;
			}
			return false;
        }

		public bool Equals(LocalizedLanguage Other)
		{
			return this.LanguageId == Other.LanguageId;
		}

		#region DataNode

		public override string GetDisplayID()
		{
			return $"{LanguageId}:{ParentDataTable?.SpreadsheetId}:{ParentDataTable?.TabId}";
		}

		public override string GetDisplayName()
		{
			if (ParentDataTable != null)
			{
				return $"{LanguageId} ({ParentDataTable.SpreadsheetTitle})";
			}
			return $"{LanguageId}";
        }

		public override string GetParentID()
		{
			return $"{LanguageId}::";
        }

		public override void PopulateDataGrid(object Obj, System.Windows.Forms.DataGridView DataGrid)
		{
			// Show key-value instead of default behavior
			for(int i = 0; i < Keys.Count; ++i)
			{
				DataGrid.Rows.Add(Keys[i], Values[i]);
			}
		}

		#endregion

	}
}
