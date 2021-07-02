using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
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
        public Guid Id { set { id = value; } }

        private readonly IStudyGroupService service;

        private readonly IAdditionalReference<SpecialtyBindingModel, SpecialtyViewModel> serviceS;

        private Guid? id;

        private string _speciality = string.Empty;

        private string _typeEduc = string.Empty;

        private string _formEduc = string.Empty;

        private string _course = string.Empty;

        private string _groupNumber = string.Empty;

        private List<SpecialtyViewModel> _listS;

        private bool _isLoad = false;

        public FormStudyGroup(IStudyGroupService service, IAdditionalReference<SpecialtyBindingModel, SpecialtyViewModel> serviceS)
        {
            InitializeComponent();
            this.service = service;
            this.serviceS = serviceS;
        }

        private void FormStudyGroup_Load(object sender, EventArgs e)
        {
            try
            {
                _listS = serviceS.GetList();
                if (_listS != null)
                {
                    comboBoxSpecialty.DisplayMember = "Title";
                    comboBoxSpecialty.ValueMember = "Id";
                    comboBoxSpecialty.DataSource = _listS;
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
                        comboBoxSpecialty.SelectedValue = view.SpecialtyId;
                        comboBoxTypeEducation.SelectedIndex = comboBoxTypeEducation.Items.IndexOf(view.TypeEducation);
                        comboBoxFormEducation.SelectedIndex = comboBoxFormEducation.Items.IndexOf(view.FormEducation);
                        textBoxCourse.Text = view.Course.ToString();
                        textBoxlGroupNumber.Text = view.GroupNumber.ToString();
                        textBoxNumderStudents.Text = view.NumderStudents.ToString();
                        textBoxNumderSubgroups.Text = view.NumderSubgroups.ToString();
                    }

                    buttonDel.Visible = true;
                }

                _isLoad = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
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
                        SpecialtyId = (Guid)comboBoxSpecialty.SelectedValue,
                        TypeEducation = (TypeEducation)comboBoxTypeEducation.SelectedValue,
                        FormEducation = (FormEducation)comboBoxFormEducation.SelectedValue,
                        Course = int.Parse(textBoxCourse.Text),
                        GroupNumber = int.Parse(textBoxlGroupNumber.Text),
                        NumderStudents = int.Parse(textBoxNumderStudents.Text),
                        NumderSubgroups = int.Parse(textBoxNumderSubgroups.Text)
                    });
                }
                else
                {
                    service.AddElement(new StudyGroupBindingModel
                    {
                        Title = textBoxTitle.Text,
                        SpecialtyId = (Guid)comboBoxSpecialty.SelectedValue,
                        TypeEducation = (TypeEducation)comboBoxTypeEducation.SelectedValue,
                        FormEducation = (FormEducation)comboBoxFormEducation.SelectedValue,
                        Course = int.Parse(textBoxCourse.Text),
                        GroupNumber = int.Parse(textBoxlGroupNumber.Text),
                        NumderStudents = int.Parse(textBoxNumderStudents.Text),
                        NumderSubgroups = int.Parse(textBoxNumderSubgroups.Text)
                    });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        service.DelElement(id.Value);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
                var elem = _listS.FirstOrDefault(x => x.Id == id);
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
                switch(te)
				{
                    case TypeEducation.Бакалавриат:
                        _typeEduc = "б";
                        break;
                    case TypeEducation.Магистратура:
                        _typeEduc = "м";
                        break;
                    case TypeEducation.Специалитет:
                        _typeEduc = "с";
                        break;
                    case TypeEducation.Аспирантура:
                        _typeEduc = "а";
                        break;
                    default:
                        _typeEduc = string.Empty;
                        break;
                }
                FillTitle();
            }
		}

		private void ComboBoxFormEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFormEducation.SelectedValue != null)
            {
                var fe = (FormEducation)comboBoxFormEducation.SelectedValue;
                switch (fe)
                {
                    case FormEducation.Очная:
                        _formEduc = "д";
                        break;
                    case FormEducation.Заочная:
                        _formEduc = "з";
                        break;
                    case FormEducation.Очнозаочная:
                        _formEduc = "в";
                        break;
                    case FormEducation.Дистанционно:
                        _formEduc = "д";
                        break;
                    default:
                        _formEduc = string.Empty;
                        break;
                }
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