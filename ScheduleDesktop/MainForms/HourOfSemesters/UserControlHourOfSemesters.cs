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

		private readonly IMainService _serviceM;

		private Guid _studyGroupId;

		private Guid _typeOfClassId;

		public UserControlHourOfSemesters()
		{
			InitializeComponent();
			_service = DependencyManager.Instance.Resolve<IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel>>();
			_serviceM = DependencyManager.Instance.Resolve<IMainService>();
			var period = _serviceM.GetPeriod(new Guid(Program.ReadAppSettingConfig(Program.CurrentPeriod)));
			_periodId = period.Id;
			_semesterId = period.SemesterId;
		}

		public void LoadData(Guid studyGroupId, Guid typeOfClassId)
		{
			_studyGroupId = studyGroupId;
			_typeOfClassId = typeOfClassId;
			var hours = _serviceM.GetHourOfSemestersPeriodRecords(new PeriodForHousOfSemesterBindingModel
			{
				StudyGroupId = studyGroupId,
				TypeOfClassId = typeOfClassId,
				PeriodId = _periodId
			});

			var grid = CreateDataGrid();

			foreach (var rec in hours.Where(x => x.HoursSecondWeek > 0 || x.HoursFirstWeek > 0))
			{
				grid.Rows.Add(new object[] {
						rec.HousOfSemesterId,
						rec.DisciplineTitle,
						rec.TeacherShortName,
						null,
						rec.SubgroupNumber?.ToString() ?? string.Empty,
						rec.TotalHours,
						rec.HourOfSemesterPeriodId,
						rec.HoursFirstWeek,
						rec.HoursSecondWeek,
						rec.Auditoriums
					});
				if (rec.Flows != null)
				{
					var dgvcbc = (DataGridViewComboBoxCell)grid.Rows[^1].Cells["Flow"];
					dgvcbc.Items.Clear();
					dgvcbc.Items.Add("Поток");
					foreach (object itemToAdd in rec.Flows)
					{
						dgvcbc.Items.Add(itemToAdd);
					}
					dgvcbc.Value = "Поток";
				}
			}

			Controls.Clear();
			Controls.Add(grid);
		}

		private DataGridView CreateDataGrid()
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
				HeaderText = "Подгр.",
				Name = "Subgroup",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 50,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Всего часов",
				Name = "NumderOfHours",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 80,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "HOSPeriodId",
				Name = "HOSPeriodId",
				CellTemplate = new DataGridViewTextBoxCell(),
				Visible = false
			});
			for (int i = 0; i < 2; i++)
			{
				grid.Columns.Add(new DataGridViewColumn
				{
					HeaderText = $"Кол-во пар на {i + 1}-й недели",
					Name = $"Week{(i + 1)}",
					CellTemplate = new DataGridViewTextBoxCell(),
					Width = 80,
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

			grid.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
			grid.KeyDown += DataGridView_KeyDown;

			return grid;
		}

		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			var grid = sender as DataGridView;
			if (grid.Rows[e.RowIndex].Cells["HOSPeriodId"].Value == null)
			{
				Program.ShowError("Для периода неизвестен идентификатор", "Ошибка");
				return;
			}
			if (e.ColumnIndex == grid.Columns["Week1"].Index || e.ColumnIndex == grid.Columns["Week2"].Index)
			{
				bool haveChanges = false;
				var firstVal = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value);
				var secondVal = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value);
				if (e.ColumnIndex == grid.Columns["Week1"].Index && secondVal > 0)
				{
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value = ++firstVal;
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value = --secondVal;
					haveChanges = true;
				}
				else if (e.ColumnIndex == grid.Columns["Week2"].Index && firstVal > 0)
				{
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value = --firstVal;
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value = ++secondVal;
					haveChanges = true;
				}
				if (haveChanges)
				{
					_serviceM.UpdateHours(new UpdateHoursBindingModel
					{
						HourOfSemesterPeriodId = (Guid)grid.Rows[e.RowIndex].Cells["HOSPeriodId"].Value,
						FirstWeekCountLessons = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value),
						SecondWeekCountLessons = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value)
					});
				}
			}
			else if (grid.Rows[e.RowIndex].Cells["Id"].Value != null)
			{
				var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
				form.StudyGroupId = _studyGroupId;
				form.Id = (Guid)grid.Rows[e.RowIndex].Cells["Id"].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData(_studyGroupId, _typeOfClassId);
				}
			}
		}

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					{
						var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
						form.StudyGroupId = _studyGroupId;
						form.FacultyId = new Guid(Parent.Parent.Parent.Parent.Parent.Parent.Parent.Name.Replace("tabPage", ""));
						if (form.ShowDialog() == DialogResult.OK)
						{
							LoadData(_studyGroupId, _typeOfClassId);
						}
					}
					break;
				case Keys.Enter: // изменить
					{
						var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
						form.StudyGroupId = _studyGroupId;
						form.Id = (Guid)grid.SelectedRows[0].Cells["Id"].Value;
						if (form.ShowDialog() == DialogResult.OK)
						{
							LoadData(_studyGroupId, _typeOfClassId);
						}
					}
					break;
				case Keys.Delete: // удалить
					if (grid?.SelectedRows.Count == 1)
					{
						var id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
						{
							try
							{
								_service.DelElement(new HourOfSemesterSearchModel { Id = id });
								LoadData(_studyGroupId, _typeOfClassId);
							}
							catch (Exception ex)
							{
								Program.ShowError(ex, "Ошибка удаления");
							}
						}
					}
					break;
			}
		}
	}
}