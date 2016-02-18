using LegionDefenceTool.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Generators
{
	public class UnitFileGenerator : FileGenerator
	{
		const string UNIT_TEMPLATE_FILE = "templates/npcs/npc_legion_unit_template.txt";
		const string TEMPLATE_VARIABLE = "{{Unit.{0}}}";

		const string UNIT_OUTPUT_TEMPLATE = "templates/npc_units_custom_template.txt";
		const string UNIT_OUTPUT = "output/npc_units_custom.txt";

		static string[] EXTERNAL_UNITS = new string[]
		{
			"data/npc_miner.txt"
		};

		public override void Generate(LegionDatabase Database)
		{
			// Units data
			string UnitTemplateFile = LoadTemplateFile(UNIT_TEMPLATE_FILE);
            List<string> GeneratedUnitData = GenerateDataForList<LegionUnit>(UnitTemplateFile, Database.LegionUnits, "Unit");

			// Add data from external unit files
			foreach (string ExternalPath in EXTERNAL_UNITS)
			{
				string UnitData = LoadTemplateFile(ExternalPath);
				GeneratedUnitData.Add(UnitData);
			}

			// Generate file and save
			string UnitBuildFile = GenerateBuildFile(UNIT_OUTPUT_TEMPLATE, GeneratedUnitData, "{Units}");
			SaveDataToFile(UNIT_OUTPUT, UnitBuildFile);
		}

	}
}
