using LegionDefenceTool.Generators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegionDefenceTool.Data
{
	public class LegionUnit
	{
		[GeneratorIgnore]
		const string DATA_COL_PARENT_VALUE = "columnUnitParentValue";
		[GeneratorIgnore]
		const string NPC_ID = "npc_legion_{0}";
		[GeneratorIgnore]
		const int LEVEL_PER_UPGRADE = 5;

		#region Unit Data

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
		public string DamageType;
		public int DamageMin;
		public int DamageMax;
		public decimal AttackRate;
		public string AttackCapability;
		public int AttackRange;
		public string ArmourType;
		public int Armour;
		public int MagicResist;
		public string AbilityKey;
		public int Bounty;
		public string UnitModel;
		public decimal ModelScale;
		public LegionUnitWearables Wearables;

		[JsonIgnore, GeneratorIgnore]
		public LegionUnit ParentUnit { get; set; }

		#endregion

		public LegionUnit()
		{
			Wearables = new LegionUnitWearables();
        }

		public LegionUnit Clone()
		{
			return (LegionUnit) this.MemberwiseClone();
		}

		public void PopulateDataGrid(DataGridView DataGrid)
		{
			// Remove extra columns
			if (DataGrid.Columns.Contains(DATA_COL_PARENT_VALUE))
			{
				DataGrid.Columns.Remove(DATA_COL_PARENT_VALUE);
			}

			// Get all fields in our unit
			var Flags = BindingFlags.Instance | BindingFlags.Public;
			var Fields = this.GetType().GetFields(Flags).ToList();
			var Properties = this.GetType().GetProperties(Flags).ToList();

			// Add extra columns if needed
			if (ParentUnit != null)
			{
				DataGrid.Columns.Add(DATA_COL_PARENT_VALUE, "Parent Value");

				var ParentStyle = new DataGridViewCellStyle();
				ParentStyle.BackColor = System.Drawing.Color.LightBlue;
                DataGrid.Columns[DATA_COL_PARENT_VALUE].DefaultCellStyle = ParentStyle;
			}

			// Add all fields to the data grid
			foreach (var Field in Fields)
			{
				if (Field.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
				{
					if (ParentUnit != null)
					{
						DataGrid.Rows.Add(Field.Name, Field.GetValue(this), Field.GetValue(ParentUnit));
					}
					else
					{
						DataGrid.Rows.Add(Field.Name, Field.GetValue(this));
					}
				}
            }

			// Add all properties to the data grid
			foreach (var Property in Properties)
			{
				if (Property.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
				{
					if (ParentUnit != null)
					{
						DataGrid.Rows.Add(Property.Name, Property.GetValue(this), Property.GetValue(ParentUnit));
					}
					else
					{
						DataGrid.Rows.Add(Property.Name, Property.GetValue(this));
					}
				}
			}
		}

		#region Properties

		[JsonIgnore]
		public string ID { get { return string.Format(NPC_ID, UnitName); } }

		[JsonIgnore]
		public string Model { get { return "IMPLEMENT"; } }

		[JsonIgnore]
		public string SoundSet { get { return "IMPLEMENT"; } }

		[JsonIgnore]
		public string SoundsFile { get { return "IMPLEMENT"; } }

		[JsonIgnore]
		public string ParticlesFile { get { return "IMPLEMENT"; } }

		[JsonIgnore]
		public string VoiceFile { get { return "IMPLEMENT"; } }

		[JsonIgnore]
		public int Level
		{
			get
			{
				int level = LEVEL_PER_UPGRADE;
				if(ParentUnit != null)
				{
					level += ParentUnit.Level;
                }
				return level;
            }
		}

		[JsonIgnore]
		public string UpgradeAbility
		{
			get
			{
				return $"\"Ability1\"\t\"upgrade_unit\"";
			}
		}

		[JsonIgnore]
		public string SellAbility
		{
			get
			{
				return $"\"Ability2\"\t\"sell_unit\"";
			}
		}

		[JsonIgnore]
		public string Abilities
		{
			get
			{
				return $"";
			}
		}

		#endregion
	}
}
