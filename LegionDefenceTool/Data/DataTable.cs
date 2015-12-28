using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace LegionDefenceTool.Data
{
	public class DataTable
	{
		public string SpreadsheetId;
		public string TabId;

		public Dictionary<string, List<string>> SpreadsheetData;
		public string SpreadsheetTitle;

		const string SPREADSHEET_URL = "https://docs.google.com/spreadsheets/d/{0}/edit#gid={1}";
		const string CSV_URL = "https://docs.google.com/spreadsheets/d/{0}/export?format=csv&id={0}&gid={1}";
		const string TSV_URL = "https://docs.google.com/spreadsheets/d/{0}/export?format=tsv&id={0}&gid={1}";
		const string GOOGLE_SHEETS_TITLE = " - Google Sheets";

		public DataTable()
		{
		}

		public DataTable(string SpreadsheetId, string TabId)
		{
			this.SpreadsheetId = SpreadsheetId;
			this.TabId = TabId;
			this.SpreadsheetData = new Dictionary<string, List<string>>();
        }

		[JsonIgnore]
		public string SpreadsheetUrl { get { return string.Format(SPREADSHEET_URL, SpreadsheetId, TabId); } }
		[JsonIgnore]
		public string SpreadsheetCsvUrl { get { return string.Format(CSV_URL, SpreadsheetId, TabId); } }
		[JsonIgnore]
		public string SpreadsheetTsvUrl { get { return string.Format(TSV_URL, SpreadsheetId, TabId); } }

		public void OpenInBrowser()
		{
			System.Diagnostics.Process.Start(SpreadsheetUrl);
		}

		public virtual void Download()
		{
			// Create spreadsheet downloader
			Utils.SpreadsheetDownloader Downloader = new Utils.SpreadsheetDownloader();

			// Get the spreadsheet title
			string Title = Downloader.GetPageTitle(SpreadsheetUrl);
			SpreadsheetTitle = Title.Replace(GOOGLE_SHEETS_TITLE, "");

			// Get data from spreadsheet and fill data dictionary
			var Data = Downloader.DownloadString(SpreadsheetCsvUrl);
			if(!string.IsNullOrWhiteSpace(Data))
			{
				string[] Headings = new string[0];
				foreach(string[] Line in Utils.StringUtils.ParseData(Data, Utils.StringUtils.ParseMethod.CSV))
				{
					if (Line.Length >= 1 && !string.IsNullOrWhiteSpace(Line[0]))
					{
						if (Headings.Length == 0)
						{
							// Create headings
							Headings = new string[Line.Length];
							for (int i = 0; i < Headings.Length; ++i)
							{
								string Key = Line[i].Trim();
                                Headings[i] = Key;
								if (!SpreadsheetData.ContainsKey(Key))
								{
									SpreadsheetData.Add(Key, new List<string>());
								}
								else
								{
									SpreadsheetData[Key] = new List<string>();
                                }
							}
						}
						else
						{
							// Add data to headings
							for (int i = 0; i < Headings.Length; ++i)
							{
								string Key = Headings[i];
								string Value = i < Line.Length ? Line[i].Trim() : string.Empty;
                                SpreadsheetData[Key].Add(Value);
							}
						}
					}
				}
            }

			// Process data
			Process();
        }

		public virtual void Process()
		{
			var Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
			var Fields = this.GetType().GetFields(Flags).ToList();
			foreach(var Field in Fields)
			{
				var Attributes = Field.GetCustomAttributes();
                foreach (var Attr in Attributes)
				{
					if(Attr is SpreadsheetColumn)
					{
						SpreadsheetColumn ColumnAttr = Attr as SpreadsheetColumn;
						List<string> ColumnData = GetDataFromHeading(ColumnAttr.Heading);
						object FieldData = ColumnAttr.ConvertDataToDesiredType(ColumnData);
                        Field.SetValue(this, FieldData);
                    }
				}
			}
        }

		public List<string> GetDataFromHeading(string Heading)
		{
			if(SpreadsheetData.ContainsKey(Heading))
			{
				return SpreadsheetData[Heading];
            }
			return null;
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

		public bool Equals(DataTable OtherSheet)
		{
			return this.SpreadsheetId == OtherSheet.SpreadsheetId && this.TabId == OtherSheet.TabId;
        }
	}
}
