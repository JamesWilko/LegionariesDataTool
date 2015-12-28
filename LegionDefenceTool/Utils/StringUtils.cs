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
		public const string CSV_REGEX = "(((?<x>(?=[,\r\n]+))|\"\"(?<x>([^\"\"]|\"\"\"\")+)\"\"|(?<x>[^,\r\n]+)),?)";

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
			string RegexStr = string.Empty;
			switch (ParsingMethod)
			{
				default:
				case ParseMethod.CSV:
					RegexStr = CSV_REGEX;
					break;
				case ParseMethod.TSV:
					RegexStr = TSV_REGEX;
					break;
			}

			foreach (string line in IterateLines(Data))
			{
				yield return (from Match m
							  in Regex.Matches(line, RegexStr, RegexOptions.ExplicitCapture)
							  select m.Groups[1].Value
							  ).Select(s => s.Replace("\"\"", "\"")).ToArray();

			}
		}
	}
}
