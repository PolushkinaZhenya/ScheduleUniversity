using ScheduleBusinessLogic.Attributes;
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop.AdditionalReferences
{
	public partial class FormAdditionalReferenceList<B, V> : Form
		where B : AdditionalReferenceBindingModel, new()
		where V : AdditionalReferenceViewModel
    {
		private readonly IAdditionalReference<B, V> _service;

        private readonly List<string> _config;

        private FormAdditionalReference<B, V> _form;

        public FormAdditionalReferenceList(IAdditionalReference<B, V> service)
		{
			InitializeComponent();
			_service = service;


            var type = typeof(V);
            _config = dataGridView.ConfigDataGrid(type);
        }

        public FormAdditionalReference<B, V> Form { set { if (value != null) _form = value; } }

		private void FormAdditionalReferenceList_Load(object sender, EventArgs e)
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
            _form.Id = null;
            if (_form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ShowRecord()
        {
            if (dataGridView.SelectedRows.Count == 1 && _form != null)
            {
                _form.Id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                if (_form.ShowDialog() == DialogResult.OK)
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
                        Guid id = (Guid)row.Cells[0].Value;
                        try
                        {
                            _service.DelElement(id);
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

        private void ButtonAdd_Click(object sender, EventArgs e) => AddRecord();

        private void ButtonUpd_Click(object sender, EventArgs e) => ShowRecord();

        private void ButtonDel_Click(object sender, EventArgs e) => DeleteRecord();

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