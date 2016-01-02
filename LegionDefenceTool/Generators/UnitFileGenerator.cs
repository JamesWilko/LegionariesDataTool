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
	public class UnitFileGenerator
	{
		const string UNIT_TEMPLATE_FILE = "templates/npcs/npc_legion_unit_template.txt";
		const string TEMPLATE_VARIABLE = "{{Unit.{0}}}";

		const string UNIT_OUTPUT_TEMPLATE = "templates/npc_units_custom_template.txt";
		const string UNIT_OUTPUT = "output/npc_units_custom.txt";

		static string[] EXTERNAL_UNITS = new string[]
		{
			"data/npc_king_dire.txt",
			"data/npc_king_radiant.txt",
			"data/npc_miner.txt"
		};

		string UnitTemplateFile = "";

		public void Generate(LegionDatabase Database)
		{
			TextReader Reader;

			if (File.Exists(UNIT_TEMPLATE_FILE))
			{
				// Load template file
				Reader = new StreamReader(UNIT_TEMPLATE_FILE, Encoding.UTF8);
				UnitTemplateFile = Reader.ReadToEnd();
				Reader.Close();
			}

			// Units data
			List<string> GeneratedUnitData = new List<string>();

			// Build unit data for all units
			foreach (LegionUnit Unit in Database.LegionUnits)
			{
				// Template file
				string Template = UnitTemplateFile;

				// Get fields from unit
				var Flags = BindingFlags.Instance | BindingFlags.Public;
				var UnitFields = Unit.GetType().GetFields(Flags).ToList();
				var UnitProperties = Unit.GetType().GetProperties(Flags).ToList();

				// Build list of values to process
				var FieldNameList = new List<string>();
				foreach(var Field in UnitFields)
				{
					if (Field.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
					{
						FieldNameList.Add(Field.Name);
					}
                }
				foreach (var Property in UnitProperties)
				{
					if (Property.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
					{
						FieldNameList.Add(Property.Name);
					}
				}

				// Fill template file
				foreach(var VariableName in FieldNameList)
				{
					// Get replacement string
					string TemplateReplaceName = string.Format(TEMPLATE_VARIABLE, VariableName);

					// Try finding field or property
					var UnitField = UnitFields.FirstOrDefault(x => x.Name == VariableName);
					var UnitProp = UnitProperties.FirstOrDefault(x => x.Name == VariableName);

					// Write property to file
					if(UnitField != null)
					{
						var UnitVar = UnitField.GetValue(Unit);
						Template = Template.Replace(TemplateReplaceName, UnitVar.ToString());
					}
					else if(UnitProp != null)
					{
						var UnitVar = UnitProp.GetValue(Unit);
						Template = Template.Replace(TemplateReplaceName, UnitVar.ToString());
					}
					else
					{
						Console.WriteLine($"No value could be found property '{VariableName}' on unit {Unit.ID}");
					}
                }

				// Add generated data
				GeneratedUnitData.Add(Template);
            }

			// Add data from external unit files
			foreach(string ExternalPath in EXTERNAL_UNITS)
			{
				// Read file data
				Reader = new StreamReader(ExternalPath, Encoding.UTF8);
				string UnitData = Reader.ReadToEnd();
				Reader.Close();

				// Add to generated data
				GeneratedUnitData.Add(UnitData);
			}

			// Read template file
			Reader = new StreamReader(UNIT_OUTPUT_TEMPLATE, Encoding.UTF8);
			string TemplateFileData = Reader.ReadToEnd();
			Reader.Close();

			// Build file data
			StringBuilder Builder = new StringBuilder();
			foreach (var GeneratedUnit in GeneratedUnitData)
			{
				Builder.AppendLine(GeneratedUnit);
			}

			// Replace
			TemplateFileData = TemplateFileData.Replace("{Units}", Builder.ToString());

			// Write file
			TextWriter Writer = new StreamWriter(UNIT_OUTPUT, false, Encoding.UTF8);
			Writer.Write(TemplateFileData);
			Writer.Close();
		}

	}
}
