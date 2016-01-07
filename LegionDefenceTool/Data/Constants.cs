using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public static class Constants
	{
		public const string JAMES_WILKO_GITHUB = "https://github.com/JamesWilko";
		public const string LEGION_DEFENCE_GITHUB = "https://github.com/JamesWilko/LegionDefence";

		public const string HERO_LIST_HERO_KV = "\t\"{0}\"\t\"{1}\"";
		public const int MAX_SINGLE_HERO = -1;

		public const string HERO_ID = "npc_legion_hero_{0}";
		public const string HERO_ABILITY_KV = "\t\"Ability{0}\"\t\"{1}\"";
		public const int MINIMUM_HERO_ABILITIES = 6;

		public const string SELL_UNIT_ABILITY = "sell_unit";
		public const string UPGRADE_UNIT_ABILITY = "upgrade_unit_{0}";

		public const string UNIT_SUMMON_ABILITY_NAME = "spawn_tower_{0}";
		public const string SPAWN_UNIT_ABILITY_PATH = "abilities/spawning/{0}";
		public const string UPGRADE_UNIT_ABILITY_PATH = "abilities/upgrading/{0}";

		public const string ABILITY_ID = "ability_{0}";
	}
}
