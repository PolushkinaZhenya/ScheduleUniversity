using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormMain : Form
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

        ScheduleViewModel scheduleActual = null;

        public FormMain(IScheduleService service, IStudyGroupService serviceSG, IClassTimeService serviceCT, IPeriodService serviceP,
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

        private void типыАудиторийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfAudiences>();
            form.ShowDialog();

            LoadSetting();
        }

        private void типыКафедрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfDepartments>();
            form.ShowDialog();

            LoadSetting();
        }

        private void типыЗанятийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfClasses>();
            form.ShowDialog();

            LoadSetting();
        }

        private void учебныеКорпусаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEducationalBuildings>();
            form.ShowDialog();

            LoadSetting();
        }

        private void времяПереходаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTransitionTimes>();
            form.ShowDialog();

            LoadSetting();
        }

        private void времяПроведенияПарToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClassTimes>();
            form.ShowDialog();

            LoadSetting();
        }

        private void учебныеГодаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAcademicYears>();
            form.ShowDialog();

            LoadSetting();
        }

        private void семестрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSemesters>();
            form.ShowDialog();

            LoadSetting();
        }

        private void периодыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPeriods>();
            form.ShowDialog();

            LoadSetting();
        }

        private void кафедрыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDepartments>();
            form.ShowDialog();

            LoadSetting();
        }

        private void аудиторииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuditoriums>();
            form.ShowDialog();

            LoadSetting();
        }

        private void преподавателиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTeachers>();
            form.ShowDialog();

            LoadSetting();
        }

        private void дисциплиныToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDisciplines>();
            form.ShowDialog();

            LoadSetting();
        }

        private void факультетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFaculties>();
            form.ShowDialog();

            LoadSetting();
        }

        private void специальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSpecialties>();
            form.ShowDialog();

            LoadSetting();
        }

        private void учебныеГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStudyGroups>();
            form.ShowDialog();

            LoadData();
        }

        private void потокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFlows>();
            form.ShowDialog();

            LoadSetting();
        }

        private void учебныеПланыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormCurriculums>();
                form.ShowDialog();

                LoadSetting();
            }
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormSchedules>();
                form.ShowDialog();
            }
        }

        private void расчасовкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormLoadTeachers>();
                form.ShowDialog();

                LoadSetting();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormSave>();
                form.ShowDialog();

                LoadSetting();
            }
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSettings>();
            form.ShowDialog();

            LoadSetting();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadSetting()
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                //выводить лого
                splitContainer1.Visible = false;
                listBoxStudyGroups.Visible = false;
                buttonCancel.Visible = false;
                buttonDel.Visible = false;
                buttonUpd.Visible = false;

                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (listBoxStudyGroups.SelectedItems.Count == 1)
                {
                    ScheduleLoad(true);
                }
                else
                {
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
            try
            {
                listBoxStudyGroups.Items.Clear();
                splitContainer2.Panel1.Controls.Clear();
                splitContainer2.Panel2.Controls.Clear();
                
                //добавление кнопок курсов
                List<StudyGroupViewModel> listCourse = serviceSG.GetListCourse();

                for (int i = 0; i < listCourse.Count; i++)
                {
                    buttonCourse = new Button();
                    buttonCourse.Location = new Point(i * 90 + 20, 80);
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
                userControlFirstWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseDoubleClick);
                userControlFirstWeek.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseClick);
                splitContainer2.Panel1.Controls.Add(userControlFirstWeek);

                userControlSecondWeek = new UserControlDataGridViewSchedule();
                userControlSecondWeek.Clear();
                userControlSecondWeek.Dock = DockStyle.Fill;
                userControlSecondWeek.Name = "2";
                userControlSecondWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlSecondWeek_CellMouseDoubleClick);
                userControlSecondWeek.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(userControlSecondWeek_CellMouseClick);
                splitContainer2.Panel2.Controls.Add(userControlSecondWeek);

                LoadDataGridViewsEmpty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //нажатие по таблице 1й недели
        public void userControlFirstWeek_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            userControlSecondWeek.dataGridView.ClearSelection();
        }

        //нажатие по таблице 2й недели
        public void userControlSecondWeek_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            userControlFirstWeek.dataGridView.ClearSelection();
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

            userControlFirstWeek.dataGridView.ClearSelection();
            userControlSecondWeek.dataGridView.ClearSelection();
        }

        //двойное нажатие по таблице 1й недели
        public void userControlFirstWeek_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewAll.SelectedRows.Count == 1)
            {
                ScheduleViewModel schedule = service.GetElement((Guid)dataGridViewAll.SelectedRows[0].Cells[0].Value);//нераспределенное занятие
                AddSchedule(userControlFirstWeek, schedule, true);
            }
            if (userControlFirstWeek.dataGridView.SelectedCells.Count == 1 && scheduleActual != null)
            {
                AddSchedule(userControlFirstWeek, scheduleActual, false);
                scheduleActual = null;
            }

            ScheduleLoad(true);
        }

        //двойное нажатие по таблице 2й недели
        public void userControlSecondWeek_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewAll.SelectedRows.Count == 1)
            {
                //ставим первый раз
                ScheduleViewModel schedule = service.GetElement((Guid)dataGridViewAll.SelectedRows[0].Cells[0].Value);//занятие
                AddSchedule(userControlSecondWeek, schedule, true);
            }
            if (userControlSecondWeek.dataGridView.SelectedCells.Count == 1 && scheduleActual != null)
            {
                //переставляем
                AddSchedule(userControlSecondWeek, scheduleActual, false);
                scheduleActual = null;
            }

            ScheduleLoad(true);
        }

        //ставим пару в расписание
        public void AddSchedule(UserControlDataGridViewSchedule userControl, ScheduleViewModel schedule, bool Type)
        {
            if (userControl.dataGridView.SelectedCells.Count == 1 && schedule.NumberWeeks == Int32.Parse(userControl.Name))
            {
                LoadTeacherViewModel loadTeacher = serviceLT.GetElement(schedule.LoadTeacherId);//расчасовка занятия

                int row = userControl.dataGridView.SelectedCells[0].RowIndex;
                int column = userControl.dataGridView.SelectedCells[0].ColumnIndex;
                string tag = userControl.dataGridView[column, row].Tag.ToString();

                if (schedule.NumberWeeks != Int32.Parse(userControl.Name))
                {
                    MessageBox.Show("Выберите другую неделю", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (userControl.dataGridView[column, row].Tag == null && schedule.NumberWeeks == Int32.Parse(userControl.Name))
                {
                    return;
                }

                if (tag == "Поток" && schedule.NumberWeeks == Int32.Parse(userControl.Name))
                {
                    MessageBox.Show("Группы потока заняты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (tag == "Препод" && schedule.NumberWeeks == Int32.Parse(userControl.Name))
                {
                    MessageBox.Show("Преподаватель занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (tag == "Ауд" && schedule.NumberWeeks == Int32.Parse(userControl.Name))
                {
                    List<LoadTeacherAuditoriumViewModel> loadTeacherAuditorium = loadTeacher.LoadTeacherAuditoriums;//аудитории расчасовки
                    int Week = Int32.Parse(userControl.Name);

                    //все пары недели
                    List<ScheduleViewModel> schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Week, "Занятие");

                    //все "закрытые" пары недели
                    List<ScheduleViewModel> scheduleAuditoriumClose = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Week, "Аудитория");

                    bool busy = false;
                    for (int i = 0; i < loadTeacherAuditorium.Count; i++)
                    {
                        busy = false;
                        for (int j = 0; j < schedulesByPeriodAndWeek.Count; j++)
                        {
                            if (loadTeacherAuditorium[i].AuditoriumId == schedulesByPeriodAndWeek[j].AuditoriumId
                                && (DayOfTheWeek)row + 1 == schedulesByPeriodAndWeek[j].DayOfTheWeek
                                && serviceCT.GetElementByNumber(column).Id == schedulesByPeriodAndWeek[j].ClassTimeId)
                            {
                                busy = true;
                            }
                        }
                        //проверяем по "закрытым"
                        for (int j = 0; j < scheduleAuditoriumClose.Count; j++)
                        {
                            if (loadTeacherAuditorium[i].AuditoriumId == scheduleAuditoriumClose[j].AuditoriumId
                                && (DayOfTheWeek)row + 1 == scheduleAuditoriumClose[j].DayOfTheWeek
                                && serviceCT.GetElementByNumber(column).Id == scheduleAuditoriumClose[j].ClassTimeId)
                            {
                                busy = true;
                            }
                        }
                        if (!busy)
                        {
                            List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                            for (int k = 0; k < flow.Count; k++)
                            {
                                ScheduleViewModel model;

                                if (Type)
                                {
                                    //ищем нерасставленные пары
                                    model = service.GetElementByParamEmpty(schedule.PeriodId, schedule.NumberWeeks, flow[k].StudyGroupId, flow[k].Subgroup, schedule.LoadTeacherId, "Занятие");
                                }
                                else
                                {
                                    //ищем расставленные пары
                                    model = service.GetElementByParamFill(schedule.PeriodId, schedule.NumberWeeks, schedule.DayOfTheWeek, schedule.ClassTimeId,
                                        flow[k].StudyGroupId, flow[k].Subgroup, schedule.LoadTeacherId, "Занятие");
                                }


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
                                    Type = model.Type,
                                    TeacherId = model.TeacherId
                                });
                            }
                            return;
                        }
                    }
                    //все занято, ставим в рандомную аудиторию
                    if (busy)
                    {
                        if (MessageBox.Show("Все аудитории из расчасовки заняты, ставить занятие в любую свободную аудиторию?", "Вопрос", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            List<AuditoriumViewModel> auditoriums = serviceA.GetList();

                            busy = false;
                            for (int i = 0; i < auditoriums.Count; i++)
                            {
                                busy = false;
                                for (int j = 0; j < schedulesByPeriodAndWeek.Count; j++)
                                {
                                    if (auditoriums[i].Id == schedulesByPeriodAndWeek[j].AuditoriumId
                                        && (DayOfTheWeek)row + 1 == schedulesByPeriodAndWeek[j].DayOfTheWeek
                                        && serviceCT.GetElementByNumber(column).Id == schedulesByPeriodAndWeek[j].ClassTimeId)
                                    {
                                        busy = true;
                                    }
                                }

                                //проверяем по "закрытым"
                                for (int j = 0; j < scheduleAuditoriumClose.Count; j++)
                                {
                                    if (auditoriums[i].Id == scheduleAuditoriumClose[j].AuditoriumId
                                        && (DayOfTheWeek)row + 1 == scheduleAuditoriumClose[j].DayOfTheWeek
                                        && serviceCT.GetElementByNumber(column).Id == scheduleAuditoriumClose[j].ClassTimeId)
                                    {
                                        busy = true;
                                    }
                                }

                                if (!busy)
                                {
                                    List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                                    for (int k = 0; k < flow.Count; k++)
                                    {
                                        ScheduleViewModel model;

                                        if (Type)
                                        {
                                            //ищем нерасставленные пары
                                            model = service.GetElementByParamEmpty(schedule.PeriodId, schedule.NumberWeeks, flow[k].StudyGroupId, flow[k].Subgroup, schedule.LoadTeacherId, "Занятие");
                                        }
                                        else
                                        {
                                            //ищем расставленные пары
                                            model = service.GetElementByParamFill(schedule.PeriodId, schedule.NumberWeeks, schedule.DayOfTheWeek, schedule.ClassTimeId,
                                                flow[k].StudyGroupId, flow[k].Subgroup, schedule.LoadTeacherId, "Занятие");
                                        }

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
                                            AuditoriumId = auditoriums[i].Id,
                                            LoadTeacherId = model.LoadTeacherId,
                                            Type = model.Type,
                                            TeacherId = model.TeacherId
                                        });
                                    }
                                    return;
                                }
                            }
                            MessageBox.Show("Не нашлось ни одной свободной аудитории на эту пару", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (tag == "Свободно" && schedule.NumberWeeks == Int32.Parse(userControl.Name))
                {
                    List<LoadTeacherAuditoriumViewModel> loadTeacherAuditorium = loadTeacher.LoadTeacherAuditoriums;//аудитории расчасовки

                    List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                    for (int i = 0; i < flow.Count; i++)
                    {
                        ScheduleViewModel model;

                        if (Type)
                        {
                            //ищем нерасставленные пары
                            model = service.GetElementByParamEmpty(schedule.PeriodId, schedule.NumberWeeks, flow[i].StudyGroupId, flow[i].Subgroup, schedule.LoadTeacherId, "Занятие");
                        }
                        else
                        {
                            //ищем расставленные пары
                            model = service.GetElementByParamFill(schedule.PeriodId, schedule.NumberWeeks, schedule.DayOfTheWeek, schedule.ClassTimeId,
                                flow[i].StudyGroupId, flow[i].Subgroup, schedule.LoadTeacherId, "Занятие");
                        }

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
                            Type = model.Type,
                            TeacherId = model.TeacherId
                        });
                    }
                }
            }
        }

        //выбор группы
        private void listBoxStudyGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleLoad(true);
        }

        //загрузка расписания группы
        public void ScheduleLoad(bool first)
        {
            userControlFirstWeek.Clear();
            userControlSecondWeek.Clear();
            LoadDataGridViewsEmpty();
            scheduleActual = null;

            if (listBoxStudyGroups.SelectedItem == null)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //id группы
            Guid StudyGroupId = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;

            if (first)
            {
                //нерасставленные пары
                List<ScheduleViewModel> scheduleByStudyGroupEmpty = service.GetListByPeroidAndStudyGroupEmpty(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), StudyGroupId, "Занятие");
                FillDataGridViewAll(scheduleByStudyGroupEmpty);
            }

            //расставленные пары
            List<ScheduleViewModel> scheduleByStudyGroupFill = service.GetListByPeroidAndStudyGroupFill(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), StudyGroupId, "Занятие");

            for (int i = 0; i < scheduleByStudyGroupFill.Count; i++)
            {
                if (scheduleByStudyGroupFill[i].NumberWeeks == 1) //заполнение первой недели
                {
                    ScheduleLoadWeek(scheduleByStudyGroupFill[i], userControlFirstWeek);
                }
                else //заполнение второй недели
                {
                    ScheduleLoadWeek(scheduleByStudyGroupFill[i], userControlSecondWeek);
                }
            }
        }

        //заполнение расписания недели
        private void ScheduleLoadWeek(ScheduleViewModel scheduleByStudyGroupFill_0, UserControlDataGridViewSchedule userControl)
        {
            //определение дня недели
            int dayofweek = userControl.GetIndexDayOfTheWeek(scheduleByStudyGroupFill_0.DayOfTheWeek.ToString());

            //формируем значение ячейки
            string educationalbuilding = serviceA.GetElement(scheduleByStudyGroupFill_0.AuditoriumId).EducationalBuilding; //№ корпуса

            string schedule = scheduleByStudyGroupFill_0.TypeOfClassTitle + " " + scheduleByStudyGroupFill_0.DisciplineTitle;

            if (scheduleByStudyGroupFill_0.Subgroups != null)
            {
                schedule += " - " + scheduleByStudyGroupFill_0.Subgroups + " п/г";
            }

            schedule += "\n " + scheduleByStudyGroupFill_0.TeacherSurname + " " +
                    educationalbuilding + "-" + scheduleByStudyGroupFill_0.AuditoriumNumber;

            userControl.Value(scheduleByStudyGroupFill_0.ClassTimeNumber.ToString(), dayofweek, schedule);
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

            dataGridViewAll.ClearSelection();
        }

        //куда переставить распределенную пару
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            UserControlDataGridViewSchedule userControl = null;

            if (userControlFirstWeek.dataGridView.SelectedCells.Count == 1 && userControlFirstWeek.dataGridView.SelectedCells[0].Value != null)
            {
                userControl = userControlFirstWeek;
            }
            else
            {
                if (userControlSecondWeek.dataGridView.SelectedCells.Count == 1 && userControlSecondWeek.dataGridView.SelectedCells[0].Value != null)
                {
                    userControl = userControlSecondWeek;
                }
                else
                {
                    MessageBox.Show("Выберите занятие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int row = userControl.dataGridView.SelectedCells[0].RowIndex;
            int column = userControl.dataGridView.SelectedCells[0].ColumnIndex;

            Guid StudyGroupId = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;
            DayOfTheWeek day = (DayOfTheWeek)row + 1;
            Guid classtime = serviceCT.GetElementByNumber(column).Id;

            scheduleActual = service.GetElementByDayAndClassTimeAndStudyGroupId(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Int32.Parse(userControl.Name), day, classtime, StudyGroupId, "Занятие");

            Coloring(scheduleActual.Id);
        }

        //отмена перестановки распределенной пары
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            scheduleActual = null;
            ScheduleLoad(true);
        }

        //убираем пару в нераспределенные
        private void buttonDel_Click(object sender, EventArgs e)
        {
            UserControlDataGridViewSchedule userControl = null;

            if (userControlFirstWeek.dataGridView.SelectedCells.Count == 1 && userControlFirstWeek.dataGridView.SelectedCells[0].Value != null)
            {
                userControl = userControlFirstWeek;
            }
            else
            {
                if (userControlSecondWeek.dataGridView.SelectedCells.Count == 1 && userControlSecondWeek.dataGridView.SelectedCells[0].Value != null)
                {
                    userControl = userControlSecondWeek;
                }
                else
                {
                    MessageBox.Show("Выберите занятие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (MessageBox.Show("Убрать пару из расписания?", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int row = userControl.dataGridView.SelectedCells[0].RowIndex;
                int column = userControl.dataGridView.SelectedCells[0].ColumnIndex;

                Guid StudyGroupId = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;
                DayOfTheWeek day = (DayOfTheWeek)row + 1;
                Guid classtime = serviceCT.GetElementByNumber(column).Id;

                //удаляемая пара
                scheduleActual = service.GetElementByDayAndClassTimeAndStudyGroupId(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Int32.Parse(userControl.Name), day, classtime, StudyGroupId, "Занятие");

                LoadTeacherViewModel loadTeacher = serviceLT.GetElement(scheduleActual.LoadTeacherId);//расчасовка занятия

                List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                for (int i = 0; i < flow.Count; i++)
                {
                    ScheduleViewModel model;

                    //ищем расставленные пары
                    model = service.GetElementByParamFill(scheduleActual.PeriodId, scheduleActual.NumberWeeks, scheduleActual.DayOfTheWeek, scheduleActual.ClassTimeId,
                        flow[i].StudyGroupId, flow[i].Subgroup, scheduleActual.LoadTeacherId, "Занятие");

                    //записываем для всех групп потока
                    service.UpdElement(new ScheduleBindingModel
                    {
                        Id = model.Id,
                        PeriodId = model.PeriodId,
                        NumberWeeks = model.NumberWeeks,
                        DayOfTheWeek = null,
                        ClassTimeId = null,
                        StudyGroupId = model.StudyGroupId,
                        Subgroups = model.Subgroups,
                        AuditoriumId = null,
                        LoadTeacherId = model.LoadTeacherId,
                        Type = model.Type,
                        TeacherId = model.TeacherId
                    });
                }

            }
            ScheduleLoad(true);
        }

        //куда поставить нераспределенную пару
        private void dataGridViewAll_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewAll.SelectedRows.Count == 1)
            {
                Guid Id = (Guid)dataGridViewAll.SelectedRows[0].Cells[0].Value;
                ScheduleLoad(false);
                Coloring(Id);
            }
        }

        //раскрашивание расписания
        public void Coloring(Guid ID)
        {
            ScheduleViewModel schedule = service.GetElement(ID);//занятие
            LoadTeacherViewModel loadTeacher = serviceLT.GetElement(schedule.LoadTeacherId);//расчасовка занятия

            if (schedule.NumberWeeks == 1)
            {
                ColoringWeek(loadTeacher, 1, userControlFirstWeek);
            }
            else
            {
                ColoringWeek(loadTeacher, 2, userControlSecondWeek);
            }
        }

        //раскрашивание расписания недели
        private void ColoringWeek(LoadTeacherViewModel loadTeacher, int NumberWeek, UserControlDataGridViewSchedule userControl)
        {
            //все пары недели периода
            List<ScheduleViewModel> schedulesByPeriodAndWeek = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), NumberWeek, "Занятие");

            ////проверка свободных аудиторий
            List<LoadTeacherAuditoriumViewModel> loadTeacherAuditorium = loadTeacher.LoadTeacherAuditoriums;//аудитории расчасовки

            for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
            {
                if (schedulesByPeriodAndWeek[i].AuditoriumId == loadTeacherAuditorium[0].AuditoriumId && schedulesByPeriodAndWeek[i].AuditoriumNumber != "ДОТ")
                {
                    //определение дня недели
                    int dayofweek = userControl.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                    userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Yellow;
                    userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                }
            }

            ////проверка "закрытых" пар у аудитории
            //все "закрытые" пары недели периода
            List<ScheduleViewModel> scheduleAuditoriumClose = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), NumberWeek, "Аудитория");

            for (int i = 0; i < scheduleAuditoriumClose.Count; i++)
            {
                if (scheduleAuditoriumClose[i].AuditoriumId == loadTeacherAuditorium[0].AuditoriumId && scheduleAuditoriumClose[i].AuditoriumNumber != "ДОТ")
                {
                    //определение дня недели
                    int dayofweek = userControl.GetIndexDayOfTheWeek(scheduleAuditoriumClose[i].DayOfTheWeek.ToString());

                    userControl.dataGridView[scheduleAuditoriumClose[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Yellow;
                    userControl.dataGridView[scheduleAuditoriumClose[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                }
            }

            ////проверка свободы преподавателя
            Guid teacherId = loadTeacher.TeacherId;//преподаватель занятия

            for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
            {
                if (schedulesByPeriodAndWeek[i].TeacherId == teacherId)
                {
                    //определение дня недели
                    int dayofweek = userControl.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                    userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Gray;
                    userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Препод";
                }
            }

            ////проверка "закрытых" пар у преподавателя
            //все "закрытые" пары недели периода
            List<ScheduleViewModel> scheduleTeacherClose = service.GetListByPeriodAndWeek(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), NumberWeek, "Преподаватель");

            for (int i = 0; i < scheduleTeacherClose.Count; i++)
            {
                if (scheduleTeacherClose[i].TeacherId == teacherId)
                {
                    //определение дня недели
                    int dayofweek = userControl.GetIndexDayOfTheWeek(scheduleTeacherClose[i].DayOfTheWeek.ToString());

                    userControl.dataGridView[scheduleTeacherClose[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Gray;
                    userControl.dataGridView[scheduleTeacherClose[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Препод";
                }
            }

            ////проверка свободы групп потока
            Guid flowId = loadTeacher.FlowId;//поток
            List<FlowStudyGroupViewModel> flowStudyGroup = serviceF.GetElement(flowId).FlowStudyGroups;

            for (int j = 0; j < flowStudyGroup.Count; j++)
            {
                schedulesByPeriodAndWeek = service.GetListByPeriodAndWeekAndStudyGroupSubgroup(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), NumberWeek,
                    flowStudyGroup[j].StudyGroupId, "Занятие");

                for (int i = 0; i < schedulesByPeriodAndWeek.Count; i++)
                {
                    //если вся группа задействована, то красим
                    if (schedulesByPeriodAndWeek[i].StudyGroupId == flowStudyGroup[j].StudyGroupId && (schedulesByPeriodAndWeek[i].Subgroups == null || flowStudyGroup[j].Subgroup == null))
                    {
                        //определение дня недели
                        int dayofweek = userControl.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                        userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                        userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Поток";
                    }

                    //если есть пара только у п/г и п/г совпадает
                    if (schedulesByPeriodAndWeek[i].Subgroups != null && schedulesByPeriodAndWeek[i].Subgroups == flowStudyGroup[j].Subgroup)
                    {
                        //красим
                        //определение дня недели
                        int dayofweek = userControl.GetIndexDayOfTheWeek(schedulesByPeriodAndWeek[i].DayOfTheWeek.ToString());

                        userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                        userControl.dataGridView[schedulesByPeriodAndWeek[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Поток";
                    }
                }
            }


            ////все остальные ячейки
            for (int i = 0; i < userControl.dataGridView.RowCount; i++)
            {
                for (int j = 1; j < userControl.dataGridView.ColumnCount; j++)
                {
                    if (userControl.dataGridView[j, i].Tag == null)
                    {
                        userControl.dataGridView[j, i].Style.BackColor = Color.Green;
                        userControl.dataGridView[j, i].Tag = "Свободно";
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

        //открытие формы расписания аудиторий
        private void buttonScheduleAud_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormScheduleAuditoriums>();
                form.ShowDialog();

                if (listBoxStudyGroups.SelectedItems.Count == 1)
                {
                    ScheduleLoad(true);
                }
            }
        }

        //открытие формы расписания преподавателей
        private void buttonScheduleTeach_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormScheduleTeachers>();
                form.ShowDialog();

                if (listBoxStudyGroups.SelectedItems.Count == 1)
                {
                    ScheduleLoad(true);
                }
            }
        }
    }
}
