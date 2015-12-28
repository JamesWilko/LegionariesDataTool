using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class DataSpreadsheet
	{
		public string SpreadsheetId;
		public string TabId;
		public string SpreadsheetTitle;
		public List<string> DownloadedData;

		static string[] IGNORED_KEYS = new string[]
		{
			"",
			"Key",
		};
		const string SPREADSHEET_URL = "https://docs.google.com/spreadsheets/d/{0}/edit#gid={1}";
		const string TSV_URL = "https://docs.google.com/spreadsheets/d/{0}/export?format=tsv&id={0}&gid={1}";
		const string GOOGLE_SHEETS_TITLE = " - Google Sheets";

		public DataSpreadsheet(string SpreadsheetId, string TabId)
		{
			this.SpreadsheetId = SpreadsheetId;
			this.TabId = TabId;
			this.DownloadedData = new List<string>();
        }

		public string SpreadsheetUrl
		{
			get { return string.Format(SPREADSHEET_URL, SpreadsheetId, TabId); }
		}

		public string SpreadsheetTsvUrl
		{
			get { return string.Format(TSV_URL, SpreadsheetId, TabId); }
		}

		public string GetSpreadsheetTitle()
		{
			if (string.IsNullOrWhiteSpace(SpreadsheetTitle))
			{
				return string.Format("{0} [{1}]", SpreadsheetId, TabId);
			}
			else
			{
				return SpreadsheetTitle;
			}
		}

		public void SetSpreadsheetTitle(string NewTitle)
		{
			SpreadsheetTitle = NewTitle;
			SpreadsheetTitle = SpreadsheetTitle.Replace(GOOGLE_SHEETS_TITLE, "");
        }

		public void OpenInBrowser()
		{
			System.Diagnostics.Process.Start(SpreadsheetUrl);
		}

		public virtual List<string> Download()
		{
			Utils.SpreadsheetDownloader Downloader = new Utils.SpreadsheetDownloader();
			var SpreadsheetData = Downloader.DownloadString(SpreadsheetTsvUrl);
			if(!string.IsNullOrWhiteSpace(SpreadsheetData))
			{
				DownloadedData = SpreadsheetData.Split('\n').ToList();
				for(int i = DownloadedData.Count - 1; i >= 0; --i)
				{
					string[] Values = DownloadedData[i].Split('\t');
					if(Values.Length == 0 || IGNORED_KEYS.Contains(Values[0]))
					{
						DownloadedData.RemoveAt(i);
                    }
                }
            }
			return DownloadedData;
        }

		public bool Equals(DataSpreadsheet OtherSheet)
		{
			return OtherSheet.SpreadsheetId == this.SpreadsheetId && OtherSheet.TabId == this.TabId;
        }
	}
}
