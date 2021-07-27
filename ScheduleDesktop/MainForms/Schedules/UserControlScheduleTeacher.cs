using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlScheduleTeacher : UserControl
	{
		private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _serviceA;

		private readonly IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel> _serviceCT;

		private readonly IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel> _serviceS;

		private readonly IMainService _serviceM;

		private readonly Guid? _periodId;

		private Guid? _teacherId;

		private readonly List<string> _config;

		private bool _placementMode;

		private bool PlacementMode
		{
			get => _placementMode;
			set
			{
				_placementMode = value;
				dataGridViewFreeLessons.Enabled = panelAuditoriums.Enabled = _placementMode;
			}
		}

		private readonly List<Guid> _selectedScheduleToMoveId;

		private int? _weekNumber;

		private Guid? _scheduleId;

		private Guid? _auditoriumId;

		private bool _loadingAuditoriums;

		public void SetTeacherId(Guid teacherId) => _teacherId = teacherId;

		public UserControlScheduleTeacher()
		{
			InitializeComponent();
			_serviceA = DependencyManager.Instance.Resolve<IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>>();
			_serviceCT = DependencyManager.Instance.Resolve<IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel>>();
			_serviceS = DependencyManager.Instance.Resolve<IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel>>();
			_serviceM = DependencyManager.Instance.Resolve<IMainService>();

			var periodId = Program.ReadAppSettingConfig(Program.CurrentPeriod);

			if (periodId.IsNotEmpty())
			{
				_periodId = new Guid(periodId);
			}
			PlacementMode = false;
			_config = dataGridViewFreeLessons.ConfigDataGrid(typeof(ScheduleViewModel));
			_selectedScheduleToMoveId = new();
		}

		private void UserControlScheduleTeacher_Load(object sender, EventArgs e)
		{
			var times = _serviceCT.GetList();
			foreach (var time in times)
			{
				dataGridViewFirstWeek.Columns.Add(new DataGridViewColumn
				{
					HeaderText = $"Пара {time.Number} {time.StartTime:hh\\:mm}-{time.EndTime:hh\\:mm}",
					Name = $"TypeOfClassFirst{time.Id}",
					CellTemplate = new DataGridViewTextBoxCell(),
					AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
					ReadOnly = true
				});
				dataGridViewSecondWeek.Columns.Add(new DataGridViewColumn
				{
					HeaderText = $"Пара {time.Number} {time.StartTime:hh\\:mm}-{time.EndTime:hh\\:mm}",
					Name = $"TypeOfClassSecond{time.Id}",
					CellTemplate = new DataGridViewTextBoxCell(),
					AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
					ReadOnly = true
				});
			}

			LoadSchedule();
		}

		/// <summary>
		/// Загрузка нераспределенных пар и расписания
		/// </summary>
		private void LoadSchedule()
		{
			try
			{
				LoadFreeLessons();
				LoadLessons(1);
				LoadLessons(2);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка при загрузке");
			}
		}

		/// <summary>
		/// Подгрузка нераспределенных занятий
		/// </summary>
		private void LoadFreeLessons()
		{
			if (!_teacherId.HasValue || !_periodId.HasValue)
			{
				return;
			}
			var list = _serviceS.GetList(new ScheduleSearchModel { TeacherId = _teacherId, PeriodId = _periodId, IsFree = true });
			if (list.Count == 0)
			{
				splitContainerMain.Panel2Collapsed = true;
				PlacementMode = false;
				LoadLessons(1);
				LoadLessons(2);
			}
			else
			{
				splitContainerMain.Panel2Collapsed = false;
				dataGridViewFreeLessons.FillDataGrid(_config, list);
			}
		}

		/// <summary>
		/// Загрузка расписания на неделю
		/// </summary>
		/// <param name="week"></param>
		private void LoadLessons(int week)
		{
			if (!_periodId.HasValue || !_teacherId.HasValue)
			{
				return;
			}
			var grid = GetDataGridView(week);
			string columnName = GetColumnNameForClassTimeColumn(week);
			string columnTypeName = GetColumnNameForDayOfWeekColumn(week);
			if (grid == null)
			{
				return;
			}
			grid.Rows.Clear();
			foreach (var dow in Enum.GetValues(typeof(DayOfTheWeek)))
			{
				grid.Rows.Add();
				grid.Rows[^1].Cells[columnTypeName].Value = dow;
			}
			try
			{
				var list = _serviceS.GetList(new ScheduleSearchModel { TeacherId = _teacherId, PeriodId = _periodId, NumberWeeks = week, IsFree = false });

				if (list == null)
				{
					return;
				}
				foreach (var rec in list)
				{
					if (!rec.DayOfTheWeek.HasValue || !rec.ClassTimeId.HasValue)
					{
						continue;
					}
					int rowIndex = (int)rec.DayOfTheWeek.Value;
					var timeId = rec.ClassTimeId.Value;
					if (grid.Rows[rowIndex - 1].Cells[$"{columnName}{timeId}"].Value == null)
					{
						grid.Rows[rowIndex - 1].Cells[$"{columnName}{timeId}"].Value = GetValueFromScheduleViewModel(rec);
						grid.Rows[rowIndex - 1].Cells[$"{columnName}{timeId}"].Tag = rec.Id;
					}
					else
					{
						grid.Rows[rowIndex - 1].Cells[$"{columnName}{timeId}"].Value += $"{Environment.NewLine}{GetValueFromScheduleViewModel(rec)}";
						grid.Rows[rowIndex - 1].Cells[$"{columnName}{timeId}"].Tag += $",{rec.Id}";
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка при получении записей расписания");
			}
			ResizeDataGridViewRows(grid);
		}

		private void DataGridView_Resize(object sender, EventArgs e) => ResizeDataGridViewRows(sender as DataGridView);

		/// <summary>
		/// Равномерное выставление высоты строк грида
		/// </summary>
		/// <param name="grid"></param>
		private static void ResizeDataGridViewRows(DataGridView grid)
		{
			if (grid == null || grid.Rows.Count == 0)
			{
				return;
			}
			var height = (grid.Height - grid.ColumnHeadersHeight) / grid.Rows.Count;
			foreach (DataGridViewRow row in grid.Rows)
			{
				row.Height = height;
			}
		}

		/// <summary>
		/// Перевод в режим расстановки занятий
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSelect_Click(object sender, EventArgs e)
		{
			PlacementMode = !PlacementMode;
			if (PlacementMode)
			{
				// пытаемся получить аудиторию для расстановки пары
				var audId = GetAudIdFromDataGridViewAudiroriums();
				if (audId.HasValue)
				{
					ViewLoads(audId.Value);
					return;
				}
				// иначе может быть не выбрана ни одна запсиь с таблицы свободных пар, тогда подгружаем одну из них
				if (dataGridViewFreeLessons.Rows.Count > 0)
				{
					if (dataGridViewFreeLessons.SelectedRows.Count == 1)
					{
						LoadAuditoriums(dataGridViewFreeLessons.SelectedRows[0]);
					}
					else
					{
						LoadAuditoriums(dataGridViewFreeLessons.Rows[0]);
					}
				}
			}
			else
			{
				LoadSchedule();
			}
		}

		/// <summary>
		/// Определение с каким гридом работать, в зависимости от недели
		/// </summary>
		/// <param name="week"></param>
		/// <returns></returns>
		private DataGridView GetDataGridView(int week)
		{
			return week == 1 ? dataGridViewFirstWeek : week == 2 ? dataGridViewSecondWeek : null;
		}

		/// <summary>
		///  Определение названия колонки грида, в зависимости от недели
		/// </summary>
		/// <param name="week"></param>
		/// <returns></returns>
		private static string GetColumnNameForClassTimeColumn(int week)
		{
			return week == 1 ? "TypeOfClassFirst" : week == 2 ? "TypeOfClassSecond" : "";
		}

		/// <summary>
		/// Определение названия колонки грида с днем недели, в зависимости от недели
		/// </summary>
		/// <param name="week"></param>
		/// <returns></returns>
		private static string GetColumnNameForDayOfWeekColumn(int week)
		{
			return week == 1 ? "ColumnDayOfWeekFirst" : week == 2 ? "ColumnDayOfWeekSecond" : "";
		}

		/// <summary>
		/// Формирование выводимой записи занятия в ячейке грида
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private static string GetValueFromScheduleViewModel(ScheduleViewModel model) =>
			$"{model.TypeOfClassShort}. {model.DisciplineTitle} {model.StudyGroupTitle}{(model.SubgroupNumber.HasValue ? $" {model.SubgroupNumber}п/г" : string.Empty)} {model.AuditoriumNumber}";

		/// <summary>
		/// Смена выбранной записи нераспределенных занятий
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataGridViewFreeLessons_SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridViewFreeLessons.SelectedRows.Count == 1)
			{
				LoadAuditoriums(dataGridViewFreeLessons.SelectedRows[0]);
			}
		}

		/// <summary>
		/// Подгрузка списка аудиторий, указанных в расчасовке по выставляемой записи расписания
		/// </summary>
		/// <param name="row"></param>
		private void LoadAuditoriums(DataGridViewRow row)
		{
			if (row == null)
			{
				return;
			}
			_loadingAuditoriums = true;
			try
			{
				// для выбранной записи заполнем список аудиторий, куда ставить занятие
				dataGridViewAudiroriums.Rows.Clear();
				textBoxAuditorium.Text = string.Empty;
				var recId = (Guid)dataGridViewFreeLessons.SelectedRows[0].Cells["Id"].Value;
				var auds = _serviceM.GetAuditoriumsByScheduleRecord(new AuditoriumsByScheduleRecordBindingModel { ScheduleId = recId });
				foreach (var (Id, Number) in auds.Auditoriums)
				{
					dataGridViewAudiroriums.Rows.Add(new object[] { Id, Number });
				}
				var audId = GetAudIdFromDataGridViewAudiroriums();
				if (audId.HasValue)
				{
					ViewLoads(audId.Value);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
			_loadingAuditoriums = false;
		}

		/// <summary>
		/// Получение идентификатора выбранной аудитории из списка
		/// </summary>
		/// <returns></returns>
		private Guid? GetAudIdFromDataGridViewAudiroriums()
		{
			Guid? audId = null;
			if (dataGridViewAudiroriums.SelectedRows.Count == 1)
			{
				audId = (Guid)dataGridViewAudiroriums.SelectedRows[0].Cells["ColumnAuditoriumId"].Value;
			}
			else if (dataGridViewAudiroriums.Rows.Count > 0)
			{
				audId = (Guid)dataGridViewAudiroriums.Rows[0].Cells["ColumnAuditoriumId"].Value;
			}
			return audId;
		}

		/// <summary>
		/// Смена выбора аудитории из списка
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataGridViewAudiroriums_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (_loadingAuditoriums || !PlacementMode)
			{
				return;
			}
			var audId = GetAudIdFromDataGridViewAudiroriums();
			if (audId.HasValue)
			{
				ViewLoads(audId.Value);
			}
		}

		/// <summary>
		/// Ввод номера аудитори вручную для установки пары
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBoxAuditorium_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && textBoxAuditorium.Text.IsNotEmpty())
			{
				try
				{
					var aud = _serviceA.GetElement(new AuditoriumSearchModel { Number = textBoxAuditorium.Text });
					if (aud == null)
					{
						Program.ShowError("Не найдена аудитория с таким номером", "Ошибка");
						return;
					}
					ViewLoads(aud.Id);
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка получения аудитории");
				}
			}
		}

		/// <summary>
		/// Выбор занятия для установки в расписание
		/// </summary>
		private void ViewLoads(Guid audId)
		{
			if (!PlacementMode)
			{
				return;
			}
			dataGridViewFirstWeek.Rows.Clear();
			dataGridViewSecondWeek.Rows.Clear();

			bool isRead = !checkBoxForcedSet.Checked;

			if (dataGridViewFreeLessons.SelectedRows.Count == 1)
			{
				try
				{
					_auditoriumId = audId;
					_scheduleId = (Guid)dataGridViewFreeLessons.SelectedRows[0].Cells["Id"].Value;
					var view = _serviceM.GetScheduleRecordsForLoad(new ScheduleRecordsForLoadBindingModel
					{
						ScheduleId = _scheduleId.Value,
						AuditoriumId = _auditoriumId.Value
					});

					_weekNumber = view.NumberWeek;
					var grid = GetDataGridView(view.NumberWeek);
					if (grid == null)
					{
						return;
					}
					string columnName = GetColumnNameForClassTimeColumn(view.NumberWeek);
					string columnTypeName = GetColumnNameForDayOfWeekColumn(view.NumberWeek);
					foreach (DayOfTheWeek dow in Enum.GetValues(typeof(DayOfTheWeek)))
					{
						grid.Rows.Add();
						var row = grid.Rows[^1];
						row.Cells[columnTypeName].Value = dow;
						for (int i = 1; i < grid.ColumnCount; ++i)
						{
							var classTimeId = new Guid(grid.Columns[i].Name.Replace(columnName, ""));
							if (view.TeachersLoads != null)
							{
								var rec = view.TeachersLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.TeacherBisy;
									row.Cells[i].ReadOnly = isRead;
									row.Cells[i].Value = GetValueFromScheduleViewModel(rec);
									continue;
								}
							}
							if (view.StudyGroupSubGroupLoads != null)
							{
								var rec = view.StudyGroupSubGroupLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.GroupBisy;
									row.Cells[i].ReadOnly = isRead;
									row.Cells[i].Value = GetValueFromScheduleViewModel(rec);
									continue;
								}
							}
							if (view.FlowLoads != null)
							{
								var rec = view.FlowLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.FlowBisy;
									row.Cells[i].ReadOnly = isRead;
									row.Cells[i].Value = GetValueFromScheduleViewModel(rec);
									continue;
								}
							}
							if (view.AuditoriumLoads != null)
							{
								var rec = view.AuditoriumLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.AuditoriumBisy;
									row.Cells[i].ReadOnly = isRead ? isRead : !checkBoxSetToFreeAuditorium.Checked;
									row.Cells[i].Value = GetValueFromScheduleViewModel(rec);
									continue;
								}
							}
							row.Cells[i].Style.BackColor = ColorSettings.Allow;
							row.Cells[i].ReadOnly = false;
						}
					}
					ResizeDataGridViewRows(grid);
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка");
				}
			}
		}

		private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var grid = sender as DataGridView;
			if (grid?.SelectedCells?.Count != 1)
			{
				return;
			}
			if (PlacementMode)
			{
				Tools.SetLesson(grid?.SelectedCells[0], _serviceM, ref _scheduleId, ref _auditoriumId, ref _weekNumber, checkBoxSetToFreeAuditorium.Checked,
					checkBoxForcedSet.Checked, GetColumnNameForClassTimeColumn, GetColumnNameForDayOfWeekColumn, LoadFreeLessons);
			}
		}

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			if (grid?.SelectedCells?.Count != 1)
			{
				return;
			}
			var cell = grid?.SelectedCells[0];
			if (cell == null)
			{
				return;
			}
			switch (e.KeyCode)
			{
				case Keys.Space:
					if (PlacementMode)
					{
						Tools.SetLesson(cell, _serviceM, ref _scheduleId, ref _auditoriumId, ref _weekNumber, checkBoxSetToFreeAuditorium.Checked,
							checkBoxForcedSet.Checked, GetColumnNameForClassTimeColumn, GetColumnNameForDayOfWeekColumn, LoadFreeLessons);
					}
					if (_selectedScheduleToMoveId.Count > 0)
					{
						Tools.MoveLesson(cell, _selectedScheduleToMoveId, _serviceS, _serviceM, GetColumnNameForClassTimeColumn, 
							GetColumnNameForDayOfWeekColumn, LoadLessons);
					}
					else
					{
						Tools.SelectLesson(cell, _selectedScheduleToMoveId, _serviceS);
					}
					break;
				case Keys.Delete:
					Tools.DropLesson(cell, _serviceS, _serviceM, LoadLessons, LoadFreeLessons);
					break;
			}
		}

		private void DataGridViewFirstWeek_CellClick(object sender, DataGridViewCellEventArgs e) => LoadLessonsToPanel(panelFirstWeek, sender as DataGridView, e);

		private void DataGridViewSecondWeek_CellClick(object sender, DataGridViewCellEventArgs e) => LoadLessonsToPanel(panelSecondWeek, sender as DataGridView, e);

		private void LoadLessonsToPanel(Panel panel, DataGridView grid, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 1 || grid == null)
			{
				return;
			}
			if (PlacementMode)
			{
				return;
			}

			var tags = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag?.ToString()?.Split(',');
			if (tags == null || tags.Length == 0)
			{
				return;
			}

			panel.Controls.Clear();
			foreach (var tag in tags)
			{
				try
				{
					var schedule = _serviceS.GetElement(new ScheduleSearchModel { Id = new Guid(tag) });
					if (schedule == null)
					{
						continue;
					}
					var button = new Button
					{
						Dock = DockStyle.Left,
						Name = $"button{tag}",
						Size = new Size(250, 30),
						Text = GetValueFromScheduleViewModel(schedule),
						UseVisualStyleBackColor = true,
						Cursor = Cursors.Default
					};
					panel.Controls.Add(button);
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка");
				}
			}
		}
	}
}