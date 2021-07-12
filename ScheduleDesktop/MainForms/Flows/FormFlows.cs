using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormFlows : Form
    {
        private readonly IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel> _service;

        public FormFlows(IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel> service)
        {
            InitializeComponent();
            _service = service;
        }

        private void FormFlows_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<FlowViewModel> list = _service.GetList(new FlowSearchModel { FlowAutoCreation = false });
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка");
            }
        }

        private void AddFlow()
        {
            var form = DependencyManager.Instance.Resolve<FormFlow>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void UpdFlow()
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormFlow>();
                form.Id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void DelFlow()
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid id = (Guid)dataGridView.SelectedRows[0].Cells[0].Value;
                    try
                    {
                        _service.DelElement(new FlowSearchModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        Program.ShowError(ex, "Ошибка");
                    }
                    LoadData();
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e) => AddFlow();

        private void ButtonUpd_Click(object sender, EventArgs e) => UpdFlow();

        private void ButtonDel_Click(object sender, EventArgs e) => DelFlow();

        private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) => UpdFlow();

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
            switch (e.KeyCode)
            {
                case Keys.Space: // добавить
                    AddFlow();
                    break;
                case Keys.Enter: // изменить
                    UpdFlow();
                    break;
                case Keys.Delete: // удалить
                    DelFlow();
                    break;
            }
        }
	}
}