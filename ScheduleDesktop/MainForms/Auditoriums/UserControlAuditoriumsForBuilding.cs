using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlAuditoriumsForBuilding : UserControl
	{
		private readonly IAuditoriumService service;

		private Guid? _buildingId = null;

		public UserControlAuditoriumsForBuilding()
		{
			InitializeComponent();
			service = DependencyManager.Instance.Resolve<IAuditoriumService>();
		}

		public async Task LoadAuditoriumsAsync(Guid buildingId)
		{
			_buildingId = buildingId;
			await LoadData();
		}

		private async Task LoadData()
		{
			if (!_buildingId.HasValue)
			{
				return;
			}

			try
			{
				var groupbByDepartments = await Task.Run(() => service.GetListByEducationalBuilding(_buildingId.Value)?.GroupBy(x => x.Department)?.OrderBy(x => x.Key)?.ToList());
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
					await Task.Run(() =>
					{
						dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(AuditoriumViewModel)), groupCourse.ToList());
					});

					tabControlDepartments.TabPages.Add(page);
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
								service.DelElement(id);
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
				var form = DependencyManager.Instance.Resolve<FormAuditorium>();
				form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					await LoadData();
				}
			}
		}
	}
}