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
	public partial class FormAuditoriums : Form
    {
        private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _service;

        private readonly Lazy<List<EducationalBuildingViewModel>> _educationalBuildings;

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
            try
            {
                var seletedTab = tabControlEducationalBuildings.SelectedTab?.Name;
                var seletedTabTab = tabControlEducationalBuildings.SelectedTab?.Controls?.Cast<UserControlAuditoriumsForBuilding>().FirstOrDefault()?.
                                                                                Controls.Cast<TabControl>()?.FirstOrDefault()?.SelectedTab?.Name;
                var seletedId = tabControlEducationalBuildings.SelectedTab?.Controls?.Cast<UserControlAuditoriumsForBuilding>().FirstOrDefault()?.
                                                                            Controls.Cast<TabControl>()?.FirstOrDefault()?.SelectedTab?.
                                                                            Controls.Cast<DataGridView>()?.FirstOrDefault()?.SelectedRows[0]?.Cells[0]?.Value;

                tabControlEducationalBuildings.TabPages.Clear();

                if (_educationalBuildings.Value == null)
                {
                    Program.ShowError("Список строений не получен", "Получение данных");
                }

                foreach (var educationalBuilding in _educationalBuildings.Value)
                {
                    var page = new TabPage
                    {
                        Name = $"tabPage{educationalBuilding.Id}",
                        Padding = new Padding(3),
                        TabIndex = 0,
                        Text = $"{educationalBuilding.Number}",
                        UseVisualStyleBackColor = true
                    };

					var control = new UserControlAuditoriumsForBuilding
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlAuditoriumsForBuilding{educationalBuilding.Id}"
					};

					page.Controls.Add(control);

                    if (tabControlEducationalBuildings.TabPages.Count == 0)
                    {
                        control.LoadAuditoriumsAsync(educationalBuilding.Id);
                    }
                    tabControlEducationalBuildings.TabPages.Add(page);
                }

                var pageSel = tabControlEducationalBuildings.TabPages.IndexOfKey(seletedTab);
                if (pageSel > -1)
                {
                    tabControlEducationalBuildings.SelectTab(pageSel);
                    if (seletedTabTab.IsNotEmpty())
                    {
                        var tab = tabControlEducationalBuildings.SelectedTab?.Controls?.Cast<UserControlAuditoriumsForBuilding>().FirstOrDefault()?.
                                                                                                    Controls.Cast<TabControl>()?.FirstOrDefault();
                        pageSel = tab.TabPages.IndexOfKey(seletedTabTab);
                        if (pageSel > -1)
                        {
                            tab.SelectTab(pageSel);

                            if (seletedId != null)
                            {
                                var grid = tab.SelectedTab?.Controls.Cast<DataGridView>()?.FirstOrDefault();

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
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка при загрузке");
            }
        }

        private void TabControlEducationalBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            var page = tabControlEducationalBuildings.SelectedTab;
            if (page != null)
            {
                var educationalBuilding = page.Name.Replace("tabPage", "");
                var control = page.Controls.Cast<UserControlAuditoriumsForBuilding>()?.FirstOrDefault();
                if (control != null)
                {
                    control.LoadAuditoriumsAsync(new Guid(educationalBuilding));
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormAuditorium>();
            var page = tabControlEducationalBuildings.SelectedTab;
            if (page != null)
            {
                form.BuildingId = new Guid(page.Name.Replace("tabPage", ""));
                var tab = page.Controls.Cast<UserControlAuditoriumsForBuilding>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
                if (tab != null)
                {
                    var department = tab.SelectedTab;
                    if (department != null)
                    {
                        form.DepartmentId = new Guid(department.Name.Replace("tabPage", ""));
                    }
                }
            }
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

		private void ButtonUpdAuditorium_Click(object sender, EventArgs e)
		{
            var page = tabControlEducationalBuildings.SelectedTab;
            if (page != null)
            {
                var tab = page.Controls.Cast<UserControlAuditoriumsForBuilding>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
                if (tab != null)
                {
                    var course = tab.SelectedTab;
                    if (course != null)
                    {
                        var grid = course.Controls.Cast<DataGridView>()?.FirstOrDefault();
                        if (grid != null)
                        {
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
            }
        }

		private void ButtonDelAuditorium_Click(object sender, EventArgs e)
		{
            if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
            {
                var page = tabControlEducationalBuildings.SelectedTab;
                if (page != null)
                {
                    var tab = page.Controls.Cast<UserControlAuditoriumsForBuilding>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
                    if (tab != null)
                    {
                        var course = tab.SelectedTab;
                        if (course != null)
                        {
                            var grid = course.Controls.Cast<DataGridView>()?.FirstOrDefault();
                            if (grid != null)
                            {
                                if (grid.SelectedRows.Count == 1)
                                {
                                    Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
                                    try
                                    {
                                        _service.DelElement(new AuditoriumSearchModel { Id = id});
                                        LoadData();
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
        }
	}
}