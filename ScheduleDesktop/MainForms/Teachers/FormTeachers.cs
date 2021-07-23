using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormTeachers : Form
	{
		private readonly IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel> _service;

		public FormTeachers(IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel> service)
		{
			InitializeComponent();
			_service = service;
		}

		private void FormTeachers_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			var seletedTab = tabControlTeachers.SelectedTab?.Name;
			var seletedId = tabControlTeachers.SelectedTab?.Controls.Cast<DataGridView>()?.FirstOrDefault()?.SelectedRows[0]?.Cells[0]?.Value;

			tabControlTeachers.TabPages.Clear();
			var groupbByFirstLetter = _service.GetList()?.GroupBy(x => x.Surname[0])?.OrderBy(x => x.Key)?.ToList();
			if (groupbByFirstLetter == null || groupbByFirstLetter.Count == 0)
			{
				return;
			}

			try
			{
				foreach (var groupTeacher in groupbByFirstLetter)
				{
					var page = new TabPage
					{
						Name = $"tabPage{groupTeacher.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{groupTeacher.Key}",
						UseVisualStyleBackColor = true
					};

					if (tabControlTeachers.TabPages.Count == 0)
					{
						LoadTeachersPage(page);
					}

					tabControlTeachers.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
			var pageSel = tabControlTeachers.TabPages.IndexOfKey(seletedTab);
			if (pageSel > -1)
			{
				tabControlTeachers.SelectTab(pageSel);
				if (seletedTab != null)
				{
					var grid = tabControlTeachers.SelectedTab?.Controls.Cast<DataGridView>()?.FirstOrDefault();
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

		private void TabControlTeachers_SelectedIndexChanged(object sender, EventArgs e) => LoadTeachersPage(tabControlTeachers.SelectedTab);

		/// <summary>
		/// Загрузка списка преподавателей
		/// </summary>
		/// <param name="page"></param>
		private void LoadTeachersPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			var letter = page.Name.Replace("tabPage", "");

			try
			{
				var teachers = _service.GetList(new TeacherSearchModel { SurnameFirstLetter = letter });
				if (teachers == null)
				{
					return;
				}
				var dataGridView = Tools.CreateDataGridView("");
				dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(TeacherViewModel)), teachers);
				dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
				dataGridView.KeyDown += DataGridView_KeyDown;
				page.Controls.Add(dataGridView);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки аудиторий");
			}
		}

		private void AddTeacher()
		{
			var form = DependencyManager.Instance.Resolve<FormTeacher>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void UpdTeacher()
		{
			var page = tabControlTeachers.SelectedTab;
			if (page != null)
			{
				var grid = page.Controls.Cast<DataGridView>()?.FirstOrDefault();
				if (grid != null)
				{
					if (grid.SelectedRows.Count == 1)
					{
						var form = DependencyManager.Instance.Resolve<FormTeacher>();
						form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (form.ShowDialog() == DialogResult.OK)
						{
							LoadTeachersPage(tabControlTeachers.SelectedTab);
						}
					}
				}
			}
		}

		private void DelTeacher()
		{
			if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
			{
				var page = tabControlTeachers.SelectedTab;
				if (page != null)
				{
					var grid = page.Controls.Cast<DataGridView>()?.FirstOrDefault();
					if (grid != null)
					{
						if (grid.SelectedRows.Count == 1)
						{
							Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
							try
							{
								_service.DelElement(new TeacherSearchModel { Id = id });
								LoadTeachersPage(tabControlTeachers.SelectedTab);
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

		private void ButtonAdd_Click(object sender, EventArgs e) => AddTeacher();

		private void ButtonUpd_Click(object sender, EventArgs e) => UpdTeacher();

		private void ButtonDel_Click(object sender, EventArgs e) => DelTeacher();

		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => UpdTeacher();

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					AddTeacher();
					break;
				case Keys.Enter: // изменить
					UpdTeacher();
					break;
				case Keys.Delete: // удалить
					DelTeacher();
					break;
			}
		}
	}
}