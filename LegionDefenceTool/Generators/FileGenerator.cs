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
	public abstract class FileGenerator
	{
		const string TEMPLATE_VARIABLE = "{{{0}.{1}}}";

		public abstract void Generate(LegionDatabase Database);

		protected virtual string LoadTemplateFile(string Path)
		{
			TextReader Reader;
			string Template = string.Empty;
			if (File.Exists(Path))
			{
				// Load template file
				Reader = new StreamReader(Path, Encoding.UTF8);
				Template = Reader.ReadToEnd();
				Reader.Close();
			}
			else
			{
				Console.WriteLine($"Could not load template file {Path}, data will not be exported!");
			}
			return Template;
        }

		protected virtual void SaveDataToFile(string SavePath, string Data)
		{
			// Create directories as required
			Directory.CreateDirectory(Path.GetDirectoryName(SavePath));

			// Write to file
			TextWriter Writer = new StreamWriter(SavePath, false, Encoding.UTF8);
			Writer.Write(Data);
			Writer.Close();
		}

		protected virtual string ProcessTemplate<T>(string TemplateFile, T Object, string ObjectName)
		{
			// Get fields from unit
			var Flags = BindingFlags.Instance | BindingFlags.Public;
			var UnitFields = typeof(T).GetFields(Flags).ToList();
			var UnitProperties = typeof(T).GetProperties(Flags).ToList();

			// Build list of values to process
			var FieldNameList = new List<string>();
			foreach (var Field in UnitFields)
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
			string DataTemplate = TemplateFile;
			foreach (var VariableName in FieldNameList)
			{
				// Get replacement string
				string TemplateReplaceName = string.Format(TEMPLATE_VARIABLE, ObjectName, VariableName);

				// Try finding field or property
				var UnitField = UnitFields.FirstOrDefault(x => x.Name == VariableName);
				var UnitProp = UnitProperties.FirstOrDefault(x => x.Name == VariableName);

				// Write property to file
				if (UnitField != null)
				{
					var UnitVar = UnitField.GetValue(Object);
					DataTemplate = DataTemplate.Replace(TemplateReplaceName, UnitVar?.ToString() ?? string.Empty);
				}
				else if (UnitProp != null)
				{
					var UnitVar = UnitProp.GetValue(Object);
					DataTemplate = DataTemplate.Replace(TemplateReplaceName, UnitVar?.ToString() ?? string.Empty);
				}
				else
				{
					Console.WriteLine($"No value could be found property '{VariableName}' on {Object}");
				}
			}

			return DataTemplate;
        }

		protected virtual List<string> GenerateDataForList<T>(string Template, List<T> ObjectList, string ObjectName)
		{
			List<string> GeneratedData = new List<string>();

			foreach (T Obj in ObjectList)
			{
				string ObjTemplate = Template;
				ObjTemplate = ProcessTemplate<T>(ObjTemplate, Obj, ObjectName);
				GeneratedData.Add(ObjTemplate);
			}

			return GeneratedData;
        }

		protected virtual string GenerateBuildFile(string FilePath, List<string> Data, string DataInsertionPoint)
		{
			// Read template file
			string TemplateFileData = LoadTemplateFile(FilePath);

			// Build file data
			StringBuilder Builder = new StringBuilder();
			foreach (var GeneratedUnit in Data)
			{
				Builder.AppendLine(GeneratedUnit);
			}

			// Insert data at correct point
			TemplateFileData = TemplateFileData.Replace(DataInsertionPoint, Builder.ToString());

			return TemplateFileData;
        }

	}
}
