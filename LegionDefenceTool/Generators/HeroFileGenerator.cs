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
	public class HeroFileGenerator : FileGenerator
	{
		const string HERO_LIST_TEMPLATE_FILE = "templates/herolist_template.txt";
		const string HERO_TEMPLATE_FILE = "templates/heroes/npc_hero_template.txt";
		const string CUSTOM_HEROES_TEMPLATE_FILE = "templates/npc_heroes_custom_template.txt";

		const string HERO_LIST_OUTPUT_FILE = "output/herolist.txt";
        const string CUSTOM_HEROES_OUTPUT_FILE = "output/npc_heroes_custom.txt";

		public override void Generate(LegionDatabase Database)
		{
			GenerateHeroList(Database);
			GenerateHeroesFile(Database);
        }

		protected void GenerateHeroList(LegionDatabase Database)
		{
			// Load hero list template
			string HeroListTemplateFile = LoadTemplateFile(HERO_LIST_TEMPLATE_FILE);

			// Build hero list
			string HeroList = HeroListTemplateFile;
			StringBuilder HeroListBuilder = new StringBuilder();
			foreach (LegionHero Hero in Database.LegionHeroes)
			{
				string HeroListItem = string.Format(Constants.HERO_LIST_HERO_KV, Hero.ID, Constants.MAX_SINGLE_HERO);
				HeroListBuilder.AppendLine(HeroListItem);
			}
			HeroList = HeroList.Replace("{Heroes}", HeroListBuilder.ToString());

			// Save hero list to file
			SaveDataToFile(HERO_LIST_OUTPUT_FILE, HeroList);
		}

		protected void GenerateHeroesFile(LegionDatabase Database)
		{
			// Load hero data template file
			string HeroTemplateFile = LoadTemplateFile(HERO_TEMPLATE_FILE);

			// Generate hero data
			List<string> GeneratedHeroData = GenerateDataForList<LegionHero>(HeroTemplateFile, Database.LegionHeroes, "Hero");

			// Build heroes data and output
			string HeroesBuildFile = GenerateBuildFile(CUSTOM_HEROES_TEMPLATE_FILE, GeneratedHeroData, "{Heroes}");
			SaveDataToFile(CUSTOM_HEROES_OUTPUT_FILE, HeroesBuildFile);
		}

	}
}
