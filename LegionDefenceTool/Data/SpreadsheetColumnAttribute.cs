using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public enum DataType
	{
		String,
		Integer,
		Decimal,
		Enum
	}

	[AttributeUsage(AttributeTargets.Field)]
	class SpreadsheetColumn : Attribute
	{
		public string Heading;
		public DataType StoredDataType;

		const string USE_PREV_VALUE_STR = "-";

		public SpreadsheetColumn(string Heading, DataType ColumnType)
		{
			this.Heading = Heading;
			this.StoredDataType = ColumnType;
        }

		public object ConvertDataToDesiredType(List<string> Data)
		{
			switch(StoredDataType)
			{
				default:
				case DataType.String:
					return Data;
				case DataType.Integer:
					return ConvertToIntList(Data);
                case DataType.Decimal:
					return ConvertToDecList(Data);
                case DataType.Enum:
					throw new NotImplementedException();
			}
		}
		
		public List<int> ConvertToIntList(List<string> Data)
		{
			List<int> IntList = new List<int>();
			for(int i = 0; i < Data.Count; ++i)
			{
				if (i > 0 && Data[i] == USE_PREV_VALUE_STR)
				{
					IntList.Add(IntList[i - 1]);
				}
				else
				{
					int Value;
					int.TryParse(Data[i], out Value);
					IntList.Add(Value);
				}
			}
			return IntList;
        }

		public List<decimal> ConvertToDecList(List<string> Data)
		{
			List<decimal> DecList = new List<decimal>();
			for (int i = 0; i < Data.Count; ++i)
			{
				if (i > 0 && Data[i] == USE_PREV_VALUE_STR)
				{
					DecList.Add(DecList[i - 1]);
				}
				else
				{
					decimal Value;
					decimal.TryParse(Data[i], out Value);
					DecList.Add(Value);
				}
			}
			return DecList;
		}
    }
}
