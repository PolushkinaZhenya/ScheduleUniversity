using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ScheduleDesktop
{
	public partial class FormStudyGroups : Form
	{
		private readonly IStudyGroupService service;

		private readonly IAdditionalReference<FacultyBindingModel, FacultyViewModel> serviceF;

		public FormStudyGroups(IStudyGroupService service, IAdditionalReference<FacultyBindingModel, FacultyViewModel> serviceF)
		{
			InitializeComponent();
			this.service = service;
			this.serviceF = serviceF;
		}
		private async void FormStudyGroups_Load(object sender, EventArgs e)
		{
			await LoadData();
		}

		private async Task LoadData()
		{
			try
			{
				tabControlFaculties.TabPages.Clear();
				var faculties = serviceF.GetList();

				if (faculties == null)
				{
					Program.ShowError("Список факультетов не получен", "Получение данных");
				}
				foreach (var faculty in faculties)
				{
					var page = new TabPage
					{
						Name = $"tabPage{faculty.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{faculty.Title}",
						UseVisualStyleBackColor = true
					};
					tabControlFaculties.TabPages.Add(page);

					var control = new UserControlStudyGroupsForFaculty
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlStudyGroupsForFaculty{faculty.Id}"
					};

					page.Controls.Add(control);

					await control.LoadGroupsAsync(faculty.Id);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			DataGridView dataGrid = (sender as DataGridView);

			if (dataGrid.SelectedRows.Count == 1)
			{
				var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
				form.Id = (Guid)dataGrid.SelectedRows[0].Cells[0].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					await LoadData();
				}
			}
		}

		private async void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				await LoadData();
			}
		}
	}
}