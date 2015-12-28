using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	class LegionDatabase
	{
		public List<LocalizationDataSpreadsheet> LocalizationSpreadsheets;

		public LegionDatabase()
		{
			LocalizationSpreadsheets = new List<LocalizationDataSpreadsheet>();
        }

		public LocalizationDataSpreadsheet AddNewLocalizationSheet(string Spreadsheet, string Tab)
		{
			LocalizationDataSpreadsheet sheet = new LocalizationDataSpreadsheet(Spreadsheet, Tab);
            LocalizationSpreadsheets.Add(sheet);
			return sheet;
        }

		public void RemoveLocalizationSheet(DataSpreadsheet sheet)
		{
			LocalizationSpreadsheets.RemoveAll(x => x.Equals(sheet));
        }

	}
}
