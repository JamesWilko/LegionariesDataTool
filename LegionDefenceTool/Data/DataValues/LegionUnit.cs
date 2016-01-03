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
	public class LegionUnit : DataNode
	{
		[GeneratorIgnore]
		const string DATA_COL_PARENT_VALUE = "columnUnitParentValue";
		[GeneratorIgnore]
		const string NPC_ID = "npc_legion_{0}";
		[GeneratorIgnore]
		const int LEVEL_PER_UPGRADE = 5;
		[GeneratorIgnore]
		const string WEARABLE_ID = "\t\t\t\"Wearable{0}\" {{ \"ItemDef\" \"{1}\" }}";

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
		public string ProjectileModel;
		public int ProjectileSpeed;
		public string ArmourType;
		public int Armour;
		public int MagicResist;
		public string AbilityKey;
		public int Bounty;
		public string UnitModel;
		public decimal ModelScale;
		public string SpawnIcon;
		public decimal SpawnEffectAOE;

		[GeneratorIgnore]
		public LegionUnitWearables WearablesOverrides;

		[JsonIgnore, GeneratorIgnore]
		public LegionUnit ParentUnit { get; set; }

		#endregion

		public LegionUnit()
		{
			WearablesOverrides = new LegionUnitWearables();
        }

		public LegionUnit Clone()
		{
			return (LegionUnit) this.MemberwiseClone();
		}

		public override string ToString()
		{
			return $"{UnitName}";
		}

		public bool IsBaseUnit()
		{
			return string.IsNullOrWhiteSpace(UpgradesFrom);
        }

		public bool IsUpgradeUnit()
		{
			return !IsBaseUnit();
        }

		#region DataNode

		public override string GetDisplayID()
		{
			return $"{UnitName}";
		}

		public override string GetDisplayName()
		{
			return $"{UnitName}";
		}

		public override string GetParentID()
		{
			if(ParentUnit != null)
			{
				return $"{ParentUnit.UnitName}";
			}
			return null;
		}

		#endregion

		#region Properties

		[JsonIgnore]
		public string ID { get { return string.Format(NPC_ID, UnitName); } }

		[JsonIgnore]
		public string Model
		{
			get
			{
				return DotaData.ActiveData.GetHeroData(UnitModel)?["Model"]?.GetString();
			}
		}

		[JsonIgnore]
		public string SoundSet
		{
			get
			{
				return DotaData.ActiveData.GetHeroData(UnitModel)?["SoundSet"]?.GetString();
			}
		}

		[JsonIgnore]
		public string SoundsFile
		{
			get
			{
				return DotaData.ActiveData.GetHeroData(UnitModel)?["GameSoundsFile"]?.GetString();
			}
		}

		[JsonIgnore]
		public string ParticlesFolder
		{
			get
			{
				return DotaData.ActiveData.GetHeroData(UnitModel)?["particle_folder"]?.GetString();
			}
		}

		[JsonIgnore]
		public string VoiceFile
		{
			get
			{
				return DotaData.ActiveData.GetHeroData(UnitModel)?["VoiceFile"]?.GetString();
			}
		}

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
				if (ParentUnit != null)
				{
					return string.Format(Constants.UPGRADE_UNIT_ABILITY, UnitName);
				}
				return null;
			}
		}

		[JsonIgnore]
		public string UpgradeAbilityScript
		{
			get
			{
				return string.Format(Constants.UPGRADE_UNIT_ABILITY_PATH, UpgradeAbility);
			}
		}

		[JsonIgnore]
		public string Abilities
		{
			get
			{
				int AbilityIndex = 1;
				StringBuilder Builder = new StringBuilder();

				// Add unit abilities
				// TODO

				// Add upgrade abilities
				var ChildUnits = LegionDatabase.ActiveDatabase.LegionUnits.Where(x => x.ParentUnit == this).ToList();
				foreach(LegionUnit Unit in ChildUnits)
				{
					Builder.AppendLine(string.Format(Constants.HERO_ABILITY_KV, AbilityIndex++, Unit.UpgradeAbility));
				}

				// Add sell ability
				Builder.AppendLine(string.Format(Constants.HERO_ABILITY_KV, AbilityIndex++, ParentHero?.SellUnitAbility ?? Constants.SELL_UNIT_ABILITY));

				return Builder.ToString();
            }
		}

		[JsonIgnore]
		public float AttackAnimationPoint
		{
			get
			{
				var value = DotaData.ActiveData.GetHeroData(UnitModel)?["AttackAnimationPoint"]?.GetFloat();
				return value.HasValue ? value.Value : 0f;
			}
		}

		[JsonIgnore]
		public string Wearables
		{
			get
			{
				var KVs = DotaData.ActiveData.GetDefaultWearablesForHero(UnitModel);
				StringBuilder Builder = new StringBuilder();
				for(int i = 0; i < KVs.Length; ++i)
				{
					string Attachment = string.Format(WEARABLE_ID, i, KVs[i]?.Key);
					Builder.AppendLine(Attachment);
                }
                return Builder.ToString();
			}
		}

		[JsonIgnore, GeneratorIgnore]
		public LegionHero ParentHero
		{
			get
			{
				var Heroes = LegionDatabase.ActiveDatabase.GetHeroes();
				foreach (var Hero in Heroes)
				{
					if (Hero.AllUnits.Contains(this))
					{
						return Hero;
					}
				}
				return null;
			}
		}

		[JsonIgnore]
		public string SummonAbility
		{
			get
			{
				return string.Format(Constants.UNIT_SUMMON_ABILITY_NAME, UnitName);
			}
		}

		[JsonIgnore]
		public string SummonAbilityScript
		{
			get
			{
				return string.Format(Constants.SPAWN_UNIT_ABILITY_PATH, SummonAbility);
			}
		}

		[JsonIgnore]
		public string SummonAbilityBaseClassPath
		{
			get
			{
				return ParentHero?.BaseSpawnAbility ?? string.Empty;
			}
		}

		[JsonIgnore]
		public string SummonAbilityBaseClass
		{
			get
			{
				string Path = SummonAbilityBaseClassPath;
				string[] PathSegments = Path.Split('/');
                return PathSegments[PathSegments.Length - 1];
			}
		}

		[JsonIgnore]
		public decimal HeroAbilityCastPoint
		{
			get
			{
				if (ParentHero != null)
				{
					return (decimal)DotaData.ActiveData?.GetHeroData(ParentHero.DotaHeroOverride)?["AttackAnimationPoint"]?.GetFloat();
				}
				else
				{
					return 0.5m;
				}
			}
		}

		#endregion
	}
}
