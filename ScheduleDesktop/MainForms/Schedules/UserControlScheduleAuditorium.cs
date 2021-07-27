using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlScheduleAuditorium : UserControl
	{
		private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _serviceA;

		private readonly IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel> _serviceCT;

		private readonly IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel> _serviceS;

		private readonly IMainService _serviceM;

		private readonly UserControlScheduleAuditoriums _mainControl;

		private readonly Guid? _periodId;

		private Guid? _auditoriumId;

		public void SetAuditoriumId(Guid auditoriumId) => _auditoriumId = auditoriumId;

		public UserControlScheduleAuditorium(UserControlScheduleAuditoriums mainControl)
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
			_mainControl = mainControl;
		}

		private void UserControlScheduleAuditorium_Load(object sender, EventArgs e)
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
				LoadLessons(1);
				LoadLessons(2);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка при загрузке");
			}
		}

		/// <summary>
		/// Загрузка расписания на неделю
		/// </summary>
		/// <param name="week"></param>
		private void LoadLessons(int week)
		{
			if (!_periodId.HasValue || !_auditoriumId.HasValue)
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
				var list = _serviceS.GetList(new ScheduleSearchModel { AuditoriumId = _auditoriumId, PeriodId = _periodId, NumberWeeks = week, IsFree = false });

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
			$"{model.TypeOfClassShort}. {model.DisciplineTitle} {model.StudyGroupTitle}{(model.SubgroupNumber.HasValue ? $" {model.SubgroupNumber}п/г" : string.Empty)} {model.TeacherShortName}";

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
					if (_mainControl.SelectedSchedulesToMove.Count > 0 && (_mainControl?.MoveFromAuditoriumId ?? null) != null)
					{
						Tools.MoveLesson(cell, _mainControl.SelectedSchedulesToMove, _serviceS, _serviceM, GetColumnNameForClassTimeColumn,
							GetColumnNameForDayOfWeekColumn, LoadLessons, _mainControl.MoveFromAuditoriumId, _auditoriumId);
						_mainControl.MoveFromAuditoriumId = null;
					}
					else
					{
						Tools.SelectLesson(cell, _mainControl.SelectedSchedulesToMove, _serviceS, true);
						_mainControl.MoveFromAuditoriumId = _auditoriumId;
					}
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