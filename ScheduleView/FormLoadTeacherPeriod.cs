using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using System.Configuration;

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
                List<PeriodViewModel> list = service.GetListBySemester(new Guid(ConfigurationManager.AppSettings["IDSemester"]));
                if (list != null)
                {
                    comboBoxPeriod.DisplayMember = "Title";
                    comboBoxPeriod.ValueMember = "Id";
                    comboBoxPeriod.DataSource = list;
                    comboBoxPeriod.SelectedValue = new Guid(ConfigurationManager.AppSettings["IDPeriod"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxPeriod.SelectedValue = model.PeriodId;
                textBoxTotalHours.Text = model.TotalHours.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTotalHours.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Int32.Parse(textBoxTotalHours.Text) % 4 != 0 || Int32.Parse(textBoxTotalHours.Text) < 8)
            {
                MessageBox.Show("Неверное значение часов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        TotalHours = Int32.Parse(textBoxTotalHours.Text),

                        HoursFirstWeek = Int32.Parse(textBoxTotalHours.Text)/4,
                        HoursSecondWeek = 0,
                    };
                }
                else
                {
                    model.PeriodId = (Guid)comboBoxPeriod.SelectedValue;
                    model.PeriodTitle = comboBoxPeriod.Text;
                    model.TotalHours = Int32.Parse(textBoxTotalHours.Text);
                    model.HoursFirstWeek = Int32.Parse(textBoxTotalHours.Text)/4;
                    model.HoursSecondWeek = 0;
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
