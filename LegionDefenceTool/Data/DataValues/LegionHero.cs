using LegionDefenceTool.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class LegionHero : DataNode
	{
		#region Hero Data

		public string HeroName;
		public string DotaHeroOverride;
		public string LegionUnitPrefix;

		#endregion

		#region DataNode

		public override string GetDisplayID()
		{
			return $"{HeroName}";
		}

		public override string GetDisplayName()
		{
			return $"{HeroName}";
		}

		public override string GetParentID()
		{
			// No nesting
			return null;
		}

		#endregion

		#region Properties

		[JsonIgnore]
		public string ID { get { return string.Format(Constants.HERO_ID, HeroName); } }

		[JsonIgnore]
		public List<LegionUnit> AllUnits
		{
			get
			{
				LegionDatabase Database = LegionDatabase.ActiveDatabase;
				List<LegionUnit> Units = new List<LegionUnit>();
				foreach (LegionUnit Unit in Database.LegionUnits)
				{
					if (Unit.UnitName.StartsWith(this.LegionUnitPrefix))
					{
						Units.Add(Unit);
                    }
				}
				return Units;
            }
		}

		[JsonIgnore]
		public List<LegionUnit> BaseUnits
		{
			get
			{
				LegionDatabase Database = LegionDatabase.ActiveDatabase;
				List<LegionUnit> Units = new List<LegionUnit>();
				foreach (LegionUnit Unit in Database.LegionUnits)
				{
					if (Unit.ParentUnit == null &&
                        Unit.UnitName.StartsWith(this.LegionUnitPrefix))
					{
						Units.Add(Unit);
					}
				}
				return Units;
			}
		}

		[JsonIgnore]
		public string BaseUnitsDisplayList { get { return BaseUnits.PrintList(); } }

		[JsonIgnore]
		public string AllUnitsDisplayList { get { return AllUnits.PrintList(); } }

		[JsonIgnore]
		public string Abilities
		{
			get
			{
				StringBuilder Builder = new StringBuilder();
				List<LegionUnit> Units = BaseUnits;

				// Sort units by tier
				Units.Sort((a, b) => a.Bounty - b.Bounty);

				// Add unit abilities to KV
				for (int i = 0; i < Units.Count; ++i)
				{
					string Ability = string.Format(Constants.HERO_ABILITY_KV, i + 1, Units[i].SummonAbility);
					Builder.AppendLine(Ability);
                }

				// Add remaining KVs if needed
				if (Units.Count < Constants.MINIMUM_HERO_ABILITIES)
				{
					for (int i = Units.Count; i < Constants.MINIMUM_HERO_ABILITIES; ++i)
					{
						string Ability = string.Format(Constants.HERO_ABILITY_KV, i + 1, string.Empty);
						Builder.AppendLine(Ability);
					}
				}

				return Builder.ToString();
            }
		}

		#endregion

	}
}
