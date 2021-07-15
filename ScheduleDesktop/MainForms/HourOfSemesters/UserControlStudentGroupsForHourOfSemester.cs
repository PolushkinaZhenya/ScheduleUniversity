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
	public partial class UserControlStudentGroupsForHourOfSemester : UserControl
	{
		private readonly IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel> serviceTC;

		private Guid? _facultyId = null;

		private List<StudyGroupViewModel> _groups;

		private readonly Lazy<List<TypeOfClassViewModel>> _typeClasses;

		public UserControlStudentGroupsForHourOfSemester()
		{
			InitializeComponent();
			serviceTC = DependencyManager.Instance.Resolve<IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel>>();
			_typeClasses = new Lazy<List<TypeOfClassViewModel>>(() => { return serviceTC.GetList(); });
		}

		public void LoadGroupsAsync(Guid facultyId, List<StudyGroupViewModel> groups)
		{
			_facultyId = facultyId;
			_groups = groups;

			LoadData();
		}

		private void LoadData()
		{
			if (!_facultyId.HasValue || _groups == null)
			{
				return;
			}

			try
			{
				listBoxStudentGroups.Items.Clear();
				listBoxStudentGroups.Items.AddRange(_groups.Select(x => x.Title).ToArray());
				if (listBoxStudentGroups.Items.Count > 0)
				{
					listBoxStudentGroups.SelectedIndex = 0;
				}

				LoadLoads();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}

		private void ListBoxStudentGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBoxStudentGroups.SelectedIndex == -1)
			{
				return;
			}
			LoadLoads();
		}

		private void LoadLoads()
		{
			try
			{
				var studyGroup = _groups.FirstOrDefault(x => x.Title == listBoxStudentGroups.SelectedItem.ToString());
				if (studyGroup == null)
				{
					Program.ShowError("Невозможно определить группу", "Ошибка получения данных");
					return;
				}
				tabControlLoads.TabPages.Clear();

				foreach (var typeClass in _typeClasses.Value)
				{
					var page = new TabPage
					{
						Name = $"tabPage{typeClass.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{typeClass.Title}",
						UseVisualStyleBackColor = true
					};
					
					var control = new UserControlHourOfSemesters
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlHourOfSemesters{typeClass.Id}"
					};

					page.Controls.Add(control);

					if (tabControlLoads.TabPages.Count == 0)
					{
						control.LoadData(studyGroup.Id, typeClass.Id);
					}

					tabControlLoads.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}

		private void TabControlLoads_SelectedIndexChanged(object sender, EventArgs e)
		{
			var page = tabControlLoads.SelectedTab;
			if (page != null)
			{
				var typeClass = page.Name.Replace("tabPage", "");
				var studyGroup = _groups.FirstOrDefault(x => x.Title == listBoxStudentGroups.SelectedItem.ToString());
				var control = page.Controls.Cast<UserControlHourOfSemesters>()?.FirstOrDefault();
				if (control != null)
				{
					control.LoadData(studyGroup.Id, new Guid(typeClass));
				}
			}
		}
	}
}