using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlScheduleStudentGroups : UserControl
	{
		private readonly Lazy<List<FacultyViewModel>> _faculties;

		private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _service;

		private List<IGrouping<int, StudyGroupViewModel>> _groupbByCourses;

		private List<StudyGroupViewModel> _studyGroups;

		public UserControlScheduleStudentGroups()
		{
			InitializeComponent();
			_faculties = new Lazy<List<FacultyViewModel>>(() => { return
				DependencyManager.Instance.Resolve<IBaseService<FacultyBindingModel, FacultyViewModel, FacultySearchModel>>().GetList(); });
			_service = DependencyManager.Instance.Resolve<IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel>>();
		}

		public void LoadData()
		{
			try
			{
				var seletedTab = tabControlFaculties.SelectedTab?.Name;

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

					if (tabControlFaculties.TabPages.Count == 0)
					{
						LoadFacultiesPage(page);
					}

					tabControlFaculties.TabPages.Add(page);
				}

				var pageSel = tabControlFaculties.TabPages.IndexOfKey(seletedTab);
				if (pageSel > -1)
				{
					tabControlFaculties.SelectTab(pageSel);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void TabControlFaculties_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				LoadFacultiesPage(tabControlFaculties.SelectedTab);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void LoadFacultiesPage(TabPage page)
		{
			try
			{
				if (page == null)
				{
					return;
				}
				page.Controls.Clear();
				var facultyId = new Guid(page.Name.Replace("tabPage", ""));

				_groupbByCourses = _service.GetList(new StudyGroupSearchModel { FacultyId = facultyId })?.GroupBy(x => x.Course)?.OrderBy(x => x.Key)?.ToList();
				if (_groupbByCourses == null || _groupbByCourses.Count == 0)
				{
					return;
				}

				var tabControlCourses = new TabControl
				{
					Dock = DockStyle.Fill,
					Location = new Point(0, 0),
					Name = "tabControlCourses",
					SelectedIndex = 0,
					Size = new Size(903, 597),
					TabIndex = 0
				};
				tabControlCourses.SelectedIndexChanged += new EventHandler(TabControlCourses_SelectedIndexChanged);

				foreach (var groupCourse in _groupbByCourses)
				{
					var newPage = new TabPage
					{
						Name = $"tabPage{groupCourse.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"Курс {groupCourse.Key}",
						UseVisualStyleBackColor = true
					};

					if (tabControlCourses.TabPages.Count == 0)
					{
						LoadCoursesPage(newPage);
					}

					tabControlCourses.TabPages.Add(newPage);
				}

				page.Controls.Add(tabControlCourses);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void TabControlCourses_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				LoadCoursesPage((sender as TabControl)?.SelectedTab);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void LoadCoursesPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();

			var panel = new Panel
			{
				Dock = DockStyle.Fill,
				TabIndex = 1,
				Name = "panelContent"
			};
			page.Controls.Add(panel);

			var listBox = new ListBox
			{
				Dock = DockStyle.Right,
				FormattingEnabled = true,
				ItemHeight = 15,
				Location = new Point(826, 0),
				Name = "listBox",
				Size = new Size(167, 701),
				TabIndex = 0
			};
			page.Controls.Add(listBox);
			listBox.SelectedIndexChanged += new EventHandler(ListBoxStudentGroups_SelectedIndexChanged);

			_studyGroups = _groupbByCourses.FirstOrDefault(x => x.Key == int.Parse(page.Name.Replace("tabPage", "")))?.ToList();
			listBox.Items.AddRange(_studyGroups.Select(x => x.Title).ToArray());
			if (listBox.Items.Count > 0)
			{
				listBox.SelectedIndex = 0;
			}
		}

		private void ListBoxStudentGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((sender as ListBox)?.SelectedIndex == -1)
			{
				return;
			}
			try
			{
				var studyGroup = _studyGroups.FirstOrDefault(x => x.Title == (sender as ListBox)?.SelectedItem.ToString());
				if (studyGroup == null)
				{
					Program.ShowError("Невозможно определить группу", "Ошибка получения данных");
					return;
				}
				var panel = (sender as ListBox).Parent.Controls.Find("panelContent", true).FirstOrDefault();
				if (panel != null)
				{
					panel.Controls.Clear();
					var control = new UserControlScheduleStudentGroup()
					{
						Dock = DockStyle.Fill,
						Name = "UserControlScheduleStudentGroup"
					};
					control.SetStudyGroupId(studyGroup.Id);
					panel.Controls.Add(control);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}
	}
}