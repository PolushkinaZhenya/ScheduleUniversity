using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces.AdditionalReferences;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
	public partial class FormTypeOfDepartment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel> service;

        private Guid? id;

        public FormTypeOfDepartment(IAdditionalReference<TypeOfDepartmentBindingModel, TypeOfDepartmentViewModel> service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTypeOfDepartment_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TypeOfDepartmentViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxType.Text = view.Title;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxType.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new TypeOfDepartmentBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxType.Text
                    });
                }
                else
                {
                    service.AddElement(new TypeOfDepartmentBindingModel
                    {
                        Title = textBoxType.Text
                    });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}