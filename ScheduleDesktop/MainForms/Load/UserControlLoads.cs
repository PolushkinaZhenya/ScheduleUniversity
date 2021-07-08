using ScheduleBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class UserControlLoads : UserControl
    {
        private readonly ILoadTeacherService service;

        public UserControlLoads()
		{
			InitializeComponent();
            service = DependencyManager.Instance.Resolve<ILoadTeacherService>();
        }

        public async Task LoadData(Guid studyGroupId, Guid typeClassId)
		{
          //  var loads = await Task.Run(() => service.GetListByTypeAndStudyGroupAndPeriod(_buildingId.Value)?.GroupBy(x => x.Department)?.OrderBy(x => x.Key)?.ToList());


            var grid = CreateDataGrid();

            Controls.Clear();
            Controls.Add(grid);
        }

		private static DataGridView CreateDataGrid()
		{
			var grid = new DataGridView
			{
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				AllowUserToResizeColumns = false,
				AllowUserToResizeRows = false,
				Dock = DockStyle.Fill,
				BackgroundColor = SystemColors.Window,
				ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
				Location = new Point(3, 3),
				Name = "dataGridView",
				RowHeadersVisible = false,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				Size = new Size(869, 232),
				TabIndex = 0
			};
			grid.RowTemplate.Height = 24;

            grid.Columns.Add(new DataGridViewColumn
            {
                HeaderText = "Id",
                Name = "Id",
                CellTemplate = new DataGridViewTextBoxCell(),
                Visible = false
            });
			grid.Columns.Add(new DataGridViewColumn
            {
                HeaderText = "Дисциплина",
                Name = "Discipline",
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 400,
                ReadOnly = true
            });

			grid.Columns.Add(new DataGridViewColumn
            {
                HeaderText = "Преподаватель",
                Name = "Teacher",
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 300,
                ReadOnly = true
            });

			grid.Columns.Add(new DataGridViewComboBoxColumn
            {
                HeaderText = "Поток",
                Name = "Flow",
                CellTemplate = new DataGridViewComboBoxCell(),
                ReadOnly = false,
                Width = 120
            });

			grid.Columns.Add(new DataGridViewColumn
            {
                HeaderText = "Всего часов",
                Name = "NumderOfHours",
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 80,
                ReadOnly = true
            });

            for (int i = 0; i < 2; i++)
            {
				grid.Columns.Add(new DataGridViewColumn
                {
                    HeaderText = i + 1 + "-ая",
                    Name = (i + 1).ToString(),
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 60,
                    ReadOnly = true
                });
            }

            grid.Columns.Add(new DataGridViewColumn
            {
                HeaderText = "Аудитории",
                Name = "Auditoriums",
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = 300,
                ReadOnly = true
            });

            return grid;
		}
	}
}