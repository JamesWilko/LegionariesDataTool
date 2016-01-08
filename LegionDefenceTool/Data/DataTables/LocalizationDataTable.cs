using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class LocalizationDataTable : DataTable
	{
		public static string[] LANGUAGES = new string[]
		{
			"English"
		};

		[SpreadsheetColumn("Key", DataType.String)]
		public List<string> Keys;

		[SpreadsheetColumn("English", DataType.String)]
		public List<string> English;

		public LocalizationDataTable(string SpreadsheetId, string TabId)
			: base(SpreadsheetId, TabId)
		{
        }

		public List<LocalizedLanguage> GetLanguages(LegionDatabase Database)
		{
			this.Process();

			List<LocalizedLanguage> Languages = new List<LocalizedLanguage>();

			// Generate language parents
			for (int i = 0; i < LANGUAGES.Length; ++i)
			{
				LocalizedLanguage Lang = new LocalizedLanguage();
				Lang.LanguageId = LANGUAGES[i];
				Lang.Keys = new List<string>();
				Lang.Values = new List<string>();
				Languages.Add(Lang);
			}

			// Generate localized languages
			for (int i = 0; i < LANGUAGES.Length; ++i)
			{
				LocalizedLanguage Lang = new LocalizedLanguage();
				Lang.LanguageId = LANGUAGES[i];
				Lang.ParentDataTable = this;
                Lang.Keys = Keys ?? new List<string>();
				Lang.Values = English ?? new List<string>();
				Languages.Add(Lang);
			}

			return Languages;
        }
    }
}
