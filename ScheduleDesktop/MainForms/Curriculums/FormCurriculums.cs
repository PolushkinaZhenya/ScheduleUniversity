using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormCurriculums : Form
    {
        private readonly IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel> _service;

        private readonly Lazy<List<AcademicYearViewModel>> _academicYears;

        public FormCurriculums(IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> serviceAY,
            IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel> service)
        {
            InitializeComponent();
            _academicYears = new Lazy<List<AcademicYearViewModel>>(() => { return serviceAY.GetList(); });
            _service = service;
        }

        private async void FormCurriculums_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                tabControlAcademicYears.TabPages.Clear();

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

                    var control = new UserControlCurriculumsForAcademicYear
                    {
                        Dock = DockStyle.Fill,
                        Name = $"UserControlCurriculumsForAcademicYear{academicYear.Id}"
                    };

                    page.Controls.Add(control);

                    if (tabControlAcademicYears.TabPages.Count == 0)
                    {
                        await control.LoadAuditoriumsAsync(academicYear.Id);
                    }
                    tabControlAcademicYears.TabPages.Add(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void TabControlAcademicYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            var page = tabControlAcademicYears.SelectedTab;
            if (page != null)
			{
                var academicYear = page.Name.Replace("tabPage", "");
                var control = page.Controls.Cast<UserControlCurriculumsForAcademicYear>()?.FirstOrDefault();
                if (control != null)
                {
                    await control.LoadAuditoriumsAsync(new Guid(academicYear));
                }
			}
        }

        private async void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormCurriculum>();
            var page = tabControlAcademicYears.SelectedTab;
            if (page != null)
            {
                var tab = page.Controls.Cast<UserControlCurriculumsForAcademicYear>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
                if (tab != null)
                {
                    var semester = tab.SelectedTab;
                    if (semester != null)
                    {
                        form.SemesterId = new Guid(semester.Name.Replace("tabPage", ""));
                    }
                }
            }
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadData();
            }
        }

        private async void ButtonUpd_Click(object sender, EventArgs e)
        {
            var page = tabControlAcademicYears.SelectedTab;
            if (page != null)
            {
                var tab = page.Controls.Cast<UserControlCurriculumsForAcademicYear>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
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
                                var form = DependencyManager.Instance.Resolve<FormCurriculum>();
                                form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    await LoadData();
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void ButtonDel_Click(object sender, EventArgs e)
        {
            if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
            {
                var page = tabControlAcademicYears.SelectedTab;
                if (page != null)
                {
                    var tab = page.Controls.Cast<UserControlCurriculumsForAcademicYear>().FirstOrDefault()?.Controls.Cast<TabControl>()?.FirstOrDefault();
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
                                        _service.DelElement(new CurriculumSearchModel { Id = id });
                                        await LoadData();
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