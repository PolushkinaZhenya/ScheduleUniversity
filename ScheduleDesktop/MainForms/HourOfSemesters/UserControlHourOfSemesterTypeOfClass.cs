using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlHourOfSemesterTypeOfClass : UserControl
	{
		private Guid? _id;

		//private bool _isLoad;

		private Guid? _studyGroupId;

		private HourOfSemesterRecordViewModel _model;

		private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _serviceA;

		private readonly IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel> _serviceF;

		private readonly Lazy<List<PeriodViewModel>> _periods;

		public UserControlHourOfSemesterTypeOfClass(Guid semesterId)
		{
			InitializeComponent();
			_serviceA = DependencyManager.Instance.Resolve<IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>>();
			_serviceF = DependencyManager.Instance.Resolve<IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel>>();
			_periods = new Lazy<List<PeriodViewModel>>(() => { 
				var serviceP = DependencyManager.Instance.Resolve<IBaseService<PeriodBindingModel, PeriodViewModel, PeriodSearchModel>>();
				return serviceP.GetList(new PeriodSearchModel { SemesterId = semesterId });
			});
		}

		private void UserControlHourOfSemesterTypeOfClass_Load(object sender, EventArgs e)
		{
			try
			{
				//	_isLoad = true;
				var serivceTC = DependencyManager.Instance.Resolve<IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel>>();
				var listTC = serivceTC.GetList();
				if (listTC != null)
				{
					comboBoxTypeOfClass.DisplayMember = "Title";
					comboBoxTypeOfClass.ValueMember = "Id";
					comboBoxTypeOfClass.DataSource = listTC;
					comboBoxTypeOfClass.SelectedItem = null;
				}
				var serivceT = DependencyManager.Instance.Resolve<IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel>>();
				var listT = serivceT.GetList();
				if (listT != null)
				{
					comboBoxTeacher.DisplayMember = "ShortName";
					comboBoxTeacher.ValueMember = "Id";
					comboBoxTeacher.DataSource = listT;
					comboBoxTeacher.SelectedItem = null;
				}
				if (_model != null)
				{
					_id = _model.Id;
					comboBoxTypeOfClass.SelectedValue = _model.TypeOfClassId;
					comboBoxTeacher.SelectedValue = _model.TeacherId;
					numericUpDownTotalHours.Value = _model.TotalHours;
					checkBoxSubgroupNumber.Checked = _model.SubgroupNumber.HasValue;
					numericUpDownSubgroupNumber.Value = _model.SubgroupNumber ?? 0;
					if (_model.FlowId.HasValue)
					{
						comboBoxFlow.SelectedValue = _model.FlowId.Value;
					}

					dataGridViewAuditorium.Rows.Clear();
					foreach (var aud in _model.HourOfSemesterAuditoriums)
					{
						dataGridViewAuditorium.Rows.Add(new object[] { aud.Id, aud.AuditoriumId, aud.AuditoriumTitle });
					}
					foreach (var period in _model.HourOfSemesterPeriods)
					{
						dataGridViewPeriods.Rows[0].Cells[$"PeriodId{period.PeriodId}"].Value = period.Id;
						dataGridViewPeriods.Rows[0].Cells[$"PeriodPeriodId{period.PeriodId}"].Value = period.PeriodId;
						dataGridViewPeriods.Rows[0].Cells[$"PeriodTitle{period.PeriodId}"].Value = $"{period.PeriodTitle}";
						dataGridViewPeriods.Rows[0].Cells[$"PeriodCountLessonFirstWeek{period.PeriodId}"].Value =period.HoursFirstWeek;
						dataGridViewPeriods.Rows[0].Cells[$"PeriodCountLessonSecondWeek{period.PeriodId}"].Value = period.HoursSecondWeek;
					}
				}
				//_isLoad = false;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки данных");
			}
		}

		public void LoadData(Guid studyGroupId, HourOfSemesterRecordViewModel model = null)
		{
			try
			{
				_studyGroupId = studyGroupId;
				_model = model;
				LoadFlows();

				dataGridViewPeriods.Columns.Clear();
				if (_periods.Value != null)
				{
					foreach (var period in _periods.Value)
					{
						dataGridViewPeriods.Columns.Add(new DataGridViewColumn
						{
							HeaderText = "PeriodId",
							Name = $"PeriodId{period.Id}",
							CellTemplate = new DataGridViewTextBoxCell(),
							Visible = false
						});
						dataGridViewPeriods.Columns.Add(new DataGridViewColumn
						{
							HeaderText = "PeriodPeriodId",
							Name = $"PeriodPeriodId{period.Id}",
							CellTemplate = new DataGridViewTextBoxCell(),
							Visible = false
						});
						dataGridViewPeriods.Columns.Add(new DataGridViewColumn
						{
							HeaderText = "Период",
							Name = $"PeriodTitle{period.Id}",
							CellTemplate = new DataGridViewTextBoxCell(),
							AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
							ReadOnly = true
						});
						dataGridViewPeriods.Columns.Add(new DataGridViewColumn
						{
							HeaderText = "Кол-во пар на 1 неделе",
							Name = $"PeriodCountLessonFirstWeek{period.Id}",
							CellTemplate = new DataGridViewTextBoxCell(),
							AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
							ReadOnly = true
						});
						dataGridViewPeriods.Columns.Add(new DataGridViewColumn
						{
							HeaderText = "Кол-во пар на 2 неделе",
							Name = $"PeriodCountLessonSecondWeek{period.Id}",
							CellTemplate = new DataGridViewTextBoxCell(),
							AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
							ReadOnly = true
						});
					}
					dataGridViewPeriods.Rows.Add();
					if (_model == null)
					{
						foreach (var period in _periods.Value)
						{
							var length = ((period.EndDate.Date - period.StartDate.Date).TotalDays + 1) / 7;
							dataGridViewPeriods.Rows[0].Cells[$"PeriodPeriodId{period.Id}"].Value = period.Id;
							dataGridViewPeriods.Rows[0].Cells[$"PeriodTitle{period.Id}"].Value = $"{period.Title} ({length} нед.)";
						}
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message, "Ошибка получения периодов");
			}
		}

		public bool Check()
		{
			if (comboBoxTypeOfClass.SelectedValue == null || comboBoxTeacher.SelectedValue == null || numericUpDownTotalHours.Value == 0)
			{
				Program.ShowError("Должны быть выбраны формы занятия и преподаватель и указано общее количество часов", "Ошибка сохранения");
				return false;
			}
			if (dataGridViewAuditorium.Rows.Count == 0)
			{
				Program.ShowError("Укзаать хотя бы одну аудиторию", "Ошибка сохранения");
				return false;
			}
			var totalSum = 0;
			for(int i = 0; i < dataGridViewPeriods.Columns.Count; i += 5)
			{
				if (dataGridViewPeriods.Rows[0].Cells[i + 3].Value != null)
				{
					totalSum += Convert.ToInt32(dataGridViewPeriods.Rows[0].Cells[i + 3].Value);
				}
				if (dataGridViewPeriods.Rows[0].Cells[i + 4].Value != null)
				{
					totalSum += Convert.ToInt32(dataGridViewPeriods.Rows[0].Cells[i + 4].Value);
				}
			}
			// 2 - 2 часа в паре, 4 - количество недель (в периоде 4 четных и 4 нечетных недели)
			if (totalSum * 2 * 4 != (int)numericUpDownTotalHours.Value)
			{
				Program.ShowError("Количество часов в периодах не совпадает с общим количеством часов", "Ошибка сохранения");
				return false;
			}
			return true;
		}

		public HourOfSemesterRecordBindingModel GetHourOfSemesterRecordBindingModel()
		{
			var model = new HourOfSemesterRecordBindingModel
			{
				TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
				TeacherId = (Guid)comboBoxTeacher.SelectedValue,
				TotalHours = (int)numericUpDownTotalHours.Value,
				SubgroupNumber = checkBoxSubgroupNumber.Checked? (int)numericUpDownSubgroupNumber.Value : null,
				FlowId = comboBoxFlow.SelectedValue != null ? (Guid)comboBoxFlow.SelectedValue : null,
				HourOfSemesterAuditoriums = new(),
				HourOfSemesterPeriods = new()
			};

			int counter = 0;
			foreach (DataGridViewRow row in dataGridViewAuditorium.Rows)
			{
				if (row.Cells["ColumnAudId"].Value != null)
				{
					model.HourOfSemesterAuditoriums.Add(new HourOfSemesterAuditoriumBindingModel
					{
						Id = row.Cells["ColumnAuditoriumId"].Value != null ? (Guid)row.Cells["ColumnAuditoriumId"].Value : new Guid(),
						AuditoriumId = (Guid)row.Cells["ColumnAudId"].Value,
						Priority = counter++
					});
				}
			}

			for (int i = 0; i < dataGridViewPeriods.Columns.Count; i += 5)
			{
				model.HourOfSemesterPeriods.Add(new HourOfSemesterPeriodBindingModel
				{
					Id = dataGridViewPeriods.Rows[0].Cells[i].Value != null ? (Guid)dataGridViewPeriods.Rows[0].Cells[i].Value : new Guid(),
					PeriodId = (Guid)dataGridViewPeriods.Rows[0].Cells[i + 1].Value,
					HoursFirstWeek = dataGridViewPeriods.Rows[0].Cells[i + 3].Value != null ? Convert.ToInt32(dataGridViewPeriods.Rows[0].Cells[i + 3].Value) : 0,
					HoursSecondWeek = dataGridViewPeriods.Rows[0].Cells[i + 4].Value != null ? Convert.ToInt32(dataGridViewPeriods.Rows[0].Cells[i + 4].Value) : 0
				});
			}

			if (_id.HasValue)
			{
				model.Id = _id.Value;
			}

			return model;
		}

		private void LoadFlows()
		{
			if (!_studyGroupId.HasValue)
			{
				return;
			}
			var listF = _serviceF.GetList(new FlowSearchModel { StudentGroupId = _studyGroupId.Value });
			if (listF != null)
			{
				comboBoxFlow.DisplayMember = "Title";
				comboBoxFlow.ValueMember = "Id";
				comboBoxFlow.DataSource = listF;
				comboBoxFlow.SelectedItem = null;
			}
		}

		private void NumericUpDownTotalHours_ValueChanged(object sender, EventArgs e)
		{
			//if (_isLoad)
			//{
			//	return;
			//}
			//// определяем количество пар
			//int countPars = (int)numericUpDownTotalHours.Value / 2;
			//// сколько у нас периодов
			//var rows = dataGridViewPeriods.Rows.Count;
			//int[] pars = new int[rows];
			//// если количество пар четно делится на количество периодов
			//if (countPars % rows == 0)
			//{
			//	for (int i = 0; i < pars.Length; ++i)
			//	{
			//		pars[i] = countPars / rows;
			//	}
			//}
			//// если нет, то на первый период больше, чем на все остальные
			//else
			//{
			//	for (int i = pars.Length - 1; i > 0; --i)
			//	{
			//		pars[i] = countPars / rows;
			//	}
			//	pars[0] = countPars - pars.Sum();
			//}
			//// распределени пар по неделям
			//for (int i = 0; i < pars.Length; ++i)
			//{
			//	// в периоде 8 недель, распределяем равномерно на
			//	if (pars[i] % 8 == 0)
			//	{
			//		dataGridViewPeriods.Rows[i].Cells["ColumnPeriodFirstWeek"].Value =
			//			dataGridViewPeriods.Rows[i].Cells["ColumnPeriodSecondWeek"].Value = pars[i] / 8;
			//	}
			//	else
			//	{
			//		dataGridViewPeriods.Rows[i].Cells["ColumnPeriodFirstWeek"].Value = pars[i] - (pars[i] % 4 - 1) * 2;
			//		dataGridViewPeriods.Rows[i].Cells["ColumnPeriodSecondWeek"].Value = (pars[i] % 4 - 1) * 2;
			//	}
			//}
		}

		private void ButtonAddFlow_Click(object sender, EventArgs e)
		{
			DependencyManager.Instance.Resolve<FormFlow>().ShowDialog();
			LoadFlows();
		}

		private void ButtonDelFlow_Click(object sender, EventArgs e) => comboBoxFlow.SelectedItem = null;

		private void ButtonAddAuditorium_Click(object sender, EventArgs e)
		{
			dataGridViewAuditorium.Rows.Add();
		}

		private void ButtonDelAuditorium_Click(object sender, EventArgs e)
		{
			if (dataGridViewAuditorium.SelectedRows.Count == 1)
			{
				dataGridViewAuditorium.Rows.RemoveAt(dataGridViewAuditorium.SelectedRows[0].Index);
			}
		}

		private void DataGridViewAuditorium_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (dataGridViewAuditorium.SelectedRows.Count == 1)
				{
					var row = dataGridViewAuditorium.SelectedRows[0];
					var aud = _serviceA.GetElement(new AuditoriumSearchModel { Number = row.Cells["ColumnAuditorium"].Value.ToString() });
					if (aud == null)
					{
						throw new Exception("Не найдена аудитория с таким названием");
					}
					row.Cells["ColumnAudId"].Value = aud.Id;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения аудитории");
			}
		}

		private void ButtonUpAuditorium_Click(object sender, EventArgs e)
		{
			if (dataGridViewAuditorium.SelectedRows.Count == 1)
			{
				var index = dataGridViewAuditorium.SelectedRows[0].Index;
				if (index > 0)
				{
					var row = dataGridViewAuditorium.Rows[index];
					dataGridViewAuditorium.Rows.RemoveAt(dataGridViewAuditorium.SelectedRows[0].Index);
					dataGridViewAuditorium.Rows.Insert(index - 1, row);
					dataGridViewAuditorium.Rows[index - 1].Selected = true;
				}
			}
		}

		private void ButtonDownAuditorium_Click(object sender, EventArgs e)
		{
			if (dataGridViewAuditorium.SelectedRows.Count == 1)
			{
				var index = dataGridViewAuditorium.SelectedRows[0].Index;
				if (index < dataGridViewAuditorium.Rows.Count - 1)
				{
					var row = dataGridViewAuditorium.Rows[index];
					dataGridViewAuditorium.Rows.RemoveAt(dataGridViewAuditorium.SelectedRows[0].Index);
					dataGridViewAuditorium.Rows.Insert(index + 1, row);
					dataGridViewAuditorium.Rows[index + 1].Selected = true;
				}
			}
		}

		private void DataGridViewPeriods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			//var index = e.RowIndex;
			//var totalSum = 0;
			//foreach (DataGridViewRow row in dataGridViewPeriods.Rows)
			//{
			//	if (row.Cells["ColumnPeriodFirstWeek"].Value != null)
			//	{
			//		totalSum += Convert.ToInt32(row.Cells["ColumnPeriodFirstWeek"].Value);
			//	}
			//	if (row.Cells["ColumnPeriodSecondWeek"].Value != null)
			//	{
			//		totalSum += Convert.ToInt32(row.Cells["ColumnPeriodSecondWeek"].Value);
			//	}
			//}

			//if (totalSum < (int)numericUpDownTotalHours.Value)
			//{
			//	int difference = (int)numericUpDownTotalHours.Value - totalSum;
			//	if (e.ColumnIndex == dataGridViewPeriods.Columns["ColumnPeriodFirstWeek"].Index)
			//	{
			//		if (dataGridViewPeriods.Rows[index].Cells["ColumnPeriodSecondWeek"].Value == null)
			//		{
			//			if (index == 0)
			//			{
			//				index++;
			//			}
			//			else
			//			{
			//				index--;
			//			}
			//			int val = Convert.ToInt32(dataGridViewPeriods.Rows[index].Cells["ColumnPeriodFirstWeek"].Value);
			//			dataGridViewPeriods.Rows[index].Cells["ColumnPeriodFirstWeek"].Value = val + difference;
			//		}
			//		else
			//		{
			//			int val = Convert.ToInt32(dataGridViewPeriods.Rows[index].Cells["ColumnPeriodSecondWeek"].Value);
			//			dataGridViewPeriods.Rows[index].Cells["ColumnPeriodSecondWeek"].Value = val + difference;
			//		}
			//	}
			//	if (e.ColumnIndex == dataGridViewPeriods.Columns["ColumnPeriodSecondWeek"].Index)
			//	{
			//		if (dataGridViewPeriods.Rows[index].Cells["ColumnPeriodFirstWeek"].Value == null)
			//		{
			//			if (index == 0)
			//			{
			//				index++;
			//			}
			//			else
			//			{
			//				index--;
			//			}
			//			int val = Convert.ToInt32(dataGridViewPeriods.Rows[index].Cells["ColumnPeriodSecondWeek"].Value);
			//			dataGridViewPeriods.Rows[index].Cells["ColumnPeriodSecondWeek"].Value = val + difference;
			//		}
			//		else
			//		{
			//			int val = Convert.ToInt32(dataGridViewPeriods.Rows[index].Cells["ColumnPeriodFirstWeek"].Value);
			//			dataGridViewPeriods.Rows[index].Cells["ColumnPeriodFirstWeek"].Value = val + difference;
			//		}
			//	}
			//}
		}

		private void DataGridViewPeriods_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete: // удалить
					var cell = dataGridViewPeriods.SelectedCells[0];
					//if (cell.ColumnIndex == dataGridViewPeriods.Columns["ColumnPeriodSecondWeek"].Index ||
					//	cell.ColumnIndex == dataGridViewPeriods.Columns["ColumnPeriodFirstWeek"].Index)
					//{
					//	int val = Convert.ToInt32(cell.Value);
					//	if (cell.ColumnIndex == dataGridViewPeriods.Columns["ColumnPeriodSecondWeek"].Index &&
					//		dataGridViewPeriods.Rows[cell.RowIndex].Cells["ColumnPeriodFirstWeek"].Value != null)
					//	{
					//		int cellVal = Convert.ToInt32(dataGridViewPeriods.Rows[cell.RowIndex].Cells["ColumnPeriodFirstWeek"].Value);
					//		dataGridViewPeriods.Rows[cell.RowIndex].Cells["ColumnPeriodFirstWeek"].Value = cellVal + val;
					//	}
					//	if (cell.ColumnIndex == dataGridViewPeriods.Columns["ColumnPeriodFirstWeek"].Index &&
					//		dataGridViewPeriods.Rows[cell.RowIndex].Cells["ColumnPeriodSecondWeek"].Value != null)
					//	{
					//		int cellVal = Convert.ToInt32(dataGridViewPeriods.Rows[cell.RowIndex].Cells["ColumnPeriodSecondWeek"].Value);
					//		dataGridViewPeriods.Rows[cell.RowIndex].Cells["ColumnPeriodSecondWeek"].Value = cellVal + val;
					//	}
					//	cell.Value = null;
					//}
					cell.Value = null;
					break;
			}
		}

		private void CheckBoxSubgroupNumber_CheckedChanged(object sender, EventArgs e) => numericUpDownSubgroupNumber.Enabled = checkBoxSubgroupNumber.Checked;
	}
}