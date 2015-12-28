using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class LegionUnit
	{
		public string UnitName;
		public string UpgradesFrom;
		public int GoldCost;
		public int FoodCost;
		public int MoveSpeed;
		public decimal TurnSpeed;
		public int Health;
		public decimal HealthRegen;
		public int Mana;
		public decimal ManaRegen;
		public int DamageMin;
		public int DamageMax;
		public decimal AttackRate;
		public string AttackType;
		public int AttackRange;
		public int Armour;
		public int MagicResist;
		public string AbilityKey;
		public int Bounty;

		public LegionUnit Clone()
		{
			return (LegionUnit) this.MemberwiseClone();
		}
	}
}
