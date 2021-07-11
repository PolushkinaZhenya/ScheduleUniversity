using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormLoadTeacherAuditorium : Form
    {
        private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _service;

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

        public FormLoadTeacherAuditorium(IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FormLoadTeacherAuditorium_Load(object sender, EventArgs e)
        {
            try
            {
                List<AuditoriumViewModel> list = _service.GetList();

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
                Program.ShowError(ex, "Ошибка");
            }
            if (model != null)
            {
                comboBoxAuditorium.SelectedValue = model.AuditoriumId;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAuditorium.SelectedValue == null)
            {
                Program.ShowError("Заполните все поля", "Ошибка");
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new LoadTeacherAuditoriumViewModel
                    {
                        AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue,
                        AuditoriumTitle = _service.GetElement(new ScheduleBusinessLogic.SearchModels.AuditoriumSearchModel { Id = (Guid)comboBoxAuditorium.SelectedValue }).Number
                    };
                }
                else
                {
                    model.AuditoriumTitle = _service.GetElement(new ScheduleBusinessLogic.SearchModels.AuditoriumSearchModel { Id = (Guid)comboBoxAuditorium.SelectedValue }).Number;
                    model.AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
