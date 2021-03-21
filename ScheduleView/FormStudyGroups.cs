using ScheduleModel;
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
    public partial class FormStudyGroups : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStudyGroupService service;

        public FormStudyGroups(IStudyGroupService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormStudyGroups_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<StudyGroupViewModel> list = service.GetListByCourse(1);
                for (int i = 0; i < list.Count; i++)
                {
                    listBox_1course.Items.Add(list[i].Title);
                }

                list = service.GetListByCourse(2);
                for (int i = 0; i < list.Count; i++)
                {
                    listBox_2course.Items.Add(list[i].Title);
                }

                list = service.GetListByCourse(3);
                for (int i = 0; i < list.Count; i++)
                {
                    listBox_3course.Items.Add(list[i].Title);
                }

                list = service.GetListByCourse(4);
                for (int i = 0; i < list.Count; i++)
                {
                    listBox_4course.Items.Add(list[i].Title);
                }

                list = service.GetListByCourse(5);
                for (int i = 0; i < list.Count; i++)
                {
                    listBox_5course.Items.Add(list[i].Title);
                }

                list = service.GetListByCourse(6);
                for (int i = 0; i < list.Count; i++)
                {
                    listBox_5course.Items.Add(list[i].Title);
                }

                //List<StudyGroupViewModel> list = service.GetList();
                //if (list != null)
                //{
                //    dataGridView.DataSource = list;
                //    dataGridView.Columns[0].Visible = false;
                //    dataGridView.Columns[5].Visible = false;
                //    dataGridView.Columns[1].AutoSizeMode =
                //    DataGridViewAutoSizeColumnMode.Fill;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStudyGroup>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            //if (dataGridView.SelectedRows.Count == 1)
            //{
            var form = Container.Resolve<FormStudyGroup>();
            form.Id = service.GetElementByTitle(listBox_1course.SelectedItem.ToString()).Id;

            //form.Id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
            //}
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void listBox_1course_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_1course.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<FormStudyGroup>();
                form.Id = service.GetElementByTitle(listBox_1course.SelectedItem.ToString()).Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void listBox_2course_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox_2course.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<FormStudyGroup>();
                form.Id = service.GetElementByTitle(listBox_2course.SelectedItem.ToString()).Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void listBox_1course_Click(object sender, EventArgs e)
        {
            listBox_2course.SelectedItems.Clear();
            listBox_3course.SelectedItems.Clear();
            listBox_4course.SelectedItems.Clear();
            listBox_5course.SelectedItems.Clear();
            listBox_6course.SelectedItems.Clear();
        }

        private void listBox_2course_Click(object sender, EventArgs e)
        {
            listBox_1course.SelectedItems.Clear();
            listBox_3course.SelectedItems.Clear();
            listBox_4course.SelectedItems.Clear();
            listBox_5course.SelectedItems.Clear();
            listBox_6course.SelectedItems.Clear();
        }

        private void listBox_3course_Click(object sender, EventArgs e)
        {
            listBox_1course.SelectedItems.Clear();
            listBox_2course.SelectedItems.Clear();
            listBox_4course.SelectedItems.Clear();
            listBox_5course.SelectedItems.Clear();
            listBox_6course.SelectedItems.Clear();
        }

        private void listBox_4course_Click(object sender, EventArgs e)
        {
            listBox_1course.SelectedItems.Clear();
            listBox_2course.SelectedItems.Clear();
            listBox_3course.SelectedItems.Clear();
            listBox_5course.SelectedItems.Clear();
            listBox_6course.SelectedItems.Clear();
        }

        private void listBox_5course_Click(object sender, EventArgs e)
        {
            listBox_1course.SelectedItems.Clear();
            listBox_2course.SelectedItems.Clear();
            listBox_3course.SelectedItems.Clear();
            listBox_4course.SelectedItems.Clear();
            listBox_6course.SelectedItems.Clear();
        }

        private void listBox_6course_Click(object sender, EventArgs e)
        {
            listBox_1course.SelectedItems.Clear();
            listBox_2course.SelectedItems.Clear();
            listBox_3course.SelectedItems.Clear();
            listBox_4course.SelectedItems.Clear();
            listBox_5course.SelectedItems.Clear();
        }
    }
}
