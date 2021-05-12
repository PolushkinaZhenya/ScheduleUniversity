using ScheduleServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public IRecordService serviceR;

        public FormMain(IRecordService serviceR)
        {
            InitializeComponent();
            this.serviceR = serviceR;
        }

        private void типыАудиторийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfAudiences>();
            form.ShowDialog();
        }

        private void типыКафедрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfDepartments>();
            form.ShowDialog();
        }

        private void типыЗанятийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfClasses>();
            form.ShowDialog();
        }

        private void учебныеКорпусаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormEducationalBuildings>();
            form.ShowDialog();
        }

        private void времяПереходаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTransitionTimes>();
            form.ShowDialog();
        }

        private void времяПроведенияПарToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClassTimes>();
            form.ShowDialog();
        }

        private void учебныеГодаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAcademicYears>();
            form.ShowDialog();
        }

        private void семестрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSemesters>();
            form.ShowDialog();
        }

        private void периодыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPeriods>();
            form.ShowDialog();
        }

        private void кафедрыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDepartments>();
            form.ShowDialog();
        }

        private void аудиторииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuditoriums>();
            form.ShowDialog();
        }

        private void преподавателиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTeachers>();
            form.ShowDialog();
        }

        private void дисциплиныToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDisciplines>();
            form.ShowDialog();
        }

        private void факультетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFaculties>();
            form.ShowDialog();
        }

        private void специальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSpecialties>();
            form.ShowDialog();
        }

        private void учебныеГруппыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStudyGroups>();
            form.ShowDialog();
        }

        private void потокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFlows>();
            form.ShowDialog();
        }

        private void учебныеПланыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormCurriculums>();
                form.ShowDialog();
            }
        }

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormSchedules>();
                form.ShowDialog();
            }
        }

        private void расчасовкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["IDAcademicYear"] == "")
            {
                MessageBox.Show("Заполните настройки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var form = Container.Resolve<FormLoadTeachers>();
                form.ShowDialog();
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSettings>();
            form.ShowDialog();
        }

        private void сохранитьВHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "html|*.html"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    serviceR.SaveHtml(sfd.FileName);

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьВEcxelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    serviceR.SaveExcel(sfd.FileName);

                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
