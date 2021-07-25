using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormSettings : Form
    {
        private readonly IMainService _service;

        private readonly List<string> _config;

        public FormSettings(IMainService service)
        {
            InitializeComponent();
            _service = service;
            _config = dataGridViewPeriods.ConfigDataGrid(typeof(PeriodWithAcademicYearViewModel));
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            buttonAllow.BackColor = ColorSettings.Allow;
            buttonGroupBisy.BackColor = ColorSettings.GroupBisy;
            buttonTeacherBisy.BackColor = ColorSettings.TeacherBisy;
            buttonAuditoriumBisy.BackColor = ColorSettings.AuditoriumBisy;
            buttonFlowBisy.BackColor = ColorSettings.FlowBisy;
            try
            {
                dataGridViewPeriods.Rows.Clear();
                var list = _service.GetPeriods();
                dataGridViewPeriods.FillDataGrid(_config, list);
                var period = Program.ReadAppSettingConfig(Program.CurrentPeriod);
                if (period.IsNotEmpty())
                {
                    foreach (DataGridViewRow row in dataGridViewPeriods.Rows)
					{
                        if (row.Cells["Id"].Value.ToString() == period)
						{
                            row.Selected = true;
                            break;
						}
					}
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка");
            }
        }

		private void ButtonSelectPeriod_Click(object sender, EventArgs e)
		{
            if (dataGridViewPeriods.SelectedRows.Count != 1)
			{
                Program.ShowError("Нужно выбрать один из периодов", "Ошибка");
                return;
			}

            Program.AddUpdateAppSettings(Program.CurrentPeriod, dataGridViewPeriods.SelectedRows[0].Cells["Id"].Value.ToString());
            Program.ShowInfo("Выбран новый период", "Результат");
		}

		private void ButtonColorSelect_Click(object sender, EventArgs e)
		{
            var cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
			{
                (sender as Button).BackColor = cd.Color;
                switch ((sender as Button).Name)
				{
                    case "buttonAllow":
                        Program.AddUpdateAppSettings(Program.ColorAllow, cd.Color.Name);
                        ColorSettings.Allow = cd.Color;
                        break;
                    case "buttonGroupBisy":
                        Program.AddUpdateAppSettings(Program.ColorGroupBisy, cd.Color.Name);
                        ColorSettings.GroupBisy = cd.Color;
                        break;
                    case "buttonTeacherBisy":
                        Program.AddUpdateAppSettings(Program.ColorTeacherBisy, cd.Color.Name);
                        ColorSettings.TeacherBisy = cd.Color;
                        break;
                    case "buttonAuditoriumBisy":
                        Program.AddUpdateAppSettings(Program.ColorAuditoriumBisy, cd.Color.Name);
                        ColorSettings.AuditoriumBisy = cd.Color;
                        break;
                    case "buttonFlowBisy":
                        Program.AddUpdateAppSettings(Program.ColorFlowBisy, cd.Color.Name);
                        ColorSettings.FlowBisy = cd.Color;
                        break;
                }
			}
		}
	}
}
