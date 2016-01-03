using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LegionDefenceTool.Utils
{
	public static class StringUtils
	{
		public enum ParseMethod
		{
			CSV,
			TSV,
		}

		public const string TSV_REGEX = "((\"[^ \"]*\" |[^, \"\n])*),";

		public static IEnumerable<string> IterateLines(string Lines)
		{
			using (StringReader reader = new StringReader(Lines))
			{
				string line = string.Empty;
				do
				{
					line = reader.ReadLine();
					if (line != null)
					{
						yield return line;
					}

				}
				while (line != null);
			}
		}

		public static IEnumerable<string[]> ParseData(string Data, ParseMethod ParsingMethod)
		{
			switch (ParsingMethod)
			{
				default:
				case ParseMethod.CSV:
					foreach (string[] s in ParseCSV(Data))
					{
						yield return s;
					}
					break;
                case ParseMethod.TSV:
					foreach (string line in IterateLines(Data))
					{
						yield return (from Match m
									  in Regex.Matches(line, TSV_REGEX, RegexOptions.ExplicitCapture)
									  select m.Groups[1].Value
									  ).Select(s => s.Replace("\"\"", "\"")).ToArray();

					}
					break;
			}			
		}

		static IEnumerable<string[]> ParseCSV(string Data)
		{
			// http://stackoverflow.com/a/17207767
			foreach (string s in IterateLines(Data))
			{
				int i;
				int a = 0;
				int count = 0;
				List<string> str = new List<string>();
				for (i = 0; i < s.Length; i++)
				{
					switch (s[i])
					{
						case ',':
							if ((count & 1) == 0)
							{
								str.Add(s.Substring(a, i - a));
								a = i + 1;
							}
							break;
						case '"':
						case '\'': count++; break;
					}
				}
				str.Add(s.Substring(a).Replace("\"", ""));
				yield return str.ToArray();
			}
		}
	}
}
