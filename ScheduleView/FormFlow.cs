using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormFlow : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

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
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = FlowStudyGroups;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFlowStudyGroup>();
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

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormFlowStudyGroup>();
                form.Model = FlowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FlowStudyGroups[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        FlowStudyGroups.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text) || 
                (FlowStudyGroups == null || FlowStudyGroups.Count == 0))
            {
                MessageBox.Show("Заполните все данные и выберете группы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<FlowStudyGroupBindingModel> FlowStudyGroupBM = new List<FlowStudyGroupBindingModel>();
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
                //MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormFlowStudyGroup>();
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
