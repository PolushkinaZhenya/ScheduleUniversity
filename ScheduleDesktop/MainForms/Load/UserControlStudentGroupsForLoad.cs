using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlStudentGroupsForLoad : UserControl
	{
		private readonly IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel> serviceTC;

		private Guid? _facultyId = null;

		private List<StudyGroupViewModel> _groups;

		private readonly Lazy<List<TypeOfClassViewModel>> _typeClasses;

		public UserControlStudentGroupsForLoad()
		{
			InitializeComponent();
			serviceTC = DependencyManager.Instance.Resolve<IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel>>();
			_typeClasses = new Lazy<List<TypeOfClassViewModel>>(() => { return serviceTC.GetList(); });
		}

		public async Task LoadGroupsAsync(Guid facultyId, List<StudyGroupViewModel> groups)
		{
			_facultyId = facultyId;
			_groups = groups;
			await LoadData();
		}

		private async Task LoadData()
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

				await LoadLoads();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}

		private async void ListBoxStudentGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBoxStudentGroups.SelectedIndex == -1)
			{
				return;
			}
			await LoadLoads();
		}

		private async Task LoadLoads()
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
					
					var control = new UserControlLoads
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlLoads{typeClass.Id}"
					};

					page.Controls.Add(control);

					if (tabControlLoads.TabPages.Count == 0)
					{
						await control.LoadData(studyGroup.Id, typeClass.Id);
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
	}
}