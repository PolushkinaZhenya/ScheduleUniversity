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
    public partial class FormPeriod : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IPeriodService service;

        private readonly ISemesterService serviceS;

        private Guid? id;

        public FormPeriod(IPeriodService service, ISemesterService serviceS)
        {
            InitializeComponent();
            this.service = service;
            this.serviceS = serviceS;
        }

        private void FormPeriod_Load(object sender, EventArgs e)
        {
            try
            {
                List<SemesterViewModel> list = serviceS.GetList();
                if (list != null)
                {
                    comboBoxSemester.DisplayMember = "Title";
                    comboBoxSemester.ValueMember = "Id";
                    comboBoxSemester.DataSource = list;
                    comboBoxSemester.SelectedItem = null;
                }
                if (id.HasValue)
                {
                    PeriodViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        maskedTextBoxStartDate.Text = view.StartDate.ToString();
                        maskedTextBoxEndDate.Text = view.EndDate.ToString();
                        comboBoxSemester.SelectedValue = view.SemesterId;
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
            if (string.IsNullOrEmpty(textBoxTitle.Text) || comboBoxSemester.SelectedValue == null 
                || string.IsNullOrEmpty(maskedTextBoxStartDate.Text) || string.IsNullOrEmpty(maskedTextBoxEndDate.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DateTime.Parse(maskedTextBoxStartDate.Text) >= DateTime.Parse(maskedTextBoxEndDate.Text))
            {
                MessageBox.Show("Дата начала не может быть больше или равно даты окончания периода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new PeriodBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxTitle.Text,
                        StartDate = DateTime.Parse(maskedTextBoxStartDate.Text),
                        EndDate = DateTime.Parse(maskedTextBoxEndDate.Text),
                        SemesterId = (Guid)comboBoxSemester.SelectedValue
                    });
                }
                else
                {
                    service.AddElement(new PeriodBindingModel
                    {
                        Title = textBoxTitle.Text,
                        StartDate = DateTime.Parse(maskedTextBoxStartDate.Text),
                        EndDate = DateTime.Parse(maskedTextBoxEndDate.Text),
                        SemesterId = (Guid)comboBoxSemester.SelectedValue
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
