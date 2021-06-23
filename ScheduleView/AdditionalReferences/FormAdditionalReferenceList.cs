using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces.AdditionalReferences;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Windows.Forms;

namespace ScheduleView.AdditionalReferences
{
	public partial class FormAdditionalReferenceList<B, V> : Form
		where B : AdditionalReferenceBindingModel
		where V : AdditionalReferenceViewModel
	{
		private readonly IAdditionalReference<B, V> _service;

		public FormAdditionalReferenceList(IAdditionalReference<B, V> service)
		{
			InitializeComponent();
			_service = service;
		}

		private void FormAdditionalReferenceList_Load(object sender, EventArgs e)
		{
            LoadData();
        }

        protected virtual void ConfigGrid() { }

        protected virtual Form GetForm(Guid? id) { return new Form(); }

        private void LoadData()
        {
            try
            {
                var list = _service.GetList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    ConfigGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRecord()
        {
            var form = GetForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ShowRecord()
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = GetForm((Guid)dataGridView.SelectedRows[0].Cells[0].Value);
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
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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