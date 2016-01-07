using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	// Attach this to a dictionary to allow a generator to use the keys as parameters during generation
	[AttributeUsage(AttributeTargets.Field)]
	public class GeneratorDictionary : Attribute
	{
	}
}
