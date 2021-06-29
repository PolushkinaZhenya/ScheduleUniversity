using Unity;
using System;
using System.Linq;
using ScheduleModel;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using ScheduleBusinessLogic.BindingModels;

namespace ScheduleView
{
    public partial class FormScheduleTeachers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IScheduleService serviceS;

        private readonly IClassTimeService serviceCT;

        private readonly ILoadTeacherService serviceLT;

        private readonly IAuditoriumService serviceA;

        private readonly IFlowService serviceF;

        private readonly IEducationalBuildingService serviceEB;

        private readonly ITeacherService service;

        UserControlDataGridViewSchedule userControlFirstWeek;

        UserControlDataGridViewSchedule userControlSecondWeek;

        TabControl tabControlTeacher = new TabControl();

        public FormScheduleTeachers(IScheduleService serviceS, IClassTimeService serviceCT, ILoadTeacherService serviceLT,
            IAuditoriumService serviceA, IFlowService serviceF, IEducationalBuildingService serviceEB, ITeacherService service)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceCT = serviceCT;
            this.serviceLT = serviceLT;
            this.serviceA = serviceA;
            this.serviceF = serviceF;
            this.serviceEB = serviceEB;
            this.service = service;
        }

        private void FormScheduleTeachers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Controls.Remove(tabControlTeacher);

                List<char> ABC = new List<char>() { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Э', 'Ю', 'Я' };

                //заполнение вкладок типов занятий
                tabControlTeacher = new TabControl();
                tabControlTeacher.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tabControlTeacher.Location = new Point(10, 10);
                tabControlTeacher.Size = new Size(1400, 400);
                tabControlTeacher.SelectedIndex = 0;
                tabControlTeacher.TabIndex = 1;
                tabControlTeacher.Dock = DockStyle.Fill;
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

                    dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseDoubleClick);
                    dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseClick);

                    tabPage.Controls.Add(dataGridView);//добавили таблицу
                    tabControlTeacher.TabPages.Add(tabPage);//добавили вкладку
                }
                //Controls.Add(tabControlTeacher);//добавили весь Control
                splitContainer1.Panel1.Controls.Add(tabControlTeacher);

                userControlFirstWeek = new UserControlDataGridViewSchedule();
                userControlFirstWeek.Clear();
                userControlFirstWeek.Dock = DockStyle.Fill;
                userControlFirstWeek.Name = "1";
                //userControlFirstWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseDoubleClick);
                userControlFirstWeek.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseClick);
                splitContainer2.Panel1.Controls.Add(userControlFirstWeek);

                userControlSecondWeek = new UserControlDataGridViewSchedule();
                userControlSecondWeek.Clear();
                userControlSecondWeek.Dock = DockStyle.Fill;
                userControlSecondWeek.Name = "2";
                //userControlSecondWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlSecondWeek_CellMouseDoubleClick);
                userControlSecondWeek.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(userControlSecondWeek_CellMouseClick);
                splitContainer2.Panel2.Controls.Add(userControlSecondWeek);

                LoadDataGridViewsEmpty();
                LoadDataGridViewSelect();
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

        //смена вкладки на tabControl
        private void tabControlTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridViewSelect();
        }

        //заполнение dataGridView на выбранной вкладке списком преподавателей
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

        //пустые DataGridViews с расписанием
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

        //выбор преподавателя
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //поиск таблицы на выбранной вкладке
            DataGridView dataGridViewSelect = (DataGridView)(tabControlTeacher.SelectedTab as TabPage).Controls.Find(tabControlTeacher.SelectedTab.Tag.ToString(), true)[0];

            if (dataGridViewSelect.SelectedRows.Count == 1)
            {
                ScheduleLoad((Guid)dataGridViewSelect.SelectedRows[0].Cells[0].Value);
            }
        }

        //загрузка расписания преподавателя
        private void ScheduleLoad(Guid TeacherId)
        {
            userControlFirstWeek.Clear();
            userControlSecondWeek.Clear();
            LoadDataGridViewsEmpty();

            //расставленные пары
            List<ScheduleViewModel> scheduleByTeacherFill = serviceS.GetListByPeroidAndTeacherFill(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), TeacherId, "Занятие");

            for (int i = 0; i < scheduleByTeacherFill.Count; i++)
            {
                if (scheduleByTeacherFill[i].NumberWeeks == 1) //заполнение первой недели
                {
                    ScheduleLoadWeek(scheduleByTeacherFill[i], userControlFirstWeek);
                }
                else //заполнение второй недели
                {
                    ScheduleLoadWeek(scheduleByTeacherFill[i], userControlSecondWeek);
                }
            }

            //отображаем "закрытые" пары
            List<ScheduleViewModel> scheduleByTeacherClose = serviceS.GetListByPeroidAndTeacherClose(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), TeacherId, "Преподаватель");
            for (int i = 0; i < scheduleByTeacherClose.Count; i++)
            {
                if (scheduleByTeacherClose[i].NumberWeeks == 1) //заполнение первой недели
                {
                    //определение дня недели
                    int dayofweek = userControlFirstWeek.GetIndexDayOfTheWeek(scheduleByTeacherClose[i].DayOfTheWeek.ToString());

                    userControlFirstWeek.dataGridView[scheduleByTeacherClose[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                    userControlFirstWeek.dataGridView[scheduleByTeacherClose[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Препод";
                }
                else //вторая неделя
                {
                    //определение дня недели
                    int dayofweek = userControlSecondWeek.GetIndexDayOfTheWeek(scheduleByTeacherClose[i].DayOfTheWeek.ToString());

                    userControlSecondWeek.dataGridView[scheduleByTeacherClose[i].ClassTimeNumber.ToString(), dayofweek].Style.BackColor = Color.Red;
                    userControlSecondWeek.dataGridView[scheduleByTeacherClose[i].ClassTimeNumber.ToString(), dayofweek].Tag = "Препод";
                }
            }
        }

        //загрузка расписания преподавателя на неделю
        private void ScheduleLoadWeek(ScheduleViewModel scheduleByTeacherFill, UserControlDataGridViewSchedule userControl)
        {
            //формируем значение ячейки
            string schedule;
            string educationalbuilding = serviceA.GetElement((Guid)scheduleByTeacherFill.AuditoriumId).EducationalBuilding;// № корпуса

            //есть ли группы в потоке
            LoadTeacherViewModel loadTeacher = serviceLT.GetElement(scheduleByTeacherFill.LoadTeacherId);//расчасовка занятия
            List<FlowStudyGroupViewModel> flow = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;//поток расчасовки

            if (flow.Count > 1)
            {
                schedule = scheduleByTeacherFill.TypeOfClassTitle + "." + scheduleByTeacherFill.DisciplineTitle + "\n";

                for (int f = 0; f < flow.Count; f++)
                {
                    if (flow[f].Subgroup != null)
                    {
                        schedule += flow[f].StudyGroupTitle + " - " + flow[f].Subgroup + " п/г" + " ";
                    }
                    else
                    {
                        schedule += flow[f].StudyGroupTitle + " ";
                    }
                }
                schedule += "\n" + scheduleByTeacherFill.TeacherSurname + " " + educationalbuilding + "-" + scheduleByTeacherFill.AuditoriumNumber;
            }
            else
            {
                schedule = scheduleByTeacherFill.TypeOfClassTitle + "." + scheduleByTeacherFill.DisciplineTitle
                        + " " + scheduleByTeacherFill.StudyGroupTitle;

                if (scheduleByTeacherFill.Subgroups != null)
                {
                    schedule += " - " + scheduleByTeacherFill.Subgroups + " п/г";
                }
                schedule += "\n" + scheduleByTeacherFill.TeacherSurname + " " +
                        educationalbuilding + "-" + scheduleByTeacherFill.AuditoriumNumber;
            }

            //определение дня недели
            int dayofweek = userControl.GetIndexDayOfTheWeek(scheduleByTeacherFill.DayOfTheWeek.ToString());

            //если ячейка пустая (для пар потока)
            if (userControl.dataGridView[scheduleByTeacherFill.ClassTimeNumber.ToString(), dayofweek].Value == null)
            {
                userControl.Value(scheduleByTeacherFill.ClassTimeNumber.ToString(), dayofweek, schedule);
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
                //поиск таблицы на выбранной вкладке
                DataGridView dataGridViewSelect = (DataGridView)(tabControlTeacher.SelectedTab as TabPage).Controls.Find(tabControlTeacher.SelectedTab.Tag.ToString(), true)[0];
                Guid TeacherId;
                if (dataGridViewSelect.SelectedRows.Count == 1)
                {
                    TeacherId = (Guid)dataGridViewSelect.SelectedRows[0].Cells[0].Value;
                }
                else
                {
                    MessageBox.Show("Выберите преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DayOfTheWeek day = (DayOfTheWeek)row + 1;
                Guid classtime = serviceCT.GetElementByNumber(column).Id;

                serviceS.AddElement(new ScheduleBindingModel
                {
                    PeriodId = new Guid(ConfigurationManager.AppSettings["IDPeriod"]),
                    NumberWeeks = Int32.Parse(userControl.Name.ToString()),
                    DayOfTheWeek = day,
                    Type = "Преподаватель",
                    ClassTimeId = classtime,
                    StudyGroupId = null,
                    Subgroups = null,
                    AuditoriumId = null,
                    LoadTeacherId = null,
                    TeacherId = TeacherId
                });

                ScheduleLoad(TeacherId);
            }
            else
            {
                MessageBox.Show("Пара уже закрыта для данного преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //поиск таблицы на выбранной вкладке
                DataGridView dataGridViewSelect = (DataGridView)(tabControlTeacher.SelectedTab as TabPage).Controls.Find(tabControlTeacher.SelectedTab.Tag.ToString(), true)[0];
                Guid TeacherId;
                if (dataGridViewSelect.SelectedRows.Count == 1)
                {
                    TeacherId = (Guid)dataGridViewSelect.SelectedRows[0].Cells[0].Value;
                }
                else
                {
                    MessageBox.Show("Выберите преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DayOfTheWeek day = (DayOfTheWeek)row + 1;
                Guid classtime = serviceCT.GetElementByNumber(column).Id;

                ScheduleViewModel scheduleDel = serviceS.GetElementByDayAndClassTimeAndTeacherId(new Guid(ConfigurationManager.AppSettings["IDPeriod"]), Int32.Parse(userControl.Name), day, classtime, TeacherId, "Преподаватель");
                serviceS.DelElement(scheduleDel.Id);

                ScheduleLoad(TeacherId);
            }
            else
            {
                MessageBox.Show("Пара уже открыта для данного преподавателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
