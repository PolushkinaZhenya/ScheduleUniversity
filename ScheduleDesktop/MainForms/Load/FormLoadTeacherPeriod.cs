using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormLoadTeacherPeriod : Form
    {
       // private readonly IBaseService<PeriodBindingModel, PeriodViewModel> service;

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

        public FormLoadTeacherPeriod(/*IAdditionalReference<PeriodBindingModel, PeriodViewModel> service*/)
        {
            InitializeComponent();
          // this.service = service;
        }

        private void FormLoadTeacherPeriod_Load(object sender, EventArgs e)
        {
            try
            {
                //List<PeriodViewModel> list = service.GetListBySemester(new Guid(ConfigurationManager.AppSettings["IDSemester"]));
                //if (list != null)
                //{
                //    comboBoxPeriod.DisplayMember = "Title";
                //    comboBoxPeriod.ValueMember = "Id";
                //    comboBoxPeriod.DataSource = list;
                //    comboBoxPeriod.SelectedValue = new Guid(ConfigurationManager.AppSettings["IDPeriod"]);
                //}
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка");
            }
            if (model != null)
            {
                comboBoxPeriod.SelectedValue = model.PeriodId;
                textBoxTotalHours.Text = model.TotalHours.ToString();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTotalHours.Text))
            {
                Program.ShowError("Заполните все поля", "Ошибка");
                return;
            }

            if (int.Parse(textBoxTotalHours.Text) % 4 != 0 || int.Parse(textBoxTotalHours.Text) < 8)
            {
                Program.ShowError("Неверное значение часов", "Ошибка");
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
                        TotalHours = int.Parse(textBoxTotalHours.Text),

                        HoursFirstWeek = int.Parse(textBoxTotalHours.Text)/4,
                        HoursSecondWeek = 0,
                    };
                }
                else
                {
                    model.PeriodId = (Guid)comboBoxPeriod.SelectedValue;
                    model.PeriodTitle = comboBoxPeriod.Text;
                    model.TotalHours = int.Parse(textBoxTotalHours.Text);
                    model.HoursFirstWeek = int.Parse(textBoxTotalHours.Text)/4;
                    model.HoursSecondWeek = 0;
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