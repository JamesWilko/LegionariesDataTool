using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class LocalizationDataTable : DataTable
	{
		[SpreadsheetColumn("Key", DataType.String)]
		public List<string> Keys;

		[SpreadsheetColumn("English", DataType.String)]
		public List<string> English;

		public LocalizationDataTable(string SpreadsheetId, string TabId)
			: base(SpreadsheetId, TabId)
		{
        }
	}
}
