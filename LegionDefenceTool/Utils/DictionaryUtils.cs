using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Utils
{
	public static class DictionaryUtils
	{
		static List<object> MissingKeysList = new List<object>();

		public static void ClearMissingKeys()
		{
			MissingKeysList.Clear();
        }

		public static void RecordMissingKey<TKey>(TKey key)
		{
			Console.WriteLine($"Missing key: {key}");
			MissingKeysList.Add(key);
        }

		public static List<object> GetMissingsKeys()
		{
			return MissingKeysList;
        }

		public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		{
			if (dictionary.ContainsKey(key))
			{
				return dictionary[key];
			}
			else
			{
				RecordMissingKey(key);
			}
			return default(TValue);
		}
	}
}
