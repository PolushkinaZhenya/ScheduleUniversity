using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlHourOfSemesters : UserControl
	{
		private readonly Guid _semesterId;

		private readonly Guid _periodId;

		private readonly IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel> _service;

		public UserControlHourOfSemesters()
		{
			InitializeComponent();
			_service = DependencyManager.Instance.Resolve<IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel>>();
			var period = DependencyManager.Instance.Resolve<IMainService>().GetPeriod(new Guid(Program.ReadAppSettingConfig(Program.CurrentPeriod)));
			_periodId = period.Id;
			_semesterId = period.SemesterId;
		}

		public void LoadData(Guid studyGroupId, Guid typeOfClassId)
		{
			var hours = _service.GetList(new HourOfSemesterSearchModel
			{
				StudyGroupId = studyGroupId,
				TypeOfClassId = typeOfClassId,
				SemesterId = _semesterId
			});


			var grid = CreateDataGrid();

			foreach (var elem in hours)
			{
				foreach (var rec in elem.HourOfSemesterRecords.Where(x => x.TypeOfClassId == typeOfClassId))
				{
					grid.Rows.Add(new object[] { 
						elem.Id, 
						elem.DisciplineTitle, 
						rec.TeacherShortName, 
						rec.Flows, 
						rec.TotalHours,
						rec.HourOfSemesterPeriods.Where(x => x.PeriodId == _periodId).Sum(x => x.HoursFirstWeek),
						rec.HourOfSemesterPeriods.Where(x => x.PeriodId == _periodId).Sum(x => x.HoursSecondWeek),
						string.Join(",", rec.HourOfSemesterAuditoriums.Select(x => x.AuditoriumTitle))
					});
				}
			}

			Controls.Clear();
			Controls.Add(grid);
		}

		private static DataGridView CreateDataGrid()
		{
			var grid = new DataGridView
			{
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				AllowUserToResizeColumns = false,
				AllowUserToResizeRows = false,
				Dock = DockStyle.Fill,
				BackgroundColor = SystemColors.Window,
				ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
				Location = new Point(3, 3),
				Name = "dataGridView",
				RowHeadersVisible = false,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				Size = new Size(869, 232),
				TabIndex = 0
			};
			grid.RowTemplate.Height = 24;

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Id",
				Name = "Id",
				CellTemplate = new DataGridViewTextBoxCell(),
				Visible = false
			});
			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Дисциплина",
				Name = "Discipline",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 400,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Преподаватель",
				Name = "Teacher",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 300,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewComboBoxColumn
			{
				HeaderText = "Поток",
				Name = "Flow",
				CellTemplate = new DataGridViewComboBoxCell(),
				ReadOnly = false,
				Width = 120
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Всего часов",
				Name = "NumderOfHours",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 80,
				ReadOnly = true
			});

			for (int i = 0; i < 2; i++)
			{
				grid.Columns.Add(new DataGridViewColumn
				{
					HeaderText = $"Кол-во пар на {i + 1}-й недели",
					Name = (i + 1).ToString(),
					CellTemplate = new DataGridViewTextBoxCell(),
					Width = 60,
					ReadOnly = true
				});
			}

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Аудитории",
				Name = "Auditoriums",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 300,
				ReadOnly = true
			});

			return grid;
		}
	}
}