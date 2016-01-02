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
	public class HeroFileGenerator
	{
		const string HERO_LIST_TEMPLATE_FILE = "templates/herolist_template.txt";
		const string HERO_TEMPLATE_FILE = "templates/heroes/npc_hero_template.txt";
		const string TEMPLATE_VARIABLE = "{{Hero.{0}}}";

		string HeroListTemplateFile;
		string HeroTemplateFile;

		public void Generate(LegionDatabase Database)
		{
			TextReader Reader;
			TextWriter Writer;

			// Load template for hero list
			if (File.Exists(HERO_LIST_TEMPLATE_FILE))
			{
				Reader = new StreamReader(HERO_LIST_TEMPLATE_FILE, Encoding.UTF8);
				HeroListTemplateFile = Reader.ReadToEnd();
				Reader.Close();
			}

			// Build hero list
			string HeroList = HeroListTemplateFile;
            StringBuilder HeroListBuilder = new StringBuilder();
			foreach (LegionHero Hero in Database.LegionHeroes)
			{
				string HeroListItem = string.Format(Constants.HERO_LIST_HERO_KV, Hero.DotaHeroOverride, Constants.MAX_SINGLE_HERO);
				HeroListBuilder.AppendLine(HeroListItem);
            }
			HeroList = HeroList.Replace("{Heroes}", HeroListBuilder.ToString());

			// Save hero list to file
			string HeroListPathOut = string.Format("output/herolist.txt");
			Writer = new StreamWriter(HeroListPathOut, false, Encoding.UTF8);
			Writer.Write(HeroList);
			Writer.Close();

			// Load template file for hero data
			if (File.Exists(HERO_TEMPLATE_FILE))
			{
				Reader = new StreamReader(HERO_TEMPLATE_FILE, Encoding.UTF8);
				HeroTemplateFile = Reader.ReadToEnd();
				Reader.Close();
			}

			// Run through all heroes
			foreach (LegionHero Hero in Database.LegionHeroes)
			{
				// Template file
				string Template = HeroTemplateFile;

				// Get fields from hero
				var Flags = BindingFlags.Instance | BindingFlags.Public;
				var UnitFields = Hero.GetType().GetFields(Flags).ToList();
				var UnitProperties = Hero.GetType().GetProperties(Flags).ToList();

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
				foreach (var VariableName in FieldNameList)
				{
					// Get replacement string
					string TemplateReplaceName = string.Format(TEMPLATE_VARIABLE, VariableName);

					// Try finding field or property
					var UnitField = UnitFields.FirstOrDefault(x => x.Name == VariableName);
					var UnitProp = UnitProperties.FirstOrDefault(x => x.Name == VariableName);

					// Write property to file
					if (UnitField != null)
					{
						var UnitVar = UnitField.GetValue(Hero);
						Template = Template.Replace(TemplateReplaceName, UnitVar.ToString());
					}
					else if (UnitProp != null)
					{
						var UnitVar = UnitProp.GetValue(Hero);
						Template = Template.Replace(TemplateReplaceName, UnitVar.ToString());
					}
					else
					{
						Console.WriteLine($"No value could be found property '{VariableName}' on unit {Hero.GetDisplayName()}");
					}
				}

				// Write out
				string PathOut = string.Format("output/npc_hero_{0}.txt", Hero.HeroName);
                Writer = new StreamWriter(PathOut, false, Encoding.UTF8);
				Writer.Write(Template);
				Writer.Close();
			}
		}
	}
}
