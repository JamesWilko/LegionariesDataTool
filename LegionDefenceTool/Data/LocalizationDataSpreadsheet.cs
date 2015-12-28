using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class LocalizationDataSpreadsheet : DataSpreadsheet
	{
		public Dictionary<string, string> LocalizationKeys;

		public LocalizationDataSpreadsheet(string SpreadsheetId, string TabId)
			: base(SpreadsheetId, TabId)
		{
			LocalizationKeys = new Dictionary<string, string>();
        }

		public override List<string> Download()
		{
			List<string> Data = base.Download();

			// Parse the keys from the spreadsheet TSV data
			LocalizationKeys.Clear();
			foreach (string Line in Data)
			{
				string[] Values = Line.Split('\t');
				if(Values.Length >= 2 && !string.IsNullOrWhiteSpace(Values[0]))
				{
					string Key = Values[0];
					string Value = Values[1];
					if (!LocalizationKeys.ContainsKey(Key))
					{
						LocalizationKeys.Add(Key, Value);
					}
					else
					{
						Console.WriteLine("Found duplicate key: {0}", Key);
						LocalizationKeys[Key] = Value;
                    }	
                }
			}

			// Get the spreadsheet title to use in our UI
			Utils.SpreadsheetDownloader Downloader = new Utils.SpreadsheetDownloader();
			SetSpreadsheetTitle(Downloader.GetPageTitle(SpreadsheetUrl));

			return Data;
		}

	}
}
