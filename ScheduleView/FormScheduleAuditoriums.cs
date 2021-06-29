using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Unity;
using System.Configuration;
using ScheduleModel;
using ScheduleBusinessLogic.BindingModels;

namespace ScheduleView
{
    public partial class FormScheduleAuditoriums : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IScheduleService serviceS;

        private readonly IClassTimeService serviceCT;

        private readonly ILoadTeacherService serviceLT;

        private readonly IAuditoriumService service;

        private readonly IFlowService serviceF;

        private readonly IEducationalBuildingService serviceEB;

        Button buttonEducationalBuilding;

        UserControlDataGridViewSchedule userControlFirstWeek;

        UserControlDataGridViewSchedule userControlSecondWeek;

        ScheduleViewModel scheduleActual = null;

        private string EducationalBuildingActive;

        public FormScheduleAuditoriums(IScheduleService serviceS, IClassTimeService serviceCT, ILoadTeacherService serviceLT,
            IAuditoriumService service, IFlowService serviceF, IEducationalBuildingService serviceEB)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceCT = serviceCT;
            this.serviceLT = serviceLT;
            this.service = service;
            this.serviceF = serviceF;
            this.serviceEB = serviceEB;
        }

        private void FormScheduleAuditoriums_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                listBoxAuditoriums.Items.Clear();

                //добавление кнопок корусов
                List<EducationalBuildingViewModel> listEducationalBuilding = serviceEB.GetList();//корпуса

                for (int i = 0; i < listEducationalBuilding.Count; i++)
                {
                    buttonEducationalBuilding = new Button();
                    buttonEducationalBuilding.Location = new Point(i * 100 + 20, 30);
                    buttonEducationalBuilding.Name = "buttonEducationalBuilding" + listEducationalBuilding[i].Number;
                    buttonEducationalBuilding.Size = new Size(80, 40);
                    buttonEducationalBuilding.Text = "Корпус №" + listEducationalBuilding[i].Number;
                    buttonEducationalBuilding.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    buttonEducationalBuilding.Click += new EventHandler(buttonEducationalBuilding_Click);
                    buttonEducationalBuilding.Tag = listEducationalBuilding[i].Number;

                    Controls.Add(buttonEducationalBuilding);//добавили кнопку
                }

                //заполнение аудиторий
                List<AuditoriumViewModel> listAuditoriums = service.GetListByEducationalBuilding(listEducationalBuilding[0].Number);
                for (int i = 0; i < listAuditoriums.Count; i++)
                {
                    listBoxAuditoriums.Items.Add(listAuditoriums[i].Number);
                }
                EducationalBuildingActive = listEducationalBuilding[0].Number;

                userControlFirstWeek = new UserControlDataGridViewSchedule();
                userControlFirstWeek.Clear();
                userControlFirstWeek.Dock = DockStyle.Fill;
                userControlFirstWeek.Name = "1";
                userControlFirstWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseDoubleClick);
                userControlFirstWeek.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseClick);
                splitContainer1.Panel1.Controls.Add(userControlFirstWeek);

                userControlSecondWeek = new UserControlDataGridViewSchedule();
                userControlSecondWeek.Clear();
                userControlSecondWeek.Dock = DockStyle.Fill;
                userControlSecondWeek.Name = "2";
                userControlSecondWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlSecondWeek_CellMouseDoubleClick);
                userControlSecondWeek.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(userControlSecondWeek_CellMouseClick);
                splitContainer1.Panel2.Controls.Add(userControlSecondWeek);

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

        //двойное нажатие по таблице 1й недели
        public void userControlFirstWeek_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (userControlFirstWeek.dataGridView.SelectedCells.Count == 1 && scheduleActual != null)
            {
                AddSchedule(userControlFirstWeek, scheduleActual);
                scheduleActual = null;
            }

            ScheduleLoad();
        }

        //двойное нажатие по таблице 2й недели
        public void userControlSecondWeek_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (userControlSecondWeek.dataGridView.SelectedCells.Count == 1 && scheduleActual != null)
            {
                AddSchedule(userControlSecondWeek, scheduleActual);
                scheduleActual = null;
            }

            ScheduleLoad();
        }

        //выбор корпуса
        private void buttonEducationalBuilding_Click(object sender, EventArgs e)
        {
            listBoxAuditoriums.Items.Clear();

            Button buttonSelect = sender as Button;

            EducationalBuildingActive = buttonSelect.Tag.ToString();

            List<AuditoriumViewModel> listAuditoriums = service.GetListByEducationalBuilding(buttonSelect.Tag.ToString());

            for (int i = 0; i < listAuditoriums.Count; i++)
            {
                if (listAuditoriums[i].Number != "ДОТ")
                {
                    listBoxAuditoriums.Items.Add(listAuditoriums[i].Number);
                }
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

        //выбор аудитории + красим при перестановке
        private void listBoxAuditoriums_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleLoad();

            if (scheduleActual != null)
            {
                //определение дня недели
                int dayofweek = userControlFirstWeek.GetIndexDayOfTheWeek(scheduleActual.DayOfTheWeek.ToString());

                //закрасить ячейку
                if (scheduleActual.NumberWeeks == 1)
                {
                    if (userControlFirstWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Value == null)
                    {
                        userControlFirstWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Green;
                        userControlFirstWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Tag = "Свободно";
                    }
                    else
                    {
                        userControlFirstWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                        userControlFirstWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                    }

                }
                if (scheduleActual.NumberWeeks == 2)
                {
                    if (userControlFirstWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Value == null)
                    {
                        userControlSecondWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Green;
                        userControlSecondWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Tag = "Свободно";
                    }
                    else
                    {
                        userControlSecondWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                        userControlSecondWeek.dataGridView[scheduleActual.ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                    }
                }
            }
        }

        //загрузка расписания аудитории
        private void ScheduleLoad()
        {
            userControlFirstWeek.Clear();
            userControlSecondWeek.Clear();
            LoadDataGridViewsEmpty();

            if (listBoxAuditoriums.SelectedItem == null)
            {
                MessageBox.Show("Выберите аудиторию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //id корпуса
            Guid EducationalBuildingId = serviceEB.GetElementByNumder(EducationalBuildingActive).Id;

            //id аудитории
            Guid AuditoriumId = service.GetElementByTitleAndEducationalBuilding(listBoxAuditoriums.SelectedItem.ToString(), EducationalBuildingId).Id;

            //расставленные пары
            List<ScheduleViewModel> scheduleByAuditoriumFill = serviceS.GetListByPeroidAndAuditoriumFill(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), AuditoriumId, "Занятие");

            for (int i = 0; i < scheduleByAuditoriumFill.Count; i++)
            {
                if (scheduleByAuditoriumFill[i].NumberWeeks == 1) //заполнение первой недели
                {
                    ScheduleLoadWeek(scheduleByAuditoriumFill[i], userControlFirstWeek);
                }
                else //вторая неделя
                {
                    ScheduleLoadWeek(scheduleByAuditoriumFill[i], userControlSecondWeek);
                }
            }

            //отображаем "закрытые" пары
            List<ScheduleViewModel> scheduleByAuditoriumClose = serviceS.GetListByPeroidAndAuditoriumClose(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), AuditoriumId, "Аудитория");
            for (int i = 0; i < scheduleByAuditoriumClose.Count; i++)
            {
                if (scheduleByAuditoriumClose[i].NumberWeeks == 1) //заполнение первой недели
                {
                    //определение дня недели
                    int dayofweek = userControlFirstWeek.GetIndexDayOfTheWeek(scheduleByAuditoriumClose[i].DayOfTheWeek.ToString());

                    userControlFirstWeek.dataGridView[scheduleByAuditoriumClose[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                    userControlFirstWeek.dataGridView[scheduleByAuditoriumClose[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                }
                else //вторая неделя
                {
                    //определение дня недели
                    int dayofweek = userControlSecondWeek.GetIndexDayOfTheWeek(scheduleByAuditoriumClose[i].DayOfTheWeek.ToString());

                    userControlSecondWeek.dataGridView[scheduleByAuditoriumClose[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                    userControlSecondWeek.dataGridView[scheduleByAuditoriumClose[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Ауд";
                }
            }
        }

        //загрузка расписания аудитории на неделю
        private void ScheduleLoadWeek(ScheduleViewModel scheduleByAuditoriumFill, UserControlDataGridViewSchedule userControl)
        {
            //формируем значение ячейки
            string schedule;
            string educationalbuilding = service.GetElement(scheduleByAuditoriumFill.AuditoriumId).EducationalBuilding;// № корпуса

            //есть ли группы в потоке
            LoadTeacherViewModel loadTeacher = serviceLT.GetElement(scheduleByAuditoriumFill.LoadTeacherId);//расчасовка занятия
            List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки
            if (flow.Count > 1) //создан вручную 
            {
                schedule = scheduleByAuditoriumFill.TypeOfClassTitle + "." + scheduleByAuditoriumFill.DisciplineTitle + "\n"
                    + serviceF.GetElement(loadTeacher.FlowId).Title + "\n" + scheduleByAuditoriumFill.TeacherSurname + " " 
                    + educationalbuilding + "-" + scheduleByAuditoriumFill.AuditoriumNumber;

            }
            else //создан вручную или автоматически
            {
                schedule = scheduleByAuditoriumFill.TypeOfClassTitle + "." + scheduleByAuditoriumFill.DisciplineTitle
                        + " ";

                if (serviceF.GetElement(loadTeacher.FlowId).FlowAutoCreation)//автоматически созданный поток
                {
                    schedule += scheduleByAuditoriumFill.StudyGroupTitle;

                    if (scheduleByAuditoriumFill.Subgroups != null)
                    {
                        schedule += " - " + scheduleByAuditoriumFill.Subgroups + " п/г";
                    }
                }

                else //поток создан вручную
                {
                    schedule += serviceF.GetElement(loadTeacher.FlowId).Title;
                }

                schedule += "\n" + scheduleByAuditoriumFill.TeacherSurname + " " +
                            educationalbuilding + "-" + scheduleByAuditoriumFill.AuditoriumNumber;
            }

            //определение дня недели
            int dayofweek = userControl.GetIndexDayOfTheWeek(scheduleByAuditoriumFill.DayOfTheWeek.ToString());

            //если ячейка пустая (для пар потока)
            if (userControl.dataGridView[scheduleByAuditoriumFill.ClassTimeNumber.ToString(), dayofweek].Value == null)
            {
                userControl.Value(scheduleByAuditoriumFill.ClassTimeNumber.ToString(), dayofweek, schedule);
            }

        }

        //переставить пару
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

            //id корпуса
            Guid EducationalBuildingId = serviceEB.GetElementByNumder(EducationalBuildingActive).Id;

            //id аудитории
            Guid AuditoriumId = service.GetElementByTitleAndEducationalBuilding(listBoxAuditoriums.SelectedItem.ToString(), EducationalBuildingId).Id;

            DayOfTheWeek day = (DayOfTheWeek)row + 1;
            Guid classtime = serviceCT.GetElementByNumber(column).Id;

            scheduleActual = serviceS.GetElementByDayAndClassTimeAndAuditoriumId(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Int32.Parse(userControl.Name), day, classtime, AuditoriumId, "Занятие");
        }

        //отмена перестановки пары
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            scheduleActual = null;
        }

        //переставляем пару в расписании
        private void AddSchedule(UserControlDataGridViewSchedule userControl, ScheduleViewModel schedule)
        {
            if (userControl.dataGridView.SelectedCells.Count == 1)
            {
                LoadTeacherViewModel loadTeacher = serviceLT.GetElement(schedule.LoadTeacherId);//расчасовка занятия

                //куда переставляем
                int row = userControl.dataGridView.SelectedCells[0].RowIndex;
                int column = userControl.dataGridView.SelectedCells[0].ColumnIndex;

                if (schedule.NumberWeeks != Int32.Parse(userControl.Name))
                {
                    MessageBox.Show("Выберите другую неделю", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (userControl.dataGridView[column, row].Tag == null)
                {
                    MessageBox.Show("Выберите окно того же дня и пары, куда переставить занятие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (userControl.dataGridView[column, row].Tag.ToString() == "Ауд")
                {
                    MessageBox.Show("Аудитория занята", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (userControl.dataGridView[column, row].Tag.ToString() == "Свободно" && schedule.NumberWeeks == Int32.Parse(userControl.Name))
                {
                    //id корпуса
                    Guid EducationalBuildingId = serviceEB.GetElementByNumder(EducationalBuildingActive).Id;

                    //id аудитории к которую переставляем пару
                    Guid AuditoriumId = service.GetElementByTitleAndEducationalBuilding(listBoxAuditoriums.SelectedItem.ToString(), EducationalBuildingId).Id;

                    List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

                    for (int i = 0; i < flow.Count; i++)
                    {
                        ScheduleViewModel model;

                        //ищем пары у каждой группы потока
                        model = serviceS.GetElementByParamFill(schedule.PeriodId, schedule.NumberWeeks, schedule.DayOfTheWeek, schedule.ClassTimeId,
                            flow[i].StudyGroupId, flow[i].Subgroup, schedule.LoadTeacherId, "Занятие");

                        //записываем для каждой группы потока
                        serviceS.UpdElement(new ScheduleBindingModel
                        {
                            Id = model.Id,
                            PeriodId = model.PeriodId,
                            NumberWeeks = model.NumberWeeks,
                            DayOfTheWeek = (DayOfTheWeek)row + 1,
                            ClassTimeId = serviceCT.GetElementByNumber(column).Id,
                            StudyGroupId = model.StudyGroupId,
                            Subgroups = model.Subgroups,
                            AuditoriumId = AuditoriumId,
                            LoadTeacherId = model.LoadTeacherId,
                            Type = model.Type
                        });
                    }
                }
            }
        }

        //открытие детальной формы аудитории
        private void listBoxAuditoriums_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxAuditoriums.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<FormAuditorium>();

                //id корпуса
                Guid EducationalBuildingId = serviceEB.GetElementByNumder(EducationalBuildingActive).Id;

                form.Id = service.GetElementByTitleAndEducationalBuilding(listBoxAuditoriums.SelectedItem.ToString(), EducationalBuildingId).Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        //ставим "закрытую пару"
        private void buttonClose_Click(object sender, EventArgs e)
        {
            UserControlDataGridViewSchedule userControl = null;

            if (userControlFirstWeek.dataGridView.SelectedCells.Count == 1 && userControlFirstWeek.dataGridView.SelectedCells[0].Value == null)
            {
                userControl = userControlFirstWeek;
            }
            else
            {
                if (userControlSecondWeek.dataGridView.SelectedCells.Count == 1 && userControlSecondWeek.dataGridView.SelectedCells[0].Value == null)
                {
                    userControl = userControlSecondWeek;
                }
                else
                {
                    MessageBox.Show("Выберите пару без занятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int row = userControl.dataGridView.SelectedCells[0].RowIndex;
            int column = userControl.dataGridView.SelectedCells[0].ColumnIndex;

            if (userControl.dataGridView.SelectedCells[0].Tag == null)
            {
                //id корпуса
                Guid EducationalBuildingId = serviceEB.GetElementByNumder(EducationalBuildingActive).Id;

                //id аудитории
                Guid AuditoriumId = service.GetElementByTitleAndEducationalBuilding(listBoxAuditoriums.SelectedItem.ToString(), EducationalBuildingId).Id;

                DayOfTheWeek day = (DayOfTheWeek)row + 1;
                Guid classtime = serviceCT.GetElementByNumber(column).Id;

                serviceS.AddElement(new ScheduleBindingModel
                {
                    PeriodId = new Guid(ConfigurationManager.AppSettings["IDPeriod"]),
                    NumberWeeks = Int32.Parse(userControl.Name.ToString()),
                    DayOfTheWeek = day,
                    Type = "Аудитория",
                    ClassTimeId = classtime,
                    StudyGroupId = null,
                    Subgroups = null,
                    AuditoriumId = AuditoriumId,
                    LoadTeacherId = null,
                    TeacherId = null
                });

                ScheduleLoad();
            }
            else
            {
                MessageBox.Show("Пара уже закрыта для данной аудитории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //убрать "закрытую пару"
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            UserControlDataGridViewSchedule userControl = null;

            if (userControlFirstWeek.dataGridView.SelectedCells.Count == 1 && userControlFirstWeek.dataGridView.SelectedCells[0].Value == null)
            {
                userControl = userControlFirstWeek;
            }
            else
            {
                if (userControlSecondWeek.dataGridView.SelectedCells.Count == 1 && userControlSecondWeek.dataGridView.SelectedCells[0].Value == null)
                {
                    userControl = userControlSecondWeek;
                }
                else
                {
                    MessageBox.Show("Выберите пару без занятия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int row = userControl.dataGridView.SelectedCells[0].RowIndex;
            int column = userControl.dataGridView.SelectedCells[0].ColumnIndex;

            if (userControl.dataGridView.SelectedCells[0].Tag != null)
            {
                //id корпуса
                Guid EducationalBuildingId = serviceEB.GetElementByNumder(EducationalBuildingActive).Id;

                //id аудитории
                Guid AuditoriumId = service.GetElementByTitleAndEducationalBuilding(listBoxAuditoriums.SelectedItem.ToString(), EducationalBuildingId).Id;

                DayOfTheWeek day = (DayOfTheWeek)row + 1;
                Guid classtime = serviceCT.GetElementByNumber(column).Id;

                ScheduleViewModel scheduleDel = serviceS.GetElementByDayAndClassTimeAndAuditoriumId(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Int32.Parse(userControl.Name), day, classtime, AuditoriumId, "Аудитория");
                serviceS.DelElement(scheduleDel.Id);

                ScheduleLoad();
            }
            else
            {
                MessageBox.Show("Пара уже открыта для данной аудитории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
