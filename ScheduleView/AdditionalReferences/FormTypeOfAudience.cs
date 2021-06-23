using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces.AdditionalReferences;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
	public partial class FormTypeOfAudience : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel> service;

        private Guid? id;

        public FormTypeOfAudience(IAdditionalReference<TypeOfAudienceBindingModel, TypeOfAudienceViewModel> service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTypeOfAudience_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TypeOfAudienceViewModel view = service.GetElement(id.Value);
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
                    service.UpdElement(new TypeOfAudienceBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxType.Text
                    });
                }
                else
                {
                    service.AddElement(new TypeOfAudienceBindingModel
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