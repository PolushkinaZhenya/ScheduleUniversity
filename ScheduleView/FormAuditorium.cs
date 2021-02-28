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
    public partial class FormAuditorium : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IAuditoriumService service;

        private readonly ITypeOfAudienceService serviceTA;

        private readonly IEducationalBuildingService serviceEB;

        private readonly IDepartmentService serviceD;

        private int? id;

        public FormAuditorium(IAuditoriumService service, ITypeOfAudienceService serviceTA, IEducationalBuildingService serviceEB, IDepartmentService serviceD)
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
                }

                List<DepartmentViewModel> listD = serviceD.GetList();
                if (listD != null)
                {
                    comboBoxDepartment.DisplayMember = "Title";
                    comboBoxDepartment.ValueMember = "Id";
                    comboBoxDepartment.DataSource = listD;
                    comboBoxDepartment.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    AuditoriumViewModel view = service.GetElement(id.Value);
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
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNumber.Text) || string.IsNullOrEmpty(textBoxCapacity.Text) || comboBoxType.SelectedValue == null
                || comboBoxEducationalBuilding.SelectedValue == null || comboBoxDepartment.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new AuditoriumBindingModel
                    {
                        Id = id.Value,
                        Number = textBoxNumber.Text,
                        Capacity = Int32.Parse(textBoxCapacity.Text),
                        TypeOfAudienceId = Convert.ToInt32(comboBoxType.SelectedValue),
                        EducationalBuildingId = Convert.ToInt32(comboBoxEducationalBuilding.SelectedValue),
                        DepartmentId = Convert.ToInt32(comboBoxDepartment.SelectedValue)
                    });
                }
                else
                {
                    service.AddElement(new AuditoriumBindingModel
                    {
                        Number = textBoxNumber.Text,
                        Capacity = Int32.Parse(textBoxCapacity.Text),
                        TypeOfAudienceId = Convert.ToInt32(comboBoxType.SelectedValue),
                        EducationalBuildingId = Convert.ToInt32(comboBoxEducationalBuilding.SelectedValue),
                        DepartmentId = Convert.ToInt32(comboBoxDepartment.SelectedValue)
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
