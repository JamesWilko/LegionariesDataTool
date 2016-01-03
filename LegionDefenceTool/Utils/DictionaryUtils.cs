﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Utils
{
	public static class DictionaryUtils
	{

		public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		{
			if (dictionary.ContainsKey(key))
			{
				return dictionary[key];
			}
			return default(TValue);
		}
	}
}
