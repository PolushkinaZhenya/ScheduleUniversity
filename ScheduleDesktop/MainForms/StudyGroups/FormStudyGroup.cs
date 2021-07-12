using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using ScheduleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormStudyGroup : Form
    {
        private Guid? _id;

        public Guid Id { set { _id = value; } }

        private Guid? _facultyId = null;

        public Guid FacultyId { set { _facultyId = value; } }

        public string Course { set { textBoxCourse.Text = value; } }

        private readonly IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> _service;

        private string _speciality = string.Empty;

        private string _typeEduc = string.Empty;

        private string _formEduc = string.Empty;

        private string _course = string.Empty;

        private string _groupNumber = string.Empty;

        private readonly Lazy<List<SpecialtyViewModel>> _listS;

        private bool _isLoad = false;

        public FormStudyGroup(IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> service,
            IBaseService<SpecialtyBindingModel, SpecialtyViewModel, SpecialtySearchModel> serviceS)
        {
            InitializeComponent();
            _service = service;
            _listS = new Lazy<List<SpecialtyViewModel>>(() => { return serviceS.GetList(new SpecialtySearchModel { FacultyId = _facultyId.Value }); });
        }

        private void FormStudyGroup_Load(object sender, EventArgs e)
        {
            try
            {
                if (_listS.Value != null)
                {
                    comboBoxSpecialty.DisplayMember = "Title";
                    comboBoxSpecialty.ValueMember = "Id";
                    comboBoxSpecialty.DataSource = _listS.Value;
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

                if (_id.HasValue)
                {
                    StudyGroupViewModel view = _service.GetElement(new StudyGroupSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        comboBoxSpecialty.SelectedValue = view.SpecialtyId;
                        comboBoxTypeEducation.SelectedIndex = comboBoxTypeEducation.Items.IndexOf(view.TypeEducation);
                        comboBoxFormEducation.SelectedIndex = comboBoxFormEducation.Items.IndexOf(view.FormEducation);
                        textBoxCourse.Text = view.Course.ToString();
                        textBoxlGroupNumber.Text = view.GroupNumber.ToString();
                        textBoxNumderStudents.Text = view.NumderStudents.ToString();
                    }
                }

                _isLoad = true;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка загрузки");
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text.IsEmpty() || textBoxCourse.Text.IsEmpty() || textBoxNumderStudents.Text.IsEmpty() 
                 || comboBoxSpecialty.SelectedValue == null || comboBoxTypeEducation.SelectedValue == null || comboBoxFormEducation.SelectedValue == null)
            {
                Program.ShowError("Заполните все поля", "Ошибка");
                return;
            }

            try
            {
                if (_id.HasValue)
                {
                    _service.UpdElement(new StudyGroupBindingModel
                    {
                        Id = _id.Value,
                        Title = textBoxTitle.Text,
                        SpecialtyId = (Guid)comboBoxSpecialty.SelectedValue,
                        TypeEducation = (TypeEducation)comboBoxTypeEducation.SelectedValue,
                        FormEducation = (FormEducation)comboBoxFormEducation.SelectedValue,
                        Course = int.Parse(textBoxCourse.Text),
                        GroupNumber = int.Parse(textBoxlGroupNumber.Text),
                        NumderStudents = int.Parse(textBoxNumderStudents.Text)
                    });
                }
                else
                {
                    _service.AddElement(new StudyGroupBindingModel
                    {
                        Title = textBoxTitle.Text,
                        SpecialtyId = (Guid)comboBoxSpecialty.SelectedValue,
                        TypeEducation = (TypeEducation)comboBoxTypeEducation.SelectedValue,
                        FormEducation = (FormEducation)comboBoxFormEducation.SelectedValue,
                        Course = int.Parse(textBoxCourse.Text),
                        GroupNumber = int.Parse(textBoxlGroupNumber.Text),
                        NumderStudents = int.Parse(textBoxNumderStudents.Text)
                    });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка сохранения");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FillTitle()
		{
            if (_isLoad)
            {
                textBoxTitle.Text = $"{_speciality}{_typeEduc}{_formEduc}-{_course}{_groupNumber}";
            }
		}

		private void ComboBoxSpecialty_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (comboBoxSpecialty.SelectedValue != null)
			{
                var id = (Guid)comboBoxSpecialty.SelectedValue;
                var elem = _listS.Value.FirstOrDefault(x => x.Id == id);
                if (elem != null)
				{
                    _speciality = elem.AbbreviatedTitle;
                    FillTitle();
                }
			}
		}

		private void ComboBoxTypeEducation_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (comboBoxTypeEducation.SelectedValue != null)
			{
                var te = (TypeEducation)comboBoxTypeEducation.SelectedValue;
				_typeEduc = te switch
				{
					TypeEducation.Бакалавриат => "б",
					TypeEducation.Магистратура => "м",
					TypeEducation.Специалитет => "с",
					TypeEducation.Аспирантура => "а",
					_ => string.Empty,
				};
				FillTitle();
            }
		}

		private void ComboBoxFormEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFormEducation.SelectedValue != null)
            {
                var fe = (FormEducation)comboBoxFormEducation.SelectedValue;
				_formEduc = fe switch
				{
					FormEducation.Очная => "д",
					FormEducation.Заочная => "з",
					FormEducation.Очнозаочная => "в",
					FormEducation.Дистанционно => "д",
					_ => string.Empty,
				};
				FillTitle();
            }
        }

		private void TextBoxCourse_TextChanged(object sender, EventArgs e)
		{
            _course = textBoxCourse.Text;
            FillTitle();
        }

		private void TextBoxlGroupNumber_TextChanged(object sender, EventArgs e)
		{
            _groupNumber = textBoxlGroupNumber.Text;
            FillTitle();
        }
	}
}