using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormLoadTeachers : Form
	{
		private readonly Lazy<List<FacultyViewModel>> _faculties;

		public FormLoadTeachers(IBaseService<FacultyBindingModel, FacultyViewModel, FacultySearchModel> serviceF)
		{
			InitializeComponent();
			_faculties = new Lazy<List<FacultyViewModel>>(() => { return serviceF.GetList(); });
		}

		private async void FormLoadTeachers_Load(object sender, EventArgs e)
		{
			await LoadData();
		}

		private async Task LoadData()
		{
			try
			{
				tabControlFaculties.TabPages.Clear();

				if (_faculties.Value == null)
				{
					Program.ShowError("Список факультетов не получен", "Получение данных");
				}
				foreach (var faculty in _faculties.Value)
				{
					var page = new TabPage
					{
						Name = $"tabPage{faculty.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{faculty.Title}",
						UseVisualStyleBackColor = true
					};

					var control = new UserControlCoursesForLoad
					{
						Dock = DockStyle.Fill,
						Name = $"UserControlCoursesForLoad{faculty.Id}"
					};

					page.Controls.Add(control);

					if (tabControlFaculties.TabPages.Count == 0)
					{
						await control.LoadFaculty(faculty.Id);
					}

					tabControlFaculties.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			//if (listBoxStudyGroups.SelectedItem == null)
			//{
			//    MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//    return;
			//}
			//else
			//{
			//    var form = Container.Resolve<FormLoadTeacher>();
			//    form.StudyGroupTitle = listBoxStudyGroups.SelectedItem.ToString();

			//    DialogResult result = form.ShowDialog();

			//    if ((result == DialogResult.OK || result == DialogResult.Cancel) && listBoxStudyGroups.SelectedItem != null)
			//    {
			//        if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
			//        {
			//            LoadDataGridViewElse();
			//        }
			//        else
			//        {
			//            LoadDataGridViewAll();
			//        }
			//    }
			//}
		}

		private void ButtonUpd_Click(object sender, EventArgs e)
		{
			//if (tabControlTypeOfClass.SelectedTab.Tag.ToString() == "ВСЕГО")
			//{
			//    MessageBox.Show("Перейдите на другую вкладку и выберите расчасовку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//    return;
			//}

			//UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы

			//if (userControlDataGridViewSelect.SelectedRowsCount() == 1)
			//{
			//    var form = Container.Resolve<FormLoadTeacher>();
			//    form.Id = userControlDataGridViewSelect.GetId();
			//    form.StudyGroupTitle = listBoxStudyGroups.SelectedItem.ToString();

			//    DialogResult result = form.ShowDialog();

			//    if ((result == DialogResult.OK || result == DialogResult.Cancel) && listBoxStudyGroups.SelectedItem != null)
			//    {
			//        if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
			//        {
			//            LoadDataGridViewElse();
			//        }
			//        else
			//        {
			//            LoadDataGridViewAll();
			//        }
			//    }
			//}
		}

		private void ButtonDel_Click(object sender, EventArgs e)
		{
			//if (tabControlTypeOfClass.SelectedTab.Tag.ToString() == "ВСЕГО")
			//{
			//    MessageBox.Show("Перейдите на другую вкладку и выберите расчасовку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//    return;
			//}

			//UserControlDataGridView userControlDataGridViewSelect = (UserControlDataGridView)((tabControlTypeOfClass.SelectedTab as TabPage).Controls.Find(tabControlTypeOfClass.SelectedTab.Tag.ToString(), true)[0]);//поиск таблицы

			//if (userControlDataGridViewSelect.SelectedRowsCount() == 1)
			//{
			//    if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			//    {
			//        try
			//        {
			//            service.DelElement(userControlDataGridViewSelect.GetId());
			//        }
			//        catch (Exception ex)
			//        {
			//            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//        }
			//        if (tabControlTypeOfClass.SelectedTab.Tag.ToString() != "ВСЕГО")
			//        {
			//            LoadDataGridViewElse();
			//        }
			//        else
			//        {
			//            LoadDataGridViewAll();
			//        }
			//    }
			//}
		}

		private async void TabControlFaculties_SelectedIndexChanged(object sender, EventArgs e)
		{
			var control = tabControlFaculties.SelectedTab?.Controls?.Cast<UserControlCoursesForLoad>()?.FirstOrDefault();
			if (control != null)
			{
				try
				{
					var facultyId = new Guid(tabControlFaculties.SelectedTab.Name.Replace("tabPage", ""));
					await control.LoadFaculty(facultyId);
				}
				catch (Exception ex)
				{
					Program.ShowError(ex, "Ошибка загрузки страницы");
				}
			}
		}
	}
}
