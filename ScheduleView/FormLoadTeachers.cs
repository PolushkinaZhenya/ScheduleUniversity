using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;
using System.Configuration;
using ScheduleServiceDAL.BindingModels;

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

        private readonly IFlowService serviceF;

        UserControlDataGridView userControlDataGridView;

        UserControlDataGridViewAll userControlDataGridViewAll;

        TabControl tabControlTypeOfClass = new TabControl();

        Button buttonCourse;

        public FormLoadTeachers(ILoadTeacherService service, IStudyGroupService serviceSG, IAcademicYearService serviceAY,
            ISemesterService serviceS, IPeriodService serviceP, ITypeOfClassService serviceTC, IFlowService serviceF)
        {
            InitializeComponent();
            this.service = service;
            this.serviceSG = serviceSG;
            this.serviceAY = serviceAY;
            this.serviceS = serviceS;
            this.serviceP = serviceP;
            this.serviceTC = serviceTC;
            this.serviceF = serviceF;
        }

        private void FormLoadTeachers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Controls.Remove(tabControlTypeOfClass);

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
                tabControlTypeOfClass.Size = new Size(1300, 700);
                tabControlTypeOfClass.SelectedIndex = 0;
                tabControlTypeOfClass.TabIndex = 1;
                tabControlTypeOfClass.SelectedIndexChanged += new EventHandler(tabControlTypeOfClass_SelectedIndexChanged);

                //первая вкладка
                TabPage tabPageTC = new TabPage("ВСЕГО");
                tabPageTC.Tag = "ВСЕГО";
                //таблицу на вкладку
                userControlDataGridViewAll = new UserControlDataGridViewAll(listTC);
                userControlDataGridViewAll.RowClear();
                userControlDataGridViewAll.Location = new Point(7, 7);
                userControlDataGridViewAll.Size = new Size(1150, 332);
                userControlDataGridViewAll.Dock = DockStyle.Fill;
                userControlDataGridViewAll.Name = "ВСЕГО";

                tabPageTC.Controls.Add(userControlDataGridViewAll);//добавили таблицу
                tabControlTypeOfClass.TabPages.Add(tabPageTC);//добавили первую вкладку

                for (int j = 0; j < listTC.Count; j++)
                {
                    tabPageTC = new TabPage(listTC[j].AbbreviatedTitle);
                    tabPageTC.Tag = listTC[j].AbbreviatedTitle;
                    //таблицу на вкладку
                    userControlDataGridView = new UserControlDataGridView();
                    userControlDataGridView.RowClear();
                    userControlDataGridView.Location = new Point(7, 7);
                    userControlDataGridView.Size = new Size(1150, 332);
                    userControlDataGridView.Dock = DockStyle.Fill;
                    userControlDataGridView.Name = listTC[j].AbbreviatedTitle;

                    userControlDataGridView.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
                    userControlDataGridView.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);

                    tabPageTC.Controls.Add(userControlDataGridView);//добавили таблицу
                    tabControlTypeOfClass.TabPages.Add(tabPageTC);//добавили вкладку с типом
                }
                Controls.Add(tabControlTypeOfClass);//добавили весь Control с типами
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //двойное нажатие
        public void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGridViewSelect = sender as DataGridView;

            if (dataGridViewSelect.Columns[dataGridViewSelect.CurrentCell.ColumnIndex].Name == "1")
            {
                if (Int32.Parse(dataGridViewSelect["2", dataGridViewSelect.CurrentCell.RowIndex].Value.ToString()) > 1)
                {
                    UpdHoursWeeks(dataGridViewSelect, Int32.Parse(dataGridViewSelect["1", dataGridViewSelect.CurrentCell.RowIndex].Value.ToString()) + 2,
                        Int32.Parse(dataGridViewSelect["2", dataGridViewSelect.CurrentCell.RowIndex].Value.ToString()) - 2);
                }
            }
            else
            {
                if (dataGridViewSelect.Columns[dataGridViewSelect.CurrentCell.ColumnIndex].Name == "2")
                {
                    if (Int32.Parse(dataGridViewSelect["1", dataGridViewSelect.CurrentCell.RowIndex].Value.ToString()) > 1)
                    {
                        UpdHoursWeeks(dataGridViewSelect, Int32.Parse(dataGridViewSelect["1", dataGridViewSelect.CurrentCell.RowIndex].Value.ToString()) - 2,
                        Int32.Parse(dataGridViewSelect["2", dataGridViewSelect.CurrentCell.RowIndex].Value.ToString()) + 2);
                    }
                }
                else
                {
                    if (dataGridViewSelect.SelectedRows.Count == 1)
                    {
                        var form = Container.Resolve<FormLoadTeacher>();
                        form.Id = new Guid(dataGridViewSelect.SelectedRows[0].Cells[0].Value.ToString());
                        form.StudyGroupTitle = listBoxStudyGroups.SelectedItem.ToString();

                        DialogResult result = form.ShowDialog();

                        if ((result == DialogResult.OK || result == DialogResult.Cancel) && listBoxStudyGroups.SelectedItem != null)
                        {
                            LoadDataGridViewElse();
                        }
                    }
                }
            }
        }

        //одно нажание (для ComboBox)
        public void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGridViewSelect = sender as DataGridView;

            if (dataGridViewSelect.Columns[dataGridViewSelect.CurrentCell.ColumnIndex].Name == "Flow")
            {
                dataGridViewSelect.BeginEdit(true);
                ComboBox comboBox = (ComboBox)dataGridViewSelect.EditingControl;
                comboBox.DroppedDown = true;
            }
        }

        //изменение часов за недели
        private void UpdHoursWeeks(DataGridView dataGridViewSelect, int HoursFirstWeek, int HoursSecondWeek)//перезаписываем часы
        {
            LoadTeacherViewModel model = service.GetElement(new Guid(dataGridViewSelect.SelectedRows[0].Cells[0].Value.ToString()));

            LoadTeacherPeriodViewModel loadnew = service.GetLoadTeacherPeriodNew(new Guid(dataGridViewSelect.SelectedRows[0].Cells[0].Value.ToString()),
                new Guid(ConfigurationManager.AppSettings["IDPeriod"]));

            List<LoadTeacherPeriodViewModel> loadold = service.GetLoadTeacherPeriodOld(new Guid(dataGridViewSelect.SelectedRows[0].Cells[0].Value.ToString()),
                new Guid(ConfigurationManager.AppSettings["IDPeriod"]));

            List<LoadTeacherPeriodBindingModel> LoadTeacherPeriodBM = new List<LoadTeacherPeriodBindingModel>();

            for (int i = 0; i < loadold.Count; ++i) //добавляем обратно старые периоды
            {
                LoadTeacherPeriodBM.Add(new LoadTeacherPeriodBindingModel
                {
                    Id = loadold[i].Id,
                    LoadTeacherId = loadold[i].LoadTeacherId,
                    PeriodId = loadold[i].PeriodId,
                    TotalHours = loadold[i].TotalHours,
                    HoursFirstWeek = loadold[i].HoursFirstWeek,
                    HoursSecondWeek = loadold[i].HoursSecondWeek
                });
            }

            LoadTeacherPeriodBM.Add(new LoadTeacherPeriodBindingModel //добавляем обновенный период
            {
                Id = loadnew.Id,
                LoadTeacherId = loadnew.LoadTeacherId,
                PeriodId = loadnew.PeriodId,
                TotalHours = loadnew.TotalHours,
                HoursFirstWeek = HoursFirstWeek,
                HoursSecondWeek = HoursSecondWeek
            });

            List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriumVM = service.GetLoadTeacherAuditorium(new Guid(dataGridViewSelect.SelectedRows[0].Cells[0].Value.ToString()));
            List<LoadTeacherAuditoriumBindingModel> LoadTeacherAuditoriumBM = new List<LoadTeacherAuditoriumBindingModel>();
            for (int i = 0; i < LoadTeacherAuditoriumVM.Count; ++i)
            {
                LoadTeacherAuditoriumBM.Add(new LoadTeacherAuditoriumBindingModel
                {
                    Id = LoadTeacherAuditoriumVM[i].Id,
                    LoadTeacherId = LoadTeacherAuditoriumVM[i].LoadTeacherId,
                    AuditoriumId = LoadTeacherAuditoriumVM[i].AuditoriumId
                });
            }

            service.UpdElement(new LoadTeacherBindingModel
            {
                Id = model.Id,
                DisciplineId = model.DisciplineId,
                TypeOfClassId = model.TypeOfClassId,
                TeacherId = model.TeacherId,
                FlowId = model.FlowId,
                LoadTeacherPeriods = LoadTeacherPeriodBM,
                LoadTeacherAuditoriums = LoadTeacherAuditoriumBM,
                Reporting = model.Reporting,
                NumberOfSubgroups = model.NumberOfSubgroups
            });

            LoadDataGridViewElse();
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

            if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
            {
                UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы
                userControlDataGridViewSelect.RowClear();
            }
            else
            {
                UserControlDataGridViewAll userControlDataGridViewSelect = (UserControlDataGridViewAll)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы
                userControlDataGridViewSelect.RowClear();
            }
        }

        private void listBoxStudyGroups_SelectedIndexChanged(object sender, EventArgs e)
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

        private void tabControlTypeOfClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStudyGroups.SelectedIndex != -1 && ConfigurationManager.AppSettings["IDPeriod"] != "")
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

        private void LoadDataGridViewAll()//заполнение таблицы на вкладке ВСЕГО
        {
            try
            {
                //получение типов занятий
                List<TypeOfClassViewModel> listTC = serviceTC.GetList();

                //id группы
                Guid StudyGroupId = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;

                UserControlDataGridViewAll userControlDataGridViewSelect = (UserControlDataGridViewAll)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы
                userControlDataGridViewSelect.RowClear();

                int row = 0;

                for (int i = 0; i < listTC.Count; i++)
                {
                    List<LoadTeacherViewModel> list = service.GetListByTypeAndStudyGroupAndPeriod(listTC[i].AbbreviatedTitle,
                                        StudyGroupId, new Guid(ConfigurationManager.AppSettings["IDPeriod"]));

                    for (int j = 0; j < list.Count; j++)
                    {
                        int numderRow = userControlDataGridViewSelect.GetRowByDisciplineTitle(list[j].DisciplineTitle);

                        if (numderRow == -1)
                        {
                            userControlDataGridViewSelect.RowAdd();
                            userControlDataGridViewSelect.Value("Discipline", row, list[j].DisciplineTitle);//записываем дисциплину
                            userControlDataGridViewSelect.Value(listTC[i].AbbreviatedTitle, row, list[j].TotalHours.ToString());//записываем часы типа
                            //userControlDataGridViewSelect.Value("NumderOfHours", row, (userControlDataGridViewSelect.GetValue("NumderOfHours", row) + list[j].TotalHours).ToString());//записываем общие часы
                            userControlDataGridViewSelect.Value("Reporting", row, list[j].Reporting.Substring(0, list[j].Reporting.Length - 2));//записываем отчетность
                            row++;
                        }
                        else
                        {
                            userControlDataGridViewSelect.Value(listTC[i].AbbreviatedTitle, numderRow, list[j].TotalHours.ToString());//записываем часы типа
                            //userControlDataGridViewSelect.Value("NumderOfHours", numderRow,
                            //    (userControlDataGridViewSelect.GetValue("NumderOfHours", numderRow) + list[j].TotalHours).ToString());//записываем общие часы
                        }
                    }
                }
                //общие часы
                for (int i = 0; i < userControlDataGridViewSelect.dataGridView.RowCount; i++)
                {
                    int count = 0;
                    for (int j = 0; j < listTC.Count; j++)
                    {
                        count += userControlDataGridViewSelect.GetValue(listTC[j].AbbreviatedTitle, i);
                    }
                    userControlDataGridViewSelect.Value("NumderOfHours", i, count.ToString());//записываем общие часы
                }

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
                //id группы
                Guid StudyGroupId = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;

                //TabPage ti = tabControlTypeOfClass.SelectedTab as TabPage;//выбираю вкладку

                UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы
                userControlDataGridViewSelect.RowClear();
                //UserControlDataGridView userControlDataGridView2 = (UserControlDataGridView)test[0];//преобразование

                List<LoadTeacherViewModel> list = service.GetListByTypeAndStudyGroupAndPeriod(tabControlTypeOfClass.SelectedTab.Tag.ToString(),
                    StudyGroupId, new Guid(ConfigurationManager.AppSettings["IDPeriod"]));

                for (int i = 0; i < list.Count; i++)
                {
                    userControlDataGridViewSelect.RowAdd();
                    userControlDataGridViewSelect.Value("Id", i, list[i].Id.ToString());//записываем id
                    userControlDataGridViewSelect.Value("Discipline", i, list[i].DisciplineTitle);//записываем дисциплину
                    userControlDataGridViewSelect.Value("Teacher", i, list[i].TeacherSurname);//записываем преподавателя
                    userControlDataGridViewSelect.ValueFlow(i, serviceF.GetElement(list[i].FlowId).FlowStudyGroups);//записываем поток

                    FlowStudyGroupViewModel flow = serviceF.GetElement(list[i].FlowId).FlowStudyGroups.Where(rec => rec.FlowId == list[i].FlowId)
                    .Select(rec => new FlowStudyGroupViewModel
                    {
                        Subgroup = rec.Subgroup
                    }).FirstOrDefault();

                    //userControlDataGridViewSelect.Value("Flow", i, list[i].FlowTitle);//записываем поток
                    userControlDataGridViewSelect.Value("NumderOfHours", i, list[i].TotalHours.ToString());//записываем общие часы
                    userControlDataGridViewSelect.ValueHoursWeek(i, list[i].HoursFirstWeek.ToString(), list[i].HoursSecondWeek.ToString());//записываем часы понедельно

                    List<LoadTeacherAuditoriumViewModel> s = list[i].LoadTeacherAuditoriums.ToList();
                    for (int j = 0; j < s.Count; j++)
                    {
                        userControlDataGridViewSelect.Value("Auditorium" + (j + 1), i, s[j].AuditoriumTitle);//записываем аудитории
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
            if (listBoxStudyGroups.SelectedItem == null)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormLoadTeacher>();
                form.StudyGroupTitle = listBoxStudyGroups.SelectedItem.ToString();

                DialogResult result = form.ShowDialog();

                if ((result == DialogResult.OK || result == DialogResult.Cancel) && listBoxStudyGroups.SelectedItem != null)
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
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (tabControlTypeOfClass.SelectedTab.Tag.ToString() == "ВСЕГО")
            {
                MessageBox.Show("Перейдите на другую вкладку и выберите расчасовку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы

            if (userControlDataGridViewSelect.SelectedRowsCount() == 1)
            {
                var form = Container.Resolve<FormLoadTeacher>();
                form.Id = userControlDataGridViewSelect.GetId();
                form.StudyGroupTitle = listBoxStudyGroups.SelectedItem.ToString();

                DialogResult result = form.ShowDialog();

                if ((result == DialogResult.OK || result == DialogResult.Cancel) && listBoxStudyGroups.SelectedItem != null)
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
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (tabControlTypeOfClass.SelectedTab.Tag.ToString() == "ВСЕГО")
            {
                MessageBox.Show("Перейдите на другую вкладку и выберите расчасовку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы

            if (userControlDataGridViewSelect.SelectedRowsCount() == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        service.DelElement(userControlDataGridViewSelect.GetId());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
    }
}
