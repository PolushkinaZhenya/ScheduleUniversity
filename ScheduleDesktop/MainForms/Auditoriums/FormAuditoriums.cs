using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormAuditoriums : Form
    {
        private readonly IAdditionalReference<EducationalBuildingBindingModel, EducationalBuildingViewModel> serviceEB;

        public FormAuditoriums(IAdditionalReference<EducationalBuildingBindingModel, EducationalBuildingViewModel> serviceEB)
        {
            InitializeComponent();
            this.serviceEB = serviceEB;
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
                var educationalBuildings = serviceEB.GetList();

                if (educationalBuildings == null)
                {
                    Program.ShowError("Список строений не получен", "Получение данных");
                }

                foreach (var educationalBuilding in educationalBuildings)
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
    }
}
