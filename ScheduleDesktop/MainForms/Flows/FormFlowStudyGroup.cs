using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormFlowStudyGroup : Form
	{
		private readonly IStudyGroupService service;

		public FlowStudyGroupViewModel Model { set; get; }

		public FormFlowStudyGroup(IStudyGroupService service)
		{
			InitializeComponent();
			this.service = service;
		}

		private void FormFlowStudyGroup_Load(object sender, EventArgs e)
		{
			try
			{
				List<StudyGroupViewModel> list = service.GetList();
				if (list != null)
				{
					comboBoxStudyGroup.DisplayMember = "Title";
					comboBoxStudyGroup.ValueMember = "Id";
					comboBoxStudyGroup.DataSource = list;
					comboBoxStudyGroup.SelectedItem = null;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
			if (Model != null)
			{
				comboBoxStudyGroup.SelectedValue = Model.StudyGroupId;
				textBoxSubgroup.Text = Model.Subgroup.ToString();
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (comboBoxStudyGroup.SelectedValue == null)
			{
				Program.ShowError("Заполите все поля", "Ошибка");
				return;
			}
			try
			{
				if (Model == null)
				{
					Model = new FlowStudyGroupViewModel
					{
						StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
						StudyGroupTitle = comboBoxStudyGroup.Text,
						Subgroup = textBoxSubgroup.Text == "" ? null : Int32.Parse(textBoxSubgroup.Text)
					};
				}
				else
				{
					Model.StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue;
					Model.Subgroup = textBoxSubgroup.Text == "" ? null : Int32.Parse(textBoxSubgroup.Text);
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