using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LegionDefenceTool.Data
{
	public class LegionDatabase
	{
		public List<LocalizationDataTable> LocalizationDataTables;
		public List<UnitDataTable> UnitDataTables;
		public List<LegionUnit> LegionUnits;

		const string SAVE_PATH = "LegionDefenseSaveData.txt";

		public LegionDatabase()
		{
			LocalizationDataTables = new List<LocalizationDataTable>();
			UnitDataTables = new List<UnitDataTable>();
			LegionUnits = new List<LegionUnit>();
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
				Reader.Close();
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

		public void AddNewUnit(LegionUnit Unit)
		{
			LegionUnits.Add(Unit);
        }

		public LegionUnit GetUnit(string UnitName)
		{
			foreach (LegionUnit Unit in LegionUnits)
			{
				if(Unit.UnitName == UnitName)
				{
					return Unit;
				}
			}
			return null;
		}

		public void ClearUnits()
		{
			LegionUnits.Clear();
        }

		public void RebuildUnitCache()
		{
			List<LegionUnit> NewUnitList = new List<LegionUnit>();

			// Add all units from all sheets to the cache
			foreach (UnitDataTable Sheet in this.UnitDataTables)
			{
				List<LegionUnit> Units = Sheet.GetUnits(this);
				foreach (LegionUnit Unit in Units)
				{
					NewUnitList.Add(Unit);
				}
			}

			// Clear list and override
			LegionUnits = NewUnitList;

			// Process list to create references for unit upgrades
			foreach (LegionUnit Unit in LegionUnits)
			{
				if (!string.IsNullOrWhiteSpace(Unit.UpgradesFrom))
				{
					foreach (LegionUnit OtherUnit in LegionUnits)
					{
						if(OtherUnit.UnitName == Unit.UpgradesFrom)
						{
							Unit.ParentUnit = OtherUnit;
                            break;
						}
					}
				}
			}
        }

		#endregion

	}
}
