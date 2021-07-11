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
        private Guid? _id;

        public Guid Id { set { _id = value; } }

        private Guid? _buildingId = null;

        public Guid BuildingId { set { _buildingId = value; } }

        private Guid? _departmentId = null;

        public Guid DepartmentId { set { _departmentId = value; } }

        private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _service;

        private readonly Lazy<List<TypeOfAudienceViewModel>> _typeOfAudiences;

        private readonly Lazy<List<EducationalBuildingViewModel>> _educationalBuildings;

        private readonly Lazy<List<DepartmentViewModel>> _departments;

        public FormAuditorium(IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> service, 
            IBaseService<TypeOfAudienceBindingModel, TypeOfAudienceViewModel, TypeOfAudienceSearchModel> serviceTA,
            IBaseService<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel> serviceEB,
            IBaseService<DepartmentBindingModel, DepartmentViewModel, DepartmentSearchModel> serviceD)
        {
            InitializeComponent();
            _service = service;

            _typeOfAudiences = new Lazy<List<TypeOfAudienceViewModel>>(() => { return serviceTA.GetList(); });
            _educationalBuildings = new Lazy<List<EducationalBuildingViewModel>>(() => { return serviceEB.GetList(); });
            _departments = new Lazy<List<DepartmentViewModel>>(() => { return serviceD.GetList(); });
        }

        private void FormAuditorium_Load(object sender, EventArgs e)
        {
            try
            {
                if (_typeOfAudiences.Value != null)
                {
                    comboBoxType.DisplayMember = "Title";
                    comboBoxType.ValueMember = "Id";
                    comboBoxType.DataSource = _typeOfAudiences.Value;
                    comboBoxType.SelectedItem = null;
                }

                if (_educationalBuildings.Value != null)
                {
                    comboBoxEducationalBuilding.DisplayMember = "Number";
                    comboBoxEducationalBuilding.ValueMember = "Id";
                    comboBoxEducationalBuilding.DataSource = _educationalBuildings.Value;
                    comboBoxEducationalBuilding.SelectedItem = null;
                    if (_buildingId.HasValue)
					{
                        comboBoxEducationalBuilding.SelectedValue = _buildingId.Value;
                    }
                }

                if (_departments.Value != null)
                {
                    comboBoxDepartment.DisplayMember = "Title";
                    comboBoxDepartment.ValueMember = "Id";
                    comboBoxDepartment.DataSource = _departments.Value;
                    comboBoxDepartment.SelectedItem = null;
                    if (_departmentId.HasValue)
                    {
                        comboBoxDepartment.SelectedValue = _departmentId.Value;
                    }
                }

                if (_id.HasValue)
                {
                    var view = _service.GetElement(new AuditoriumSearchModel { Id = _id.Value });
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
            if (textBoxNumber.Text.IsEmpty() || textBoxCapacity.Text.IsEmpty() || comboBoxType.SelectedValue == null
                || comboBoxEducationalBuilding.SelectedValue == null || comboBoxDepartment.SelectedValue == null)
            {
                Program.ShowError("Заполните все поля", "Ошибка");
                return;
            }  

            try
            {
                if (_id.HasValue)
                {
                    _service.UpdElement(new AuditoriumBindingModel
                    {
                        Id = _id.Value,
                        Number = textBoxNumber.Text,
                        Capacity = int.Parse(textBoxCapacity.Text),
                        TypeOfAudienceId = (Guid)comboBoxType.SelectedValue,
                        EducationalBuildingId = (Guid)comboBoxEducationalBuilding.SelectedValue,
                        DepartmentId = (Guid)comboBoxDepartment.SelectedValue
                    });
                }
                else
                {
                    _service.AddElement(new AuditoriumBindingModel
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