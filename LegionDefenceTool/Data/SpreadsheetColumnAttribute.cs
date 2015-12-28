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
				int Value;
				if(int.TryParse(Data[i], out Value))
				{
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
				decimal Value;
				if (decimal.TryParse(Data[i], out Value))
				{
					DecList.Add(Value);
				}
			}
			return DecList;
		}
    }
}
