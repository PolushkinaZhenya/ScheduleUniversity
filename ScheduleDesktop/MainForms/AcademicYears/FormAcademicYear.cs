using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
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
	public partial class FormAcademicYear : Form
	{
		private Guid? id;

		public Guid Id { set { id = value; } }

		private readonly List<string> _config;

		private readonly IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> _serviceAY;

		private readonly IBaseService<SemesterBindingModel, SemesterViewModel, SemesterSearchModel> _serviceS;

		private bool _isAddSemester;

		public FormAcademicYear(IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> serviceAY,
			IBaseService<SemesterBindingModel, SemesterViewModel, SemesterSearchModel> serviceS)
		{
			InitializeComponent();
			_serviceAY = serviceAY;
			_serviceS = serviceS;

			_config = dataGridViewSemesters.ConfigDataGrid(typeof(SemesterViewModel));
		}

		private void FormAcademicYear_Load(object sender, EventArgs e)
		{
			try
			{
				if (id.HasValue)
				{
					var view = _serviceAY.GetElement(new AcademicYearSearchModel { Id = id.Value });
					if (view != null)
					{
						textBoxTitle.Text = view.Title;
					}
					LoadSemesters();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки");
			}
		}

		private void LoadSemesters()
		{
			if (id.HasValue)
			{
				dataGridViewSemesters.Rows.Clear();
				var semetser = _serviceS.GetList(new SemesterSearchModel { AcademicYearId = id.Value });
				dataGridViewSemesters.FillDataGrid(_config, semetser);
			}
		}

		private void ButtonCreateSemesters_Click(object sender, EventArgs e)
		{
			if (dataGridViewSemesters.Rows.Count != 0)
			{
				return;
			}

			dataGridViewSemesters.Rows.Add(new object[] { Guid.NewGuid(), "Осенний семестр", textBoxTitle.Text });
			dataGridViewSemesters.Rows.Add(new object[] { Guid.NewGuid(), "Весенний семестр", textBoxTitle.Text });
		}

		private void ButtonAddSemester_Click(object sender, EventArgs e)
		{
			textBoxSemester.Text = string.Empty;
			panelSemester.Visible = true;
			dataGridViewSemesters.Enabled = false;
			_isAddSemester = true;
		}

		private void ButtonUpdSemester_Click(object sender, EventArgs e)
		{
			if (dataGridViewSemesters.SelectedRows.Count == 1)
			{
				textBoxSemester.Text = dataGridViewSemesters.SelectedRows[0].Cells[1].Value.ToString();
				dataGridViewSemesters.Enabled = false;
				panelSemester.Visible = true;
				_isAddSemester = false;
			}
		}

		private void ButtonDelSemester_Click(object sender, EventArgs e)
		{
			if (dataGridViewSemesters.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in dataGridViewSemesters.SelectedRows)
				{
					dataGridViewSemesters.Rows.Remove(row);
				}
			}
		}

		private void ButtonSemesterSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxSemester.Text))
			{
				return;
			}
			if (_isAddSemester)
			{
				dataGridViewSemesters.Rows.Add(new object[] { Guid.NewGuid(), textBoxSemester.Text, textBoxTitle.Text });
			}
			else
			{
				dataGridViewSemesters.SelectedRows[0].Cells[1].Value = textBoxSemester.Text;
			}
			panelSemester.Visible = false;
			dataGridViewSemesters.Enabled = true;
		}

		private void ButtonSemseterCancel_Click(object sender, EventArgs e)
		{
			panelSemester.Visible = false;
			dataGridViewSemesters.Enabled = true;
		}
	}
}
