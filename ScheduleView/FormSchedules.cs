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
    public partial class FormSchedules : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IScheduleService service;

        private readonly IStudyGroupService serviceSG;

        private readonly IClassTimeService serviceCT;

        Button buttonCourse;

        public FormSchedules(IScheduleService service, IStudyGroupService serviceSG, IClassTimeService serviceCT)
        {
            InitializeComponent();
            this.service = service;
            this.serviceSG = serviceSG;
            this.serviceCT = serviceCT;
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

                UserControlDataGridViewSchedule userControlFirstWeek = new UserControlDataGridViewSchedule();
                userControlFirstWeek.RowClear();
                userControlFirstWeek.Location = new Point(10, 80);
                userControlFirstWeek.Size = new Size(1300, 200); 
                //userControlFirstWeek.Dock = DockStyle.Fill;
                userControlFirstWeek.Name = "userControlFirstWeek";
                Controls.Add(userControlFirstWeek);

                UserControlDataGridViewSchedule userControlSecondWeek = new UserControlDataGridViewSchedule();
                userControlSecondWeek.RowClear();
                userControlSecondWeek.Location = new Point(10, 300);
                userControlSecondWeek.Size = new Size(1300, 200);
                //userControlFirstWeek.Dock = DockStyle.Fill;
                userControlSecondWeek.Name = "userControlFirstWeek";
                Controls.Add(userControlSecondWeek);



                List<ClassTimeViewModel> list = serviceCT.GetList();//номера пар

                List<string> dayOfTheWeek = Enum.GetNames(typeof(DayOfTheWeek)).ToList();//дни недели
                userControlFirstWeek.RowDayOfTheWeekAdd(dayOfTheWeek, Int32.Parse(ConfigurationManager.AppSettings["DayOfTheWeek"]));
                userControlSecondWeek.RowDayOfTheWeekAdd(dayOfTheWeek, Int32.Parse(ConfigurationManager.AppSettings["DayOfTheWeek"]));

                userControlFirstWeek.ColumnClassTimeAdd(list);
                userControlSecondWeek.ColumnClassTimeAdd(list);


                List<ScheduleViewModel> list2 = service.GetList();
                if (list2 != null)
                {
                    dataGridViewFirstWeek.DataSource = list2;
                    dataGridViewFirstWeek.Columns[0].Visible = false;
                    dataGridViewFirstWeek.Columns[1].Visible = false;
                    dataGridViewFirstWeek.Columns[5].Visible = false;
                    dataGridViewFirstWeek.Columns[7].Visible = false;
                    dataGridViewFirstWeek.Columns[10].Visible = false;
                    dataGridViewFirstWeek.Columns[12].Visible = false;
                    dataGridViewFirstWeek.Columns[14].Visible = false;
                    dataGridViewFirstWeek.Columns[16].Visible = false;
                    dataGridViewFirstWeek.Columns[2].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
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

            //if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
            //{
            //    UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы
            //    userControlDataGridViewSelect.RowClear();
            //}
            //else
            //{
            //    UserControlDataGridViewAll userControlDataGridViewSelect = (UserControlDataGridViewAll)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы
            //    userControlDataGridViewSelect.RowClear();
            //}
        }

        private void listBoxStudyGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
            //{
            //    LoadDataGridViewElse();
            //}
            //else
            //{
            //    LoadDataGridViewAll();
            //}
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSchedule>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewFirstWeek.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSchedule>();
                form.Id = (Guid)dataGridViewFirstWeek.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewFirstWeek.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Guid id = (Guid)dataGridViewFirstWeek.SelectedRows[0].Cells[0].Value;
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

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewFirstWeek.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSchedule>();
                form.Id = (Guid)dataGridViewFirstWeek.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
