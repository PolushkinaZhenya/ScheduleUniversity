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
    public partial class FormClassTime : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IClassTimeService service;

        private Guid? id;

        public FormClassTime(IClassTimeService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormClassTime_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ClassTimeViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxNumber.Text = view.Number.ToString();
                        maskedTextBoxStartTime.Text = view.StartTime.ToString();
                        maskedTextBoxEndTime.Text = view.EndTime.ToString();
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
            if (string.IsNullOrEmpty(textBoxNumber.Text) || string.IsNullOrEmpty(maskedTextBoxStartTime.Text) || string.IsNullOrEmpty(maskedTextBoxEndTime.Text))
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TimeSpan.Parse(maskedTextBoxStartTime.Text) >= TimeSpan.Parse(maskedTextBoxEndTime.Text))
            {
                MessageBox.Show("Время начала не может быть больше или равно времени окончания пары", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new ClassTimeBindingModel
                    {
                        Id = id.Value,
                        Number = Int32.Parse(textBoxNumber.Text),
                        StartTime = TimeSpan.Parse(maskedTextBoxStartTime.Text),
                        EndTime = TimeSpan.Parse(maskedTextBoxEndTime.Text)
                    });
                }
                else
                {
                    service.AddElement(new ClassTimeBindingModel
                    {
                        Number = Int32.Parse(textBoxNumber.Text),
                        StartTime = TimeSpan.Parse(maskedTextBoxStartTime.Text),
                        EndTime = TimeSpan.Parse(maskedTextBoxEndTime.Text)
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
