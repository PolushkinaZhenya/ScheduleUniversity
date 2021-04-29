using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormSchedule : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IScheduleService service;

        private readonly IPeriodService serviceP;

        private readonly IClassTimeService serviceCT;

        private readonly IStudyGroupService serviceSG;

        private readonly IAuditoriumService serviceA;

        private readonly ITypeOfClassService serviceTC;

        private readonly IDisciplineService serviceD;

        private readonly ITeacherService serviceT;

        private readonly ILoadTeacherService serviceL;

        private Guid? id;

        public FormSchedule(IScheduleService service, IPeriodService serviceP, IClassTimeService serviceCT, IStudyGroupService serviceSG,
            IAuditoriumService serviceA, ITypeOfClassService serviceTC, IDisciplineService serviceD, ITeacherService serviceT, ILoadTeacherService serviceL)
        {
            InitializeComponent();
            this.service = service;
            this.serviceP = serviceP;
            this.serviceCT = serviceCT;
            this.serviceSG = serviceSG;
            this.serviceA = serviceA;
            this.serviceTC = serviceTC;
            this.serviceD = serviceD;
            this.serviceT = serviceT;
            this.serviceL = serviceL;
        }

        private void FormSchedule_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxDayOfTheWeek.DisplayMember = "Value";
                comboBoxDayOfTheWeek.ValueMember = "Key";
                comboBoxDayOfTheWeek.DataSource = Enum.GetValues(typeof(DayOfTheWeek));
                comboBoxDayOfTheWeek.SelectedItem = null;

                List<ClassTimeViewModel> listCT = serviceCT.GetList();
                if (listCT != null)
                {
                    comboBoxClassTime.DisplayMember = "Number";
                    comboBoxClassTime.ValueMember = "Id";
                    comboBoxClassTime.DataSource = listCT;
                    comboBoxClassTime.SelectedItem = null;
                }

                List<AuditoriumViewModel> listA = serviceA.GetList();
                if (listA != null)
                {
                    comboBoxAuditorium.DisplayMember = "Number";
                    comboBoxAuditorium.ValueMember = "Id";
                    comboBoxAuditorium.DataSource = listA;
                    comboBoxAuditorium.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    ScheduleViewModel view = service.GetElement(id.Value);
                    
                    if (view != null)
                    {
                        if (view.DayOfTheWeek == null)
                        {
                            textBoxPeriod.Text = view.PeriodTitle;
                            textBoxNumberWeeks.Text = view.NumberWeeks.ToString();
                            textBoxStudyGroup.Text = view.StudyGroupTitle;
                            textBoxSubgroups.Text = view.Subgroups.ToString();
                            textBoxTypeOfClass.Text = view.TypeOfClassTitle;
                            textBoxDiscipline.Text = view.DisciplineTitle;
                            textBoxTeacher.Text = view.TeacherSurname;
                        }
                        else
                        {
                            textBoxPeriod.Text = view.PeriodTitle;
                            textBoxNumberWeeks.Text = view.NumberWeeks.ToString();
                            comboBoxClassTime.SelectedValue = view.ClassTimeId;
                            comboBoxDayOfTheWeek.SelectedIndex = comboBoxDayOfTheWeek.Items.IndexOf(view.DayOfTheWeek);
                            textBoxStudyGroup.Text = view.StudyGroupTitle;
                            textBoxSubgroups.Text = view.Subgroups.ToString();
                            comboBoxAuditorium.SelectedValue = view.AuditoriumId;
                            textBoxTypeOfClass.Text = view.TypeOfClassTitle;
                            textBoxDiscipline.Text = view.DisciplineTitle;
                            textBoxTeacher.Text = view.TeacherSurname;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxDayOfTheWeek.SelectedValue == null || comboBoxClassTime.SelectedValue == null || comboBoxAuditorium.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (id.HasValue)
                {
                    ScheduleViewModel view = service.GetElement(id.Value);

                    service.UpdElement(new ScheduleBindingModel
                    {
                        Id = view.Id,
                        PeriodId = view.PeriodId,
                        NumberWeeks = view.NumberWeeks,
                        DayOfTheWeek = (DayOfTheWeek)comboBoxDayOfTheWeek.SelectedValue,
                        ClassTimeId = (Guid)comboBoxClassTime.SelectedValue,
                        StudyGroupId = view.StudyGroupId,
                        Subgroups = view.Subgroups,
                        AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue,
                        LoadTeacherId = view.LoadTeacherId
                    });
                }
                //else
                //{
                //    ScheduleViewModel view = service.GetElement(id.Value);

                //    service.AddElement(new ScheduleBindingModel
                //    {
                //        PeriodId = (Guid)comboBoxPeriod.SelectedValue,
                //        NumberWeeks = Int32.Parse(textBoxNumberWeeks.Text),
                //        DayOfTheWeek = comboBoxDayOfTheWeek.SelectedValue == null ? (DayOfTheWeek?)null : (DayOfTheWeek)comboBoxDayOfTheWeek.SelectedValue,
                //        ClassTimeId = comboBoxClassTime.SelectedValue == null ? (Guid?)null : (Guid)comboBoxClassTime.SelectedValue,
                //        StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
                //        Subgroups = textBoxSubgroups.Text == "" ? (int?)null : Int32.Parse(textBoxSubgroups.Text),
                //        AuditoriumId = comboBoxAuditorium.SelectedValue == null ? (Guid?)null : (Guid)comboBoxAuditorium.SelectedValue
                //    });
                //}
                //MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
