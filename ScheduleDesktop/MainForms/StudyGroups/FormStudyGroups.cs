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
	public partial class FormStudyGroups : Form
	{
		private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _service;

		private readonly Lazy<List<FacultyViewModel>> _faculties;

		public FormStudyGroups(IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> service, 
			IBaseService<FacultyBindingModel, FacultyViewModel, FacultySearchModel> serviceF)
		{
			InitializeComponent();
			_service = service;
			_faculties = new Lazy<List<FacultyViewModel>>(() => { return serviceF.GetList(); });
		}
		private void FormStudyGroups_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				var seletedTab = tabControlFaculties.SelectedTab?.Name;
				var seletedTabTab = tabControlFaculties.SelectedTab?.Controls?.Cast<UserControlStudyGroupsForFaculty>().FirstOrDefault()?.
																				Controls.Cast<TabControl>()?.FirstOrDefault()?.SelectedTab?.Name;
				var seletedId = tabControlFaculties.SelectedTab?.Controls?.Cast<UserControlStudyGroupsForFaculty>().FirstOrDefault()?.
																			Controls.Cast<TabControl>()?.FirstOrDefault()?.SelectedTab?.
																			Controls.Cast<DataGridView>()?.FirstOrDefault()?.SelectedRows[0]?.Cells[0]?.Value;

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

					var control = new UserControlStudyGroupsForFaculty
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlStudyGroupsForFaculty{faculty.Id}"
					};

					page.Controls.Add(control);

					if (tabControlFaculties.TabPages.Count == 0)
					{
						control.LoadGroupsAsync(faculty.Id);
					}

					tabControlFaculties.TabPages.Add(page);
				}

				var pageSel = tabControlFaculties.TabPages.IndexOfKey(seletedTab);
				if (pageSel > -1)
				{
					tabControlFaculties.SelectTab(pageSel);
					if (seletedTabTab.IsNotEmpty())
					{
						var tab = tabControlFaculties.SelectedTab?.Controls?.Cast<UserControlStudyGroupsForFaculty>().FirstOrDefault()?.
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
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void TabControlFaculties_SelectedIndexChanged(object sender, EventArgs e)
		{
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				var faculty = page.Name.Replace("tabPage", "");
				var control = page.Controls.Cast<UserControlStudyGroupsForFaculty>()?.FirstOrDefault();
				if (control != null)
				{
					control.LoadGroupsAsync(new Guid(faculty));
				}
			}
		}

		private void ButtonAddGroup_Click(object sender, EventArgs e)
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
				LoadData();
			}
		}

		private void ButtonUpdGroup_Click(object sender, EventArgs e)
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
								form.FacultyId = new Guid(page.Name.Replace("tabPage", ""));
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

		private void ButtonDelGroup_Click(object sender, EventArgs e)
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
										_service.DelElement(new StudyGroupSearchModel { Id = id });
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