using ScheduleDesktop.AdditionalReferences;
using System;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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

        private void УчебныеГодаToolStripMenuItem_Click(object sender, EventArgs e) => 
            DependencyManager.Instance.Resolve<FormAcademicYears>().ShowDialog();


		private void АудиторииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			var form = DependencyManager.Instance.Resolve<FormAuditoriums>();
			form.ShowDialog();

			//LoadSetting();
		}

        private void ПреподавателиToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormTeachers>();
			form.ShowDialog();

			//LoadSetting();
		}

        private void УчебныеГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormStudyGroups>();
            form.ShowDialog();
        }

        private void ПотокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = DependencyManager.Instance.Resolve<FormFlows>();
			form.ShowDialog();

			//LoadSetting();
		}

        private void учебныеПланыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            //{
            //    MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    var form = Container.Resolve<FormCurriculums>();
            //    form.ShowDialog();

            //    LoadSetting();
            //}
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            //{
            //    MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    var form = Container.Resolve<FormSchedules>();
            //    form.ShowDialog();
            //}
        }

        private void РасчасовкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ButtonScheduleStudyGroups_Click(object sender, EventArgs e)
        {
        }

        private void ButtonLoads_Click(object sender, EventArgs e)
        {
            //if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            //{
            //    MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            DependencyManager.Instance.Resolve<FormLoadTeachers>().Show();
            //}
        }

        private void ToolStripMenuItemSync_Click(object sender, EventArgs e)
        {
            //var form = Container.Resolve<FormSyncWith1C>();
            //form.ShowDialog();
            //LoadSetting();
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

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            //var form = Container.Resolve<FormSettings>();
            //form.ShowDialog();

            //LoadSetting();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

		private void ButtonBD_Click(object sender, EventArgs e) => new FormConfiguration().ShowDialog();
	}
}