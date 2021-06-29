using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormLoadTeacherAuditorium : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IAuditoriumService service;

        private readonly IEducationalBuildingService serviceEB;

        private LoadTeacherAuditoriumViewModel model;

        public LoadTeacherAuditoriumViewModel Model
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

        public FormLoadTeacherAuditorium(IAuditoriumService service, IEducationalBuildingService serviceEB)
        {
            InitializeComponent();
            this.service = service;
            this.serviceEB = serviceEB;
        }

        private void FormLoadTeacherAuditorium_Load(object sender, EventArgs e)
        {
            try
            {
                List<AuditoriumViewModel> list = service.GetList();

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Number = list[i].EducationalBuilding + "-" + list[i].Number;
                }

                if (list != null)
                {
                    comboBoxAuditorium.DisplayMember = "Number";
                    comboBoxAuditorium.ValueMember = "Id";
                    comboBoxAuditorium.DataSource = list;
                    comboBoxAuditorium.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxAuditorium.SelectedValue = model.AuditoriumId;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAuditorium.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new LoadTeacherAuditoriumViewModel
                    {
                        AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue,
                        AuditoriumTitle = service.GetElement((Guid)comboBoxAuditorium.SelectedValue).Number
                    };
                }
                else
                {
                    model.AuditoriumTitle = service.GetElement((Guid)comboBoxAuditorium.SelectedValue).Number;
                    model.AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue;
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
