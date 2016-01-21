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

		public virtual string LoadTemplateFile(string Path)
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
			SaveDataToFile(SavePath, Data, Encoding.UTF8);
        }

		protected virtual void SaveDataToFile(string SavePath, string Data, Encoding Encode)
		{
			// Create directories as required
			Directory.CreateDirectory(Path.GetDirectoryName(SavePath));

			// Write to file
			TextWriter Writer = new StreamWriter(SavePath, false, Encode);
			Writer.Write(Data);
			Writer.Close();
		}

		public virtual string ProcessTemplate<T>(string TemplateFile, T Object, string ObjectName)
		{
			// Get fields from unit
			var Flags = BindingFlags.Instance | BindingFlags.Public;
			var UnitFields = typeof(T).GetFields(Flags).ToList();
			var UnitProperties = typeof(T).GetProperties(Flags).ToList();

			// Build list of values to process
			Dictionary<string, object> ValuesDict = new Dictionary<string, object>();
			foreach (var Field in UnitFields)
			{
				if (Field.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
				{
					if (Field.GetCustomAttribute(typeof(GeneratorDictionary)) != null)
					{
						// Field should be a dictionary, add all KVPs
                        Dictionary<object, object> Dict = Field.GetValue(Object) as Dictionary<object, object>;
						foreach(var KVP in Dict)
						{
                            ValuesDict.Add(KVP.Key.ToString(), KVP.Value);
						}
                    }
					else
					{
						// Normal field, add value
						ValuesDict.Add(Field.Name, Field.GetValue(Object));
					}
                }
			}
			foreach (var Property in UnitProperties)
			{
				if (Property.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
				{
					ValuesDict.Add(Property.Name, Property.GetValue(Object));
				}
			}

			// Fill template file
			string DataTemplate = TemplateFile;
			foreach (var ValueKVP in ValuesDict)
			{
				string TemplateReplaceName = string.Format(TEMPLATE_VARIABLE, ObjectName, ValueKVP.Key);

				// Check if we have a value for the property
				if (ValueKVP.Value != null && !string.IsNullOrWhiteSpace(ValueKVP.Value?.ToString()))
				{
					// Write property to template file
					DataTemplate = DataTemplate.Replace(TemplateReplaceName, ValueKVP.Value?.ToString() ?? string.Empty);
				}
				else
				{
					// Remove property line from the file to use Dota's default value
					List<string> TemplateLines = DataTemplate.Split('\n').ToList();
					for(int i = TemplateLines.Count - 1; i >= 0; --i)
					{
						if (TemplateLines[i].Contains(TemplateReplaceName))
						{
							TemplateLines.RemoveAt(i);
                        }
                    }

					// Rebuild template file
					StringBuilder Builder = new StringBuilder();
					for(int i = 0; i < TemplateLines.Count; ++i)
					{
						Builder.AppendLine(TemplateLines[i].Trim('\n', '\r'));
                    }
					DataTemplate = Builder.ToString();
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
