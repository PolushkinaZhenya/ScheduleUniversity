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
    public partial class FormEducationalBuilding : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IEducationalBuildingService service;

        private Guid? id;

        public FormEducationalBuilding(IEducationalBuildingService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormEducationalBuilding_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    EducationalBuildingViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxNumber.Text = view.Number;
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
            if (string.IsNullOrEmpty(textBoxNumber.Text))
            {
                MessageBox.Show("Заполните номер корпуса", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new EducationalBuildingBindingModel
                    {
                        Id = id.Value,
                        Number = textBoxNumber.Text
                    });
                }
                else
                {
                    service.AddElement(new EducationalBuildingBindingModel
                    {
                        Number = textBoxNumber.Text
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
