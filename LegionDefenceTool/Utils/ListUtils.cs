using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Utils
{
	public static class ListUtils
	{
		public static string PrintList<T>(this List<T> list)
		{
			StringBuilder Builder = new StringBuilder();
			foreach (T element in list)
			{
				if (Builder.Length > 0)
				{
					Builder.Append(", ");
				}
				Builder.Append(element);
			}
			return Builder.ToString();
		}
	}
}
