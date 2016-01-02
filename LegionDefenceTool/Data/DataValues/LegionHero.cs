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

		#endregion

	}
}
