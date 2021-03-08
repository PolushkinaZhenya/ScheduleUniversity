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
    public partial class FormTransitionTime : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly ITransitionTimeService service;

        private readonly IEducationalBuildingService serviceEB;

        private Guid? id;

        public FormTransitionTime(ITransitionTimeService service, IEducationalBuildingService serviceEB)
        {
            InitializeComponent();
            this.service = service;
            this.serviceEB = serviceEB;
        }

        private void FormTransitionTime_Load(object sender, EventArgs e)
        {
            try
            {
                List<EducationalBuildingViewModel> listFrom = serviceEB.GetList();
                if (listFrom != null)
                {
                    comboBoxEducationalBuildingFrom.DisplayMember = "Number";
                    comboBoxEducationalBuildingFrom.ValueMember = "Id";
                    comboBoxEducationalBuildingFrom.DataSource = listFrom;
                    comboBoxEducationalBuildingFrom.SelectedItem = null;
                }

                List<EducationalBuildingViewModel> listTo = serviceEB.GetList();
                if (listTo != null)
                {
                    comboBoxEducationalBuildingTo.DisplayMember = "Number";
                    comboBoxEducationalBuildingTo.ValueMember = "Id";
                    comboBoxEducationalBuildingTo.DataSource = listTo;
                    comboBoxEducationalBuildingTo.SelectedItem = null;
                }
                if (id.HasValue)
                {
                    TransitionTimeViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        maskedTextBoxTime.Text = view.Time.ToString();
                        comboBoxEducationalBuildingFrom.SelectedValue = view.EducationalBuildingId_1;
                        comboBoxEducationalBuildingTo.SelectedValue = view.EducationalBuildingId_2;
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
            if (string.IsNullOrEmpty(maskedTextBoxTime.Text) 
                || comboBoxEducationalBuildingFrom.SelectedValue == null 
                || comboBoxEducationalBuildingTo.SelectedValue == null)
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new TransitionTimeBindingModel
                    {
                        Id = id.Value,
                        Time = TimeSpan.Parse(maskedTextBoxTime.Text),
                        EducationalBuildingId_1 = (Guid)comboBoxEducationalBuildingFrom.SelectedValue,
                        EducationalBuildingId_2 = (Guid)comboBoxEducationalBuildingTo.SelectedValue
                    });
                }
                else
                {
                    service.AddElement(new TransitionTimeBindingModel
                    {
                        Time = TimeSpan.Parse(maskedTextBoxTime.Text),
                        EducationalBuildingId_1 = (Guid)comboBoxEducationalBuildingFrom.SelectedValue,
                        EducationalBuildingId_2 = (Guid)comboBoxEducationalBuildingTo.SelectedValue
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
