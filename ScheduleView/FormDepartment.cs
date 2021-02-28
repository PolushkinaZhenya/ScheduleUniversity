using ScheduleServiceDAL.BindingModels;
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
    public partial class FormDepartment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IDepartmentService service;

        private readonly ITypeOfDepartmentService serviceT;

        private int? id;

        public FormDepartment(IDepartmentService service, ITypeOfDepartmentService serviceT)
        {
            InitializeComponent();
            this.service = service;
            this.serviceT = serviceT;
        }

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            try
            {
                List<TypeOfDepartmentViewModel> list = serviceT.GetList();
                if (list != null)
                {
                    comboBoxType.DisplayMember = "Title";
                    comboBoxType.ValueMember = "Id";
                    comboBoxType.DataSource = list;
                    comboBoxType.SelectedItem = null;
                }
                if (id.HasValue)
                {
                    DepartmentViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        comboBoxType.SelectedValue = view.TypeOfDepartmentId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxType.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип кафедры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new DepartmentBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxTitle.Text,
                        TypeOfDepartmentId = Convert.ToInt32(comboBoxType.SelectedValue)
                    });
                }
                else
                {
                    service.AddElement(new DepartmentBindingModel
                    {
                        Title = textBoxTitle.Text,
                        TypeOfDepartmentId = Convert.ToInt32(comboBoxType.SelectedValue)
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
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
