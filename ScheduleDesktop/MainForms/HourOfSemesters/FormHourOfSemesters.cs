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
	public partial class FormHourOfSemesters : Form
	{
		private readonly Lazy<List<FacultyViewModel>> _faculties;

		private readonly Lazy<List<TypeOfClassViewModel>> _typeClasses;

		private readonly IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel> _service;

		private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _serviceSG;

		private readonly IMainService _serviceM;

		private List<IGrouping<int, StudyGroupViewModel>> _studyGroupbByCourses;

		private List<StudyGroupViewModel> _studyGroupsByCourse;

		private readonly Guid? _periodId = null;

		private Guid? _studyGroupId = null;

		private Guid? _typeOfClassId = null;

		public FormHourOfSemesters(IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel> service,
			IBaseService<FacultyBindingModel, FacultyViewModel, FacultySearchModel> serviceF,
			IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> serviceSG,
			IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel> serviceTC,
			IMainService serviceM)
		{
			InitializeComponent();
			_service = service;
			_serviceSG = serviceSG;
			_serviceM = serviceM;
			_faculties = new Lazy<List<FacultyViewModel>>(() => { return serviceF.GetList(); });
			_typeClasses = new Lazy<List<TypeOfClassViewModel>>(() => { return serviceTC.GetList(); });
			if (Program.CurrentPeriod.IsNotEmpty())
			{
				var periodFromSettings = Program.ReadAppSettingConfig(Program.CurrentPeriod);
				if (periodFromSettings.IsNotEmpty())
				{
					_periodId = new Guid(periodFromSettings);
				}
			}
		}

		private void FormHourOfSemesters_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		/// <summary>
		/// Загрузка факультетов (TabControl с вкладками под каждый факультет)
		/// </summary>
		private void LoadData()
		{
			var seletedTab = tabControlFaculties.SelectedTab?.Name;
			var seletedTabTab = (tabControlFaculties.SelectedTab?.Controls["tabControlCourses"] as TabControl)?.SelectedTab?.Name;

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
						LoadFacultiesPage(page);
					}

					tabControlFaculties.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки факультетов");
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
					}
				}
			}
		}

		private void TabControlFaculties_SelectedIndexChanged(object sender, EventArgs e) => LoadFacultiesPage((sender as TabControl)?.SelectedTab);

		/// <summary>
		/// Загрухка курсов факультета (TabControl с вкладками под каждый курс)
		/// </summary>
		/// <param name="page"></param>
		private void LoadFacultiesPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();
			var facultyId = new Guid(page.Name.Replace("tabPage", ""));

			try
			{
				_studyGroupbByCourses = _serviceSG.GetList(new StudyGroupSearchModel { FacultyId = facultyId })?.GroupBy(x => x.Course)?.OrderBy(x => x.Key)?.ToList();
				if (_studyGroupbByCourses == null || _studyGroupbByCourses.Count == 0)
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

				foreach (var groupCourse in _studyGroupbByCourses)
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
				Program.ShowError(ex, "Ошибка зарузки курсов");
			}
		}

		private void TabControlCourses_SelectedIndexChanged(object sender, EventArgs e) => LoadCoursesPage((sender as TabControl)?.SelectedTab);

		/// <summary>
		/// Загрузка списка групп курса (ListBox со списком групп) и типов проводимых занятий (TabControl)
		/// </summary>
		/// <param name="page"></param>
		private void LoadCoursesPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();

			var tabControlTypeClasses = new TabControl
			{
				Dock = DockStyle.Fill,
				Location = new Point(0, 0),
				Name = "tabControlTypeClasses",
				SelectedIndex = 0,
				Size = new Size(903, 597),
				TabIndex = 0
			};
			tabControlTypeClasses.SelectedIndexChanged += new EventHandler(TabControlTypeClasses_SelectedIndexChanged);

			try
			{
				foreach (var typeClass in _typeClasses.Value)
				{
					var newPage = new TabPage
					{
						Name = $"tabPage{typeClass.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{typeClass.Title}",
						UseVisualStyleBackColor = true
					};
					newPage.Controls.Add(CreateDataGrid());
					tabControlTypeClasses.TabPages.Add(newPage);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки типов занятий");
			}

			page.Controls.Add(tabControlTypeClasses);

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

			_studyGroupsByCourse = _studyGroupbByCourses?.FirstOrDefault(x => x.Key == int.Parse(page.Name.Replace("tabPage", "")))?.ToList();
			if (_studyGroupsByCourse != null)
			{
				listBox.Items.AddRange(_studyGroupsByCourse.Select(x => x.Title).ToArray());
			}
			if (listBox.Items.Count > 0)
			{
				listBox.SelectedIndex = 0;
			}
		}

		private void TabControlTypeClasses_SelectedIndexChanged(object sender, EventArgs e) => LoadHoursOfSemestersByTypeClass((sender as TabControl)?.SelectedTab);

		private void LoadHoursOfSemestersByTypeClass(TabPage page)
		{
			if (!_studyGroupId.HasValue)
			{
				Program.ShowError("Не выбрана учебная группа", "Ошибка загрузки расчасовок");
				return;
			}
			if (!_periodId.HasValue)
			{
				Program.ShowError("Не выбран период", "Ошибка загрузки расчасовок");
				return;
			}
			if (page == null)
			{
				return;
			}
			if (page.Controls[0] is not DataGridView grid)
			{
				return;
			}
			grid.Rows.Clear();
			_typeOfClassId = new Guid(page.Name.Replace("tabPage", ""));
			try
			{
				var hours = _serviceM.GetHourOfSemestersPeriodRecords(new PeriodForHousOfSemesterBindingModel
				{
					StudyGroupId = _studyGroupId.Value,
					TypeOfClassId = _typeOfClassId.Value,
					PeriodId = _periodId.Value
				});
				foreach (var rec in hours.Where(x => x.HoursSecondWeek > 0 || x.HoursFirstWeek > 0))
				{
					grid.Rows.Add(new object[] {
						rec.HousOfSemesterId,
						rec.DisciplineTitle,
						rec.TeacherShortName,
						null,
						rec.SubgroupNumber?.ToString() ?? string.Empty,
						rec.TotalHours,
						rec.HourOfSemesterPeriodId,
						rec.HoursFirstWeek,
						rec.HoursSecondWeek,
						rec.Auditoriums
					});
					if (rec.Flows != null)
					{
						var dgvcbc = (DataGridViewComboBoxCell)grid.Rows[^1].Cells["Flow"];
						dgvcbc.Items.Clear();
						dgvcbc.Items.Add("Поток");
						foreach (object itemToAdd in rec.Flows)
						{
							dgvcbc.Items.Add(itemToAdd);
						}
						dgvcbc.Value = "Поток";
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}

		private void ListBoxStudentGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((sender as ListBox)?.SelectedIndex == -1)
			{
				return;
			}
			var studyGroup = _studyGroupsByCourse?.FirstOrDefault(x => x.Title == (sender as ListBox)?.SelectedItem.ToString());
			if (studyGroup == null)
			{
				Program.ShowError("Невозможно определить группу", "Ошибка получения данных");
				return;
			}
			_studyGroupId = studyGroup.Id;
			if ((sender as ListBox).Parent.Controls["tabControlTypeClasses"] is TabControl tab)
			{
				LoadHoursOfSemestersByTypeClass(tab.SelectedTab);
			}
		}

		private DataGridView CreateDataGrid()
		{
			var grid = new DataGridView
			{
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				AllowUserToResizeColumns = false,
				AllowUserToResizeRows = false,
				Dock = DockStyle.Fill,
				BackgroundColor = SystemColors.Window,
				ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
				Location = new Point(3, 3),
				Name = "dataGridView",
				RowHeadersVisible = false,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				Size = new Size(869, 232),
				TabIndex = 0
			};
			grid.RowTemplate.Height = 24;

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Id",
				Name = "Id",
				CellTemplate = new DataGridViewTextBoxCell(),
				Visible = false
			});
			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Дисциплина",
				Name = "Discipline",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 400,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Преподаватель",
				Name = "Teacher",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 300,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewComboBoxColumn
			{
				HeaderText = "Поток",
				Name = "Flow",
				CellTemplate = new DataGridViewComboBoxCell(),
				ReadOnly = false,
				Width = 120
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Подгр.",
				Name = "Subgroup",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 50,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Всего часов",
				Name = "NumderOfHours",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 80,
				ReadOnly = true
			});

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "HOSPeriodId",
				Name = "HOSPeriodId",
				CellTemplate = new DataGridViewTextBoxCell(),
				Visible = false
			});
			for (int i = 0; i < 2; i++)
			{
				grid.Columns.Add(new DataGridViewColumn
				{
					HeaderText = $"Кол-во пар на {i + 1}-й недели",
					Name = $"Week{(i + 1)}",
					CellTemplate = new DataGridViewTextBoxCell(),
					Width = 80,
					ReadOnly = true
				});
			}

			grid.Columns.Add(new DataGridViewColumn
			{
				HeaderText = "Аудитории",
				Name = "Auditoriums",
				CellTemplate = new DataGridViewTextBoxCell(),
				Width = 300,
				ReadOnly = true
			});

			grid.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
			grid.KeyDown += DataGridView_KeyDown;

			return grid;
		}

		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			var grid = sender as DataGridView;
			if (grid.Rows[e.RowIndex].Cells["HOSPeriodId"].Value == null)
			{
				Program.ShowError("Для периода неизвестен идентификатор", "Ошибка");
				return;
			}
			if (e.ColumnIndex == grid.Columns["Week1"].Index || e.ColumnIndex == grid.Columns["Week2"].Index)
			{
				bool haveChanges = false;
				var firstVal = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value);
				var secondVal = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value);
				if (e.ColumnIndex == grid.Columns["Week1"].Index && secondVal > 0)
				{
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value = ++firstVal;
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value = --secondVal;
					haveChanges = true;
				}
				else if (e.ColumnIndex == grid.Columns["Week2"].Index && firstVal > 0)
				{
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value = --firstVal;
					grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value = ++secondVal;
					haveChanges = true;
				}
				if (haveChanges)
				{
					_serviceM.UpdateHours(new UpdateHoursBindingModel
					{
						HourOfSemesterPeriodId = (Guid)grid.Rows[e.RowIndex].Cells["HOSPeriodId"].Value,
						FirstWeekCountLessons = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week1"].Index].Value),
						SecondWeekCountLessons = Convert.ToInt32(grid.Rows[e.RowIndex].Cells[grid.Columns["Week2"].Index].Value)
					});
				}
			}
			else if (grid.Rows[e.RowIndex].Cells["Id"].Value != null)
			{
				var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
				form.StudyGroupId = _studyGroupId.Value;
				form.Id = (Guid)grid.Rows[e.RowIndex].Cells["Id"].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadHoursOfSemestersByTypeClass(grid.Parent as TabPage);
				}
			}
		}

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					{
						var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
						form.StudyGroupId = _studyGroupId.Value;
						form.FacultyId = new Guid(Parent.Parent.Parent.Parent.Parent.Parent.Parent.Name.Replace("tabPage", ""));
						if (form.ShowDialog() == DialogResult.OK)
						{
							LoadHoursOfSemestersByTypeClass(grid.Parent as TabPage);
						}
					}
					break;
				case Keys.Enter: // изменить
					{
						var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
						form.StudyGroupId = _studyGroupId.Value;
						form.Id = (Guid)grid.SelectedRows[0].Cells["Id"].Value;
						if (form.ShowDialog() == DialogResult.OK)
						{
							LoadHoursOfSemestersByTypeClass(grid.Parent as TabPage);
						}
					}
					break;
				case Keys.Delete: // удалить
					if (grid?.SelectedRows.Count == 1)
					{
						var id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
						{
							try
							{
								_service.DelElement(new HourOfSemesterSearchModel { Id = id });
								LoadHoursOfSemestersByTypeClass(grid.Parent as TabPage);
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

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
			TabPage selPage = null;
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				form.FacultyId = new Guid(page.Name.Replace("tabPage", ""));
				if (_studyGroupId.HasValue)
				{
					form.StudyGroupId = _studyGroupId.Value;
				}
				else if (page.Controls["tabControlCourses"] is TabControl tab)
				{
					if (tab.SelectedTab?.Controls["listBoxStudentGroups"] is ListBox listbox && listbox.SelectedIndex > -1)
					{
						var sg = _serviceSG.GetElement(new StudyGroupSearchModel { Title = listbox.SelectedItem.ToString() });
						if (sg != null)
						{
							form.StudyGroupId = sg.Id;
						}
					}
					if (tab.SelectedTab?.Controls["tabControlTypeClasses"] is TabControl tab2)
					{
						selPage = tab2.SelectedTab;
					}
				}
			}
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (selPage != null)
				{
					LoadHoursOfSemestersByTypeClass(selPage);
				}
				else
				{
					LoadData();
				}
			}
		}

		private void ButtonUpd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormHourOfSemester>();
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				form.FacultyId = new Guid(page.Name.Replace("tabPage", ""));
				if (page.Controls["tabControlCourses"] is TabControl tab)
				{
					if (_studyGroupId.HasValue)
					{
						form.StudyGroupId = _studyGroupId.Value;
					}
					else if (tab.SelectedTab?.Controls["listBoxStudentGroups"] is ListBox listbox && listbox.SelectedIndex > -1)
					{
						var sg = _serviceSG.GetElement(new StudyGroupSearchModel { Title = listbox.SelectedItem.ToString() });
						if (sg != null)
						{
							form.StudyGroupId = sg.Id;
						}
					}
					if (tab.SelectedTab?.Controls?["tabControlTypeClasses"] is TabControl tab2)
					{
						if (tab2.SelectedTab?.Controls["dataGridView"] is DataGridView grid && grid.SelectedRows.Count == 1)
						{
							form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
							if (form.ShowDialog() == DialogResult.OK)
							{
								LoadHoursOfSemestersByTypeClass(tab2.SelectedTab);
							}
						}
					}
				}
			}
		}

		private void ButtonDel_Click(object sender, EventArgs e)
		{
			var page = tabControlFaculties.SelectedTab;
			if (page != null)
			{
				if (page.Controls["tabControlCourses"] is TabControl tab)
				{
					if (tab.SelectedTab?.Controls?["tabControlTypeClasses"] is TabControl tab2)
					{
						if (tab2.SelectedTab?.Controls["dataGridView"] is DataGridView grid && grid.SelectedRows.Count == 1)
						{
							if (Program.ShowQuestion("Удалить запись?") == DialogResult.Yes)
							{
								Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
								try
								{
									_service.DelElement(new HourOfSemesterSearchModel { Id = id });
									LoadHoursOfSemestersByTypeClass(tab2.SelectedTab);
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

		private void ButtonDuplicate_Click(object sender, EventArgs e)
		{
			if (textBoxStudyGroup.Text.IsNotEmpty())
			{
				var studyGroup = _serviceSG.GetElement(new StudyGroupSearchModel { Title = textBoxStudyGroup.Text });
				if (studyGroup == null)
				{
					Program.ShowError("Невозможно определить группу", "Ошибка получения данных");
					return;
				}
				var page = tabControlFaculties.SelectedTab;
				if (page != null)
				{
					if (page.Controls["tabControlCourses"] is TabControl tab)
					{
						if (tab.SelectedTab?.Controls?["tabControlTypeClasses"] is TabControl tab2)
						{
							if (tab2.SelectedTab?.Controls["dataGridView"] is DataGridView grid && grid.SelectedRows.Count == 1)
							{
								try
								{
									if (Program.ShowQuestion("Создать дубликат для этой группы?") == DialogResult.Yes)
									{
										Guid id = (Guid)grid.SelectedRows[0].Cells[0].Value;
										_serviceM.CreateDuplicateByHourOfSemesters(new CreateDuplicateByHOSBindingModel
										{
											HousOfSemesterId = id,
											StudyGroupId = studyGroup.Id
										});
										Program.ShowInfo("Дубликат создан", "Результат операции");
									}
								}
								catch (Exception ex)
								{
									Program.ShowError(ex, "Ошибка");
								}
							}
						}
					}
				}
			}
		}
	}
}