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
    public partial class FormLoadTeacherPeriod : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IPeriodService service;

        private LoadTeacherPeriodViewModel model;

        public LoadTeacherPeriodViewModel Model
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

        public FormLoadTeacherPeriod(IPeriodService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormLoadTeacherPeriod_Load(object sender, EventArgs e)
        {
            try
            {
                List<PeriodViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxPeriod.DisplayMember = "Title";
                    comboBoxPeriod.ValueMember = "Id";
                    comboBoxPeriod.DataSource = list;
                    comboBoxPeriod.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxPeriod.SelectedValue = model.PeriodId;
                textBoxNumderOfHours.Text = model.NumderOfHours.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxPeriod.SelectedValue == null || string.IsNullOrEmpty(textBoxNumderOfHours.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new LoadTeacherPeriodViewModel
                    {
                        PeriodId = (Guid)comboBoxPeriod.SelectedValue,
                        PeriodTitle = comboBoxPeriod.Text,
                        NumderOfHours = Int32.Parse(textBoxNumderOfHours.Text),
                    };
                }
                else
                {
                    model.PeriodId = (Guid)comboBoxPeriod.SelectedValue;
                    model.NumderOfHours = Int32.Parse(textBoxNumderOfHours.Text);
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
