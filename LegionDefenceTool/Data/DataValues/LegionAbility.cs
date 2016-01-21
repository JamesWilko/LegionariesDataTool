using LegionDefenceTool.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegionDefenceTool.Data
{
	public class LegionAbility : DataNode
	{
		public string AbilityID;
		public string AbilityFile;
		public string AbilityUnitAI;
		public string AbilityTexture;

		[GeneratorDictionary]
		public Dictionary<object, object> AbilityValues;

		private List<string> InternalModifierList;

		const string MODIFIERS_REGEX = "\"(modifier_[^\"]*)";

		#region DataNode

		public override string GetDisplayID()
		{
			return $"{AbilityID}";
		}

		public override string GetDisplayName()
		{
			return $"{AbilityID}";
		}

		public override string GetParentID()
		{
			// No nesting
			return null;
		}

		#endregion

		public override void PopulateDataGrid(object Obj, DataGridView DataGrid)
		{
			// Populate default data
			base.PopulateDataGrid(Obj, DataGrid);

			// Show ability values from dictionary
			foreach(var kvp in AbilityValues)
			{
				DataGrid.Rows.Add(kvp.Key, kvp.Value);
			}
		}

		public List<string> GenerateModifierList()
		{
			List<string> ModifiersList = new List<string>();

			Generators.AbilityFileGenerator Generator = new Generators.AbilityFileGenerator();
			string AbilityFilePath = Generator.GetPathForAbilityFile(AbilityFile);
			string AbilityTemplate = Generator.LoadTemplateFile(AbilityFilePath);
			AbilityTemplate = Generator.ProcessTemplate<LegionAbility>(AbilityTemplate, this, "Ability");

			Regex ModifiersRegex = new Regex(MODIFIERS_REGEX);

			string[] Lines = AbilityTemplate.Split('\n');
			foreach (string Line in Lines)
			{
				Match LineMatch = ModifiersRegex.Match(Line);
				if (LineMatch.Success)
				{
					string ModifierName = LineMatch.Value.Replace("\"", "").Trim();
					if (!ModifiersList.Contains(ModifierName))
					{
						ModifiersList.Add(ModifierName);
					}
				}
			}

			return ModifiersList;
		}

		public override string ToString()
		{
			return $"[LegionAbility (ID: {AbilityID})]";
        }

		#region Properties

		public string ID
		{
			get
			{
				return string.Format(Constants.ABILITY_ID, AbilityID);
			}
		}

		public List<string> Modifiers
		{
			get
			{
				if (InternalModifierList == null)
				{
					InternalModifierList = new List<string>();
					InternalModifierList = InternalModifierList.Concat(GenerateModifierList()).ToList();
                }
				return InternalModifierList;
            }
		}

		#endregion

	}
}
