using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegionDefenceTool.Data;

namespace LegionDefenceTool.Generators
{
	class AbilityFileGenerator : FileGenerator
	{
		const string SPAWN_UNIT_TEMPLATE = "templates/abilities/ability_spawn_unit_template.txt";
		const string SPAWN_UNIT_LUA_TEMPLATE = "templates/abilities/spawn_unit_template.lua";

		const string UPGRADE_UNIT_TEMPLATE = "templates/abilities/ability_upgrade_unit_template.txt";
        const string UPGRADE_UNIT_LUA_TEMPLATE = "templates/abilities/upgrade_unit_template.lua";

		const string CUSTOM_ABILITIES_FILE = "templates/npc_abilities_custom_template.txt";

		const string CUSTOM_ABILITIES_OUTPUT = "output/npc_abilities_custom.txt";
		const string LUA_SPAWN_ABILITY_OUTPUT = "output/vscripts/abilities/spawning/{0}.lua";
		const string LUA_UPGRADE_ABILITY_OUTPUT = "output/vscripts/abilities/upgrading/{0}.lua";

		static string[] EXTERNAL_ABILITIES = new string[]
		{
			"templates/abilities/sell_unit_template.txt",
			"templates/abilities/sell_unit_fire_template.txt",
		};

		public override void Generate(LegionDatabase Database)
		{
			GenerateAbilitiesFile(Database);

			GenerateSummonAbilitiesLua(Database);
			GenerateUpgradeAbilitiesLua(Database);

			// GenerateUnitAbilities(Database);
		}

		protected List<LegionUnit> GetSummonableUnits(LegionDatabase Database)
		{
			List<LegionUnit> SummonableUnits = new List<LegionUnit>();
			foreach (LegionUnit Unit in Database.LegionUnits)
			{
				if (Unit.IsBaseUnit())
				{
					SummonableUnits.Add(Unit);
				}
			}
			return SummonableUnits;
        }

		protected List<LegionUnit> GetUpgradeUnits(LegionDatabase Database)
		{
			List<LegionUnit> UpgradeUnits = new List<LegionUnit>();
			foreach (LegionUnit Unit in Database.LegionUnits)
			{
				if (Unit.IsUpgradeUnit())
				{
					UpgradeUnits.Add(Unit);
				}
			}
			return UpgradeUnits;
		}

		protected void GenerateAbilitiesFile(LegionDatabase Database)
		{
			// Load ability templates
			string SummonAbilityTemplate = LoadTemplateFile(SPAWN_UNIT_TEMPLATE);
			string UpgradeAbilityTemplate = LoadTemplateFile(UPGRADE_UNIT_TEMPLATE);

			// Generate data from each unit
			List<string> SummonAbilities = GenerateDataForList<LegionUnit>(SummonAbilityTemplate, GetSummonableUnits(Database), "Unit");
			List<string> UpgradeAbilities = GenerateDataForList< LegionUnit>(UpgradeAbilityTemplate, GetUpgradeUnits(Database), "Unit");

			// Merge all data
			List<string> GeneratedAbilitiesData = new List<string>();
			GeneratedAbilitiesData = GeneratedAbilitiesData.Concat(SummonAbilities).ToList();
			GeneratedAbilitiesData = GeneratedAbilitiesData.Concat(UpgradeAbilities).ToList();

			// Add external data
			foreach (string ExternalPath in EXTERNAL_ABILITIES)
			{
				string UnitData = LoadTemplateFile(ExternalPath);
				GeneratedAbilitiesData.Add(UnitData);
			}

			// Generate file and save
			string AbilityBuildFile = GenerateBuildFile(CUSTOM_ABILITIES_FILE, GeneratedAbilitiesData, "{Abilities}");
			SaveDataToFile(CUSTOM_ABILITIES_OUTPUT, AbilityBuildFile);
		}

		protected void GenerateSummonAbilitiesLua(LegionDatabase Database)
		{
			// Load template
			string AbilityTemplateFile = LoadTemplateFile(SPAWN_UNIT_LUA_TEMPLATE);

			// Generate for all summonable units
			foreach (LegionUnit Unit in GetSummonableUnits(Database))
			{
				// Process template
				string UnitTemplate = AbilityTemplateFile;
				UnitTemplate = ProcessTemplate<LegionUnit>(UnitTemplate, Unit, "Unit");

				// Save unit lua
				string OutputFile = string.Format(LUA_SPAWN_ABILITY_OUTPUT, Unit.SummonAbility);
                SaveDataToFile(OutputFile, UnitTemplate);
			}
		}

		protected void GenerateUpgradeAbilitiesLua(LegionDatabase Database)
		{
			// Load template
			string AbilityTemplateFile = LoadTemplateFile(UPGRADE_UNIT_LUA_TEMPLATE);

			// Generate for all unit upgrades
			foreach (LegionUnit Unit in GetUpgradeUnits(Database))
			{
				// Process template
				string UnitTemplate = AbilityTemplateFile;
				UnitTemplate = ProcessTemplate<LegionUnit>(UnitTemplate, Unit, "Unit");

				// Save unit lua
				string OutputFile = string.Format(LUA_UPGRADE_ABILITY_OUTPUT, Unit.UpgradeAbility);
				SaveDataToFile(OutputFile, UnitTemplate);
			}
		}

	}
}
