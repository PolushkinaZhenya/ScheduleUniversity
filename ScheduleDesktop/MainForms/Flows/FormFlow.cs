using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleDesktop
{
	public partial class FormFlow : Form
    {
        public Guid Id { set { id = value; } }

        private readonly IFlowService service;

        private Guid? id;

        private List<FlowStudyGroupViewModel> FlowStudyGroups;

        public FormFlow(IFlowService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormFlow_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    FlowViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        FlowStudyGroups = view.FlowStudyGroups;
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
                FlowStudyGroups = new List<FlowStudyGroupViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (FlowStudyGroups != null)
                {
                    dataGridView.DataSource = FlowStudyGroups;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
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
                    if (id.HasValue)
                    {
                        form.Model.FlowId = id.Value;
                    }
                    FlowStudyGroups.Add(form.Model);
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormFlowStudyGroup>();
                form.Model = FlowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FlowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
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
                        FlowStudyGroups.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
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
            if (string.IsNullOrEmpty(textBoxTitle.Text) || 
                (FlowStudyGroups == null || FlowStudyGroups.Count == 0))
            {
                Program.ShowError("Заполните все данные и выберете группы", "Ошибка");
                return;
            }
            try
            {
                var FlowStudyGroupBM = new List<FlowStudyGroupBindingModel>();
                for (int i = 0; i < FlowStudyGroups.Count; ++i)
                {
                    FlowStudyGroupBM.Add(new FlowStudyGroupBindingModel
                    {
                        Id = FlowStudyGroups[i].Id,
                        FlowId = FlowStudyGroups[i].FlowId,
                        StudyGroupId = FlowStudyGroups[i].StudyGroupId,
                        Subgroup = FlowStudyGroups[i].Subgroup
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new FlowBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxTitle.Text,
                        FlowAutoCreation = false,
                        FlowStudyGroups = FlowStudyGroupBM
                    });
                }
                else
                {
                    service.AddElement(new FlowBindingModel
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
                form.Model = FlowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FlowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }
    }
}
