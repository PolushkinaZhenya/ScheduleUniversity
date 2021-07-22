using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlScheduleStudentGroup : UserControl
	{
		private readonly IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel> _serviceCT;

		private readonly IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel> _serviceS;

		private readonly IMainService _serviceM;

		private Guid _periodId;

		private Guid _studyGroupId;

		private int setLesson;

		public UserControlScheduleStudentGroup()
		{
			InitializeComponent();
			_serviceCT = DependencyManager.Instance.Resolve<IBaseService<ClassTimeBindingModel, ClassTimeViewModel, ClassTimeSearchModel>>();
			_serviceS = DependencyManager.Instance.Resolve<IBaseService<ScheduleBindingModel, ScheduleViewModel, ScheduleSearchModel>>();
			_serviceM = DependencyManager.Instance.Resolve<IMainService>();

			var periodId = Program.ReadAppSettingConfig(Program.CurrentPeriod);

			if (periodId.IsNotEmpty())
			{
				_periodId = new Guid(periodId);
			}
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

			try
			{
				var list = _serviceS.GetList(new ScheduleSearchModel { StudyGroupId = _studyGroupId, PeriodId = _periodId, IsFree = true });
				if (list.Count == 0)
				{
					splitContainerMain.Panel2Collapsed = true;
				}
				else
				{
					dataGridViewFreeLessons.FillDataGrid(dataGridViewFreeLessons.ConfigDataGrid(typeof(ScheduleViewModel)), list);
				}
				var firstWeekLessons = _serviceS.GetList(new ScheduleSearchModel { StudyGroupId = _studyGroupId, PeriodId = _periodId, NumberWeeks = 1, IsFree = false });
				LoadLessons(dataGridViewFirstWeek, firstWeekLessons, 1);
				var secondWeekLessons = _serviceS.GetList(new ScheduleSearchModel { StudyGroupId = _studyGroupId, PeriodId = _periodId, NumberWeeks = 2, IsFree = false });
				LoadLessons(dataGridViewSecondWeek, secondWeekLessons, 2);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка при загрузке");
			}
		}

		private void DataGridView_Resize(object sender, EventArgs e)
		{
			var grid = (sender as DataGridView);
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

		public void LoadData(Guid studyGroupId)
		{
			_studyGroupId = studyGroupId;
		}

		private void ButtonSelect_Click(object sender, EventArgs e) => ViewLoads();

		private static void LoadLessons(DataGridView grid, List<ScheduleViewModel> list, int week)
		{
			string columnName = week == 1 ? "TypeOfClassFirst" : week == 2 ? "TypeOfClassSecond" : "";
			string columnTypeName = week == 1 ? "ColumnDayOfWeekFirst" : week == 2 ? "ColumnDayOfWeekSecond" : "";
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

		private static string GetValueFromScheduleViewModel(ScheduleViewModel model) => $"{model.DisciplineTitle}{Environment.NewLine}{model.TeacherShortName}{model.AuditoriumNumber}";

		private void DataGridViewFreeLessons_SelectionChanged(object sender, EventArgs e)
		{
			if (dataGridViewFreeLessons.SelectedRows.Count == 1)
			{
				try
				{
					dataGridViewAudiroriums.Rows.Clear();
					var recId = (Guid)dataGridViewFreeLessons.SelectedRows[0].Cells["Id"].Value;
					var auds = _serviceM.GetAuditoriumsByScheduleRecord(new AuditoriumsByScheduleRecordBindingModel { ScheduleId = recId });
					foreach (var (Id, Number) in auds.Auditoriums)
					{
						dataGridViewAudiroriums.Rows.Add(new object[] { Id, Number });
					}
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка");
				}
			}
		}

		private void ViewLoads()
		{
			if (dataGridViewFreeLessons.SelectedRows.Count == 1)
			{
				try
				{
					var recId = (Guid)dataGridViewFreeLessons.SelectedRows[0].Cells["Id"].Value;
					var audId = dataGridViewAudiroriums.SelectedRows.Count > 0 ?
						(Guid)dataGridViewAudiroriums.SelectedRows[0].Cells["ColumnAuditoriumId"].Value :
						(Guid)dataGridViewAudiroriums.Rows[0].Cells["ColumnAuditoriumId"].Value;
					var view = _serviceM.GetScheduleRecordsForLoad(new ScheduleRecordsForLoadBindingModel { ScheduleId = recId, AuditoriumId = audId });

					var grid = view.NumberWeek == 1 ? dataGridViewFirstWeek : view.NumberWeek == 2 ? dataGridViewSecondWeek : null;
					setLesson = view.NumberWeek;
					string columnName = view.NumberWeek == 1 ? "TypeOfClassFirst" : view.NumberWeek == 2 ? "TypeOfClassSecond" : "";
					string columnTypeName = view.NumberWeek == 1 ? "ColumnDayOfWeekFirst" : view.NumberWeek == 2 ? "ColumnDayOfWeekSecond" : "";
					if (grid == null)
					{
						return;
					}

					foreach (DataGridViewRow row in grid.Rows)
					{
						for (int i = 1; i < grid.ColumnCount; ++i)
						{
							var dow = (DayOfTheWeek)row.Cells[columnTypeName].Value;
							var classTimeId = new Guid(grid.Columns[i].Name.Replace(columnName, ""));
							if (view.StudyGroupSubGroupLoads != null)
							{
								var rec = view.StudyGroupSubGroupLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.GroupBisy;
									continue;
								}
							}
							if (view.TeachersLoads != null)
							{
								var rec = view.TeachersLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.TeacherBisy;
									continue;
								}
							}
							if (view.AuditoriumLoads != null)
							{
								var rec = view.AuditoriumLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.AuditoriumBisy;
									continue;
								}
							}
							if (view.FlowLoads != null)
							{
								var rec = view.FlowLoads.FirstOrDefault(x => x.DayOfTheWeek == dow && x.ClassTimeId == classTimeId);
								if (rec != null)
								{
									row.Cells[i].Style.BackColor = ColorSettings.FlowBisy;
									continue;
								}
							}
							row.Cells[i].Style.BackColor = ColorSettings.Allow;
						}
					}
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка");
				}
			}
		}

		private void DataGridViewFirstWeek_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewFreeLessons.SelectedRows.Count == 1)
			{
				var recId = (Guid)dataGridViewFreeLessons.SelectedRows[0].Cells["Id"].Value;
				if (setLesson == 1)
				{
					if (dataGridViewFirstWeek.SelectedCells.Count != 1)
					{
						return;
					}
					var cell = dataGridViewFirstWeek.SelectedCells[0];

					var dow = (DayOfTheWeek)dataGridViewFirstWeek.Rows[cell.RowIndex].Cells["ColumnDayOfWeekFirst"].Value;
					var classTimeId = new Guid(dataGridViewFirstWeek.Columns[cell.ColumnIndex].Name.Replace("TypeOfClassFirst", ""));
					_serviceM.SetLesson(new LessonBindingModel { ScheduleId = recId, ClassTimeId = classTimeId, DayOfTheWeek = dow });

					var firstWeekLessons = _serviceS.GetList(new ScheduleSearchModel { StudyGroupId = _studyGroupId, PeriodId = _periodId, NumberWeeks = 1, IsFree = false });
					LoadLessons(dataGridViewFirstWeek, firstWeekLessons, 1);

					setLesson = 0;
				}
			}
		}
	}
}