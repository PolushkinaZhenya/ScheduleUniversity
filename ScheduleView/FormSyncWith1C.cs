using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
	public partial class FormSyncWith1C : Form
	{
		[Dependency]
		public new IUnityContainer Container { get; set; }

		private readonly ISyncWith1C _syncWith1C1;

		public FormSyncWith1C(ISyncWith1C syncWith1C)
		{
			InitializeComponent();
			_syncWith1C1 = syncWith1C;
		}

		private void ButtonSync_Click(object sender, EventArgs e)
		{
			var result = _syncWith1C1?.SyncWith1C(new SyncWith1CBindingModel
			{
				BaseAddress = textBoxAddress.Text,
				Username = textBoxUserName.Text,
				Password = textBoxPassword.Text,
				UniverStructure = (checkBoxGetUniverStructure.Checked, checkBoxGetFullUniverStructure.Checked),
				AuditoriumStructure = (checkBoxGetAuditoriumStructure.Checked, checkBoxGetFullAuditoriumStructure.Checked),
				Groups = (checkBoxGetGroups.Checked, checkBoxGetFullGroups.Checked),
				StudyPlan = (checkBoxGetStudyPlan.Checked, checkBoxGetFullStudyPlan.Checked),
				Chart = (checkBoxGetChart.Checked, checkBoxGetFullChart.Checked)
			});

			if (result.IsSuccess)
			{
				MessageBox.Show("Синхронизация прошла успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show($"При синхронизации возникла ошибка: {result.ErrorMessage}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
