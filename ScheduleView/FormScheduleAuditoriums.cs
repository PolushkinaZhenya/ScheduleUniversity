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
using System.Configuration;
using ScheduleModel;

namespace ScheduleView
{
    public partial class FormScheduleAuditoriums : Form
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

        private readonly IEducationalBuildingService serviceEB;

        Button buttonEducationalBuilding;

        UserControlDataGridViewSchedule userControlFirstWeek;

        UserControlDataGridViewSchedule userControlSecondWeek;

        ScheduleViewModel scheduleActual = null;

        public FormScheduleAuditoriums(IScheduleService service, IStudyGroupService serviceSG, IClassTimeService serviceCT, IPeriodService serviceP,
            ILoadTeacherService serviceLT, IAuditoriumService serviceA, IFlowService serviceF, IEducationalBuildingService serviceEB)
        {
            InitializeComponent();
            this.service = service;
            this.serviceSG = serviceSG;
            this.serviceCT = serviceCT;
            this.serviceP = serviceP;
            this.serviceLT = serviceLT;
            this.serviceA = serviceA;
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
                List<AuditoriumViewModel> listAuditoriums = serviceA.GetListByEducationalBuilding(listEducationalBuilding[0].Number);
                for (int i = 0; i < listAuditoriums.Count; i++)
                {
                    listBoxAuditoriums.Items.Add(listAuditoriums[i].Number);
                }

                userControlFirstWeek = new UserControlDataGridViewSchedule();
                userControlFirstWeek.Clear();
                userControlFirstWeek.Dock = DockStyle.Fill;
                userControlFirstWeek.Name = "1";
                //userControlFirstWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseDoubleClick);
                userControlFirstWeek.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(userControlFirstWeek_CellMouseClick);
                splitContainer1.Panel1.Controls.Add(userControlFirstWeek);

                userControlSecondWeek = new UserControlDataGridViewSchedule();
                userControlSecondWeek.Clear();
                userControlSecondWeek.Dock = DockStyle.Fill;
                userControlSecondWeek.Name = "2";
                //userControlSecondWeek.dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(userControlSecondWeek_CellMouseDoubleClick);
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

        //выбор корпуса
        private void buttonEducationalBuilding_Click(object sender, EventArgs e)
        {
            listBoxAuditoriums.Items.Clear();

            Button buttonSelect = sender as Button;

            //List<StudyGroupViewModel> list = serviceSG.GetListByCourse(Int32.Parse(buttonSelect.Tag.ToString()));

            List<AuditoriumViewModel> listAuditoriums = serviceA.GetListByEducationalBuilding(buttonSelect.Tag.ToString());

            for (int i = 0; i < listAuditoriums.Count; i++)
            {
                listBoxAuditoriums.Items.Add(listAuditoriums[i].Number);
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

        //выбор аудитории
        private void listBoxAuditoriums_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
