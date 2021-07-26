using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlScheduleTeachers : UserControl
	{
		private readonly Lazy<List<IGrouping<char, TeacherViewModel>>> _groupbByFirstLetter;

		public UserControlScheduleTeachers()
		{
			InitializeComponent();
			_groupbByFirstLetter = new Lazy<List<IGrouping<char, TeacherViewModel>>>(() =>
			{
				var service = DependencyManager.Instance.Resolve<IBaseService<TeacherBindingModel, TeacherViewModel, TeacherSearchModel>>();
				return service.GetList()?.GroupBy(x => x.Surname[0])?.OrderBy(x => x.Key)?.ToList();
			});
		}

		private void UserControlScheduleTeachers_Load(object sender, EventArgs e)
		{
		}

		public void LoadData()
		{
			var seletedTab = tabControlTeachers.SelectedTab?.Name;

			tabControlTeachers.TabPages.Clear();

			try
			{
				if (_groupbByFirstLetter.Value == null || _groupbByFirstLetter.Value.Count == 0)
				{
					return;
				}
				foreach (var groupTeacher in _groupbByFirstLetter.Value)
				{
					var page = new TabPage
					{
						Name = $"tabPage{groupTeacher.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{groupTeacher.Key}",
						UseVisualStyleBackColor = true
					};

					if (tabControlTeachers.TabPages.Count == 0)
					{
						LoadTeachersPage(page);
					}

					tabControlTeachers.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка");
			}
			var pageSel = tabControlTeachers.TabPages.IndexOfKey(seletedTab);
			if (pageSel > -1)
			{
				tabControlTeachers.SelectTab(pageSel);
			}
		}

		private void TabControlTeachers_SelectedIndexChanged(object sender, EventArgs e) => LoadTeachersPage(tabControlTeachers.SelectedTab);

		/// <summary>
		/// Загрузка списка преподавателей
		/// </summary>
		/// <param name="page"></param>
		private void LoadTeachersPage(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			page.Controls.Clear();

			var panel = new Panel
			{
				Dock = DockStyle.Fill,
				TabIndex = 1,
				Name = "panelContent"
			};
			page.Controls.Add(panel);

			var listBox = new ListBox
			{
				Dock = DockStyle.Right,
				FormattingEnabled = true,
				ItemHeight = 15,
				Location = new Point(826, 0),
				Name = "listBox",
				Size = new Size(167, 701),
				TabIndex = 0
			};
			page.Controls.Add(listBox);
			listBox.SelectedIndexChanged += new EventHandler(ListBoxStudentGroups_SelectedIndexChanged);

			var letter = Convert.ToChar(page.Name.Replace("tabPage", ""));
			try
			{
				var teachers = _groupbByFirstLetter.Value.FirstOrDefault(x => x.Key == letter);
				if (teachers == null)
				{
					return;
				}
				listBox.Items.AddRange(teachers.Select(x => x.ShortName).ToArray());
				if (listBox.Items.Count > 0)
				{
					listBox.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки аудиторий");
			}
		}

		private void ListBoxStudentGroups_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((sender as ListBox)?.SelectedIndex == -1)
			{
				return;
			}
			try
			{
				var letter = Convert.ToChar((sender as ListBox).Parent.Name.Replace("tabPage", ""));
				var teacher = _groupbByFirstLetter.Value.FirstOrDefault(x => x.Key == letter)?.SingleOrDefault(x => x.ShortName == (sender as ListBox)?.SelectedItem.ToString());
				if (teacher == null)
				{
					Program.ShowError("Невозможно определить преподавателя", "Ошибка получения данных");
					return;
				}
				var panel = (sender as ListBox).Parent.Controls.Find("panelContent", true).FirstOrDefault();
				if (panel != null)
				{
					panel.Controls.Clear();
					var control = new UserControlScheduleTeacher()
					{
						Dock = DockStyle.Fill,
						Name = "UserControlScheduleTeacher"
					};
					control.SetTeacherId(teacher.Id);
					panel.Controls.Add(control);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
		}
	}
}