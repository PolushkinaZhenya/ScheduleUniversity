using ScheduleBusinessLogic.Interfaces;
using ScheduleDesktop.AdditionalReferences;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormMain : Form
    {
        private readonly IMainService _service;

        public FormMain(IMainService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }

        #region Reference
        private void ТипыАудиторийToolStripMenuItem_Click(object sender, EventArgs e) => 
            AdditionalReferenceCreator.GetTypeOfAudienceForm().ShowDialog();

		private void ТипыКафедрToolStripMenuItem_Click(object sender, EventArgs e) => 
            AdditionalReferenceCreator.GetTypeOfDepartmentForm().ShowDialog();

        private void ТипыЗанятийToolStripMenuItem_Click(object sender, EventArgs e) => 
            AdditionalReferenceCreator.GetTypeOfClassForm().ShowDialog();

        private void УчебныеКорпусаToolStripMenuItem_Click(object sender, EventArgs e) => 
            AdditionalReferenceCreator.GetEducationalBuildingForm().ShowDialog();

        private void ВремяПереходаToolStripMenuItem_Click(object sender, EventArgs e) => 
            AdditionalReferenceCreator.GetTransitionTimeForm().ShowDialog();

        private void ВремяПроведенияПарToolStripMenuItem_Click(object sender, EventArgs e) =>
            AdditionalReferenceCreator.GetClassTimeForm().ShowDialog();

        private void КафедрыToolStripMenuItem_Click(object sender, EventArgs e) =>
            AdditionalReferenceCreator.GetDepartmentForm().ShowDialog();

        private void ДисциплиныToolStripMenuItem_Click(object sender, EventArgs e) =>
            AdditionalReferenceCreator.GetDisciplineForm().ShowDialog();

        private void ФакультетыToolStripMenuItem_Click(object sender, EventArgs e) =>
            AdditionalReferenceCreator.GetFacultyForm().ShowDialog();

        private void СпециальностиToolStripMenuItem_Click(object sender, EventArgs e) =>
            AdditionalReferenceCreator.GetSpecialtyForm().ShowDialog();
		#endregion

		private void УчебныеПланыToolStripMenuItem_Click(object sender, EventArgs e) => 
            DependencyManager.Instance.Resolve<FormCurriculums>().ShowDialog();

		private void УчебныеГодаToolStripMenuItem_Click(object sender, EventArgs e) => 
            DependencyManager.Instance.Resolve<FormAcademicYears>().ShowDialog();


		private void АудиторииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyManager.Instance.Resolve<FormAuditoriums>().ShowDialog();
            LoadSetting();
        }

        private void ПреподавателиToolStripMenuItem_Click(object sender, EventArgs e)
		{
            DependencyManager.Instance.Resolve<FormTeachers>().ShowDialog();
            LoadSetting();
        }

        private void УчебныеГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyManager.Instance.Resolve<FormStudyGroups>().ShowDialog();
            LoadSetting();
        }

        private void ПотокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyManager.Instance.Resolve<FormFlows>().ShowDialog();
			LoadSetting();
		}

        private void ButtonScheduleStudyGroups_Click(object sender, EventArgs e)
        {
            var control = new UserControlScheduleStudentGroups()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "UserControlScheduleStudentGroups",
                Size = new Size(903, 597),
                TabIndex = 0
            };
            panelContent.Controls.Clear();
            panelContent.Controls.Add(control);
            control.LoadData();
        }

        private void ButtonScheduleTeach_Click(object sender, EventArgs e)
        {
            var control = new UserControlScheduleTeachers()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "UserControlScheduleTeachers",
                Size = new Size(903, 597),
                TabIndex = 0
            };
            panelContent.Controls.Clear();
            panelContent.Controls.Add(control);
            control.LoadData();
        }

        private void ButtonScheduleAud_Click(object sender, EventArgs e)
        {
            var control = new UserControlScheduleAuditoriums()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "UserControlScheduleAuditoriums",
                Size = new Size(903, 597),
                TabIndex = 0
            };
            panelContent.Controls.Clear();
            panelContent.Controls.Add(control);
            control.LoadData();
        }

        private void ButtonHourOfSemesters_Click(object sender, EventArgs e)
        {
            DependencyManager.Instance.Resolve<FormHourOfSemesters>().Show();
            LoadSetting();
        }

		private void ButtonUpload_Click(object sender, EventArgs e) => (new FormUpload()).Show();

		private void ButtonSetting_Click(object sender, EventArgs e)
        {
            DependencyManager.Instance.Resolve<FormSettings>().ShowDialog();
            LoadSetting();
        }

		private void ButtonBD_Click(object sender, EventArgs e) => new FormConfiguration().ShowDialog();

        private void LoadSetting()
		{
            try
            {
                var period = Program.ReadAppSettingConfig(Program.CurrentPeriod);
                if (period.IsNotEmpty())
                {
                    var view = _service.GetPeriod(new Guid(period));
                    if (view != null)
					{
                        Text = $"Расписание университета. Учебный год {view.AcademicYearTitle} - {view.SemesterTitle} ({view.PeriodTitle})";
					}
                }
            }
            catch(Exception ex)
			{
                Program.ShowError(ex, "Ошибка");
			}
		}
	}
}