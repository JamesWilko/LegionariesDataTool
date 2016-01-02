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
	public class LocalizationFileGenerator
	{
		const string TEMPLATE_FILE = "templates/addon_language_template.txt";
		const string OUTPUT_FILE = "output/addon_{0}.txt";

		const string TOKEN_LINE = "\t\t\"{0}\"\t\"{1}\"";

		string LanguageTemplateFile = "";

		public void Generate(LegionDatabase Database)
		{
			if (File.Exists(TEMPLATE_FILE))
			{
				// Load template file
				TextReader Reader = new StreamReader(TEMPLATE_FILE, Encoding.UTF8);
				LanguageTemplateFile = Reader.ReadToEnd();
				Reader.Close();

				// Process languages
				foreach (var Language in LocalizationDataTable.LANGUAGES)
				{
					GenerateLocalizationFile(Language, Database);
				}
			}
		}

		void GenerateLocalizationFile( string Language, LegionDatabase Database)
		{
			Console.WriteLine("Generating language: " + Language);

			// Build tokens for file
			StringBuilder TokenBuilder = new StringBuilder();
			foreach(var DataTable in Database.LocalizationDataTables)
			{
				var Flags = BindingFlags.Instance | BindingFlags.Public;
				var Fields = DataTable.GetType().GetFields(Flags).ToList();
				var LanguageList = (List<string>) Fields.First(x => x.Name == Language).GetValue(DataTable);

				for(int i = 0; i < DataTable.Keys.Count; ++i)
				{
					string Token = string.Format(TOKEN_LINE, DataTable.Keys[i], LanguageList[i]);
					TokenBuilder.AppendLine(Token);
                }
			}

			// Generate file contents
			string FileContents = LanguageTemplateFile;
			FileContents = FileContents.Replace("{Language}", Language);
			FileContents = FileContents.Replace("{Tokens}", TokenBuilder.ToString());

			// Write file
			string OutputPath = string.Format(OUTPUT_FILE, Language.ToLower());
            TextWriter Writer = new StreamWriter(OutputPath, false, Encoding.UTF8);
			Writer.Write(FileContents);
			Writer.Close();
		}

	}
}
