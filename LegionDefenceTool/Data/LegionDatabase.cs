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
		public List<LocalizationDataTable> LocalizationDataTables;
		public List<UnitDataTable> UnitDataTables;

		const string SAVE_PATH = "LegionDefenseSaveData.txt";

		public LegionDatabase()
		{
			LocalizationDataTables = new List<LocalizationDataTable>();
			UnitDataTables = new List<UnitDataTable>();
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
			LocalizationDataTable Sheet = new LocalizationDataTable(Spreadsheet, Tab);
            LocalizationDataTables.Add(Sheet);
			return Sheet;
        }

		public void RemoveLocalizationSheet(DataTable Sheet)
		{
			LocalizationDataTables.RemoveAll(x => x.Equals(Sheet));
        }

		#endregion

		#region Units

		public UnitDataTable AddNewUnitSheet(string Spreadsheet, string Tab)
		{
			UnitDataTable Sheet = new UnitDataTable(Spreadsheet, Tab);
			UnitDataTables.Add(Sheet);
			return Sheet;
		}

		public void RemoveUnitSheet(DataTable Sheet)
		{
			UnitDataTables.RemoveAll(x => x.Equals(Sheet));
		}

		#endregion

	}
}
