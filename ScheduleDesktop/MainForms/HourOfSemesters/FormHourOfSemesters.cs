using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormHourOfSemesters : Form
	{
		private readonly Lazy<List<FacultyViewModel>> _faculties;

		private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _serviceSG;

		private readonly IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel> _service;

		public FormHourOfSemesters(IBaseService<FacultyBindingModel, FacultyViewModel, FacultySearchModel> serviceF,
			IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> serviceSG,
			IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel> service)
		{
			InitializeComponent();
			_faculties = new Lazy<List<FacultyViewModel>>(() => { return serviceF.GetList(); });
			_serviceSG = serviceSG;
			_service = service;
		}

		private void FormHourOfSemesters_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
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

					var control = new UserControlCoursesForHourOfSemesters
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlCoursesForHourOfSemesters{faculty.Id}"
					};

					page.Controls.Add(control);

					if (tabControlFaculties.TabPages.Count == 0)
					{
						control.LoadFaculty(faculty.Id);
					}

					tabControlFaculties.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void TabControlFaculties_SelectedIndexChanged(object sender, EventArgs e)
		{
			var control = tabControlFaculties.SelectedTab?.Controls?.Cast<UserControlCoursesForHourOfSemesters>()?.FirstOrDefault();
			if (control != null)
			{
				try
				{
					var facultyId = new Guid(tabControlFaculties.SelectedTab.Name.Replace("tabPage", ""));
					control.LoadFaculty(facultyId);
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка загрузки страницы");
				}
			}
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				form.FacultyId = new Guid(page.Name.Replace("tabPage", ""));
				var tab = page.Controls.Cast<UserControlCoursesForHourOfSemesters>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
				if (tab != null)
				{
					if (tab.SelectedTab?.Controls?.Cast<UserControlStudentGroupsForHourOfSemester>()?.FirstOrDefault()?.Controls?.Find("listBoxStudentGroups", true)[0] is ListBox listbox && listbox.SelectedIndex > -1)
					{
						var sg = _serviceSG.GetElement(new StudyGroupSearchModel { Title = listbox.SelectedItem.ToString() });
						if (sg != null)
						{
							form.StudyGroupId = sg.Id;
						}
					}
				}
			}
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void ButtonUpd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				form.FacultyId = new Guid(page.Name.Replace("tabPage", ""));
				var tab = page.Controls.Cast<UserControlCoursesForHourOfSemesters>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
				if (tab != null)
				{
					if (tab.SelectedTab?.Controls?.Cast<UserControlStudentGroupsForHourOfSemester>()?.FirstOrDefault()?.Controls?.Find("listBoxStudentGroups", true)[0] is ListBox listbox && listbox.SelectedIndex > -1)
					{
						var sg = _serviceSG.GetElement(new StudyGroupSearchModel { Title = listbox.SelectedItem.ToString() });
						if (sg != null)
						{
							form.StudyGroupId = sg.Id;
						}
					}
					if (tab.SelectedTab?.Controls?.Cast<UserControlStudentGroupsForHourOfSemester>()?.FirstOrDefault()?.Controls?.Find("tabControlLoads", true)[0] is TabControl tab2)
					{
						var grid = tab2.SelectedTab?.Controls?.Cast<UserControlHourOfSemesters>()?.FirstOrDefault()?.Controls?.Cast<DataGridView>()?.FirstOrDefault();
						if (grid != null && grid.SelectedRows.Count == 1)
						{
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

		private void ButtonDel_Click(object sender, EventArgs e)
		{
			if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
			{
				var page = tabControlFaculties.SelectedTab;
				if (page != null)
				{
					var tab = page.Controls.Cast<UserControlCoursesForHourOfSemesters>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
					if (tab != null)
					{
						if (tab.SelectedTab?.Controls?.Cast<UserControlStudentGroupsForHourOfSemester>()?.FirstOrDefault()?.Controls?.Find("tabControlLoads", true)[0] is TabControl tab2)
						{
							var grid = tab2.SelectedTab?.Controls?.Cast<UserControlHourOfSemesters>()?.FirstOrDefault()?.Controls?.Cast<DataGridView>()?.FirstOrDefault();
							if (grid != null && grid.SelectedRows.Count == 1)
							{
								Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
								try
								{
									_service.DelElement(new HourOfSemesterSearchModel { Id = id });
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