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
    public partial class FormTypeOfClass : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly ITypeOfClassService service;

        private Guid? id;

        public FormTypeOfClass(ITypeOfClassService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTypeOfClass_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TypeOfClassViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxType.Text = view.Title;
                        textBoxAbbreviated.Text = view.AbbreviatedTitle;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxType.Text)|| string.IsNullOrEmpty(textBoxAbbreviated.Text))
            {
                MessageBox.Show("Заполните данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new TypeOfClassBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxType.Text,
                        AbbreviatedTitle = textBoxAbbreviated.Text
                    });
                }
                else
                {
                    service.AddElement(new TypeOfClassBindingModel
                    {
                        Title = textBoxType.Text,
                        AbbreviatedTitle = textBoxAbbreviated.Text
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
