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
    public partial class FormTeacherDepartment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDepartmentService service;

        private TeacherDepartmentViewModel model;

        public TeacherDepartmentViewModel Model
        {
            set
            {
                model = value;
            }
            get
            {
                return model;
            }
        }

        public FormTeacherDepartment(IDepartmentService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTeacherDepartment_Load(object sender, EventArgs e)
        {
            try
            {
                List<DepartmentViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxDepartment.DisplayMember = "Title";
                    comboBoxDepartment.ValueMember = "Id";
                    comboBoxDepartment.DataSource = list;
                    comboBoxDepartment.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxDepartment.SelectedValue = model.DepartmentId;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxDepartment.SelectedValue == null)
            {
                MessageBox.Show("Выберите кафедру", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new TeacherDepartmentViewModel
                    {
                        DepartmentId = (Guid)comboBoxDepartment.SelectedValue,
                        DepartmentTitle = comboBoxDepartment.Text
                    };
                }
                else
                {
                    model.DepartmentId = (Guid)comboBoxDepartment.SelectedValue;
                    model.DepartmentTitle = comboBoxDepartment.Text;
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
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
