using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormStudyGroups : Form
	{
		private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _service;

		private readonly Lazy<List<FacultyViewModel>> _faculties;

		private List<IGrouping<int, StudyGroupViewModel>> _groupbByCourses;

		private Guid? _facultyId = null;

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
			var seletedTab = tabControlFaculties.SelectedTab?.Name;
			var seletedTabTab = (tabControlFaculties.SelectedTab?.Controls["tabControlCourses"] as TabControl)?.SelectedTab?.Name;
			var seletedId = ((tabControlFaculties.SelectedTab?.Controls["tabControlCourses"] as TabControl)?.SelectedTab?.
																		Controls["dataGridView"] as DataGridView)?.SelectedRows[0]?.Cells[0]?.Value;


			tabControlFaculties.TabPages.Clear();

			try
			{
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
						LoadCoursesPage(page);
					}

					tabControlFaculties.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}

			var pageSel = tabControlFaculties.TabPages.IndexOfKey(seletedTab);
			if (pageSel > -1)
			{
				tabControlFaculties.SelectTab(pageSel);
				if (seletedTabTab.IsNotEmpty() && tabControlFaculties.SelectedTab?.Controls["tabControlCourses"] is TabControl tab)
				{
					pageSel = tab.TabPages.IndexOfKey(seletedTabTab);
					if (pageSel > -1)
					{
						tab.SelectTab(pageSel);

						if (seletedId != null && tab.SelectedTab?.Controls["dataGridView"] is DataGridView grid)
						{
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

		private void TabControlFaculties_SelectedIndexChanged(object sender, EventArgs e) => LoadCoursesPage(tabControlFaculties.SelectedTab);

		/// <summary>
		/// Загрузка курсов факультета (TabControl с вкладками под каждую курсе)
		/// </summary>
		/// <param name="page"></param>
		private void LoadCoursesPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			_facultyId = new Guid(page.Name.Replace("tabPage", ""));

			try
			{
				_groupbByCourses = _service.GetList(new StudyGroupSearchModel { FacultyId = _facultyId.Value })?.
																		GroupBy(x => x.Course)?.OrderBy(x => x.Key)?.ToList();
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
						LoadStudyGroupsPage(newPage);
					}

					tabControlCourses.TabPages.Add(newPage);
				}

				page.Controls.Add(tabControlCourses);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки учебных групп");
			}
		}

		private void TabControlCourses_SelectedIndexChanged(object sender, EventArgs e) => LoadStudyGroupsPage((sender as TabControl)?.SelectedTab);

		/// <summary>
		/// Загрузка списка учебных групп
		/// </summary>
		/// <param name="page"></param>
		private void LoadStudyGroupsPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			var course = Convert.ToInt32(page.Name.Replace("tabPage", ""));

			try
			{
				var studyGroups = _service.GetList(new StudyGroupSearchModel { Course = course });
				if (studyGroups == null)
				{
					return;
				}
				var dataGridView = Tools.CreateDataGridView("");
				dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(StudyGroupViewModel)), studyGroups);
				dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
				dataGridView.KeyDown += DataGridView_KeyDown;
				page.Controls.Add(dataGridView);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки аудиторий");
			}
		}

		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => OpenForm(sender as DataGridView);

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
					if (_facultyId.HasValue)
					{
						form.FacultyId = _facultyId.Value;
					}
					if (grid.Parent is TabPage page)
					{
						form.Course = page.Name.Replace("tabPage", "");
					}
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadStudyGroupsPage(grid.Parent as TabPage);
					}
					break;
				case Keys.Enter: // изменить
					OpenForm(grid);
					break;
				case Keys.Delete: // удалить
					if (grid?.SelectedRows.Count == 1)
					{
						var id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (Program.ShowQuestion("Удалить запись?") == DialogResult.Yes)
						{
							try
							{
								_service.DelElement(new StudyGroupSearchModel { Id = id });
								LoadStudyGroupsPage(grid.Parent as TabPage);
							}
							catch (Exception ex)
							{
								Program.ShowError(ex, "Ошибка удаления");
							}
						}
					}
					break;
			}
		}

		private void OpenForm(DataGridView grid)
		{
			if (grid == null)
			{
				return;
			}

			if (grid.SelectedRows.Count == 1)
			{
				var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
				form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadStudyGroupsPage(grid.Parent as TabPage);
				}
			}
		}

		private void ButtonAddGroup_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
			TabPage selPage = null;
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				form.FacultyId = new Guid(page.Name.Replace("tabPage", ""));
				if (tabControlFaculties.SelectedTab?.Controls["tabControlCourses"] is TabControl tab)
				{
					selPage = tab.SelectedTab;
					if (selPage != null)
					{
						form.Course = selPage.Name.Replace("tabPage", "");
					}
				}
			}
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (selPage != null)
				{
					LoadStudyGroupsPage(selPage);
				}
				else
				{
					LoadData();
				}
			}
		}

		private void ButtonUpdGroup_Click(object sender, EventArgs e)
		{
			if (tabControlFaculties.SelectedTab?.Controls["tabControlCourses"] is TabControl tab)
			{
				OpenForm(tab.SelectedTab?.Controls["dataGridView"] as DataGridView);
			}
		}

		private void ButtonDelGroup_Click(object sender, EventArgs e)
		{
			if (Program.ShowQuestion("Удалить запись?") == DialogResult.Yes)
			{
				if (tabControlFaculties.SelectedTab?.Controls["tabControlCourses"] is TabControl tab)
				{
					if (tab.SelectedTab?.Controls["dataGridView"] is DataGridView grid && grid.SelectedRows.Count == 1)
					{
						Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						try
						{
							_service.DelElement(new StudyGroupSearchModel { Id = id });
							LoadStudyGroupsPage(tab.SelectedTab);
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