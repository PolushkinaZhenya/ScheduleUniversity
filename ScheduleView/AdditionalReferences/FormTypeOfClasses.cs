using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormTypeOfClasses : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ITypeOfClassService service;

        public FormTypeOfClasses(ITypeOfClassService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTypeOfClasses_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<TypeOfClassViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRecord()
        {
            var form = Container.Resolve<FormTypeOfClass>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ShowRecord()
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTypeOfClass>();
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
                            service.DelElement(id);
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