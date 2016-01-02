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
		const string TEMPLATE_FILE = "templates/npcs/npc_unit_template.txt";
		const string OUTPUT_FILE = "output/{0}.txt";
		const string TEMPLATE_VARIABLE = "Unit.{0}";

		string UnitTemplateFile = "";

		public void Generate(LegionDatabase Database)
		{
			if (File.Exists(TEMPLATE_FILE))
			{
				// Load template file
				TextReader Reader = new StreamReader(TEMPLATE_FILE, Encoding.UTF8);
				UnitTemplateFile = Reader.ReadToEnd();
				Reader.Close();
			}

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
					TemplateReplaceName = "{" + TemplateReplaceName + "}";

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

				// Save file
				string OutputPath = string.Format(OUTPUT_FILE, Unit.ID);
				TextWriter Writer = new StreamWriter(OutputPath, false, Encoding.UTF8);
				Writer.Write(Template);
				Writer.Close();
			}
		}

	}
}
