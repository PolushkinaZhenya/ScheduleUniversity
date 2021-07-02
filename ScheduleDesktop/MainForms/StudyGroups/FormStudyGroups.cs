using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormStudyGroups : Form
	{
		private readonly IAdditionalReference<FacultyBindingModel, FacultyViewModel> serviceF;

		public FormStudyGroups(IAdditionalReference<FacultyBindingModel, FacultyViewModel> serviceF)
		{
			InitializeComponent();
			this.serviceF = serviceF;
		}
		private async void FormStudyGroups_Load(object sender, EventArgs e)
		{
			await LoadData();
		}

		private async Task LoadData()
		{
			try
			{
				tabControlFaculties.TabPages.Clear();
				var faculties = serviceF.GetList();

				if (faculties == null)
				{
					Program.ShowError("Список факультетов не получен", "Получение данных");
				}
				foreach (var faculty in faculties)
				{
					var page = new TabPage
					{
						Name = $"tabPage{faculty.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{faculty.Title}",
						UseVisualStyleBackColor = true
					};
					tabControlFaculties.TabPages.Add(page);

					var control = new UserControlStudyGroupsForFaculty
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlStudyGroupsForFaculty{faculty.Id}"
					};

					page.Controls.Add(control);

					await control.LoadGroupsAsync(faculty.Id);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private async void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				form.FacultyId = new Guid(page.Name.Replace("tabPage", ""));
				var tab = page.Controls.Cast<UserControlStudyGroupsForFaculty>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
				if (tab != null)
				{
					var course = tab.SelectedTab;
					if (course != null)
					{
						form.Course = course.Name.Replace("tabPage", "");
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