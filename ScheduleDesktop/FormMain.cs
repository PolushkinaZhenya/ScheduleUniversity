﻿using ScheduleBusinessLogic.Interfaces;
using ScheduleDesktop.AdditionalReferences;
using System;
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
        }

        private void ButtonHourOfSemesters_Click(object sender, EventArgs e)
        {
            DependencyManager.Instance.Resolve<FormHourOfSemesters>().Show();
            LoadSetting();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            //{
            //    MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    var form = Container.Resolve<FormSave>();
            //    form.ShowDialog();

            //    LoadSetting();
            //}
        }

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