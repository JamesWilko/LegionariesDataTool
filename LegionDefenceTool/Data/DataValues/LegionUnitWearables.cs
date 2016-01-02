using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class LegionUnitWearables
	{
		public int? Wearable1;
		public int? Wearable2;
		public int? Wearable3;
		public int? Wearable4;
		public int? Wearable5;
		public int? Wearable6;

		public override string ToString()
		{
			string str = "";
			str += Wearable1.HasValue ? $"Wearable1: {Wearable1}, " : string.Empty;
			str += Wearable2.HasValue ? $"Wearable2: {Wearable2}, " : string.Empty;
			str += Wearable3.HasValue ? $"Wearable3: {Wearable3}, " : string.Empty;
			str += Wearable4.HasValue ? $"Wearable4: {Wearable4}, " : string.Empty;
			str += Wearable5.HasValue ? $"Wearable5: {Wearable5}, " : string.Empty;
			str += Wearable6.HasValue ? $"Wearable6: {Wearable6}, " : string.Empty;
			return str;
		}
	}
}
