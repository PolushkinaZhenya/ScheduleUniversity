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
    public partial class FormLoadTeachers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ILoadTeacherService service;


        private readonly IStudyGroupService serviceSG;

        public FormLoadTeachers(ILoadTeacherService service, IStudyGroupService serviceSG)
        {
            InitializeComponent();
            this.service = service;
            this.serviceSG = serviceSG;
        }

        private void FormLoadTeachers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                listBoxStudyGroups.Items.Clear();
                List<StudyGroupViewModel> list = serviceSG.GetListByCourse(tabControl1.SelectedIndex + 1);
                for (int i = 0; i < list.Count; i++)
                {
                    listBoxStudyGroups.Items.Add(list[i].Title);
                }

                //List<LoadTeacherViewModel> list1 = service.GetList();
                //if (list1 != null)
                //{
                //    dataGridView.DataSource = list1;
                //    dataGridView.Columns[0].Visible = false;
                //    dataGridView.Columns[1].Visible = false;
                //    dataGridView.Columns[3].Visible = false;
                //    dataGridView.Columns[5].Visible = false;
                //    dataGridView.Columns[7].Visible = false;
                //    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLoadTeacher>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacher>();
                Guid id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                form.Id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacher>();
                form.Id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxStudyGroups.Items.Clear();

            List<StudyGroupViewModel> list = serviceSG.GetListByCourse(tabControl1.SelectedIndex+1);

            for (int i = 0; i < list.Count; i++)
            {
                listBoxStudyGroups.Items.Add(list[i].Title);
            }
        }

        private void listBoxStudyGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxStudyGroups.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<FormStudyGroup>();
                form.Id = serviceSG.GetElementByTitle(listBoxStudyGroups.SelectedItem.ToString()).Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
