using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlAuditoriumsForBuilding : UserControl
	{
		private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> service;

		private Guid? _buildingId = null;

		public UserControlAuditoriumsForBuilding()
		{
			InitializeComponent();
			service = DependencyManager.Instance.Resolve<IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>>();
		}

		public void LoadAuditoriumsAsync(Guid buildingId)
		{
			_buildingId = buildingId;
			LoadData();
		}

		private void LoadData()
		{
			if (!_buildingId.HasValue)
			{
				return;
			}

			try
			{
				var groupbByDepartments = service.GetList(new AuditoriumSearchModel { EducationalBuildingId = _buildingId.Value })?.
																		GroupBy(x => x.Department)?.OrderBy(x => x.Key)?.ToList();
				if (groupbByDepartments == null || groupbByDepartments.Count == 0)
				{
					return;
				}

				tabControlDepartments.TabPages.Clear();
				foreach (var groupCourse in groupbByDepartments)
				{
					var page = new TabPage
					{
						Name = $"tabPage{groupCourse.First().DepartmentId}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{groupCourse.Key}",
						UseVisualStyleBackColor = true
					};

					var dataGridView = Tools.CreateDataGridView(groupCourse.Key.ToString());
					dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
					dataGridView.KeyDown += DataGridView_KeyDown;

					page.Controls.Add(dataGridView);
					dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(AuditoriumViewModel)), groupCourse.ToList());

					tabControlDepartments.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}

		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => OpenForm(sender as DataGridView);

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					var form = DependencyManager.Instance.Resolve<FormAuditorium>();
					if (_buildingId.HasValue)
					{
						form.BuildingId = _buildingId.Value;
					}
					var page = tabControlDepartments.SelectedTab;
					if (page != null)
					{
						form.DepartmentId = new Guid(page.Name.Replace("tabPage", ""));
					}
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadData();
					}
					break;
				case Keys.Enter: // изменить
					OpenForm(grid);
					break;
				case Keys.Delete: // удалить
					if (grid?.SelectedRows.Count == 1)
					{
						var id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
						{
							try
							{
								service.DelElement(new AuditoriumSearchModel { Id = id });
								LoadData();
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

		private void OpenForm(DataGridView grid)
		{
			if (grid == null)
			{
				return;
			}

			if (grid.SelectedRows.Count == 1)
			{
				var form = DependencyManager.Instance.Resolve<FormAuditorium>();
				form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}
	}
}