using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormAuditorium : Form
    {
        public Guid Id { set { id = value; } }

        private Guid? _buildingId = null;

        public Guid BuildingId { set { _buildingId = value; } }

        private Guid? _departmentId = null;

        public Guid DepartmentId { set { _departmentId = value; } }

        private readonly IAuditoriumService service;

        private readonly IBaseService<TypeOfAudienceBindingModel, TypeOfAudienceViewModel, TypeOfAudienceSearchModel> serviceTA;

        private readonly IBaseService<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel> serviceEB;

        private readonly IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel> serviceD;

        private Guid? id;

        public FormAuditorium(IAuditoriumService service, 
            IBaseService<TypeOfAudienceBindingModel, TypeOfAudienceViewModel, TypeOfAudienceSearchModel> serviceTA,
            IBaseService<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel> serviceEB,
            IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel> serviceD)
        {
            InitializeComponent();
            this.service = service;
            this.serviceTA = serviceTA;
            this.serviceEB = serviceEB;
            this.serviceD = serviceD;
        }

        private void FormAuditorium_Load(object sender, EventArgs e)
        {
            try
            {
                List<TypeOfAudienceViewModel> listTA = serviceTA.GetList();
                if (listTA != null)
                {
                    comboBoxType.DisplayMember = "Title";
                    comboBoxType.ValueMember = "Id";
                    comboBoxType.DataSource = listTA;
                    comboBoxType.SelectedItem = null;
                }

                List<EducationalBuildingViewModel> listEB = serviceEB.GetList();
                if (listEB != null)
                {
                    comboBoxEducationalBuilding.DisplayMember = "Number";
                    comboBoxEducationalBuilding.ValueMember = "Id";
                    comboBoxEducationalBuilding.DataSource = listEB;
                    comboBoxEducationalBuilding.SelectedItem = null;
                    if (_buildingId.HasValue)
					{
                        comboBoxEducationalBuilding.SelectedValue = _buildingId.Value;
                    }
                }

                List<DepartmentViewModel> listD = serviceD.GetList();
                if (listD != null)
                {
                    comboBoxDepartment.DisplayMember = "Title";
                    comboBoxDepartment.ValueMember = "Id";
                    comboBoxDepartment.DataSource = listD;
                    comboBoxDepartment.SelectedItem = null;
                    if (_departmentId.HasValue)
                    {
                        comboBoxDepartment.SelectedValue = _departmentId.Value;
                    }
                }

                if (id.HasValue)
                {
                    AuditoriumViewModel view = service.GetElement(new AuditoriumSearchModel { Id = id.Value });
                    if (view != null)
                    {
                        textBoxNumber.Text = view.Number;
                        textBoxCapacity.Text = view.Capacity.ToString();
                        comboBoxType.SelectedValue = view.TypeOfAudienceId;
                        comboBoxEducationalBuilding.SelectedValue = view.EducationalBuildingId;
                        comboBoxDepartment.SelectedValue = view.DepartmentId;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка загрузки");
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNumber.Text) || string.IsNullOrEmpty(textBoxCapacity.Text) || comboBoxType.SelectedValue == null
                || comboBoxEducationalBuilding.SelectedValue == null || comboBoxDepartment.SelectedValue == null)
            {
                Program.ShowError("Заполните все поля", "Ошибка");
                return;
            }  

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new AuditoriumBindingModel
                    {
                        Id = id.Value,
                        Number = textBoxNumber.Text,
                        Capacity = int.Parse(textBoxCapacity.Text),
                        TypeOfAudienceId = (Guid)comboBoxType.SelectedValue,
                        EducationalBuildingId = (Guid)comboBoxEducationalBuilding.SelectedValue,
                        DepartmentId = (Guid)comboBoxDepartment.SelectedValue
                    });
                }
                else
                {
                    service.AddElement(new AuditoriumBindingModel
                    {
                        Number = textBoxNumber.Text,
                        Capacity = int.Parse(textBoxCapacity.Text),
                        TypeOfAudienceId = (Guid)comboBoxType.SelectedValue,
                        EducationalBuildingId = (Guid)comboBoxEducationalBuilding.SelectedValue,
                        DepartmentId = (Guid)comboBoxDepartment.SelectedValue
                    });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка сохранения");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}