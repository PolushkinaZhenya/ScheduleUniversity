using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlStudyGroupsForFaculty : UserControl
	{
		private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _service;

		private Guid? _facultyId = null;

		public UserControlStudyGroupsForFaculty()
		{
			InitializeComponent();
			_service = DependencyManager.Instance.Resolve<IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel>>();
		}

		public void LoadGroupsAsync(Guid facultyId)
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
				var groupbByCourses = _service.GetList(new StudyGroupSearchModel { FacultyId = _facultyId.Value })?.GroupBy(x => x.Course)?.OrderBy(x => x.Key)?.ToList();
				if (groupbByCourses == null || groupbByCourses.Count == 0)
				{
					return;
				}

				tabControlCourses.TabPages.Clear();
				foreach (var groupCourse in groupbByCourses)
				{
					var page = new TabPage
					{
						Name = $"tabPage{groupCourse.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"Курс {groupCourse.Key}",
						UseVisualStyleBackColor = true
					};

					var dataGridView = Tools.CreateDataGridView(groupCourse.Key.ToString());
					dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
					dataGridView.KeyDown += DataGridView_KeyDown;

					page.Controls.Add(dataGridView);
					dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(StudyGroupViewModel)), groupCourse.ToList());

					tabControlCourses.TabPages.Add(page);
				}
			}
			catch(Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
			
			SetFocusToGrid(tabControlCourses.SelectedTab);
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
					var page = tabControlCourses.SelectedTab;
					if (page != null)
					{
						form.Course = page.Name.Replace("tabPage", "");
					}
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadData();
					}
					break;
				case Keys.Enter: // изменить
					OpenForm(grid);
					break;
				case Keys.Delete: // удалить
					if (grid?.SelectedRows.Count == 1)
					{
						var id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
						{
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
					LoadData();
				}
			}
		}

		private void TabControlCourses_SelectedIndexChanged(object sender, EventArgs e) => SetFocusToGrid(tabControlCourses.SelectedTab);

		private static void SetFocusToGrid(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			var grid = page.Controls.Cast<DataGridView>().FirstOrDefault();
			if (grid != null)
			{
				grid.Focus();
			}

		}
	}
}