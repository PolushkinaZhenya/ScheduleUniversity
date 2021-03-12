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
    public partial class FormStudyGroup : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IStudyGroupService service;

        private readonly ISpecialtyService serviceS;

        private Guid? id;


        public FormStudyGroup(IStudyGroupService service, ISpecialtyService serviceS)
        {
            InitializeComponent();
            this.service = service;
            this.serviceS = serviceS;
        }

        private void FormStudyGroup_Load(object sender, EventArgs e)
        {
            try
            {
                List<SpecialtyViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxSpecialty.DisplayMember = "Title";
                    comboBoxSpecialty.ValueMember = "Id";
                    comboBoxSpecialty.DataSource = listS;
                    comboBoxSpecialty.SelectedItem = null;
                }

                comboBoxTypeEducation.DisplayMember = "Value";
                comboBoxTypeEducation.ValueMember = "Key";
                comboBoxTypeEducation.DataSource = Enum.GetValues(typeof(TypeEducation));
                comboBoxTypeEducation.SelectedItem = null;

                comboBoxFormEducation.DisplayMember = "Value";
                comboBoxFormEducation.ValueMember = "Key";
                comboBoxFormEducation.DataSource = Enum.GetValues(typeof(FormEducation));
                comboBoxFormEducation.SelectedItem = null;

                if (id.HasValue)
                {
                    StudyGroupViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        textBoxCourse.Text = view.Course.ToString();
                        textBoxNumderStudents.Text = view.NumderStudents.ToString();
                        textBoxNumderSubgroups.Text = view.NumderSubgroups.ToString();
                        comboBoxSpecialty.SelectedValue = view.SpecialtyId;

                        comboBoxTypeEducation.SelectedValue = view.TypeEducation;

                        //comboBoxTypeEducation.SelectedValue = (int)Enum.Parse(typeof(TypeEducation), view.TypeEducation);

                        //object n = Enum.Parse(typeof(TypeEducation), view.TypeEducation);
                        

                        comboBoxFormEducation.SelectedValue = view.FormEducation;
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
            if (string.IsNullOrEmpty(textBoxTitle.Text) || string.IsNullOrEmpty(textBoxCourse.Text)
                            || string.IsNullOrEmpty(textBoxNumderStudents.Text) || string.IsNullOrEmpty(textBoxNumderSubgroups.Text)
                            || comboBoxSpecialty.SelectedValue == null || comboBoxTypeEducation.SelectedValue == null 
                            || comboBoxFormEducation.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new StudyGroupBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxTitle.Text,
                        Course = Int32.Parse(textBoxCourse.Text),
                        NumderStudents = Int32.Parse(textBoxNumderStudents.Text),
                        NumderSubgroups = Int32.Parse(textBoxNumderSubgroups.Text),
                        SpecialtyId = (Guid)comboBoxSpecialty.SelectedValue,
                        TypeEducation = (TypeEducation)comboBoxTypeEducation.SelectedValue,
                        FormEducation = (FormEducation)comboBoxFormEducation.SelectedValue
                    });
                }
                else
                {
                    service.AddElement(new StudyGroupBindingModel
                    {
                        Title = textBoxTitle.Text,
                        Course = Int32.Parse(textBoxCourse.Text),
                        NumderStudents = Int32.Parse(textBoxNumderStudents.Text),
                        NumderSubgroups = Int32.Parse(textBoxNumderSubgroups.Text),
                        SpecialtyId = (Guid)comboBoxSpecialty.SelectedValue,
                        TypeEducation = (TypeEducation)comboBoxTypeEducation.SelectedValue,
                        FormEducation = (FormEducation)comboBoxFormEducation.SelectedValue
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
