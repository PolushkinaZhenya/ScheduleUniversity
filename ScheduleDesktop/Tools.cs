using ScheduleBusinessLogic.Attributes;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public static class Tools
	{
		public static DataGridView CreateDataGridView(string key)
		{
			var dataGridView = new DataGridView
			{
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				AllowUserToOrderColumns = true,
				AllowUserToResizeColumns = false,
				AllowUserToResizeRows = false,
				BackgroundColor = SystemColors.Window,
				Dock = DockStyle.Fill,
				ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
				Name = $"dataGridView{key}",
				MultiSelect = false,
				ReadOnly = true,
				RowHeadersVisible = false,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				Size = new Size(100, 300),
				TabIndex = 0
			};
			dataGridView.RowTemplate.Height = 24;
			return dataGridView;
		}

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
								ReadOnly = columnAttr.ReadOnly,
								HeaderText = columnAttr.Title,
								Visible = columnAttr.Visible,
								Width = columnAttr.Width
							};
							if (columnAttr.GridViewAutoSize != GridViewAutoSize.None)
							{
								column.AutoSizeMode = (DataGridViewAutoSizeColumnMode)Enum.Parse(typeof(DataGridViewAutoSizeColumnMode), columnAttr.GridViewAutoSize.ToString());
							}
							if (columnAttr.Format.IsNotEmpty())
							{
								column.DefaultCellStyle.Format = columnAttr.Format;
							}
							if ((attr as ColumnAttribute).Title == "Id")
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
			if (grid == null || data == null)
			{
				return;
			}
			grid.Rows.Clear();

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

		public static bool IsNotEmpty(this string str) => !string.IsNullOrEmpty(str);

		public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);


		/// <summary>
		/// Выставление свободной пары в расписание
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="serviceM"></param>
		/// <param name="scheduleId"></param>
		/// <param name="auditoriumId"></param>
		/// <param name="weekNumber"></param>
		/// <param name="setToFreeAuditorium"></param>
		/// <param name="forcedSet"></param>
		/// <param name="GetColumnName"></param>
		/// <param name="GetColumnTypeName"></param>
		/// <param name="LoadFreeLessons"></param>
		public static void SetLesson(DataGridViewCell cell, IMainService serviceM,
			ref Guid? scheduleId, ref Guid? auditoriumId, ref int? weekNumber, bool setToFreeAuditorium, bool forcedSet,
			Func<int, string> GetColumnName, Func<int, string> GetColumnTypeName, Action LoadFreeLessons)
		{
			if (!scheduleId.HasValue || !auditoriumId.HasValue || !weekNumber.HasValue)
			{
				return;
			}

			if (cell == null)
			{
				return;
			}

			var grid = cell.DataGridView;
			string columnName = GetColumnName(weekNumber.Value);
			string columnTypeName = GetColumnTypeName(weekNumber.Value);
			if (grid == null)
			{
				return;
			}

			var dow = (DayOfTheWeek)grid.Rows[cell.RowIndex].Cells[columnTypeName].Value;
			var classTimeId = new Guid(grid.Columns[cell.ColumnIndex].Name.Replace(columnName, ""));
			try
			{
				serviceM.SetLesson(new LessonBindingModel
				{
					ScheduleId = scheduleId.Value,
					ClassTimeId = classTimeId,
					DayOfTheWeek = dow,
					AuditoriumId = auditoriumId.Value,
					SetToFreeAuditorium = setToFreeAuditorium,
					ForcedSet = forcedSet
				});
				scheduleId = null;
				auditoriumId = null;
				weekNumber = null;
				LoadFreeLessons();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		/// <summary>
		/// Сброс пары
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="serviceS"></param>
		/// <param name="serviceM"></param>
		/// <param name="LoadLessons"></param>
		/// <param name="LoadFreeLessons"></param>
		public static void DropLesson(DataGridViewCell cell,
			IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel> serviceS, IMainService serviceM,
			Action<int> LoadLessons, Action LoadFreeLessons)
		{
			var tags = cell.Tag?.ToString()?.Split(',');
			if (tags == null || tags.Length == 0)
			{
				return;
			}
			foreach (var tag in tags)
			{
				try
				{
					var schedule = serviceS.GetElement(new ScheduleSearchModel { Id = new Guid(tag) });
					if (schedule == null)
					{
						continue;
					}
					if (Program.ShowQuestion($"Удалить пару{(schedule.SubgroupNumber.HasValue ? $" {schedule.SubgroupNumber} п/г" : string.Empty)}?") == DialogResult.Yes)
					{
						serviceM.DropLesson(new LessonBindingModel { ScheduleId = schedule.Id });
						LoadLessons(schedule.NumberWeeks);
						LoadFreeLessons();
					}
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка");
				}
			}
		}

		/// <summary>
		/// Выбор пары для перестановки
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="selectedScheduleToMoveId"></param>
		/// <param name="serviceS"></param>
		/// <param name="changeAuditorium"></param>
		public static void SelectLesson(DataGridViewCell cell, List<Guid> selectedScheduleToMoveId,
			IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel> serviceS, bool changeAuditorium = false)
		{
			if (selectedScheduleToMoveId is null)
			{
				selectedScheduleToMoveId = new();
			}
			else if (selectedScheduleToMoveId.Count > 0)
			{
				return;
			}
			var tags = cell.Tag?.ToString()?.Split(',');
			if (tags == null || tags.Length == 0)
			{
				return;
			}
			foreach (var tag in tags)
			{
				try
				{
					var schedule = serviceS.GetElement(new ScheduleSearchModel { Id = new Guid(tag) });
					if (schedule == null)
					{
						continue;
					}
					if (changeAuditorium ||
						Program.ShowQuestion($"Выбарть пару{(schedule.SubgroupNumber.HasValue ? $" {schedule.SubgroupNumber} п/г" : string.Empty)} для переноса?") == DialogResult.Yes)
					{
						selectedScheduleToMoveId.Add(schedule.Id);
						cell.Style.BackColor = Color.Gray;
					}
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка");
				}
			}
		}

		/// <summary>
		/// Перестановка пары
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="selectedScheduleToMoveId"></param>
		/// <param name="serviceS"></param>
		/// <param name="serviceM"></param>
		/// <param name="GetColumnName"></param>
		/// <param name="GetColumnTypeName"></param>
		/// <param name="LoadLessons"></param>
		public static void MoveLesson(DataGridViewCell cell, List<Guid> selectedScheduleToMoveId, 
			IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel> serviceS, IMainService serviceM, 
			Func<int, string> GetColumnName, Func<int, string> GetColumnTypeName, Action<int> LoadLessons,
			Guid? moveFromAuditoriumId = null, Guid? moveToAuditoriumId = null)
		{
			if (selectedScheduleToMoveId is null || selectedScheduleToMoveId.Count == 0)
			{
				return;
			}
			if (cell == null)
			{
				return;
			}
			try
			{
				// если на устанавливаемую пару уже стоят занятия, то их сносим
				var exsistLessons = new List<(Guid ScheduleId, Guid AuditoriumId)>();
				if (cell.Tag != null)
				{
					var tags = cell.Tag?.ToString()?.Split(',');
					if (tags != null)
					{
						foreach (var tag in tags)
						{
							var lesson = serviceS.GetElement(new ScheduleSearchModel { Id = new Guid(tag) });
							exsistLessons.Add((new Guid(tag), lesson.AuditoriumId.Value));
							serviceM.DropLesson(new LessonBindingModel { ScheduleId = lesson.Id });
						}
					}
				}

				var grid = cell.DataGridView;
				if (grid == null)
				{
					return;
				}

				int week = 0;
				Guid? classTimeId = null;
				DayOfTheWeek? dow = null;
				Guid? flowId = null;
				// запоминаем, где стоит переносимое занятие, чтобы в случае чего на его место поставить занятия, стоявшее на этой паре
				Guid? lessonClassTimeId = null;
				DayOfTheWeek? lessonDow = null;

				foreach (var id in selectedScheduleToMoveId)
				{
					var schedule = serviceS.GetElement(new ScheduleSearchModel { Id = id });
					if (week == 0)
					{
						week = schedule.NumberWeeks;
						dow = (DayOfTheWeek)grid.Rows[cell.RowIndex].Cells[GetColumnTypeName(week)].Value;
						classTimeId = new Guid(grid.Columns[cell.ColumnIndex].Name.Replace(GetColumnName(week), ""));

						lessonClassTimeId = schedule.ClassTimeId;
						lessonDow = schedule.DayOfTheWeek;
					}
					if (flowId.HasValue && schedule.FlowId == flowId)
					{
						// поточное занятие было перенесено сразу для всех
						continue;
					}
					else if (schedule.FlowId.HasValue && flowId != schedule.FlowId)
					{
						flowId = schedule.FlowId;
					}

					
					serviceM.MoveLesson(new LessonBindingModel
					{
						ScheduleId = id,
						ClassTimeId = classTimeId.Value,
						DayOfTheWeek = dow.Value,
						AuditoriumId = moveToAuditoriumId ?? schedule.AuditoriumId.Value,
						ForcedSet = false,
						SetToFreeAuditorium = false
					});
				}
				selectedScheduleToMoveId.Clear();
				flowId = null;
				foreach(var (ScheduleId, AuditoriumId) in exsistLessons)
				{
					var lesson = serviceS.GetElement(new ScheduleSearchModel { Id = ScheduleId });
					if (flowId.HasValue && lesson.FlowId == flowId)
					{
						// поточное занятие было выставлено сразу для всех
						continue;
					}
					else if (lesson.FlowId.HasValue && flowId != lesson.FlowId)
					{
						flowId = lesson.FlowId;
					}
					serviceM.SetLesson(new LessonBindingModel
					{
						ScheduleId = ScheduleId,
						ClassTimeId = lessonClassTimeId.Value,
						DayOfTheWeek = lessonDow.Value,
						AuditoriumId = moveFromAuditoriumId ?? AuditoriumId,
						ForcedSet = false,
						SetToFreeAuditorium = true
					});
				}
				LoadLessons(week);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}
	}
}