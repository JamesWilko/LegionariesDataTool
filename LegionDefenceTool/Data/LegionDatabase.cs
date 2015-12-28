using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LegionDefenceTool.Data
{
	class LegionDatabase
	{
		public List<LocalizationDataTable> LocalizationSpreadsheets;

		const string SAVE_PATH = "LegionDefenseSaveData.txt";

		public LegionDatabase()
		{
			LocalizationSpreadsheets = new List<LocalizationDataTable>();
        }

		#region File Operations

		public void Save()
		{
			JsonSerializerSettings Settings = new JsonSerializerSettings();
			Settings.Formatting = Formatting.Indented;

            string JsonOutput = JsonConvert.SerializeObject(this, Settings);
			TextWriter Writer = new StreamWriter(SAVE_PATH, false, Encoding.UTF8);
			Writer.Write(JsonOutput);
			Writer.Close();
        }

		public LegionDatabase Load()
		{
			if(File.Exists(SAVE_PATH))
			{
				TextReader Reader = new StreamReader(SAVE_PATH, Encoding.UTF8);
				string JsonData = Reader.ReadToEnd();
				return JsonConvert.DeserializeObject<LegionDatabase>(JsonData);
			}
			return null;
		}

		#endregion

		#region Localization

		public LocalizationDataTable AddNewLocalizationSheet(string Spreadsheet, string Tab)
		{
			LocalizationDataTable sheet = new LocalizationDataTable(Spreadsheet, Tab);
            LocalizationSpreadsheets.Add(sheet);
			return sheet;
        }

		public void RemoveLocalizationSheet(DataTable sheet)
		{
			LocalizationSpreadsheets.RemoveAll(x => x.Equals(sheet));
        }

		#endregion

	}
}
