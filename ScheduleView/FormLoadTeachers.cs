using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormLoadTeachers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ILoadTeacherService service;

        private readonly IStudyGroupService serviceSG;

        private readonly IAcademicYearService serviceAY;

        private readonly ISemesterService serviceS;

        private readonly IPeriodService serviceP;

        private readonly ITypeOfClassService serviceTC;

        UserControlDataGridView userControlDataGridView;

        TabControl tabControlTypeOfClass = new TabControl();

        Button buttonCourse;

        public FormLoadTeachers(ILoadTeacherService service, IStudyGroupService serviceSG, IAcademicYearService serviceAY,
            ISemesterService serviceS, IPeriodService serviceP, ITypeOfClassService serviceTC)
        {
            InitializeComponent();
            this.service = service;
            this.serviceSG = serviceSG;
            this.serviceAY = serviceAY;
            this.serviceS = serviceS;
            this.serviceP = serviceP;
            this.serviceTC = serviceTC;
        }

        private void FormLoadTeachers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                listBoxStudyGroups.Items.Clear();

                //добавление кнопок курсов
                List<StudyGroupViewModel> listCourse = serviceSG.GetListCourse();
                for (int i = 0; i < listCourse.Count; i++)
                {
                    buttonCourse = new Button();
                    buttonCourse.Location = new Point(i * 90 + 20, 20);
                    buttonCourse.Name = "buttonCourse" + listCourse[i].Course;
                    buttonCourse.Size = new Size(70, 40);
                    buttonCourse.Text = listCourse[i].Course + " курс";
                    buttonCourse.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    buttonCourse.Click += new EventHandler(buttonCourse_Click);
                    buttonCourse.Tag = listCourse[i].Course;

                    Controls.Add(buttonCourse);//добавили кнопку
                }

                //заполнение групп
                List<StudyGroupViewModel> list = serviceSG.GetListByCourse(1);
                for (int i = 0; i < list.Count; i++)
                {
                    listBoxStudyGroups.Items.Add(list[i].Title);
                }

                //получение типов занятий
                List<TypeOfClassViewModel> listTC = serviceTC.GetList();

                //заполнение вкладок типов занятий
                tabControlTypeOfClass = new TabControl();
                tabControlTypeOfClass.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tabControlTypeOfClass.Location = new Point(10, 70);
                tabControlTypeOfClass.Size = new Size(1270, 362);
                tabControlTypeOfClass.SelectedIndex = 0;
                tabControlTypeOfClass.TabIndex = 1;
                tabControlTypeOfClass.SelectedIndexChanged += new EventHandler(tabControlTypeOfClass_SelectedIndexChanged);

                //первая вкладка
                TabPage tabPageTC = new TabPage("ВСЕГО");
                tabPageTC.Tag = "ВСЕГО";
                //таблицу на вкладку
                userControlDataGridView = new UserControlDataGridView();
                userControlDataGridView.Location = new Point(7, 7);
                userControlDataGridView.Size = new Size(1150, 332);
                userControlDataGridView.Dock = DockStyle.Fill;
                userControlDataGridView.Name = "ВСЕГО";

                tabPageTC.Controls.Add(userControlDataGridView);//добавили таблицу
                tabControlTypeOfClass.TabPages.Add(tabPageTC);//добавили первую вкладку

                for (int j = 0; j < listTC.Count; j++)
                {
                    tabPageTC = new TabPage(listTC[j].AbbreviatedTitle);
                    tabPageTC.Tag = listTC[j].AbbreviatedTitle;
                    //таблицу на вкладку
                    userControlDataGridView = new UserControlDataGridView();
                    userControlDataGridView.Location = new Point(7, 7);
                    userControlDataGridView.Size = new Size(1150, 332);
                    userControlDataGridView.Dock = DockStyle.Fill;
                    userControlDataGridView.Name = listTC[j].AbbreviatedTitle;
                    tabPageTC.Controls.Add(userControlDataGridView);//добавили таблицу

                    tabControlTypeOfClass.TabPages.Add(tabPageTC);//добавили вкладку с типом
                }

                Controls.Add(tabControlTypeOfClass);//добавили весь Control с типами

                List<AcademicYearViewModel> listAY = serviceAY.GetList();
                if (listAY != null)
                {
                    comboBoxAcademicYear.DisplayMember = "Title";
                    comboBoxAcademicYear.ValueMember = "Id";
                    comboBoxAcademicYear.DataSource = listAY;
                    comboBoxAcademicYear.SelectedItem = null;
                }

                comboBoxSemester.Items.Clear();
                comboBoxPeriod.Items.Clear();

                List<LoadTeacherViewModel> list1 = service.GetList();
                if (list1 != null)
                {
                    dataGridView.DataSource = list1;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[7].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCourse_Click(object sender, EventArgs e)
        {
            listBoxStudyGroups.Items.Clear();

            Button buttonSelect = sender as Button;

            List<StudyGroupViewModel> list = serviceSG.GetListByCourse(Int32.Parse(buttonSelect.Tag.ToString()));
            for (int i = 0; i < list.Count; i++)
            {
                listBoxStudyGroups.Items.Add(list[i].Title);
            }
        }

        private void listBoxStudyGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPeriod.SelectedValue != null)
            {
                if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
                {
                    LoadDataGridViewElse();
                }
                else
                {
                    LoadDataGridViewAll();
                }
            }
            else
            {
                MessageBox.Show("Выберите период", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControlTypeOfClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            object i = listBoxStudyGroups.SelectedIndex;
            object j = comboBoxPeriod.SelectedValue;

            if (listBoxStudyGroups.SelectedIndex != -1 && comboBoxPeriod.SelectedValue != null)
            {
                if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
                {
                    LoadDataGridViewElse();
                }
                else
                {
                    LoadDataGridViewAll();
                }
            }
        }

        private void LoadDataGridViewAll()//заполненрие таблицы на вкладке ВСЕГО
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataGridViewElse()//заполнение таблицы на остальных вкладках
        {
            try
            {
                Guid StudyGroupId = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;

                //TabPage ti = tabControlTypeOfClass.SelectedTab as TabPage;//выбираю вкладку

                UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы
                userControlDataGridViewSelect.RowClear();
                //UserControlDataGridView userControlDataGridView2 = (UserControlDataGridView)test[0];//преобразование
                
                List<LoadTeacherViewModel> list = service.GetListByTypeAndStudyGroupAndPeriod(tabControlTypeOfClass.SelectedTab.Tag.ToString(),
                    StudyGroupId, (Guid)comboBoxPeriod.SelectedValue);

                for (int i = 0; i < list.Count; i++)
                {
                    userControlDataGridViewSelect.RowAdd();
                    userControlDataGridViewSelect.Value("Discipline", i, list[i].DisciplineTitle);
                    userControlDataGridViewSelect.Value("Teacher", i, list[i].TeacherSurname);
                    userControlDataGridViewSelect.Value("NumderOfHours", i, list[i].NumderOfHours.ToString());

                    List<LoadTeacherAuditoriumViewModel> s = list[i].LoadTeacherAuditoriums.ToList();
                    for (int j = 0; j < s.Count; j++)
                    {
                        userControlDataGridViewSelect.Value("Auditorium" + (j + 1), i, s[j].AuditoriumTitle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLoadTeacher>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacher>();
                Guid id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                form.Id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void listBoxStudyGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxStudyGroups.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<FormStudyGroup>();
                form.Id = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void comboBoxAcademicYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBoxSemester.DataSource = null;
            comboBoxPeriod.DataSource = null;

            Guid AcademicYearId = (Guid)comboBoxAcademicYear.SelectedValue;

            List<SemesterViewModel> list = serviceS.GetListByAcademicYear(AcademicYearId);
            if (list != null)
            {
                comboBoxSemester.DisplayMember = "Title";
                comboBoxSemester.ValueMember = "Id";
                comboBoxSemester.DataSource = list;
                comboBoxSemester.SelectedItem = null;
            }
        }

        private void comboBoxSemester_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBoxPeriod.DataSource = null;

            Guid SemesterId = (Guid)comboBoxSemester.SelectedValue;

            List<PeriodViewModel> list = serviceP.GetListBySemester(SemesterId);
            if (list != null)
            {
                comboBoxPeriod.DisplayMember = "Title";
                comboBoxPeriod.ValueMember = "Id";
                comboBoxPeriod.DataSource = list;
                comboBoxPeriod.SelectedItem = null;
            }
        }
    }
}
