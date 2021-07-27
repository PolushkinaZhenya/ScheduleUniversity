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
	public partial class UserControlScheduleAuditoriums : UserControl
	{
		private readonly IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel> _serviceA;

		private readonly Lazy<List<EducationalBuildingViewModel>> _educationalBuildings;

		private List<AuditoriumViewModel> _auditoriums;

		public List<Guid> SelectedSchedulesToMove;

		public Guid? MoveFromAuditoriumId = null;

		public UserControlScheduleAuditoriums()
		{
			InitializeComponent();
			_serviceA = DependencyManager.Instance.Resolve<IBaseService<AuditoriumBindingModel, AuditoriumViewModel, AuditoriumSearchModel>>();
			   _educationalBuildings = new Lazy<List<EducationalBuildingViewModel>>(() =>
			{
				var service = DependencyManager.Instance.Resolve<IBaseService<EducationalBuildingBindingModel, EducationalBuildingViewModel, EducationalBuildingSearchModel>>();
				return service.GetList();
			});
			SelectedSchedulesToMove = new();
		}

		public void LoadData()
		{
			var seletedTab = tabControlEducationalBuildings.SelectedTab?.Name;
			var seletedTabTab = (tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] as TabControl)?.SelectedTab?.Name;
			var seletedId = ((tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] as TabControl)?.SelectedTab?.
																		Controls["dataGridView"] as DataGridView)?.SelectedRows[0]?.Cells[0]?.Value;

			tabControlEducationalBuildings.TabPages.Clear();

			if (_educationalBuildings.Value == null)
			{
				Program.ShowError("Список строений не получен", "Получение данных");
				return;
			}
			try
			{
				foreach (var educationalBuilding in _educationalBuildings.Value)
				{
					var page = new TabPage
					{
						Name = $"tabPage{educationalBuilding.Id}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"{educationalBuilding.Title}",
						UseVisualStyleBackColor = true
					};

					if (tabControlEducationalBuildings.TabPages.Count == 0)
					{
						LoadAuditoriumsPage(page);
					}
					tabControlEducationalBuildings.TabPages.Add(page);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка при загрузке");
			}

			var pageSel = tabControlEducationalBuildings.TabPages.IndexOfKey(seletedTab);
			if (pageSel > -1)
			{
				tabControlEducationalBuildings.SelectTab(pageSel);
				if (seletedTabTab.IsNotEmpty() && tabControlEducationalBuildings.SelectedTab?.Controls["tabControlDepartments"] is TabControl tab)
				{
					pageSel = tab.TabPages.IndexOfKey(seletedTabTab);
					if (pageSel > -1)
					{
						tab.SelectTab(pageSel);

						if (seletedId != null && tab.SelectedTab?.Controls["dataGridView"] is DataGridView grid)
						{
							var row = grid.Rows
									.Cast<DataGridViewRow>()
									.Where(r => r.Cells[0].Value.ToString().Equals(seletedId.ToString()))
									.First()?.Index;
							if (row.HasValue && row > -1)
							{
								grid.Rows[row.Value].Selected = true;
							}
						}
					}
				}
			}
		}

		private void TabControlEducationalBuildings_SelectedIndexChanged(object sender, EventArgs e) => LoadAuditoriumsPage(tabControlEducationalBuildings.SelectedTab);

		/// <summary>
		/// Загрузка аудиторий строения
		/// </summary>
		/// <param name="page"></param>
		private void LoadAuditoriumsPage(TabPage page)
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

			var buildingId = new Guid(page.Name.Replace("tabPage", ""));

			try
			{
				_auditoriums = _serviceA.GetList(new AuditoriumSearchModel { EducationalBuildingId = buildingId })?.
																		OrderBy(x => x.Number)?.ToList();
				if (_auditoriums == null || _auditoriums.Count == 0)
				{
					return;
				}

				listBox.Items.AddRange(_auditoriums.Select(x => x.Number).ToArray());
				if (listBox.Items.Count > 0)
				{
					listBox.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка зарузки аудиторий");
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
				var auditorium = _auditoriums.SingleOrDefault(x => x.Number == (sender as ListBox)?.SelectedItem.ToString());
				if (auditorium == null)
				{
					Program.ShowError("Невозможно определить аудиторию", "Ошибка получения данных");
					return;
				}
				var panel = (sender as ListBox).Parent.Controls.Find("panelContent", true).FirstOrDefault();
				if (panel != null)
				{
					panel.Controls.Clear();
					var control = new UserControlScheduleAuditorium(this)
					{
						Dock = DockStyle.Fill,
						Name = "UserControlScheduleAuditorium"
					};
					control.SetAuditoriumId(auditorium.Id);
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