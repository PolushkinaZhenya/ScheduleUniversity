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
    public partial class FormCurriculum : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly ICurriculumService service;

        private readonly IDisciplineService serviceD;

        private readonly IStudyGroupService serviceSG;

        private readonly ITypeOfClassService serviceTC;

        private readonly ISemesterService serviceS;

        private Guid? id;

        public FormCurriculum(ICurriculumService service, IDisciplineService serviceD, 
            IStudyGroupService serviceSG, ITypeOfClassService serviceTC, ISemesterService serviceS)
        {
            InitializeComponent();
            this.service = service;
            this.serviceD = serviceD;
            this.serviceSG = serviceSG;
            this.serviceTC = serviceTC;
            this.serviceS = serviceS;
        }

        private void FormCurriculum_Load(object sender, EventArgs e)
        {
            try
            {
                List<DisciplineViewModel> listD = serviceD.GetList();
                if (listD != null)
                {
                    comboBoxDiscipline.DisplayMember = "Title";
                    comboBoxDiscipline.ValueMember = "Id";
                    comboBoxDiscipline.DataSource = listD;
                    comboBoxDiscipline.SelectedItem = null;
                }

                List<StudyGroupViewModel> listSG = serviceSG.GetList();
                if (listSG != null)
                {
                    comboBoxStudyGroup.DisplayMember = "Title";
                    comboBoxStudyGroup.ValueMember = "Id";
                    comboBoxStudyGroup.DataSource = listSG;
                    comboBoxStudyGroup.SelectedItem = null;
                }

                List<TypeOfClassViewModel> listTC = serviceTC.GetList();
                if (listTC != null)
                {
                    comboBoxTypeOfClass.DisplayMember = "Title";
                    comboBoxTypeOfClass.ValueMember = "Id";
                    comboBoxTypeOfClass.DataSource = listTC;
                    comboBoxTypeOfClass.SelectedItem = null;
                }

                List<SemesterViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxSemester.DisplayMember = "Title";
                    comboBoxSemester.ValueMember = "Id";
                    comboBoxSemester.DataSource = listS;
                    comboBoxSemester.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    CurriculumViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        comboBoxDiscipline.SelectedValue = view.DisciplineId;
                        comboBoxStudyGroup.SelectedValue = view.StudyGroupId;
                        comboBoxTypeOfClass.SelectedValue = view.TypeOfClassId;
                        comboBoxSemester.SelectedValue = view.SemesterId;
                        textBoxNumderOfHours.Text = view.NumderOfHours.ToString();
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
            if (comboBoxDiscipline.SelectedValue == null || string.IsNullOrEmpty(textBoxNumderOfHours.Text) || comboBoxStudyGroup.SelectedValue == null
                || comboBoxTypeOfClass.SelectedValue == null || comboBoxSemester.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new CurriculumBindingModel
                    {
                        Id = id.Value,
                        DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                        StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
                        TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                        SemesterId = (Guid)comboBoxSemester.SelectedValue,
                        NumderOfHours = Int32.Parse(textBoxNumderOfHours.Text)
                    });
                }
                else
                {
                    service.AddElement(new CurriculumBindingModel
                    {
                        DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                        StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
                        TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                        SemesterId = (Guid)comboBoxSemester.SelectedValue,
                        NumderOfHours = Int32.Parse(textBoxNumderOfHours.Text)
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
