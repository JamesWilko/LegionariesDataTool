using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class UnitDataTable : DataTable
	{
		public UnitDataTable(string SpreadsheetId, string TabId)
			: base(SpreadsheetId, TabId)
		{
		}

		[SpreadsheetColumn("UnitName", DataType.String)]
		List<string> UnitName;

		[SpreadsheetColumn("UpgradesFrom", DataType.String)]
		List<string> UpgradesFrom;

		[SpreadsheetColumn("GoldCost", DataType.Integer)]
		List<int> GoldCost;

		[SpreadsheetColumn("FoodCost", DataType.Integer)]
		List<int> FoodCost;

		[SpreadsheetColumn("MoveSpeed", DataType.Integer)]
		List<int> MoveSpeed;

		[SpreadsheetColumn("TurnSpeed", DataType.Decimal)]
		List<decimal> TurnSpeed;

		[SpreadsheetColumn("Health", DataType.Integer)]
		List<int> Health;

		[SpreadsheetColumn("HealthRegen", DataType.Decimal)]
		List<decimal> HealthRegen;

		[SpreadsheetColumn("Mana", DataType.Integer)]
		List<int> Mana;

		[SpreadsheetColumn("ManaRegen", DataType.Decimal)]
		List<decimal> ManaRegen;

		[SpreadsheetColumn("DamageType", DataType.String)]
		List<string> DamageType;

		[SpreadsheetColumn("DamageMin", DataType.Integer)]
		List<int> DamageMin;

		[SpreadsheetColumn("DamageMax", DataType.Integer)]
		List<int> DamageMax;

		[SpreadsheetColumn("AttackRate", DataType.Decimal)]
		List<decimal> AttackRate;

		[SpreadsheetColumn("AttackCapability", DataType.String)]
		List<string> AttackCapability;

		[SpreadsheetColumn("AttackRange", DataType.Integer)]
		List<int> AttackRange;

		[SpreadsheetColumn("ProjectileModel", DataType.String)]
		List<string> ProjectileModel;

		[SpreadsheetColumn("ProjectileSpeed", DataType.Integer)]
		List<int> ProjectileSpeed;

		[SpreadsheetColumn("ArmourType", DataType.String)]
		List<string> ArmourType;

		[SpreadsheetColumn("Armour", DataType.Integer)]
		List<int> Armour;

		[SpreadsheetColumn("MagicResist", DataType.Integer)]
		List<int> MagicResist;

		[SpreadsheetColumn("Ability", DataType.String)]
		List<string> AbilityKey;

		[SpreadsheetColumn("Bounty", DataType.Integer)]
		List<int> Bounty;

		[SpreadsheetColumn("UnitModel", DataType.String)]
		List<string> UnitModel;

		[SpreadsheetColumn("ModelScale", DataType.Decimal)]
		List<decimal> ModelScale;

		[SpreadsheetColumn("SpawnIcon", DataType.String)]
		List<string> SpawnIcon;

		[SpreadsheetColumn("SpawnEffectAOE", DataType.Decimal)]
		List<decimal> SpawnEffectAOE;

		[SpreadsheetColumn("WearablesList", DataType.String)]
		List<string> WearablesList;

		public List<LegionUnit> GetUnits(LegionDatabase Database)
		{
			this.Process();

			List<LegionUnit> Units = new List<LegionUnit>();

			if (UnitName != null)
			{
				for (int i = 0; i < UnitName.Count; ++i)
				{
					// Create unit
					LegionUnit Unit = Database.GetUnit(UnitName[i]) ?? new LegionUnit();
					
					// Check if unit is an upgrade from a previous one
					if(!string.IsNullOrWhiteSpace(UpgradesFrom[i]))
					{
						foreach(LegionUnit PrevUnit in Units)
						{
							if(PrevUnit.UnitName == UpgradesFrom[i])
							{
								Unit = PrevUnit.Clone();
                            }
						}
					}

					// Set unit details
					Unit.UnitName = UnitName[i];
					Unit.UpgradesFrom = UpgradesFrom[i];
					Unit.GoldCost = GoldCost[i];
					Unit.FoodCost = FoodCost[i];
					Unit.MoveSpeed = MoveSpeed[i];
					Unit.TurnSpeed = TurnSpeed[i];
					Unit.Health = Health[i];
					Unit.HealthRegen = HealthRegen[i];
					Unit.Mana = Mana[i];
					Unit.ManaRegen = ManaRegen[i];
					Unit.DamageType = DamageType[i];
					Unit.DamageMin = DamageMin[i];
					Unit.DamageMax = DamageMax[i];
					Unit.AttackRate = AttackRate[i];
					Unit.AttackCapability = AttackCapability[i];
					Unit.AttackRange = AttackRange[i];
					Unit.ProjectileModel = ProjectileModel[i];
					Unit.ProjectileSpeed = ProjectileSpeed[i];
                    Unit.ArmourType = ArmourType[i];
					Unit.Armour = Armour[i];
					Unit.MagicResist = MagicResist[i];
					Unit.AbilityKey = AbilityKey[i];
					Unit.Bounty = Bounty[i];
					Unit.UnitModel = UnitModel[i];
					Unit.ModelScale = ModelScale[i];
					Unit.SpawnIcon = SpawnIcon[i];
					Unit.SpawnEffectAOE = SpawnEffectAOE[i];
					Unit.WearablesList = WearablesList[i];

					// Add unit to list
					Units.Add(Unit);
                }
			}

			return Units;
        }
	}
}
