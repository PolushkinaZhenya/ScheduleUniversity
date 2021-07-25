using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlScheduleStudentGroup : UserControl
	{
		private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _serviceA;

		private readonly IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel> _serviceCT;

		private readonly IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel> _serviceS;

		private readonly IMainService _serviceM;

		private readonly Guid? _periodId;

		private Guid? _studyGroupId;

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

		private int? _weekNumber;

		private Guid? _scheduleId;

		private Guid? _auditoriumId;

		private bool _loadingAuditoriums;

		public void SetStudyGroupId(Guid studyGroupId) => _studyGroupId = studyGroupId;

		public UserControlScheduleStudentGroup()
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
		}

		private void UserControlScheduleStudentGroup_Load(object sender, EventArgs e)
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

		private void LoadFreeLessons()
		{
			if (!_studyGroupId.HasValue || !_periodId.HasValue)
			{
				return;
			}
			var list = _serviceS.GetList(new ScheduleSearchModel { StudyGroupId = _studyGroupId, PeriodId = _periodId, IsFree = true });
			if (list.Count == 0)
			{
				splitContainerMain.Panel2Collapsed = true;
			}
			else
			{
				dataGridViewFreeLessons.FillDataGrid(_config, list);
			}
		}

		/// <summary>
		/// Загрузка расписания на неделю
		/// </summary>
		/// <param name="week"></param>
		private void LoadLessons(int week)
		{
			if (!_periodId.HasValue || !_studyGroupId.HasValue)
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
				var list = _serviceS.GetList(new ScheduleSearchModel { StudyGroupId = _studyGroupId, PeriodId = _periodId, NumberWeeks = week, IsFree = false });

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
			$"{model.DisciplineTitle} {model.TeacherShortName} {model.AuditoriumNumber}";

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
			if (!_loadingAuditoriums || !PlacementMode)
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
							if (view.StudyGroupSubGroupLoads != null)
							{
								var rec = view.StudyGroupSubGroupLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.GroupBisy;
									row.Cells[i].ReadOnly = isRead;
									continue;
								}
							}
							if (view.TeachersLoads != null)
							{
								var rec = view.TeachersLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.TeacherBisy;
									row.Cells[i].ReadOnly = isRead;
									continue;
								}
							}
							if (view.AuditoriumLoads != null)
							{
								var rec = view.AuditoriumLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.AuditoriumBisy;
									row.Cells[i].ReadOnly = isRead? isRead : !checkBoxSetToFreeAuditorium.Checked;
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
				SetLesson(grid?.SelectedCells[0]);
			}
		}

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			if (grid?.SelectedCells?.Count != 1 || grid.SelectedCells[0].ReadOnly)
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
						SetLesson(grid?.SelectedCells[0]);
					}
					break;
				case Keys.Enter:
					if (cell.Tag == null)
					{
						return;
					}
					break;
				case Keys.Delete:
					break;
			}
		}

		/// <summary>
		/// Выставление свободной пары в расписание
		/// </summary>
		/// <param name="cell"></param>
		private void SetLesson(DataGridViewCell cell)
		{
			if (!_scheduleId.HasValue || !_auditoriumId.HasValue || !_weekNumber.HasValue || !PlacementMode)
			{
				return;
			}

			if (cell == null)
			{
				return;
			}

			var grid = cell.DataGridView;
			string columnName = GetColumnNameForClassTimeColumn(_weekNumber.Value);
			string columnTypeName = GetColumnNameForDayOfWeekColumn(_weekNumber.Value);
			if (grid == null)
			{
				return;
			}

			var dow = (DayOfTheWeek)grid.Rows[cell.RowIndex].Cells[columnTypeName].Value;
			var classTimeId = new Guid(grid.Columns[cell.ColumnIndex].Name.Replace(columnName, ""));
			try
			{
				_serviceM.SetLesson(new LessonBindingModel
				{
					ScheduleId = _scheduleId.Value,
					ClassTimeId = classTimeId,
					DayOfTheWeek = dow,
					AuditoriumId = _auditoriumId.Value,
					SetToFreeAuditorium = checkBoxSetToFreeAuditorium.Checked,
					ForcedSet = checkBoxForcedSet.Checked
				});
				_scheduleId = null;
				_auditoriumId = null;
				_weekNumber = null;
				LoadFreeLessons();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}
	}
}