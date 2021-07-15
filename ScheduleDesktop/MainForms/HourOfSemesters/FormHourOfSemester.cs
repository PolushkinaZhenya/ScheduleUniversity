using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormHourOfSemester : Form
	{
		private Guid? _id;

		public Guid Id { set { _id = value; } }

		private Guid? _facultyId;

		public Guid FacultyId { set { _facultyId = value; } }

		private Guid? _studyGroupId;

		public Guid StudyGroupId { set { _studyGroupId = value; } }

		private Guid _semesterId;

		private readonly IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel> _service;

		private readonly Lazy<List<DisciplineViewModel>> _disciplines;

		private readonly Lazy<List<StudyGroupViewModel>> _studyGroups;

		public FormHourOfSemester(IMainService serviceM,
			IBaseService<HourOfSemesterBindingModel, HourOfSemesterViewModel, HourOfSemesterSearchModel> service,
			IBaseService<DisciplineBindingModel, DisciplineViewModel, DisciplineSearchModel> serviceD,
			IBaseService<StudyGroupBindingModel, StudyGroupViewModel, StudyGroupSearchModel> serviceSG)
		{
			InitializeComponent();
			_service = service;
			var periodId = Program.ReadAppSettingConfig(Program.CurrentPeriod);
			if (periodId.IsNotEmpty())
			{
				try
				{
					var period = serviceM.GetPeriod(new Guid(periodId));
					if (period != null)
					{
						textBoxSemester.Text = period.SemesterTitle;
						_semesterId = period.SemesterId;
					}
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка получения периода");
				}
			}
			_disciplines = new Lazy<List<DisciplineViewModel>>(() => { return serviceD.GetList(); });
			_studyGroups = new Lazy<List<StudyGroupViewModel>>(() => { return serviceSG.GetList(new StudyGroupSearchModel { FacultyId = _facultyId }); });
		}

		private void FormHourOfSemester_Load(object sender, EventArgs e)
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
					if (_studyGroupId.HasValue)
					{
						comboBoxStudyGroup.SelectedValue = _studyGroupId.Value;
					}
				}
				if (_id.HasValue)
				{
					var view = _service.GetElement(new HourOfSemesterSearchModel { Id = _id.Value });
					if (view != null)
					{
						comboBoxDiscipline.SelectedValue = view.DisciplineId;
						comboBoxStudyGroup.SelectedValue = view.StudyGroupId;
						textBoxReporting.Text = view.Reporting;
						textBoxWishes.Text = view.Wishes;
						view.HourOfSemesterRecords.Reverse();
						foreach (var record in view.HourOfSemesterRecords)
						{
							var control = new UserControlHourOfSemesterTypeOfClass
							{
								Dock = DockStyle.Top
							};

							control.LoadData(_semesterId, _studyGroupId.Value, record);

							splitContainerData.Panel1.Controls.Add(control);
						}
					}
				}
			}
			catch(Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрухки данных");
			}
		}

		private void ButtonAddPanel_Click(object sender, EventArgs e)
		{
			if (comboBoxStudyGroup.SelectedValue == null)
			{
				Program.ShowError("Нужно выбрать учебную группу", "Ошибка");
				return;
			}
			var control = new UserControlHourOfSemesterTypeOfClass
			{
				Dock = DockStyle.Top,
				BorderStyle = BorderStyle.FixedSingle
			};

			control.LoadData(_semesterId, (Guid)comboBoxStudyGroup.SelectedValue);

			splitContainerData.Panel1.Controls.Add(control);
		}

		private void ComboBoxReportingForms_SelectedIndexChanged(object sender, EventArgs e) =>
			textBoxReporting.Text += $"{comboBoxReportingForms.Text}, ";

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (comboBoxDiscipline.SelectedValue == null || comboBoxStudyGroup.SelectedValue == null)
			{
				Program.ShowError("Должны быть выбраны дисциплина и группа", "Ошибка сохранения");
				return;
			}
			if (splitContainerData.Panel1.Controls.Count == 0)
			{
				Program.ShowError("Нет данных по типам занятий", "Ошибка сохранения");
				return;
			}
			var list = splitContainerData.Panel1.Controls.Cast<UserControlHourOfSemesterTypeOfClass>();
			foreach (var elem in list)
			{
				if (!elem.Check())
				{
					return;
				}
			}

			var model = new HourOfSemesterBindingModel
			{
				DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
				SemesterId = _semesterId,
				StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
				Reporting = textBoxReporting.Text,
				Wishes = textBoxWishes.Text,
				HourOfSemesterRecords = new List<HourOfSemesterRecordBindingModel>()
			};
			foreach (var elem in list)
			{
				model.HourOfSemesterRecords.Add(elem.GetHourOfSemesterRecordBindingModel());
			}
			try
			{
				if (_id.HasValue)
				{
					model.Id = _id.Value;
					_service.UpdElement(model);
				}
				else
				{
					_service.AddElement(model);
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch(Exception ex)
			{
				Program.ShowError(ex, "Ошибка сохранения");
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}