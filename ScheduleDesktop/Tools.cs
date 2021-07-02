using ScheduleBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public static class Tools
	{
		public static List<string> ConfigDataGrid(this DataGridView grid, Type t)
		{
			var config = new List<string>();
			foreach (var prop in t.GetProperties())
			{
				// получаем список атрибутов
				var attributes = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
				if (attributes != null && attributes.Length > 0)
				{
					foreach (var attr in attributes)
					{
						// ищем нужный нам атрибут
						if (attr is ColumnAttribute columnAttr)
						{
							var column = new DataGridViewTextBoxColumn
							{
								Name = prop.Name,
								ReadOnly = true,
								HeaderText = columnAttr.Title,
								Visible = columnAttr.Visible,
								Width = columnAttr.Width
							};
							if (columnAttr.GridViewAutoSize != GridViewAutoSize.None)
							{
								column.AutoSizeMode = (DataGridViewAutoSizeColumnMode)Enum.Parse(typeof(DataGridViewAutoSizeColumnMode), columnAttr.GridViewAutoSize.ToString());
							}
							if ((attr as ColumnAttribute).Title == "id")
							{
								config.Insert(0, prop.Name);
								grid.Columns.Insert(0, column);
							}
							else
							{
								config.Add(prop.Name);
								grid.Columns.Add(column);
							}
						}
					}
				}
			}

			return config;
		}

		public static void FillDataGrid<T>(this DataGridView grid, List<string> config, List<T> data)
		{
			if (data != null)
			{
				foreach (var elem in data)
				{
					var objs = new List<object>();
					foreach (var conf in config)
					{
						var value = elem.GetType().GetProperty(conf).GetValue(elem);

						objs.Add(value);
					}

					grid.Rows.Add(objs.ToArray());
				}
			}
		}
	}
}