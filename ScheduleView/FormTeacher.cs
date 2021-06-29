using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
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
using Unity;

namespace ScheduleView
{
    public partial class FormTeacher : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly ITeacherService service;

        private Guid? id;

        private List<TeacherDepartmentViewModel> TeacherDepartments;

        public FormTeacher(ITeacherService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TeacherViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxSurname.Text = view.Surname;
                        textBoxName.Text = view.Name;
                        textBoxPatronymic.Text = view.Patronymic;
                        TeacherDepartments = view.TeacherDepartments;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                TeacherDepartments = new List<TeacherDepartmentViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (TeacherDepartments != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = TeacherDepartments;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTeacherDepartment>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.TeacherId = id.Value;
                    }
                    TeacherDepartments.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTeacherDepartment>();
                form.Model = TeacherDepartments[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TeacherDepartments[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
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
                    try
                    {
                        TeacherDepartments.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSurname.Text) || string.IsNullOrEmpty(textBoxName.Text) 
                || string.IsNullOrEmpty(textBoxPatronymic.Text) || 
                (TeacherDepartments == null || TeacherDepartments.Count == 0))
            {
                MessageBox.Show("Заполните все данные и выберете кафедры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<TeacherDepartmentBindingModel> TeacherDepartmentBM = new List<TeacherDepartmentBindingModel>();
                for (int i = 0; i < TeacherDepartments.Count; ++i)
                {
                    TeacherDepartmentBM.Add(new TeacherDepartmentBindingModel
                    {
                        Id = TeacherDepartments[i].Id,
                        TeacherId = TeacherDepartments[i].TeacherId,
                        DepartmentId = TeacherDepartments[i].DepartmentId
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new TeacherBindingModel
                    {
                        Id = id.Value,
                        Surname = textBoxSurname.Text,
                        Name = textBoxName.Text,
                        Patronymic = textBoxPatronymic.Text,
                        TeacherDepartments = TeacherDepartmentBM
                    });
                }
                else
                {
                    service.AddElement(new TeacherBindingModel
                    {
                        Surname = textBoxSurname.Text,
                        Name = textBoxName.Text,
                        Patronymic = textBoxPatronymic.Text,
                        TeacherDepartments = TeacherDepartmentBM
                    });
                }
                //MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTeacherDepartment>();
                form.Model = TeacherDepartments[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TeacherDepartments[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }
    }
}
