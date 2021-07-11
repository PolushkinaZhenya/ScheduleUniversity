using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlCurriculumsForAcademicYear : UserControl
	{
		private readonly IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel> _service;

		private Guid? _academicYearId = null;

		public UserControlCurriculumsForAcademicYear()
		{
			InitializeComponent();
			_service = DependencyManager.Instance.Resolve<IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel>>();
		}

		public async Task LoadAuditoriumsAsync(Guid academicYearId)
		{
			_academicYearId = academicYearId;
			await LoadData();
		}

		private async Task LoadData()
		{
			if (!_academicYearId.HasValue)
			{
				return;
			}

			try
			{
				var groupbBySemesters = await Task.Run(() => _service.GetList(new CurriculumSearchModel { AcademicYearId = _academicYearId.Value })?
				.GroupBy(x => x.SemesterId)?.OrderBy(x => x.Key)?.ToList());
				if (groupbBySemesters == null || groupbBySemesters.Count == 0)
				{
					return;
				}

				tabControlSemesters.TabPages.Clear();
				foreach (var groupCourse in groupbBySemesters)
				{
					var page = new TabPage
					{
						Name = $"tabPage{groupCourse.First().SemesterId}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{groupCourse.First()?.SemesterTitle}",
						UseVisualStyleBackColor = true
					};

					var dataGridView = Tools.CreateDataGridView(groupCourse.Key.ToString());
					dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
					dataGridView.KeyDown += DataGridView_KeyDown;

					page.Controls.Add(dataGridView);
					await Task.Run(() =>
					{
						dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(CurriculumViewModel)), groupCourse.ToList());
					});

					tabControlSemesters.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}

		private async void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => await OpenForm(sender as DataGridView);

		private async void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					var form = DependencyManager.Instance.Resolve<FormCurriculum>();
					var page = tabControlSemesters.SelectedTab;
					if (page != null)
					{
						form.SemesterId = new Guid(page.Name.Replace("tabPage", ""));
					}
					if (form.ShowDialog() == DialogResult.OK)
					{
						await LoadData();
					}
					break;
				case Keys.Enter: // изменить
					await OpenForm(grid);
					break;
				case Keys.Delete: // удалить
					if (grid?.SelectedRows.Count == 1)
					{
						var id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
						{
							try
							{
								_service.DelElement(new CurriculumSearchModel { Id = id });
								await LoadData();
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

		private async Task OpenForm(DataGridView grid)
		{
			if (grid == null)
			{
				return;
			}

			if (grid.SelectedRows.Count == 1)
			{
				var form = DependencyManager.Instance.Resolve<FormCurriculum>();
				form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					await LoadData();
				}
			}
		}
	}
}
