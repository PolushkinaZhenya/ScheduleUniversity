using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces.AdditionalReferences;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleView.AdditionalReferences
{
	public partial class FormAdditionalReferenceList<B, V, F> : Form
		where B : AdditionalReferenceBindingModel
		where V : AdditionalReferenceViewModel
        where F : FormAdditionalReference<B, V>
    {
		private readonly IAdditionalReference<B, V> _service;

        private readonly List<string> _config;

        public FormAdditionalReferenceList(IAdditionalReference<B, V> service)
		{
			InitializeComponent();
			_service = service;


            var type = typeof(V);
            _config = new List<string>();
            foreach (var prop in type.GetProperties())
            {
                // получаем список атрибутов
                //var attributes = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
                //if (attributes != null && attributes.Length > 0)
                //{
                //    foreach (var attr in attributes)
                //    {
                //        // ищем нужный нам атрибут
                //        if (attr is ColumnAttribute columnAttr)
                //        {
                //            var column = new DataGridViewTextBoxColumn
                //            {
                //                Name = prop.Name,
                //                ReadOnly = true,
                //                HeaderText = columnAttr.Title,
                //                Visible = columnAttr.Visible,
                //                Width = columnAttr.Width
                //            };
                //            if (columnAttr.GridViewAutoSize != GridViewAutoSize.None)
                //            {
                //                column.AutoSizeMode = (DataGridViewAutoSizeColumnMode)Enum.Parse(typeof(DataGridViewAutoSizeColumnMode), columnAttr.GridViewAutoSize.ToString());
                //            }
                //            if ((attr as ColumnAttribute).Title == "id")
                //            {
                //                _config.Insert(0, prop.Name);
                //                dataGridView.Columns.Insert(0, column);
                //            }
                //            else
                //            {
                //                _config.Add(prop.Name);
                //                dataGridView.Columns.Add(column);
                //            }
                //        }
                //    }
                //}
            }
        }

		private void FormAdditionalReferenceList_Load(object sender, EventArgs e)
		{
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _service.GetList();
                if (list != null)
                {
                    foreach (var elem in list)
                    {
                        var objs = new List<object>();
                        foreach (var conf in _config)
                        {
                            var value = elem.GetType().GetProperty(conf).GetValue(elem);

                            objs.Add(value);
                        }

                        dataGridView.Rows.Add(objs.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRecord()
        {
            var form = DependencyManager.Instance.Resolve<F>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ShowRecord()
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<F>();
                form.Id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
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