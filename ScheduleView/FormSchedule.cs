using ScheduleModel;
using ScheduleServiceDAL.BindingModels;
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

        private Guid? id;

        public FormSchedule(IScheduleService service, IPeriodService serviceP, IClassTimeService serviceCT, IStudyGroupService serviceSG,
            IAuditoriumService serviceA, ITypeOfClassService serviceTC, IDisciplineService serviceD, ITeacherService serviceT)
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
        }

        private void FormSchedule_Load(object sender, EventArgs e)
        {
            try
            {
                List<PeriodViewModel> listP = serviceP.GetList();
                if (listP != null)
                {
                    comboBoxPeriod.DisplayMember = "Title";
                    comboBoxPeriod.ValueMember = "Id";
                    comboBoxPeriod.DataSource = listP;
                    comboBoxPeriod.SelectedItem = null;
                }

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

                List<StudyGroupViewModel> listSG = serviceSG.GetList();
                if (listSG != null)
                {
                    comboBoxStudyGroup.DisplayMember = "Title";
                    comboBoxStudyGroup.ValueMember = "Id";
                    comboBoxStudyGroup.DataSource = listSG;
                    comboBoxStudyGroup.SelectedItem = null;
                }

                List<AuditoriumViewModel> listA = serviceA.GetList();
                if (listA != null)
                {
                    comboBoxAuditorium.DisplayMember = "Number";
                    comboBoxAuditorium.ValueMember = "Id";
                    comboBoxAuditorium.DataSource = listA;
                    comboBoxAuditorium.SelectedItem = null;
                }

                List<TypeOfClassViewModel> listTC = serviceTC.GetList();
                if (listTC != null)
                {
                    comboBoxTypeOfClass.DisplayMember = "Title";
                    comboBoxTypeOfClass.ValueMember = "Id";
                    comboBoxTypeOfClass.DataSource = listTC;
                    comboBoxTypeOfClass.SelectedItem = null;
                }

                List<DisciplineViewModel> listD = serviceD.GetList();
                if (listD != null)
                {
                    comboBoxDiscipline.DisplayMember = "Title";
                    comboBoxDiscipline.ValueMember = "Id";
                    comboBoxDiscipline.DataSource = listD;
                    comboBoxDiscipline.SelectedItem = null;
                }

                List<TeacherViewModel> listT = serviceT.GetList();
                if (listT != null)
                {
                    comboBoxTeacher.DisplayMember = "Surname";
                    comboBoxTeacher.ValueMember = "Id";
                    comboBoxTeacher.DataSource = listT;
                    comboBoxTeacher.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    ScheduleViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        comboBoxPeriod.SelectedValue = view.PeriodId;
                        textBoxNumberWeeks.Text = view.NumberWeeks.ToString();
                        comboBoxDayOfTheWeek.SelectedValue = view.DayOfTheWeek;
                        comboBoxClassTime.SelectedValue = view.ClassTimeId;
                        comboBoxStudyGroup.SelectedValue = view.StudyGroupId;
                        textBoxSubgroups.Text = view.Subgroups.ToString();
                        comboBoxAuditorium.SelectedValue = view.AuditoriumId;
                        comboBoxTypeOfClass.SelectedValue = view.TypeOfClassId;
                        comboBoxDiscipline.SelectedValue = view.DisciplineId;
                        comboBoxTeacher.SelectedValue = view.TeacherId;
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
            if (string.IsNullOrEmpty(textBoxNumberWeeks.Text) || string.IsNullOrEmpty(textBoxSubgroups.Text) || comboBoxPeriod.SelectedValue == null
                || comboBoxDayOfTheWeek.SelectedValue == null || comboBoxDayOfTheWeek.SelectedValue == null
                || comboBoxClassTime.SelectedValue == null || comboBoxStudyGroup.SelectedValue == null
                || comboBoxAuditorium.SelectedValue == null || comboBoxTypeOfClass.SelectedValue == null
                || comboBoxDiscipline.SelectedValue == null || comboBoxTeacher.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new ScheduleBindingModel
                    {
                        Id = id.Value,
                        PeriodId = (Guid)comboBoxPeriod.SelectedValue,
                        NumberWeeks = Int32.Parse(textBoxNumberWeeks.Text),
                        DayOfTheWeek = (DayOfTheWeek)comboBoxDayOfTheWeek.SelectedValue,
                        ClassTimeId = (Guid)comboBoxClassTime.SelectedValue,
                        StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
                        Subgroups = Int32.Parse(textBoxSubgroups.Text),
                        AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue,
                        TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                        DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                        TeacherId = (Guid)comboBoxTeacher.SelectedValue
                    });
                }
                else
                {
                    service.AddElement(new ScheduleBindingModel
                    {
                        PeriodId = (Guid)comboBoxPeriod.SelectedValue,
                        NumberWeeks = Int32.Parse(textBoxNumberWeeks.Text),
                        DayOfTheWeek = (DayOfTheWeek)comboBoxDayOfTheWeek.SelectedValue,
                        ClassTimeId = (Guid)comboBoxClassTime.SelectedValue,
                        StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
                        Subgroups = Int32.Parse(textBoxSubgroups.Text),
                        AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue,
                        TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                        DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                        TeacherId = (Guid)comboBoxTeacher.SelectedValue
                    });
                }
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
