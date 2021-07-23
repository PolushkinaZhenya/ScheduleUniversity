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
	public partial class FormCurriculums : Form
	{
		private readonly IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel> _service;

		private readonly Lazy<List<AcademicYearViewModel>> _academicYears;

		private List<IGrouping<Guid, CurriculumViewModel>> _groupbBySemesters;

		private Guid? _academicYearId = null;

		public FormCurriculums(IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> serviceAY,
			IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel> service)
		{
			InitializeComponent();
			_academicYears = new Lazy<List<AcademicYearViewModel>>(() => { return serviceAY.GetList(); });
			_service = service;
		}

		private void FormCurriculums_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			var seletedTab = tabControlAcademicYears.SelectedTab?.Name;
			var seletedTabTab = (tabControlAcademicYears.SelectedTab?.Controls["tabControlSemesters"] as TabControl)?.SelectedTab?.Name;
			var seletedId = ((tabControlAcademicYears.SelectedTab?.Controls["tabControlSemesters"] as TabControl)?.SelectedTab?.
																		Controls["dataGridView"] as DataGridView)?.SelectedRows[0]?.Cells[0]?.Value;
			tabControlAcademicYears.TabPages.Clear();
			try
			{
				if (_academicYears.Value == null)
				{
					Program.ShowError("Список учебных годов не получен", "Получение данных");
				}

				foreach (var academicYear in _academicYears.Value)
				{
					var page = new TabPage
					{
						Name = $"tabPage{academicYear.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{academicYear.Title}",
						UseVisualStyleBackColor = true
					};

					if (tabControlAcademicYears.TabPages.Count == 0)
					{
						LoadAcademicYearPage(page);
					}
					tabControlAcademicYears.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки данных");
			}

			var pageSel = tabControlAcademicYears.TabPages.IndexOfKey(seletedTab);
			if (pageSel > -1)
			{
				tabControlAcademicYears.SelectTab(pageSel);
				if (seletedTabTab.IsNotEmpty() && tabControlAcademicYears.SelectedTab?.Controls["tabControlSemesters"] is TabControl tab)
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

		private void TabControlAcademicYears_SelectedIndexChanged(object sender, EventArgs e) => LoadAcademicYearPage(tabControlAcademicYears.SelectedTab);

		/// <summary>
		/// Загрузка учебных планов учбеного года (TabControl с вкладками под каждый семестр)
		/// </summary>
		/// <param name="page"></param>
		private void LoadAcademicYearPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			_academicYearId = new Guid(page.Name.Replace("tabPage", ""));

			try
			{
				_groupbBySemesters = _service.GetList(new CurriculumSearchModel { AcademicYearId = _academicYearId.Value })?.
																		GroupBy(x => x.SemesterId)?.OrderBy(x => x.Key)?.ToList();
				if (_groupbBySemesters == null || _groupbBySemesters.Count == 0)
				{
					return;
				}

				var tabControlSemesters = new TabControl
				{
					Dock = DockStyle.Fill,
					Location = new Point(0, 0),
					Name = "tabControlSemesters",
					SelectedIndex = 0,
					Size = new Size(903, 597),
					TabIndex = 0
				};
				tabControlSemesters.SelectedIndexChanged += new EventHandler(TabControlSemesters_SelectedIndexChanged);

				foreach (var groupSemester in _groupbBySemesters)
				{
					var newPage = new TabPage
					{
						Name = $"tabPage{groupSemester.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{groupSemester.First()?.SemesterTitle}",
						UseVisualStyleBackColor = true
					};

					if (tabControlSemesters.TabPages.Count == 0)
					{
						LoadCurriculumsPage(newPage);
					}

					tabControlSemesters.TabPages.Add(newPage);
				}

				page.Controls.Add(tabControlSemesters);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка зарузки аудиторий");
			}
		}

		private void TabControlSemesters_SelectedIndexChanged(object sender, EventArgs e) => LoadCurriculumsPage((sender as TabControl)?.SelectedTab);

		/// <summary>
		/// Загрузка списка учебных планов семестра
		/// </summary>
		/// <param name="page"></param>
		private void LoadCurriculumsPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			var semesterId = new Guid(page.Name.Replace("tabPage", ""));

			try
			{
				var curriculums = _service.GetList(new CurriculumSearchModel { SemesterId = semesterId });
				if (curriculums == null)
				{
					return;
				}
				var dataGridView = Tools.CreateDataGridView("");
				dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(CurriculumViewModel)), curriculums);
				dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
				dataGridView.KeyDown += DataGridView_KeyDown;
				page.Controls.Add(dataGridView);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки учебных планов");
			}
		}

		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => OpenForm(sender as DataGridView);

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					var form = DependencyManager.Instance.Resolve<FormCurriculum>();
					if (grid.Parent is TabPage page)
					{
						form.SemesterId = new Guid(page.Name.Replace("tabPage", ""));
					}
					if (form.ShowDialog() == DialogResult.OK)
					{
						LoadCurriculumsPage(grid.Parent as TabPage);
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
								_service.DelElement(new CurriculumSearchModel { Id = id });
								LoadCurriculumsPage(grid.Parent as TabPage);
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
				var form = DependencyManager.Instance.Resolve<FormCurriculum>();
				form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadCurriculumsPage(grid.Parent as TabPage);
				}
			}
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormCurriculum>();
			TabPage selPage = null;
			var page = tabControlAcademicYears.SelectedTab;
			if (page != null)
			{
				if (tabControlAcademicYears.SelectedTab?.Controls["tabControlSemesters"] is TabControl tab)
				{
					selPage = tab.SelectedTab;
					if (selPage != null)
					{
						form.SemesterId = new Guid(selPage.Name.Replace("tabPage", ""));
					}
				}
			}
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (selPage != null)
				{
					LoadCurriculumsPage(selPage);
				}
				else
				{
					LoadData();
				}
			}
		}

		private void ButtonUpd_Click(object sender, EventArgs e)
		{
			if (tabControlAcademicYears.SelectedTab?.Controls["tabControlSemesters"] is TabControl tab)
			{
				OpenForm(tab.SelectedTab?.Controls["dataGridView"] as DataGridView);
			}
		}

		private void ButtonDel_Click(object sender, EventArgs e)
		{
			if (Program.ShowQuestion("Удалить запись?") == DialogResult.Yes)
			{
				if (tabControlAcademicYears.SelectedTab?.Controls["tabControlSemesters"] is TabControl tab)
				{
					if (tab.SelectedTab?.Controls["dataGridView"] is DataGridView grid && grid.SelectedRows.Count == 1)
					{
						Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						try
						{
							_service.DelElement(new CurriculumSearchModel { Id = id });
							LoadCurriculumsPage(tab.SelectedTab);
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