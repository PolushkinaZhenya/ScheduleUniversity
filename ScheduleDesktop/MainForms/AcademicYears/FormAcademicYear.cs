using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormAcademicYear : Form
	{
		private Guid? _id;

		public Guid Id { set { _id = value; } }

		private readonly List<string> _configSemesters;

		private readonly List<string> _configPeriods;

		private readonly IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> _serviceAY;

		private readonly IBaseService<SemesterBindingModel, SemesterViewModel, SemesterSearchModel> _serviceS;

		private readonly IBaseService<PeriodBindingModel, PeriodViewModel, PeriodSearchModel> _serviceP;

		public FormAcademicYear(IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> serviceAY,
			IBaseService<SemesterBindingModel, SemesterViewModel, SemesterSearchModel> serviceS,
			IBaseService<PeriodBindingModel, PeriodViewModel, PeriodSearchModel> serviceP)
		{
			InitializeComponent();
			_serviceAY = serviceAY;
			_serviceS = serviceS;
			_serviceP = serviceP;

			_configSemesters = dataGridViewSemesters.ConfigDataGrid(typeof(SemesterViewModel));
			_configPeriods = dataGridViewPeriods.ConfigDataGrid(typeof(PeriodViewModel));
		}

		private void FormAcademicYear_Load(object sender, EventArgs e)
		{
			try
			{
				if (_id.HasValue)
				{
					var view = _serviceAY.GetElement(new AcademicYearSearchModel { Id = _id.Value });
					if (view != null)
					{
						textBoxTitle.Text = view.Title;
					}
					LoadSemesters();
					LoadPeriods();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки");
			}
		}

		private void LoadSemesters()
		{
			if (_id.HasValue)
			{
				dataGridViewSemesters.Rows.Clear();
				dataGridViewSemesters.FillDataGrid(_configSemesters, _serviceS.GetList(new SemesterSearchModel { AcademicYearId = _id.Value }));
			}
		}

		private void LoadPeriods()
		{
			if (_id.HasValue)
			{
				dataGridViewPeriods.Rows.Clear();
				dataGridViewPeriods.FillDataGrid(_configPeriods, _serviceP.GetList(new PeriodSearchModel { AcademicYearId = _id.Value }));
			}
		}

		private void ButtonCreateSemesters_Click(object sender, EventArgs e)
		{
			if (dataGridViewSemesters.Rows.Count != 0)
			{
				return;
			}
			if (textBoxTitle.Text.IsEmpty())
			{
				Program.ShowError("Должен быть указан учебный год", "Оишбка создания");
				return;
			}

			dataGridViewSemesters.Rows.Add(new object[] { Guid.NewGuid(), "Осенний семестр", textBoxTitle.Text });
			dataGridViewSemesters.Rows.Add(new object[] { Guid.NewGuid(), "Весенний семестр", textBoxTitle.Text });
		}

		private void DataGridViewSemesters_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					if (textBoxTitle.Text.IsEmpty())
					{
						Program.ShowError("Должен быть указан учебный год", "Оишбка создания");
						return;
					}
					dataGridViewSemesters.Rows.Add(new object[] { Guid.NewGuid(), string.Empty, textBoxTitle.Text });
					break;
				case Keys.Delete: // удалить
					if (dataGridViewSemesters.SelectedRows.Count > 0)
					{
						foreach (DataGridViewRow row in dataGridViewSemesters.SelectedRows)
						{
							for (int i = 0; i < dataGridViewPeriods.Rows.Count; ++i)
							{
								if (dataGridViewPeriods.Rows[i].Cells["SemesterId"].Value == row.Cells["Id"].Value)
								{
									dataGridViewPeriods.Rows.RemoveAt(i--);
								}
							}
							dataGridViewSemesters.Rows.Remove(row);
						}
					}
					break;
			}
		}

		private void ButtonCreatePeriods_Click(object sender, EventArgs e)
		{
			if (dataGridViewSemesters.SelectedRows.Count != 1)
			{
				Program.ShowError("Должен быть выбран строго ОДИН семестр", "Оишбка создания");
				return;
			}
			var startDate = dateTimePickerStartDate.Value.Date;
			var countDays = Convert.ToInt32(numericUpDownPeriodLength.Value * 7) - 1;
			for (int i = 0; i < numericUpDownPeriodsCount.Value; ++i)
			{
				dataGridViewPeriods.Rows.Add(
					new object[] {
						Guid.NewGuid(),
						$"Период {i + 1}",
						startDate,
						startDate.AddDays(countDays),
						dataGridViewSemesters.SelectedRows[0].Cells[0].Value,
						dataGridViewSemesters.SelectedRows[0].Cells[1].Value
					});
				startDate = startDate.AddDays(countDays + 1);
			}
		}

		private void DataGridViewPeriods_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					if (dataGridViewSemesters.SelectedRows.Count != 1)
					{
						Program.ShowError("Должен быть выбран строго ОДИН семестр", "Оишбка создания");
						return;
					}
					dataGridViewPeriods.Rows.Add(new object[] {
						Guid.NewGuid(),
						string.Empty,
						string.Empty,
						string.Empty,
						dataGridViewSemesters.SelectedRows[0].Cells[0].Value,
						dataGridViewSemesters.SelectedRows[0].Cells[1].Value });
					break;
				case Keys.Delete: // удалить
					if (dataGridViewPeriods.SelectedRows.Count > 0)
					{
						foreach (DataGridViewRow row in dataGridViewPeriods.SelectedRows)
						{
							dataGridViewPeriods.Rows.Remove(row);
						}
					}
					break;
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (textBoxTitle.Text.IsEmpty())
			{
				Program.ShowError("Должен быть указан учебный год", "Оишбка сохранения");
				return;
			}
			if (dataGridViewSemesters.Rows.Count == 0)
			{
				Program.ShowError("Должен быть хотя бы один семестр", "Оишбка сохранения");
				return;
			}
			else
			{
				foreach (DataGridViewRow row in dataGridViewSemesters.Rows)
				{
					if (row.Cells["Title"].Value.ToString().IsEmpty())
					{
						Program.ShowError("У всех семестров должны быть названия", "Оишбка сохранения");
						return;
					}
				}
			}
			if (dataGridViewPeriods.Rows.Count == 0)
			{
				Program.ShowError("Должен быть хотя бы один период", "Оишбка сохранения");
				return;
			}
			else
			{
				foreach (DataGridViewRow row in dataGridViewPeriods.Rows)
				{
					if (row.Cells["Title"].Value.ToString().IsEmpty() || row.Cells["StartDate"].Value.ToString().IsEmpty() || row.Cells["EndDate"].Value.ToString().IsEmpty())
					{
						Program.ShowError("У всех периодов должны быть названия, начало и конец", "Оишбка сохранения");
						return;
					}
				}
			}
			try
			{
				if (_id.HasValue)
				{
					_serviceAY.UpdElement(new AcademicYearBindingModel { Id = _id.Value, Title = textBoxTitle.Text });
					var semesters = _serviceS.GetList(new SemesterSearchModel { AcademicYearId = _id.Value });
					foreach (DataGridViewRow row in dataGridViewSemesters.Rows)
					{
						var sem = semesters.FirstOrDefault(x => x.Id == new Guid(row.Cells["Id"].Value.ToString()));
						if (sem != null)
						{
							_serviceS.UpdElement(new SemesterBindingModel { Id = sem.Id, AcademicYearId = _id.Value, Title = row.Cells["Title"].Value.ToString() });
						}
						else
						{
							_serviceS.AddElement(new SemesterBindingModel { AcademicYearId = _id.Value, Title = row.Cells["Title"].Value.ToString() });
						}
						semesters.Remove(sem);
					}
					foreach(var sem in semesters)
					{
						_serviceS.DelElement(new SemesterSearchModel { Id = sem.Id });
					}
					var periods = _serviceP.GetList(new PeriodSearchModel { AcademicYearId = _id.Value });
					semesters = _serviceS.GetList(new SemesterSearchModel { AcademicYearId = _id.Value });
					foreach (DataGridViewRow row in dataGridViewPeriods.Rows)
					{
						var per = periods.FirstOrDefault(x => x.Id == new Guid(row.Cells["Id"].Value.ToString()));
						if (per != null)
						{
							_serviceP.UpdElement(new PeriodBindingModel { 
								Id = per.Id, 
								SemesterId = per.SemesterId,
								Title = row.Cells["Title"].Value.ToString(),
								EndDate = Convert.ToDateTime(row.Cells["EndDate"].Value),
								StartDate = Convert.ToDateTime(row.Cells["StartDate"].Value)
							});
						}
						else
						{
							var sem = semesters.FirstOrDefault(x => x.Title == row.Cells["SemesterTitle"].Value.ToString());
							if (sem == null)
							{
								Program.ShowError($"Для периода {row.Cells["Title"].Value} не найден семестр {row.Cells["SemesterTitle"].Value}", "Ошибка сохранения");
								continue;
							}
							_serviceP.AddElement(new PeriodBindingModel
							{
								SemesterId = sem.Id,
								Title = row.Cells["Title"].Value.ToString(),
								EndDate = Convert.ToDateTime(row.Cells["EndDate"].Value),
								StartDate = Convert.ToDateTime(row.Cells["StartDate"].Value)
							});
						}
						periods.Remove(per);
					}
					foreach (var per in periods)
					{
						_serviceP.DelElement(new PeriodSearchModel { Id = per.Id });
					}
				}
				else
				{
					_serviceAY.AddElement(new AcademicYearBindingModel { Title = textBoxTitle.Text });
					var ay = _serviceAY.GetElement(new AcademicYearSearchModel { Title = textBoxTitle.Text });
					if (ay == null)
					{
						Program.ShowError("Не найден сохраненый учебный год", "Ошибка сохранения");
						return;
					}
					foreach (DataGridViewRow row in dataGridViewSemesters.Rows)
					{
						_serviceS.AddElement(new SemesterBindingModel { AcademicYearId = ay.Id, Title = row.Cells["Title"].Value.ToString() });
					}
					var semesters = _serviceS.GetList(new SemesterSearchModel { AcademicYearId = ay.Id });
					if (semesters == null || semesters.Count == 0)
					{
						Program.ShowError("Не найдены сохраненые семестры", "Ошибка сохранения");
						return;
					}
					foreach (DataGridViewRow row in dataGridViewPeriods.Rows)
					{
						var sem = semesters.FirstOrDefault(x => x.Title == row.Cells["SemesterTitle"].Value.ToString());
						if (sem == null)
						{
							Program.ShowError($"Для периода {row.Cells["Title"].Value} не найден семестр {row.Cells["SemesterTitle"].Value}", "Ошибка сохранения");
							continue;
						}
						_serviceP.AddElement(new PeriodBindingModel
						{
							SemesterId = sem.Id,
							Title = row.Cells["Title"].Value.ToString(),
							EndDate = Convert.ToDateTime(row.Cells["EndDate"].Value),
							StartDate = Convert.ToDateTime(row.Cells["StartDate"].Value)
						});
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка сохранения");
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
