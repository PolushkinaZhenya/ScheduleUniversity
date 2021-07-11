using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormCurriculum : Form
	{
		public Guid Id { set { _id = value; } }

		private Guid? _id;

		private Guid? _semesterId = null;

		public Guid SemesterId { set { _semesterId = value; } }

		private readonly IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel> _service;

		private readonly Lazy<List<TypeOfClassViewModel>> _typeOfClass;

		private readonly Lazy<List<DisciplineViewModel>> _disciplines;

		private readonly Lazy<List<StudyGroupViewModel>> _studyGroups;

		private readonly Lazy<List<SemesterViewModel>> _semesters;

		public FormCurriculum(IBaseService<CurriculumBindingModel, CurriculumViewModel, CurriculumSearchModel> service,
			IBaseService<DisciplineBindingModel, DisciplineViewModel, DisciplineSearchModel> serviceD,
			IStudyGroupService serviceSG,
			IBaseService<TypeOfClassBindingModel, TypeOfClassViewModel, TypeOfClassSearchModel> serviceTC,
			IBaseService<SemesterBindingModel, SemesterViewModel, SemesterSearchModel> serviceS)
		{
			InitializeComponent();
			_service = service;
			_typeOfClass = new Lazy<List<TypeOfClassViewModel>>(() => { return serviceTC.GetList(); });
			_disciplines = new Lazy<List<DisciplineViewModel>>(() => { return serviceD.GetList(); });
			_studyGroups = new Lazy<List<StudyGroupViewModel>>(() => { return serviceSG.GetList(); });
			_semesters = new Lazy<List<SemesterViewModel>>(() => { return serviceS.GetList(); });
		}

		private void FormCurriculum_Load(object sender, EventArgs e)
		{
			try
			{
				if (_disciplines.Value != null)
				{
					comboBoxDiscipline.DisplayMember = "Title";
					comboBoxDiscipline.ValueMember = "Id";
					comboBoxDiscipline.DataSource = _disciplines.Value;
					comboBoxDiscipline.SelectedItem = null;
				}

				if (_studyGroups.Value != null)
				{
					comboBoxStudyGroup.DisplayMember = "Title";
					comboBoxStudyGroup.ValueMember = "Id";
					comboBoxStudyGroup.DataSource = _studyGroups.Value;
					comboBoxStudyGroup.SelectedItem = null;
				}

				if (_typeOfClass.Value != null)
				{
					comboBoxTypeOfClass.DisplayMember = "Title";
					comboBoxTypeOfClass.ValueMember = "Id";
					comboBoxTypeOfClass.DataSource = _typeOfClass.Value;
					comboBoxTypeOfClass.SelectedItem = null;
				}

				if (_semesters.Value != null)
				{
					comboBoxSemester.DisplayMember = "Title";
					comboBoxSemester.ValueMember = "Id";
					comboBoxSemester.DataSource = _semesters.Value;
					comboBoxSemester.SelectedItem = null;
					if (_semesterId.HasValue)
					{
						comboBoxSemester.SelectedValue = _semesterId.Value;
					}
				}

				if (_id.HasValue)
				{
					CurriculumViewModel view = _service.GetElement(new CurriculumSearchModel { Id = _id.Value });
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
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (comboBoxDiscipline.SelectedValue == null || textBoxNumderOfHours.Text.IsEmpty() || comboBoxStudyGroup.SelectedValue == null
				|| comboBoxTypeOfClass.SelectedValue == null || comboBoxSemester.SelectedValue == null)
			{
				Program.ShowError("Заполните все поля", "Ошибка");
				return;
			}

			try
			{
				if (_id.HasValue)
				{
					_service.UpdElement(new CurriculumBindingModel
					{
						Id = _id.Value,
						DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
						StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
						TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
						SemesterId = (Guid)comboBoxSemester.SelectedValue,
						NumderOfHours = int.Parse(textBoxNumderOfHours.Text)
					});
				}
				else
				{
					_service.AddElement(new CurriculumBindingModel
					{
						DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
						StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
						TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
						SemesterId = (Guid)comboBoxSemester.SelectedValue,
						NumderOfHours = int.Parse(textBoxNumderOfHours.Text)
					});
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}