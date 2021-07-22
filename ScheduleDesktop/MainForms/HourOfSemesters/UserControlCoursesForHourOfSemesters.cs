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
	public partial class UserControlCoursesForHourOfSemesters : UserControl
	{
		private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _service;

		private Guid? _facultyId = null;

		private List<IGrouping<int, StudyGroupViewModel>> _groupbByCourses;

		public UserControlCoursesForHourOfSemesters()
		{
			InitializeComponent();
			_service = DependencyManager.Instance.Resolve<IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel>>();
		}

		public void LoadFaculty(Guid facultyId)
		{
			_facultyId = facultyId;
			LoadData();
		}

		private void LoadData()
		{
			if (!_facultyId.HasValue)
			{
				return;
			}

			try
			{
				_groupbByCourses = _service.GetList(new StudyGroupSearchModel { FacultyId = _facultyId.Value })?.GroupBy(x => x.Course)?.OrderBy(x => x.Key)?.ToList();
				if (_groupbByCourses == null || _groupbByCourses.Count == 0)
				{
					return;
				}

				tabControlCourses.TabPages.Clear();
				foreach (var groupCourse in _groupbByCourses)
				{
					var page = new TabPage
					{
						Name = $"tabPage{groupCourse.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"Курс {groupCourse.Key}",
						UseVisualStyleBackColor = true
					};

					var control = new UserControlStudentGroupsForHourOfSemester
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlStudentGroupsForHourOfSemester{_facultyId}{groupCourse.Key}"
					};

					page.Controls.Add(control);

					if (tabControlCourses.TabPages.Count == 0)
					{
						control.LoadGroupsAsync(_facultyId.Value, groupCourse.ToList());
					}

					tabControlCourses.TabPages.Add(page);

				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}

		private void TabControlCourses_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_groupbByCourses == null || !_facultyId.HasValue)
			{
				return;
			}

			var control = tabControlCourses.SelectedTab?.Controls?.Cast<UserControlStudentGroupsForHourOfSemester>()?.FirstOrDefault();
			if (control != null)
			{
				try
				{
					var course = tabControlCourses.SelectedTab.Name.Replace("tabPage", "");
					control.LoadGroupsAsync(_facultyId.Value, _groupbByCourses.FirstOrDefault(x => x.Key == int.Parse(course))?.ToList());
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка загрузки страницы");
				}
			}
		}
	}
}