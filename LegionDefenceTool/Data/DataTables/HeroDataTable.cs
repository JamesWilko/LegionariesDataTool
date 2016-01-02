using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class HeroDataTable : DataTable
	{
		public HeroDataTable(string SpreadsheetId, string TabId)
			: base(SpreadsheetId, TabId)
		{
		}

		[SpreadsheetColumn("HeroName", DataType.String)]
		public List<string> HeroName;

		[SpreadsheetColumn("DotaHeroOverride", DataType.String)]
		public List<string> DotaHeroOverride;

		[SpreadsheetColumn("LegionUnitPrefix", DataType.String)]
		public List<string> LegionUnitPrefix;

		public List<LegionHero> GetHeroes(LegionDatabase Database)
		{
			this.Process();

			List<LegionHero> Builders = new List<LegionHero>();

			if (HeroName != null)
			{
				for (int i = 0; i < HeroName.Count; ++i)
				{
					// Create hero
					LegionHero Hero = new LegionHero();

					// Set details
					Hero.HeroName = HeroName[i];
					Hero.DotaHeroOverride = DotaHeroOverride[i];
					Hero.LegionUnitPrefix = LegionUnitPrefix[i];

					// Add unit to list
					Builders.Add(Hero);
				}
			}

			return Builders;
		}
	}
}
