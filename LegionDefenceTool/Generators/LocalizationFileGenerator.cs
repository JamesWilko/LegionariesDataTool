using LegionDefenceTool.Data;
using LegionDefenceTool.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Generators
{
	public class LocalizationFileGenerator : FileGenerator
	{
		const string TEMPLATE_FILE = "templates/addon_language_template.txt";
		const string OUTPUT_FILE = "output/resource/addon_{0}.txt";

		const string TOKEN_LINE = "\t\t\"{0}\"\t\"{1}\"";

		const string ABILITY_TOOLTIP = "DOTA_Tooltip_Ability_{0}";
		const string ABILITY_DESC_TOOLTIP = "DOTA_Tooltip_Ability_{0}_Description";
		const string ABILITY_DESC_TOOLTIP_NOTE0 = "DOTA_Tooltip_Ability_{0}_Note0";
		const string ABILITY_DESC_TOOLTIP_NOTE1 = "DOTA_Tooltip_Ability_{0}_Note1";
		const string ABILITY_DESC = "{0}_Description";

		const string ABILITY_MODIFIER_TOOLTIP = "DOTA_Tooltip_{0}";

		const string SUMMON_UNIT_LOCALIZATION = "legion_summon_unit";
		const string UPGRADE_UNIT_LOCALIZATION = "legion_upgrade_unit";

		const string MISSING_KEYS_FILE = "output/missing_keys.txt";
		const string MISSING_KEYS_HEADER = "Found missing keys during localization generation:\n";

		static string[] GOLD_COST_TOOLTIP = new string[] { "DOTA_Tooltip_Ability_{0}_GoldCost", "legion_currency_gold_cost" };
		static string[] GEMS_COST_TOOLTIP = new string[] { "DOTA_Tooltip_Ability_{0}_GemsCost", "legion_currency_gems_cost" };
		static string[] FOOD_COST_TOOLTIP = new string[] { "DOTA_Tooltip_Ability_{0}_PopulationCost", "legion_currency_food_cost" };

		string LanguageTemplateFile = "";

		public override void Generate(LegionDatabase Database)
		{
			DictionaryUtils.ClearMissingKeys();
			LanguageTemplateFile = LoadTemplateFile(TEMPLATE_FILE);

			// Process languages
			foreach (var Language in LocalizationDataTable.LANGUAGES)
			{
				GenerateLocalizationFile(Language, Database);
			}

			// Export missing keys list
			if (DictionaryUtils.GetMissingsKeys().Count > 0)
			{
				StringBuilder Builder = new StringBuilder();
				Builder.AppendLine(MISSING_KEYS_HEADER);
				foreach (object Key in DictionaryUtils.GetMissingsKeys())
				{
					Builder.AppendLine(Key.ToString());
				}
				SaveDataToFile(MISSING_KEYS_FILE, Builder.ToString());
			}
		}

		void GenerateLocalizationFile(string Language, LegionDatabase Database)
		{
			Console.WriteLine("Generating language: " + Language);

			Dictionary<string, string> LocalizedList = new Dictionary<string, string>();

			// Build tokens for file
			StringBuilder TokenBuilder = new StringBuilder();
			foreach(var DataTable in Database.LocalizationDataTables)
			{
				var Flags = BindingFlags.Instance | BindingFlags.Public;
				var Fields = DataTable.GetType().GetFields(Flags).ToList();
				var LanguageList = (List<string>) Fields.First(x => x.Name == Language).GetValue(DataTable);

				for(int i = 0; i < DataTable.Keys.Count; ++i)
				{
					string LocalizedLine = LanguageList[i].EscapeCharacters();
                    string Token = string.Format(TOKEN_LINE, DataTable.Keys[i], LocalizedLine);
					TokenBuilder.AppendLine(Token);

					LocalizedList.Add(DataTable.Keys[i], LocalizedLine);
                }
			}

			// Build localizations for units
			foreach(var Unit in Database.LegionUnits)
			{
				string UnitName = LocalizedList.Get(Unit.UnitName);
				string UnitDesc = LocalizedList.Get(string.Format(ABILITY_DESC, Unit.UnitName));
				string UnitValue = "";
				string TooltipId = "";

				// Add unit name and description
				TokenBuilder.AppendLine(string.Format(TOKEN_LINE, Unit.ID, UnitName));
				TokenBuilder.AppendLine(string.Format(TOKEN_LINE, string.Format(ABILITY_DESC, Unit.ID), UnitDesc));

				// Add summon ability tooltips
				if (Unit.IsBaseUnit())
				{
					TooltipId = Unit.SummonAbility;
                    UnitValue = LocalizedList.Get(SUMMON_UNIT_LOCALIZATION);
					UnitValue = string.Format(UnitValue, UnitName);
				}
				else if (Unit.IsUpgradeUnit())
				{
					TooltipId = Unit.UpgradeAbility;
					UnitValue = LocalizedList.Get(UPGRADE_UNIT_LOCALIZATION);
					UnitValue = string.Format(UnitValue, UnitName);
				}

				// Add ability name and description
				string AbilityName = string.Format(ABILITY_TOOLTIP, TooltipId);
				TokenBuilder.AppendLine(string.Format(TOKEN_LINE, AbilityName, UnitValue));

				string AbilityDesc = string.Format(ABILITY_DESC_TOOLTIP, TooltipId);
				TokenBuilder.AppendLine(string.Format(TOKEN_LINE, AbilityDesc, UnitDesc));

				// Add currency tooltips
				string GoldTooltip = string.Format(GOLD_COST_TOOLTIP[0], TooltipId);
				TokenBuilder.AppendLine(string.Format(TOKEN_LINE, GoldTooltip, LocalizedList.Get(GOLD_COST_TOOLTIP[1])));

				string GemsTooltip = string.Format(GEMS_COST_TOOLTIP[0], TooltipId);
				TokenBuilder.AppendLine(string.Format(TOKEN_LINE, GemsTooltip, LocalizedList.Get(GEMS_COST_TOOLTIP[1])));

				string FoodTooltip = string.Format(FOOD_COST_TOOLTIP[0], TooltipId);
				TokenBuilder.AppendLine(string.Format(TOKEN_LINE, FoodTooltip, LocalizedList.Get(FOOD_COST_TOOLTIP[1])));

				// Unit Ability
				foreach (LegionAbility Ability in Unit.LegionAbilities)
				{
					// Build ability ID localizations
					// id, id_Description, id_Note0, etc.
					List<string> Keys = LocalizedList.Keys.Where(x => x.Contains(Ability.AbilityID)).ToList();
					foreach (string Key in Keys)
					{
						string AbilityKey = Key.Replace(Ability.AbilityID, Ability.ID);
						string UnitAbilityKey = string.Format(ABILITY_TOOLTIP, AbilityKey);
						TokenBuilder.AppendLine(string.Format(TOKEN_LINE, UnitAbilityKey, LocalizedList.Get(Key)));
					}

					// Build ability modifier localizations
					foreach(string Modifier in Ability.Modifiers)
					{
						string ModifierKey = string.Format(ABILITY_MODIFIER_TOOLTIP, Modifier);
						LocalizedList.Get(Modifier);
                    }
				}
            }

			// Generate file contents
			string FileContents = LanguageTemplateFile;
			FileContents = FileContents.Replace("{Language}", Language);
			FileContents = FileContents.Replace("{Tokens}", TokenBuilder.ToString());

			// Write file
			string OutputPath = string.Format(OUTPUT_FILE, Language.ToLower());
			SaveDataToFile(OutputPath, FileContents, Encoding.Unicode);
		}

	}
}
