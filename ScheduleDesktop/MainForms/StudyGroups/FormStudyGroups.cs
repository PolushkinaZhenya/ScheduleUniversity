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
	public partial class FormStudyGroups : Form
	{
		private readonly IStudyGroupService service;

		private readonly Lazy<List<FacultyViewModel>> _faculties;

		public FormStudyGroups(IStudyGroupService service, IAdditionalReference<FacultyBindingModel, FacultyViewModel> serviceF)
		{
			InitializeComponent();
			this.service = service;
			_faculties = new Lazy<List<FacultyViewModel>>(() => { return serviceF.GetList(); });
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

				if (_faculties.Value == null)
				{
					Program.ShowError("Список факультетов не получен", "Получение данных");
				}
				foreach (var faculty in _faculties.Value)
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

		private async void ButtonAddGroup_Click(object sender, EventArgs e)
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

		private async void ButtonUpdGroup_Click(object sender, EventArgs e)
		{
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				var tab = page.Controls.Cast<UserControlStudyGroupsForFaculty>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
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
								var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
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

		private async void ButtonDelGroup_Click(object sender, EventArgs e)
		{
			if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
			{
				var page = tabControlFaculties.SelectedTab;
				if (page != null)
				{
					var tab = page.Controls.Cast<UserControlStudyGroupsForFaculty>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
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