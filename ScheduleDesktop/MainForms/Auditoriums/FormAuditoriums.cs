using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormAuditoriums : Form
    {
        private readonly IAuditoriumService service;

        private readonly Lazy<List<EducationalBuildingViewModel>> _educationalBuildings;

        public FormAuditoriums(IAuditoriumService service, IAdditionalReference<EducationalBuildingBindingModel, EducationalBuildingViewModel> serviceEB)
        {
            InitializeComponent();
            this.service = service;
            _educationalBuildings = new Lazy<List<EducationalBuildingViewModel>>(() => { return serviceEB.GetList(); });
        }

        private async void FormAuditoriums_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
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
                    tabControlEducationalBuildings.TabPages.Add(page);

					var control = new UserControlAuditoriumsForBuilding
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlAuditoriumsForBuilding{educationalBuilding.Id}"
					};

					page.Controls.Add(control);

					await control.LoadAuditoriumsAsync(educationalBuilding.Id);
				}
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка при загрузке");
            }
        }

        private async void ButtonAdd_Click(object sender, EventArgs e)
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
                await LoadData();
            }
        }

		private async void ButtonUpdAuditorium_Click(object sender, EventArgs e)
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
                                    await LoadData();
                                }
                            }
                        }
                    }
                }
            }
        }

		private async void ButtonDelAuditorium_Click(object sender, EventArgs e)
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
                                        service.DelElement(id);
                                        await LoadData();
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