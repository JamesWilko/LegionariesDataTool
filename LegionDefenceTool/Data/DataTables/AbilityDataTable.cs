using LegionDefenceTool.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class AbilityDataTable : DataTable
	{
		public AbilityDataTable(string SpreadsheetId, string TabId)
			: base(SpreadsheetId, TabId)
		{
		}

		[SpreadsheetColumn("AbilityID", DataType.String)]
		public List<string> AbilityID;

		[SpreadsheetColumn("AbilityFile", DataType.String)]
		public List<string> AbilityFile;

		public List<Dictionary<object, object>> AbilityValues;

		public override void Process()
		{
			// Process attributes
			base.Process();
			AbilityValues = new List<Dictionary<object, object>>();

			// Get headings that are processed automatically
			List<string> Headings = GetSpreadsheetColumnFieldHeadings();

			// Find all headings that aren't processed automatically
			List<string> ValueHeadings = new List<string>();
			foreach (var Key in SpreadsheetData.Keys)
			{
				if (!Headings.Contains(Key))
				{
					ValueHeadings.Add(Key);
                }
			}

			// Get number of abilities in the sheet
			int NumberOfAbilities = 0;
			if(Headings.Count > 0 && SpreadsheetData.ContainsKey(Headings[0]))
			{
				NumberOfAbilities = SpreadsheetData[Headings[0]].Count;
            }

			// Run through all abilities and build our value dictionary
			for (int i = 0; i < NumberOfAbilities; ++i)
			{
				Dictionary<object, object> ValuesDict = new Dictionary<object, object>();
				foreach(var Heading in ValueHeadings)
				{
					// Check we actually have a value
					string ValueString = SpreadsheetData[Heading][i];
					if(!string.IsNullOrWhiteSpace(ValueString))
					{
						// Split the column into key and value and add to dictionary
						string[] SplitValues = ValueString.Split(':');
						ValuesDict.Add(SplitValues[0].Trim(), SplitValues[1].Trim());
                    }
                }
				AbilityValues.Add(ValuesDict);
			}
		}

		public List<LegionAbility> GetAbilities(LegionDatabase Database)
		{
			// Process abilities data
			this.Process();

			List<LegionAbility> Abilities = new List<LegionAbility>();

			if (AbilityID != null)
			{
				for (int i = 0; i < AbilityID.Count; ++i)
				{
					// Build ability data
					LegionAbility Ability = new LegionAbility();
					Ability.AbilityID = AbilityID[i];
					Ability.AbilityFile = AbilityFile[i];
					Ability.AbilityValues = AbilityValues[i];

					// Add ability
					Abilities.Add(Ability);
				}
			}

			return Abilities;
        }
	}
}
