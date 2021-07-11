using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormAcademicYears : Form
	{
		private readonly List<string> _config;

		private readonly IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> _service;

		public FormAcademicYears(IBaseService<AcademicYearBindingModel, AcademicYearViewModel, AcademicYearSearchModel> service)
		{
			InitializeComponent();
			_service = service;

			_config = dataGridView.ConfigDataGrid(typeof(AcademicYearViewModel));
		}

		private void FormAcademicYears_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				dataGridView.Rows.Clear();
				var list = _service.GetList();
				dataGridView.FillDataGrid(_config, list);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, "Ошибка загрузки");
			}
		}

		private void AddRecord()
		{
			var form = DependencyManager.Instance.Resolve<FormAcademicYear>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void ShowRecord()
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var form = DependencyManager.Instance.Resolve<FormAcademicYear>();
				form.Id = (Guid)dataGridView.SelectedRows[0].Cells["Id"].Value;
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}

		private void DeleteRecord()
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
				{
					foreach (DataGridViewRow row in dataGridView.SelectedRows)
					{
						try
						{
							_service.DelElement(new AcademicYearSearchModel { Id = (Guid)row.Cells[0].Value });
						}
						catch (Exception ex)
						{
							Program.ShowError(ex, "Ошибка удаления");
						}
					}
					LoadData();
				}
			}
		}

		private void ButtonAddAcademinYear_Click(object sender, EventArgs e) => AddRecord();

		private void ButtonUpdAcademinYear_Click(object sender, EventArgs e) => ShowRecord();

		private void ButtonDelAcademinYear_Click(object sender, EventArgs e) => DeleteRecord();

		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => ShowRecord();

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space: // добавить
					AddRecord();
					break;
				case Keys.Enter: // изменить
					ShowRecord();
					break;
				case Keys.Delete: // удалить
					DeleteRecord();
					break;
			}
		}
	}
}