using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlStudyGroupsForFaculty : UserControl
	{
		private readonly IStudyGroupService service;

		private Guid? _facultyId = null;

		public UserControlStudyGroupsForFaculty()
		{
			InitializeComponent();
			service = DependencyManager.Instance.Resolve<IStudyGroupService>();
		}

		public async Task LoadGroupsAsync(Guid facultyId)
		{
			_facultyId = facultyId;
			await LoadData();
		}

		private async Task LoadData()
		{
			if (!_facultyId.HasValue)
			{
				return;
			}

			try
			{
				var groupbByCourses = await Task.Run(() => service.GetListByFaculty(_facultyId.Value)?.GroupBy(x => x.Course)?.OrderBy(x => x.Key)?.ToList());
				if (groupbByCourses == null || groupbByCourses.Count == 0)
				{
					return;
				}

				tabControlCourses.TabPages.Clear();
				foreach (var groupCourse in groupbByCourses)
				{
					var page = new TabPage
					{
						Name = $"tabPage{groupCourse.Key}",
						Padding = new Padding(3),
						TabIndex = 0,
						Text = $"Курс {groupCourse.Key}",
						UseVisualStyleBackColor = true
					};

					var dataGridView = new DataGridView
					{
						AllowUserToAddRows = false,
						AllowUserToDeleteRows = false,
						AllowUserToOrderColumns = true,
						AllowUserToResizeColumns = false,
						AllowUserToResizeRows = false,
						Dock = DockStyle.Fill,
						ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
						Name = $"dataGridView{groupCourse.Key}",
						ReadOnly = true,
						RowHeadersVisible = false
					};
					dataGridView.RowTemplate.Height = 24;
					dataGridView.Size = new Size(100, 300);
					dataGridView.BackgroundColor = SystemColors.Window;
					dataGridView.TabIndex = 43;
					dataGridView.MultiSelect = false;
					dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
					dataGridView.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
					dataGridView.KeyDown += DataGridView_KeyDown;

					page.Controls.Add(dataGridView);
					await Task.Run(() =>
					{
						dataGridView.FillDataGrid(dataGridView.ConfigDataGrid(typeof(StudyGroupViewModel)), groupCourse.ToList());
					});

					tabControlCourses.TabPages.Add(page);
				}
			}
			catch(Exception ex)
			{
				Program.ShowError(ex, "Ошибка получения данных");
				return;
			}
			
			SetFocusToGrid(tabControlCourses.SelectedTab);
		}

		private async void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => await OpenForm(sender as DataGridView);

		private async void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			var grid = sender as DataGridView;
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
					if (form.ShowDialog() == DialogResult.OK)
					{
						await LoadData();
					}
					break;
				case Keys.Enter: // изменить
					await OpenForm(grid);
					break;
				case Keys.Delete: // удалить
					if (grid?.SelectedRows.Count == 1)
					{
						var id = (Guid)grid.SelectedRows[0].Cells[0].Value;
						if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
						{
							try
							{
								service.DelElement(id);
								await LoadData();
							}
							catch (Exception ex)
							{
								Program.ShowError(ex, "Ошибка удаления");
							}
						}
					}
					break;
			}
		}

		private async Task OpenForm(DataGridView grid)
		{
			if (grid == null)
			{
				return;
			}

			if (grid.SelectedRows.Count == 1)
			{
				var form = DependencyManager.Instance.Resolve<FormStudyGroup>();
				form.Id = (Guid)grid.SelectedRows[0].Cells[0].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					await LoadData();
				}
			}
		}

		private void TabControlCourses_SelectedIndexChanged(object sender, EventArgs e) => SetFocusToGrid(tabControlCourses.SelectedTab);

		private static void SetFocusToGrid(TabPage page)
		{
			if (page == null)
			{
				return;
			}
			var grid = page.Controls.Cast<DataGridView>().FirstOrDefault();
			if (grid != null)
			{
				grid.Focus();
			}

		}
	}
}