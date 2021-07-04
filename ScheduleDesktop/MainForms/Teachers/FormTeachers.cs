using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormTeachers : Form
    {
        private readonly ITeacherService service;

        public FormTeachers(ITeacherService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private async void FormTeachers_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                tabControlTeachers.TabPages.Clear();
                var groupbByFirstLetter = await Task.Run(() => service.GetList()?.GroupBy(x => x.Surname[0])?.OrderBy(x => x.Key)?.ToList());
                if (groupbByFirstLetter == null || groupbByFirstLetter.Count == 0)
                {
                    return;
                }

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

                    var dataGridView = Tools.CreateDataGridView(groupTeacher.Key.ToString());
                    dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
                    dataGridView.KeyDown += DataGridView_KeyDown;

                    page.Controls.Add(dataGridView);
                    await Task.Run(() =>
                    {
                        dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(TeacherViewModel)), groupTeacher.ToList());
                    });

                    tabControlTeachers.TabPages.Add(page);
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка");
            }
        }

        private async Task AddTeacher()
        {
            var form = DependencyManager.Instance.Resolve<FormTeacher>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadData();
            }
        }

        private async Task UpdTeacher()
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
                            await LoadData();
                        }
                    }
                }
            }
        }

        private async Task DelTeacher()
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
                                service.DelElement(id);
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


        private async void ButtonAdd_Click(object sender, EventArgs e) => await AddTeacher();

		private async void ButtonUpd_Click(object sender, EventArgs e) => await UpdTeacher();

        private async void ButtonDel_Click(object sender, EventArgs e) => await DelTeacher();

        //открытие формы преподавателя
        private async void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => await UpdTeacher();

        private async void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space: // добавить
                    await AddTeacher();
                    break;
                case Keys.Enter: // изменить
                    await UpdTeacher();
                    break;
                case Keys.Delete: // удалить
                    await DelTeacher();
                    break;
            }
        }
    }
}