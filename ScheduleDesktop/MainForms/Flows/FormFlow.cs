using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.SearchModels;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormFlow : Form
    {
        private Guid? _id;

        public Guid Id { set { _id = value; } }

        private readonly IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel> _service;

        private List<FlowStudyGroupViewModel> _flowStudyGroups;

        private readonly List<string> _config;

        public FormFlow(IBaseService<FlowBindingModel, FlowViewModel, FlowSearchModel> service)
        {
            InitializeComponent();
            _service = service;

            _config = dataGridView.ConfigDataGrid(typeof(FlowStudyGroupViewModel));
        }

        private void FormFlow_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    FlowViewModel view = _service.GetElement(new FlowSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        _flowStudyGroups = view.FlowStudyGroups;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowError(ex, "Ошибка");
                }
            }
            else
            {
                _flowStudyGroups = new List<FlowStudyGroupViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                dataGridView.FillDataGrid(_config, _flowStudyGroups);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка");
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormFlowStudyGroup>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (_id.HasValue)
                    {
                        form.Model.FlowId = _id.Value;
                    }
                    _flowStudyGroups.Add(form.Model);
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormFlowStudyGroup>();
                form.Model = _flowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _flowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (Program.ShowQuestion("Удалить запись") == DialogResult.Yes)
                {
                    try
                    {
                        _flowStudyGroups.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        Program.ShowError(ex, "Ошибка удаления");
                    }
                    LoadData();
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text.IsEmpty() || (_flowStudyGroups == null || _flowStudyGroups.Count == 0))
            {
                Program.ShowError("Заполните все данные и выберете группы", "Ошибка");
                return;
            }
            try
            {
                var FlowStudyGroupBM = new List<FlowStudyGroupBindingModel>();
                for (int i = 0; i < _flowStudyGroups.Count; ++i)
                {
                    FlowStudyGroupBM.Add(new FlowStudyGroupBindingModel
                    {
                        Id = _flowStudyGroups[i].Id,
                        FlowId = _flowStudyGroups[i].FlowId,
                        StudyGroupId = _flowStudyGroups[i].StudyGroupId,
                        Subgroup = _flowStudyGroups[i].Subgroup
                    });
                }
                if (_id.HasValue)
                {
                    _service.UpdElement(new FlowBindingModel
                    {
                        Id = _id.Value,
                        Title = textBoxTitle.Text,
                        FlowAutoCreation = false,
                        FlowStudyGroups = FlowStudyGroupBM
                    });
                }
                else
                {
                    _service.AddElement(new FlowBindingModel
                    {
                        Title = textBoxTitle.Text,
                        FlowAutoCreation = false,
                        FlowStudyGroups = FlowStudyGroupBM
                    });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex, "Ошибка  сохранения");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
            Close();
        }

        private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormFlowStudyGroup>();
                form.Model = _flowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _flowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }
    }
}