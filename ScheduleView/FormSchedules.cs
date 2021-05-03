using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;
using System.Configuration;
using ScheduleModel;
using ScheduleServiceDAL.BindingModels;

namespace ScheduleView
{
    public partial class FormSchedules : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IScheduleService service;

        private readonly IStudyGroupService serviceSG;

        private readonly IClassTimeService serviceCT;

        private readonly IPeriodService serviceP;

        private readonly ILoadTeacherService serviceLT;

        private readonly IAuditoriumService serviceA;

        private readonly IFlowService serviceF;

        Button buttonCourse;

        UserControlDataGridViewSchedule userControlFirstWeek;

        UserControlDataGridViewSchedule userControlSecondWeek;

        public FormSchedules(IScheduleService service, IStudyGroupService serviceSG, IClassTimeService serviceCT, IPeriodService serviceP,
            ILoadTeacherService serviceLT, IAuditoriumService serviceA, IFlowService serviceF)
        {
            InitializeComponent();
            this.service = service;
            this.serviceSG = serviceSG;
            this.serviceCT = serviceCT;
            this.serviceP = serviceP;
            this.serviceLT = serviceLT;
            this.serviceA = serviceA;
            this.serviceF = serviceF;
        }

        private void FormSchedules_Load(object sender, EventArgs e)
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
                List<StudyGroupViewModel> listSG = serviceSG.GetListByCourse(1);
                for (int i = 0; i < listSG.Count; i++)
                {
                    listBoxStudyGroups.Items.Add(listSG[i].Title);
                }

                userControlFirstWeek = new UserControlDataGridViewSchedule();
                userControlFirstWeek.Clear();
                userControlFirstWeek.Dock = DockStyle.Fill;
                userControlFirstWeek.Name = "1";
                userControlFirstWeek.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userControlFirstWeek_CellMouseDoubleClick);
                splitContainer2.Panel1.Controls.Add(userControlFirstWeek);

                userControlSecondWeek = new UserControlDataGridViewSchedule();
                userControlSecondWeek.Clear();
                userControlSecondWeek.Dock = DockStyle.Fill;
                userControlSecondWeek.Name = "2";
                userControlSecondWeek.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userControlSecondWeek_CellMouseDoubleClick);
                splitContainer2.Panel2.Controls.Add(userControlSecondWeek);

                LoadDataGridViewsEmpty();

                List<string> type = new List<string>() { "Учебные занятия", "Сессия" };
                comboBoxType.DataSource = type;
                comboBoxType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //смена типа занятия
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //двойное нажатие по таблице 1й недели
        public void userControlFirstWeek_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AddSchedule(userControlFirstWeek);
            ScheduleLoad();
        }

        //двойное нажатие по таблице 2й недели
        public void userControlSecondWeek_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AddSchedule(userControlSecondWeek);
            ScheduleLoad();
        }

        public void AddSchedule(UserControlDataGridViewSchedule userControl)
        {
            if (userControl.dataGridView.SelectedCells.Count == 1 && dataGridViewAll.SelectedRows.Count == 1)
            {
                ScheduleViewModel schedule = service.GetElement((Guid)dataGridViewAll.SelectedRows[0].Cells[0].Value);//занятие
                LoadTeacherViewModel loadTeacher = serviceLT.GetElement(schedule.LoadTeacherId);//расчасовка занятия

                int row = userControl.dataGridView.SelectedCells[0].RowIndex;
                int column = userControl.dataGridView.SelectedCells[0].ColumnIndex;
                string tag = userControl.dataGridView[column, row].Tag.ToString();

                if (tag == "Поток")
                {
                    MessageBox.Show("Группы потока заняты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (tag == "Препод")
                {
                    MessageBox.Show("Преподаватель занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (tag == "Ауд")
                {
                    List<LoadTeacherAuditoriumViewModel> loadTeacherAuditorium = loadTeacher.LoadTeacherAuditoriums;//аудитории расчасовки
                    int Week = Int32.Parse(userControl.Name);
                    //все пары недели
                    List<ScheduleViewModel> schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Week);

                    bool busy = false;
                    for (int i = 0; i < loadTeacherAuditorium.Count; i++)
                    {
                        busy = false;
                        for (int j = 0; j < schedulesByPeriodAndWeek.Count; j++)
                        {
                            if (loadTeacherAuditorium[i].AuditoriumId == schedulesByPeriodAndWeek[j].AuditoriumId
                                && schedule.NumberWeeks == schedulesByPeriodAndWeek[j].NumberWeeks
                                && (DayOfTheWeek)row + 1 == schedulesByPeriodAndWeek[j].DayOfTheWeek
                                && serviceCT.GetElementByNumber(column).Id == schedulesByPeriodAndWeek[j].ClassTimeId)
                            {
                                MessageBox.Show("Все занято для ауд " + loadTeacherAuditorium[i].AuditoriumTitle, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                busy = true;
                            }
                        }
                        if (!busy)
                        {
                            List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                            for (int k = 0; k < flow.Count; k++)
                            {
                                //ищем нерасставленные пары
                                ScheduleViewModel model = service.GetElementByParam(schedule.PeriodId, schedule.NumberWeeks, flow[k].StudyGroupId, flow[k].Subgroup, schedule.LoadTeacherId);

                                //записываем для всех групп потока
                                service.UpdElement(new ScheduleBindingModel
                                {
                                    Id = model.Id,
                                    PeriodId = model.PeriodId,
                                    NumberWeeks = model.NumberWeeks,
                                    DayOfTheWeek = (DayOfTheWeek)row + 1,
                                    ClassTimeId = serviceCT.GetElementByNumber(column).Id,
                                    StudyGroupId = model.StudyGroupId,
                                    Subgroups = model.Subgroups,
                                    AuditoriumId = loadTeacherAuditorium[i].AuditoriumId,
                                    LoadTeacherId = model.LoadTeacherId,
                                    Type = model.Type
                                });
                            }
                            return;
                        }
                    }
                    //все занято, ставим в рандомную аудиторию
                    if (busy)
                    {
                        if (MessageBox.Show("Все аудитории из расчасовки заняты, ставить в рандомную?", "Вопрос", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            
                        }
                    }
                }

                if (tag == "Свободно" && schedule.NumberWeeks == Int32.Parse(userControl.Name))
                {
                    List<LoadTeacherAuditoriumViewModel> loadTeacherAuditorium = loadTeacher.LoadTeacherAuditoriums;//аудитории расчасовки

                    List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                    for (int i = 0; i < flow.Count; i++)
                    {
                        //ищем нерасставленные пары
                        ScheduleViewModel model = service.GetElementByParam(schedule.PeriodId, schedule.NumberWeeks, flow[i].StudyGroupId, flow[i].Subgroup, schedule.LoadTeacherId);

                        //записываем для всех групп потока
                        service.UpdElement(new ScheduleBindingModel
                        {
                            Id = model.Id,
                            PeriodId = model.PeriodId,
                            NumberWeeks = model.NumberWeeks,
                            DayOfTheWeek = (DayOfTheWeek)row + 1,
                            ClassTimeId = serviceCT.GetElementByNumber(column).Id,
                            StudyGroupId = model.StudyGroupId,
                            Subgroups = model.Subgroups,
                            AuditoriumId = loadTeacherAuditorium[0].AuditoriumId,
                            LoadTeacherId = model.LoadTeacherId,
                            Type = model.Type
                        });
                    }
                }
            }
        }

        //выбор курса
        private void buttonCourse_Click(object sender, EventArgs e)
        {
            listBoxStudyGroups.Items.Clear();

            Button buttonSelect = sender as Button;

            List<StudyGroupViewModel> list = serviceSG.GetListByCourse(Int32.Parse(buttonSelect.Tag.ToString()));
            for (int i = 0; i < list.Count; i++)
            {
                listBoxStudyGroups.Items.Add(list[i].Title);
            }
            userControlFirstWeek.Clear();
            userControlSecondWeek.Clear();
            LoadDataGridViewsEmpty();
        }

        //пустые DataGridViews
        private void LoadDataGridViewsEmpty()
        {
            List<ClassTimeViewModel> classTime = serviceCT.GetList();//номера пар
            userControlFirstWeek.ColumnClassTimeAdd(classTime);
            userControlSecondWeek.ColumnClassTimeAdd(classTime);

            List<string> dayOfTheWeek = Enum.GetNames(typeof(DayOfTheWeek)).ToList();//дни недели
            userControlFirstWeek.RowDayOfTheWeekAdd(dayOfTheWeek, Int32.Parse(ConfigurationManager.AppSettings["DayOfTheWeek"]));
            userControlSecondWeek.RowDayOfTheWeekAdd(dayOfTheWeek, Int32.Parse(ConfigurationManager.AppSettings["DayOfTheWeek"]));
        }

        //выбор группы
        private void listBoxStudyGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleLoad();
        }

        //загрузка расписания группы
        public void ScheduleLoad()
        {
            userControlFirstWeek.Clear();
            userControlSecondWeek.Clear();
            LoadDataGridViewsEmpty();

            if (listBoxStudyGroups.SelectedItem == null)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //id группы
            Guid StudyGroupId = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;

            //нерасставленные пары
            List<ScheduleViewModel> scheduleByStudyGroupEmpty = service.GetListByPeroidAndStudyGroupEmpty(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), StudyGroupId);
            FillDataGridViewAll(scheduleByStudyGroupEmpty);

            //расставленные пары
            List<ScheduleViewModel> scheduleByStudyGroupFill = service.GetListByPeroidAndStudyGroupFill(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), StudyGroupId);

            for (int i = 0; i < scheduleByStudyGroupFill.Count; i++)
            {
                if (scheduleByStudyGroupFill[i].NumberWeeks == 1) //заполнение первой недели
                {
                    //определение дня недели
                    int dayofweek = userControlFirstWeek.GetIndexDayOfTheWeek(scheduleByStudyGroupFill[i].DayOfTheWeek.ToString());

                    //формируем значение ячейки
                    string schedule;
                    string educationalbuilding = serviceA.GetElement(scheduleByStudyGroupFill[i].AuditoriumId).EducationalBuilding;// № корпуса
                    if (scheduleByStudyGroupFill[i].Subgroups != null)
                    {
                        schedule = scheduleByStudyGroupFill[i].TypeOfClassTitle + " " + scheduleByStudyGroupFill[i].DisciplineTitle
                            + " - " + scheduleByStudyGroupFill[i].Subgroups + " п/г" + "\n " + scheduleByStudyGroupFill[i].TeacherSurname + " " +
                            educationalbuilding + "-" + scheduleByStudyGroupFill[i].AuditoriumNumber;
                    }
                    else
                    {
                        schedule = scheduleByStudyGroupFill[i].TypeOfClassTitle + " " + scheduleByStudyGroupFill[i].DisciplineTitle
                            + "\n " + scheduleByStudyGroupFill[i].TeacherSurname + " " +
                            educationalbuilding + "-" + scheduleByStudyGroupFill[i].AuditoriumNumber;
                    }
                    userControlFirstWeek.Value(scheduleByStudyGroupFill[i].ClassTimeNumber.ToString(), dayofweek, schedule);
                }
                else //вторая неделя
                {
                    //определение дня недели
                    int dayofweek = userControlSecondWeek.GetIndexDayOfTheWeek(scheduleByStudyGroupFill[i].DayOfTheWeek.ToString());

                    //формируем значение ячейки
                    string schedule;
                    string educationalbuilding = serviceA.GetElement(scheduleByStudyGroupFill[i].AuditoriumId).EducationalBuilding;// № корпуса
                    if (scheduleByStudyGroupFill[i].Subgroups != null)
                    {
                        schedule = scheduleByStudyGroupFill[i].TypeOfClassTitle + " " + scheduleByStudyGroupFill[i].DisciplineTitle
                            + " - " + scheduleByStudyGroupFill[i].Subgroups + " п/г" + "\n " + scheduleByStudyGroupFill[i].TeacherSurname + " " +
                            educationalbuilding + "-" + scheduleByStudyGroupFill[i].AuditoriumNumber;
                    }
                    else
                    {
                        schedule = scheduleByStudyGroupFill[i].TypeOfClassTitle + " " + scheduleByStudyGroupFill[i].DisciplineTitle
                            + "\n " + scheduleByStudyGroupFill[i].TeacherSurname + " " +
                            educationalbuilding + "-" + scheduleByStudyGroupFill[i].AuditoriumNumber;
                    }
                    userControlSecondWeek.Value(scheduleByStudyGroupFill[i].ClassTimeNumber.ToString(), dayofweek, schedule);
                }
            }
        }

        //заполняем 3й dataGridView
        void FillDataGridViewAll(List<ScheduleViewModel> list)
        {
            if (list != null)
            {
                dataGridViewAll.DataSource = list;
                dataGridViewAll.Columns[0].Visible = false;
                dataGridViewAll.Columns[1].Visible = false;
                dataGridViewAll.Columns[5].Visible = false;
                dataGridViewAll.Columns[8].Visible = false;
                dataGridViewAll.Columns[11].Visible = false;
                dataGridViewAll.Columns[15].Visible = false;
                dataGridViewAll.Columns[17].Visible = false;
                dataGridViewAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewAll.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSchedule>();
                form.Id = (Guid)dataGridViewAll.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewAll.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid id = (Guid)dataGridViewAll.SelectedRows[0].Cells[0].Value;
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

        //раскрашивание расписания
        private void dataGridViewAll_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewAll.SelectedRows.Count == 1)
            {
                Guid Id = (Guid)dataGridViewAll.SelectedRows[0].Cells[0].Value;
                ScheduleViewModel schedule = service.GetElement(Id);//занятие
                LoadTeacherViewModel loadTeacher = serviceLT.GetElement(schedule.LoadTeacherId);//расчасовка занятия

                ////проверка свободных аудиторий
                List<LoadTeacherAuditoriumViewModel> loadTeacherAuditorium = loadTeacher.LoadTeacherAuditoriums;//аудитории расчасовки

                //все пары 1 недели периода
                List<ScheduleViewModel> schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), 1);

                for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
                {
                    if (schedulesByPeriodAndWeek[i].AuditoriumId == loadTeacherAuditorium[0].AuditoriumId)
                    {
                        //определение дня недели
                        int dayofweek = userControlFirstWeek.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                        userControlFirstWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Yellow;
                        userControlFirstWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                    }
                }

                //все пары 2 недели периода
                schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), 2);

                for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
                {
                    if (schedulesByPeriodAndWeek[i].AuditoriumId == loadTeacherAuditorium[0].AuditoriumId)
                    {
                        //определение дня недели
                        int dayofweek = userControlSecondWeek.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                        userControlSecondWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Yellow;
                        userControlSecondWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                    }
                }


                ////проверка свободы преподавателя
                Guid teacherId = loadTeacher.TeacherId;//преподаватель занятия

                //все пары 1 недели периода
                schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), 1);

                for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
                {
                    if (schedulesByPeriodAndWeek[i].TeacherId == teacherId)
                    {
                        //определение дня недели
                        int dayofweek = userControlFirstWeek.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                        userControlFirstWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                        userControlFirstWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Препод";
                    }
                }

                //все пары 2 недели периода
                schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), 2);

                for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
                {
                    if (schedulesByPeriodAndWeek[i].TeacherId == teacherId)
                    {
                        //определение дня недели
                        int dayofweek = userControlSecondWeek.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                        userControlSecondWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                        userControlSecondWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Препод";
                    }
                }


                ////проверка свободы групп потока
                Guid flowId = loadTeacher.FlowId;//поток
                List<FlowStudyGroupViewModel> flowStudyGroup = serviceF.GetElement(flowId).FlowStudyGroups;

                //все пары 1 недели периода
                schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), 1);

                for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
                {
                    for (int j = 0; j < flowStudyGroup.Count; j++)
                    {
                        if (schedulesByPeriodAndWeek[i].StudyGroupId == flowStudyGroup[j].StudyGroupId)
                        {
                            //определение дня недели
                            int dayofweek = userControlFirstWeek.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                            userControlFirstWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Chocolate;
                            userControlFirstWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Поток";
                        }
                    }
                }

                //все пары 2 недели периода
                schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), 2);

                for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
                {
                    for (int j = 0; j < flowStudyGroup.Count; j++)
                    {
                        if (schedulesByPeriodAndWeek[i].StudyGroupId == flowStudyGroup[j].StudyGroupId)
                        {
                            //определение дня недели
                            int dayofweek = userControlSecondWeek.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                            userControlSecondWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Chocolate;
                            userControlSecondWeek.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Поток";
                        }
                    }

                }

                ////все остальные ячейки
                for (int i = 0; i < userControlFirstWeek.dataGridView.RowCount; i++)
                {
                    for (int j = 1; j < userControlFirstWeek.dataGridView.ColumnCount; j++)
                    {
                        if (userControlFirstWeek.dataGridView[j, i].Tag == null)
                        {
                            userControlFirstWeek.dataGridView[j, i].Style.BackColor = Color.Green;
                            userControlFirstWeek.dataGridView[j, i].Tag = "Свободно";
                        }

                        if (userControlSecondWeek.dataGridView[j, i].Tag == null)
                        {
                            userControlSecondWeek.dataGridView[j, i].Style.BackColor = Color.Green;
                            userControlSecondWeek.dataGridView[j, i].Tag = "Свободно";
                        }

                    }
                }

            }
        }

        //открытие детальной формы группы
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
