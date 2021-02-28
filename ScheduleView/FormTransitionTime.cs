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

        public int Id { set { id = value; } }

        private readonly ITransitionTimeService service;

        private readonly IEducationalBuildingService serviceEB;

        private int? id;

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
                List<EducationalBuildingViewModel> list = serviceEB.GetList();
                if (list != null)
                {
                    comboBoxEducationalBuildingFrom.DisplayMember = "Number";
                    comboBoxEducationalBuildingFrom.ValueMember = "Id";
                    comboBoxEducationalBuildingFrom.DataSource = list;
                    comboBoxEducationalBuildingFrom.SelectedItem = null;

                    //comboBoxEducationalBuildingTo.DisplayMember = "Number";
                    //comboBoxEducationalBuildingTo.ValueMember = "Id";
                    //comboBoxEducationalBuildingTo.DataSource = list;
                    //comboBoxEducationalBuildingTo.SelectedItem = null;
                }
                if (id.HasValue)
                {
                    TransitionTimeViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        maskedTextBoxTime.Text = view.Time.ToString();
                        comboBoxEducationalBuildingFrom.SelectedValue = view.EducationalBuildingId;
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
            if (string.IsNullOrEmpty(maskedTextBoxTime.Text))
            {
                MessageBox.Show("Заполните время", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxEducationalBuildingFrom.SelectedValue == null)//добавить 2й корпус
            {
                MessageBox.Show("Выберите корпуса", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        EducationalBuildingId = Convert.ToInt32(comboBoxEducationalBuildingFrom.SelectedValue)
                        //добавить
                    });
                }
                else
                {
                    service.AddElement(new TransitionTimeBindingModel
                    {
                        Time = TimeSpan.Parse(maskedTextBoxTime.Text),
                        EducationalBuildingId = Convert.ToInt32(comboBoxEducationalBuildingFrom.SelectedValue)
                        //добавить
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
