using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormTeachers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ITeacherService service;

        TabControl tabControlTeacher = new TabControl();

        public FormTeachers(ITeacherService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTeachers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Controls.Remove(tabControlTeacher);

                List<char> ABC = new List<char>() { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Э', 'Ю', 'Я' };

                //заполнение вкладок
                tabControlTeacher = new TabControl();
                tabControlTeacher.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tabControlTeacher.Location = new Point(10, 10);
                tabControlTeacher.Size = new Size(1400, 775);
                tabControlTeacher.SelectedIndex = 0;
                tabControlTeacher.TabIndex = 1;
                //tabControlTeacher.ItemSize = new Size(15, 20);
                tabControlTeacher.SelectedIndexChanged += new EventHandler(tabControlTeacher_SelectedIndexChanged);

                for (int i = 0; i < ABC.Count; i++)
                {
                    TabPage tabPage = new TabPage(ABC[i].ToString());
                    tabPage.Tag = ABC[i];

                    //таблицу для вкладки
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.Rows.Clear();
                    dataGridView.Location = new Point(10, 10);
                    dataGridView.Size = new Size(1150, 332);
                    dataGridView.Dock = DockStyle.Fill;
                    dataGridView.Name = ABC[i].ToString();
                    dataGridView.RowHeadersVisible = false;
                    dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;

                    dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseDoubleClick);

                    tabPage.Controls.Add(dataGridView);//добавили таблицу
                    tabControlTeacher.TabPages.Add(tabPage);//добавили вкладку
                }
                Controls.Add(tabControlTeacher);//добавили весь Control

                LoadDataGridViewSelect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //смена вкладки
        private void tabControlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridViewSelect();
        }

        //заполнение dataGridView на выбранной вкладке
        private void LoadDataGridViewSelect()
        {
            //поиск таблицы на выбранной вкладке
            DataGridView dataGridViewSelect = (DataGridView)(tabControlTeacher.SelectedTab as TabPage).Controls.Find(tabControlTeacher.SelectedTab.Tag.ToString(), true)[0];
            dataGridViewSelect.DataSource = null;

            List<TeacherViewModel> listTeacher = service.GetListByChar(dataGridViewSelect.Name);

            if (listTeacher != null)
            {
                dataGridViewSelect.DataSource = listTeacher;
                dataGridViewSelect.Columns[0].Visible = false;
                dataGridViewSelect.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTeacher>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDataGridViewSelect();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            //поиск таблицы на выбранной вкладке
            DataGridView dataGridViewSelect = (DataGridView)(tabControlTeacher.SelectedTab as TabPage).Controls.Find(tabControlTeacher.SelectedTab.Tag.ToString(), true)[0];

            if (dataGridViewSelect.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTeacher>();
                form.Id = (Guid)dataGridViewSelect.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDataGridViewSelect();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //поиск таблицы на выбранной вкладке
            DataGridView dataGridViewSelect = (DataGridView)(tabControlTeacher.SelectedTab as TabPage).Controls.Find(tabControlTeacher.SelectedTab.Tag.ToString(), true)[0];

            if (dataGridViewSelect.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid id = (Guid)dataGridViewSelect.SelectedRows[0].Cells[0].Value;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadDataGridViewSelect();
                }
            }
        }

        //открытие формы преподавателя
        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //поиск таблицы на выбранной вкладке
            DataGridView dataGridViewSelect = (DataGridView)(tabControlTeacher.SelectedTab as TabPage).Controls.Find(tabControlTeacher.SelectedTab.Tag.ToString(), true)[0];

            if (dataGridViewSelect.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTeacher>();
                form.Id = (Guid)dataGridViewSelect.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDataGridViewSelect();
                }
            }
        }
    }
}
