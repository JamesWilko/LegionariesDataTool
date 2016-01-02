using LegionDefenceTool.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegionDefenceTool.Data
{
	public abstract class DataNode
	{
		// Used to display nodes in the UI
		public abstract string GetDisplayID();
		public abstract string GetDisplayName();
		public abstract string GetParentID();

		// Used to display information in the UI
		public virtual void PopulateDataGrid(object Obj, DataGridView DataGrid)
		{
			// Get fields and properties
			var Flags = BindingFlags.Instance | BindingFlags.Public;
			var Fields = Obj.GetType().GetFields(Flags).ToList();
			var Properties = Obj.GetType().GetProperties(Flags).ToList();

			// Add all fields to the data grid
			foreach (var Field in Fields)
			{
				if (Field.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
				{
					DataGrid.Rows.Add(Field.Name, Field.GetValue(Obj));
				}
			}

			// Add all properties to the data grid
			foreach (var Property in Properties)
			{
				if (Property.GetCustomAttribute(typeof(GeneratorIgnore)) == null)
				{
					DataGrid.Rows.Add(Property.Name, Property.GetValue(Obj));
				}
			}
		}
    }
}
