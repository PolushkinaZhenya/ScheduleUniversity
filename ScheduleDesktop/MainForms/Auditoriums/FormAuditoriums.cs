using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormAuditoriums : Form
	{
		private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _service;

		private readonly Lazy<List<EducationalBuildingViewModel>> _educationalBuildings;

		private List<IGrouping<Guid, AuditoriumViewModel>> _groupbByDepartments;

		private Guid? _buildingId = null;

		public FormAuditoriums(IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> service,
			IBaseService<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel> serviceEB)
		{
			InitializeComponent();
			_service = service;
			_educationalBuildings = new Lazy<List<EducationalBuildingViewModel>>(() => { return serviceEB.GetList(); });
		}

		private void FormAuditoriums_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			var seletedTab = tabControlEducationalBuildings.SelectedTab?.Name;
			var seletedTabTab = (tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] as TabControl)?.SelectedTab?.Name;
			var seletedId = ((tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] as TabControl)?.SelectedTab?.
																		Controls["dataGridView"] as DataGridView)?.SelectedRows[0]?.Cells[0]?.Value;

			tabControlEducationalBuildings.TabPages.Clear();

			if (_educationalBuildings.Value == null)
			{
				Program.ShowError("Список строений не получен", "Получение данных");
				return;
			}
			try
			{

				foreach (var educationalBuilding in _educationalBuildings.Value)
				{
					var page = new TabPage
					{
						Name = $"tabPage{educationalBuilding.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{educationalBuilding.Title}",
						UseVisualStyleBackColor = true
					};

					if (tabControlEducationalBuildings.TabPages.Count == 0)
					{
						LoadEducationalBuildingPage(page);
					}
					tabControlEducationalBuildings.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка при загрузке");
			}

			var pageSel = tabControlEducationalBuildings.TabPages.IndexOfKey(seletedTab);
			if (pageSel > -1)
			{
				tabControlEducationalBuildings.SelectTab(pageSel);
				if (seletedTabTab.IsNotEmpty() && tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] is TabControl tab)
				{
					pageSel = tab.TabPages.IndexOfKey(seletedTabTab);
					if (pageSel > -1)
					{
						tab.SelectTab(pageSel);

						if (seletedId != null && tab.SelectedTab?.Controls["dataGridView"] is DataGridView grid)
						{
							var row = grid.Rows
									.Cast<DataGridViewRow>()
									.Where(r => r.Cells[0].Value.ToString().Equals(seletedId.ToString()))
									.First()?.Index;
							if (row.HasValue && row > -1)
							{
								grid.Rows[row.Value].Selected = true;
							}
						}
					}
				}
			}
		}

		private void TabControlEducationalBuildings_SelectedIndexChanged(object sender, EventArgs e) => LoadEducationalBuildingPage(tabControlEducationalBuildings.SelectedTab);

		/// <summary>
		/// Загрузка аудиторий строения (TabControl с вкладками под каждую кафедру)
		/// </summary>
		/// <param name="page"></param>
		private void LoadEducationalBuildingPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			_buildingId = new Guid(page.Name.Replace("tabPage", ""));

			try
			{
				_groupbByDepartments = _service.GetList(new AuditoriumSearchModel { EducationalBuildingId = _buildingId.Value })?.
																		GroupBy(x => x.DepartmentId)?.OrderBy(x => x.Key)?.ToList();
				if (_groupbByDepartments == null || _groupbByDepartments.Count == 0)
				{
					return;
				}

				var tabControlDepartments = new TabControl
				{
					Dock = DockStyle.Fill,
					Location = new Point(0, 0),
					Name = "tabControlDepartments",
					SelectedIndex = 0,
					Size = new Size(903, 597),
					TabIndex = 0
				};
				tabControlDepartments.SelectedIndexChanged += new EventHandler(TabControlDepartments_SelectedIndexChanged);

				foreach (var groupDepartment in _groupbByDepartments)
				{
					var newPage = new TabPage
					{
						Name = $"tabPage{groupDepartment.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{groupDepartment.First()?.Department}",
						UseVisualStyleBackColor = true
					};

					if (tabControlDepartments.TabPages.Count == 0)
					{
						LoadAuditoriumsPage(newPage);
					}

					tabControlDepartments.TabPages.Add(newPage);
				}

				page.Controls.Add(tabControlDepartments);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка зарузки аудиторий");
			}
		}

		private void TabControlDepartments_SelectedIndexChanged(object sender, EventArgs e) => LoadAuditoriumsPage((sender as TabControl)?.SelectedTab);

		/// <summary>
		/// Загрузка списка аудиторий
		/// </summary>
		/// <param name="page"></param>
		private void LoadAuditoriumsPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			var departemntId = new Guid(page.Name.Replace("tabPage", ""));

			try
			{
				var auditoriums = _service.GetList(new AuditoriumSearchModel { DepartmentId = departemntId });
				if (auditoriums == null)
				{
					return;
				}
				var dataGridView = Tools.CreateDataGridView("");
				dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(AuditoriumViewModel)), auditoriums);
				dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
				dataGridView.KeyDown += DataGridView_KeyDown;
				page.Controls.Add(dataGridView);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки аудиторий");
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
					if (grid.Parent is TabPage page)
					{
						form.DepartmentId = new Guid(page.Name.Replace("tabPage", ""));
					}
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadAuditoriumsPage(grid.Parent as TabPage);
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
								_service.DelElement(new AuditoriumSearchModel { Id = id });
								LoadAuditoriumsPage(grid.Parent as TabPage);
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
					LoadAuditoriumsPage(grid.Parent as TabPage);
				}
			}
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormAuditorium>();
			TabPage selPage = null;
			var page = tabControlEducationalBuildings.SelectedTab;
			if (page != null)
			{
				form.BuildingId = new Guid(page.Name.Replace("tabPage", ""));
				if (tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] is TabControl tab)
				{
					selPage = tab.SelectedTab;
					if (selPage != null)
					{
						form.DepartmentId = new Guid(selPage.Name.Replace("tabPage", ""));
					}
				}
			}
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (selPage != null)
				{
					LoadAuditoriumsPage(selPage);
				}
				else
				{
					LoadData();
				}
			}
		}

		private void ButtonUpdAuditorium_Click(object sender, EventArgs e)
		{
			if (tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] is TabControl tab)
			{
				OpenForm(tab.SelectedTab?.Controls["dataGridView"] as DataGridView);
			}
		}

		private void ButtonDelAuditorium_Click(object sender, EventArgs e)
		{
			if (Program.ShowQuestion("Удалить запись?") == DialogResult.Yes)
			{
				if (tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] is TabControl tab)
				{
					if (tab.SelectedTab?.Controls["dataGridView"] is DataGridView grid && grid.SelectedRows.Count == 1)
					{
						Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						try
						{
							_service.DelElement(new AuditoriumSearchModel { Id = id });
							LoadAuditoriumsPage(tab.SelectedTab);
						}
						catch (Exception ex)
						{
							Program.ShowError(ex, "Ошибка удаления");
						}
					}
				}
			}
		}
	}
}