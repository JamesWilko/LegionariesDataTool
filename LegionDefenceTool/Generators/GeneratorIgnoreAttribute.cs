using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Generators
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class GeneratorIgnore : Attribute
	{
	}
}
