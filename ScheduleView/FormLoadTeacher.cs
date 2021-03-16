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
    public partial class FormLoadTeacher : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly ILoadTeacherService service;

        private readonly IDisciplineService serviceD;

        private readonly ITypeOfClassService serviceTC;

        private readonly ITeacherService serviceT;

        private readonly IFlowService serviceF;

        private Guid? id;

        private List<LoadTeacherPeriodViewModel> LoadTeacherPeriods;

        private List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriums;

        public FormLoadTeacher(ILoadTeacherService service, IDisciplineService serviceD, ITypeOfClassService serviceTC,
            ITeacherService serviceT, IFlowService serviceF)
        {
            InitializeComponent();
            this.service = service;
            this.serviceD = serviceD;
            this.serviceTC = serviceTC;
            this.serviceT = serviceT;
            this.serviceF = serviceF;
        }

        private void FormLoadTeacher_Load(object sender, EventArgs e)
        {
            try
            {
                List<DisciplineViewModel> listD = serviceD.GetList();
                if (listD != null)
                {
                    comboBoxDiscipline.DisplayMember = "Title";
                    comboBoxDiscipline.ValueMember = "Id";
                    comboBoxDiscipline.DataSource = listD;
                    comboBoxDiscipline.SelectedItem = null;
                }

                List<TypeOfClassViewModel> listTC = serviceTC.GetList();
                if (listTC != null)
                {
                    comboBoxTypeOfClass.DisplayMember = "Title";
                    comboBoxTypeOfClass.ValueMember = "Id";
                    comboBoxTypeOfClass.DataSource = listTC;
                    comboBoxTypeOfClass.SelectedItem = null;
                }

                List<TeacherViewModel> listT = serviceT.GetList();
                if (listT != null)
                {
                    comboBoxTeacher.DisplayMember = "Surname";
                    comboBoxTeacher.ValueMember = "Id";
                    comboBoxTeacher.DataSource = listT;
                    comboBoxTeacher.SelectedItem = null;
                }

                List<FlowViewModel> listF = serviceF.GetList();
                if (listF != null)
                {
                    comboBoxFlow.DisplayMember = "Title";
                    comboBoxFlow.ValueMember = "Id";
                    comboBoxFlow.DataSource = listF;
                    comboBoxFlow.SelectedItem = null;
                }


                if (id.HasValue)
                {
                    LoadTeacherViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        comboBoxDiscipline.SelectedValue = view.DisciplineId;
                        comboBoxTypeOfClass.SelectedValue = view.TypeOfClassId;
                        comboBoxTeacher.SelectedValue = view.TeacherId;
                        comboBoxFlow.SelectedValue = view.FlowId;
                        LoadTeacherPeriods = view.LoadTeacherPeriods;
                        LoadTeacherAuditoriums = view.LoadTeacherAuditoriums;
                        LoadData();
                    }
                }
                else
                {
                    LoadTeacherPeriods = new List<LoadTeacherPeriodViewModel>();
                    LoadTeacherAuditoriums = new List<LoadTeacherAuditoriumViewModel>();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (LoadTeacherPeriods != null)
                {
                    dataGridViewPeriod.DataSource = null;
                    dataGridViewPeriod.DataSource = LoadTeacherPeriods;
                    dataGridViewPeriod.Columns[0].Visible = false;
                    dataGridViewPeriod.Columns[1].Visible = false;
                    dataGridViewPeriod.Columns[2].Visible = false;
                    dataGridViewPeriod.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (LoadTeacherAuditoriums != null)
                {
                    dataGridViewAuditorium.DataSource = null;
                    dataGridViewAuditorium.DataSource = LoadTeacherAuditoriums;
                    dataGridViewAuditorium.Columns[0].Visible = false;
                    dataGridViewAuditorium.Columns[1].Visible = false;
                    dataGridViewAuditorium.Columns[2].Visible = false;
                    dataGridViewAuditorium.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddPeriod_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLoadTeacherPeriod>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.LoadTeacherId = id.Value;
                    }
                    LoadTeacherPeriods.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonAddAuditorium_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLoadTeacherAuditorium>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.LoadTeacherId = id.Value;
                    }
                    LoadTeacherAuditoriums.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpdPeriod_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeriod.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacherPeriod>();
                form.Model = LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonUpdAuditorium_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuditorium.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacherAuditorium>();
                form.Model = LoadTeacherAuditoriums[dataGridViewAuditorium.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTeacherAuditoriums[dataGridViewAuditorium.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDelPeriod_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeriod.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        LoadTeacherPeriods.RemoveAt(dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonDelAuditorium_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuditorium.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        LoadTeacherAuditoriums.RemoveAt(dataGridViewAuditorium.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefPeriod_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonRefAuditorium_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxDiscipline.SelectedValue == null || comboBoxTypeOfClass.SelectedValue == null
                || comboBoxTeacher.SelectedValue == null || comboBoxFlow.SelectedValue == null ||
                (LoadTeacherPeriods == null || LoadTeacherPeriods.Count == 0) || (LoadTeacherAuditoriums == null || LoadTeacherAuditoriums.Count == 0))
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<LoadTeacherPeriodBindingModel> LoadTeacherPeriodBM = new List<LoadTeacherPeriodBindingModel>();
                for (int i = 0; i < LoadTeacherPeriods.Count; ++i)
                {
                    LoadTeacherPeriodBM.Add(new LoadTeacherPeriodBindingModel
                    {
                        Id = LoadTeacherPeriods[i].Id,
                        LoadTeacherId = LoadTeacherPeriods[i].LoadTeacherId,
                        PeriodId = LoadTeacherPeriods[i].PeriodId,
                        NumderOfHours = LoadTeacherPeriods[i].NumderOfHours
                    });
                }

                List<LoadTeacherAuditoriumBindingModel> LoadTeacherAuditoriumBM = new List<LoadTeacherAuditoriumBindingModel>();
                for (int i = 0; i < LoadTeacherAuditoriums.Count; ++i)
                {
                    LoadTeacherAuditoriumBM.Add(new LoadTeacherAuditoriumBindingModel
                    {
                        Id = LoadTeacherAuditoriums[i].Id,
                        LoadTeacherId = LoadTeacherAuditoriums[i].LoadTeacherId,
                        AuditoriumId = LoadTeacherAuditoriums[i].AuditoriumId
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new LoadTeacherBindingModel
                    {
                        Id = id.Value,
                        DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                        TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                        TeacherId = (Guid)comboBoxTeacher.SelectedValue,
                        FlowId = (Guid)comboBoxFlow.SelectedValue,
                        LoadTeacherPeriods = LoadTeacherPeriodBM,
                        LoadTeacherAuditoriums = LoadTeacherAuditoriumBM
                    });
                }
                else
                {
                    service.AddElement(new LoadTeacherBindingModel
                    {
                        DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                        TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                        TeacherId = (Guid)comboBoxTeacher.SelectedValue,
                        FlowId = (Guid)comboBoxFlow.SelectedValue,
                        LoadTeacherPeriods = LoadTeacherPeriodBM,
                        LoadTeacherAuditoriums = LoadTeacherAuditoriumBM
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

        private void dataGridViewPeriod_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewPeriod.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacherPeriod>();
                form.Model = LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void dataGridViewAuditorium_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewAuditorium.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacherAuditorium>();
                form.Model = LoadTeacherAuditoriums[dataGridViewAuditorium.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTeacherAuditoriums[dataGridViewAuditorium.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }
    }
}
