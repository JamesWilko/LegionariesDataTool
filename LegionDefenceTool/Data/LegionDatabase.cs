using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using KVLib;
using LegionDefenceTool.Utils;

namespace LegionDefenceTool.Data
{
	public class LegionDatabase
	{
		public List<LocalizationDataTable> LocalizationDataTables;
		public List<LocalizedLanguage> LocalizedLanguages;

		public List<UnitDataTable> UnitDataTables;
		public List<LegionUnit> LegionUnits;

		public List<HeroDataTable> HeroDataTables;
		public List<LegionHero> LegionHeroes;

		public List<AbilityDataTable> AbilityDataTables;
		public List<LegionAbility> LegionAbilities;

		const string SAVE_PATH = "LegionDefenseSaveData.txt";

		public static LegionDatabase ActiveDatabase { get; private set; }

		public LegionDatabase()
		{
			LocalizationDataTables = new List<LocalizationDataTable>();
			LocalizedLanguages = new List<LocalizedLanguage>();

			UnitDataTables = new List<UnitDataTable>();
			LegionUnits = new List<LegionUnit>();

			HeroDataTables = new List<HeroDataTable>();
			LegionHeroes = new List<LegionHero>();

			AbilityDataTables = new List<AbilityDataTable>();
			LegionAbilities = new List<LegionAbility>();
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
				LegionDatabase Database = JsonConvert.DeserializeObject<LegionDatabase>(JsonData);
				return Database;
            }
			return null;
		}

		public void Setup()
		{
			ActiveDatabase = this;
		}

		#endregion

		#region Localization

		public List<LocalizationDataTable> GetLocalizationSheets()
		{
			return LocalizationDataTables;
		}

		public List<LocalizedLanguage> GetLocalizationLanguages()
		{
			return LocalizedLanguages;
		}

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

		public void RebuildLanguageCache()
		{
			List<string> ParentLanguages = new List<string>();
			List<LocalizedLanguage> LanguagesList = new List<LocalizedLanguage>();

			// Add all units from all sheets to the cache
			foreach (LocalizationDataTable Sheet in this.LocalizationDataTables)
			{
				List<LocalizedLanguage> Languages = Sheet.GetLanguages(this);

				// Find and add parent languages
				foreach (LocalizedLanguage Language in Languages)
				{
					if (Language.ParentDataTable == null && !ParentLanguages.Contains(Language.LanguageId))
					{
						ParentLanguages.Add(Language.LanguageId);
						LanguagesList.Add(Language);
					}
				}

				// Add all other languages
				foreach (LocalizedLanguage Language in Languages)
				{
					if (Language.ParentDataTable != null)
					{
						LanguagesList.Add(Language);
					}
				}
			}

			// Clear list and override
			LocalizedLanguages = LanguagesList;
		}

		#endregion

		#region Units

		public List<UnitDataTable> GetUnitSheets()
		{
			return UnitDataTables;
        }

		public List<LegionUnit> GetUnits()
		{
			return LegionUnits;
		}

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
				foreach (var Unit in Units)
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

		#region Heroes

		public List<HeroDataTable> GetHeroSheets()
		{
			return HeroDataTables;
		}

		public List<LegionHero> GetHeroes()
		{
			return LegionHeroes;
		}

		public HeroDataTable AddNewHeroSheet(string Spreadsheet, string Tab)
		{
			HeroDataTable Sheet = new HeroDataTable(Spreadsheet, Tab);
			HeroDataTables.Add(Sheet);
			return Sheet;
		}

		public void RemoveHeroSheet(DataTable Sheet)
		{
			HeroDataTables.RemoveAll(x => x.Equals(Sheet));
		}

		public void RebuildHeroCache()
		{
			List<LegionHero> NewHeroList = new List<LegionHero>();

			// Add all heroes from all sheets to the cache
			foreach (HeroDataTable Sheet in this.HeroDataTables)
			{
				List<LegionHero> Heroes = Sheet.GetHeroes(this);
				foreach (var Hero in Heroes)
				{
					NewHeroList.Add(Hero);
				}
			}

			// Clear list and override
			LegionHeroes = NewHeroList;
		}

		#endregion

		#region Abilities

		public List<AbilityDataTable> GetAbilitySheets()
		{
			return AbilityDataTables;
		}

		public List<LegionAbility> GetAbilities()
		{
			return LegionAbilities;
		}

		public AbilityDataTable AddNewAbilitySheet(string Spreadsheet, string Tab)
		{
			AbilityDataTable Sheet = new AbilityDataTable(Spreadsheet, Tab);
			AbilityDataTables.Add(Sheet);
			return Sheet;
		}

		public void RemoveAbilitySheet(DataTable Sheet)
		{
			AbilityDataTables.RemoveAll(x => x.Equals(Sheet));
		}

		public void RebuildAbilityCache()
		{
			List<LegionAbility> AbilitiesList = new List<LegionAbility>();

			// Add all heroes from all sheets to the cache
			foreach (AbilityDataTable Sheet in this.AbilityDataTables)
			{
				List<LegionAbility> Abilities = Sheet.GetAbilities(this);
				foreach(var Ability in Abilities)
				{
					AbilitiesList.Add(Ability);
                }
            }

			// Clear list and override
			LegionAbilities = AbilitiesList;
		}

		#endregion

	}
}
