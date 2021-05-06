using ScheduleServiceDAL.BindingModels;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using System.Configuration;

namespace ScheduleView
{
    public partial class FormLoadTeacher : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        public string StudyGroupTitle { set { studyGroupTitle = value; } }

        private readonly ILoadTeacherService service;

        private readonly IDisciplineService serviceD;

        private readonly ITypeOfClassService serviceTC;

        private readonly ITeacherService serviceT;

        private readonly IFlowService serviceF;

        private readonly IStudyGroupService serviceSG;

        private readonly IScheduleService serviceS;

        private readonly IPeriodService serviceP;

        private Guid? id;

        private string studyGroupTitle;

        private List<LoadTeacherPeriodViewModel> LoadTeacherPeriods;

        private List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriums;

        List<string> ReportingForms = new List<string>() { "Зачет", "Зачет с оценкой", "Экзамен", "Курсовая работа", "Курсовой проект" };

        public FormLoadTeacher(ILoadTeacherService service, IDisciplineService serviceD, ITypeOfClassService serviceTC,
            ITeacherService serviceT, IFlowService serviceF, IStudyGroupService serviceSG, IScheduleService serviceS, IPeriodService serviceP)
        {
            InitializeComponent();
            this.service = service;
            this.serviceD = serviceD;
            this.serviceTC = serviceTC;
            this.serviceT = serviceT;
            this.serviceF = serviceF;
            this.serviceSG = serviceSG;
            this.serviceS = serviceS;
            this.serviceP = serviceP;
        }

        private void FormLoadTeacher_Load(object sender, EventArgs e)
        {
            try
            {
                //название группы в заголовок
                this.Text += " " + studyGroupTitle;

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
                for (int i=0; i< listT.Count; i++)
                {
                    listT[i].Surname = listT[i].Surname + " " + listT[i].Name.Substring(0, 1) + " " + listT[i].Patronymic.Substring(0, 1);
                }
                if (listT != null)
                {
                    comboBoxTeacher.DisplayMember = "Surname";
                    comboBoxTeacher.ValueMember = "Id";
                    comboBoxTeacher.DataSource = listT;
                    comboBoxTeacher.SelectedItem = null;
                }

                //получаем ID группы и лист
                List<FlowViewModel> listF = serviceF.GetListNotFlowAutoCreationByStudyGroup(serviceSG.GetElementByTitle(studyGroupTitle).Id);
                if (listF != null)
                {
                    comboBoxFlow.DisplayMember = "Title";
                    comboBoxFlow.ValueMember = "Id";
                    comboBoxFlow.DataSource = listF;
                    comboBoxFlow.SelectedItem = null;
                }

                comboBoxReportingForms.DataSource = ReportingForms;
                comboBoxReportingForms.SelectedItem = null;

                if (id.HasValue)
                {
                    LoadTeacherViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        comboBoxDiscipline.SelectedValue = view.DisciplineId;
                        comboBoxTypeOfClass.SelectedValue = view.TypeOfClassId;
                        comboBoxTeacher.SelectedValue = view.TeacherId;
                        comboBoxFlow.SelectedValue = view.FlowId;
                        textBoxReporting.Text = view.Reporting;
                        textBoxNumberOfSubgroups.Text = view.NumberOfSubgroups.ToString();
                        LoadTeacherPeriods = view.LoadTeacherPeriods;
                        LoadTeacherAuditoriums = view.LoadTeacherAuditoriums;
                        LoadData();

                        checkBoxFlowActive.Enabled = false;
                        comboBoxFlow.Enabled = false;
                        buttonAddFlow.Enabled = false;
                        textBoxNumberOfSubgroups.Enabled = false;
                        comboBoxTeacher.Enabled = false;
                    }
                }
                else
                {
                    LoadTeacherPeriods = new List<LoadTeacherPeriodViewModel>();
                    LoadTeacherAuditoriums = new List<LoadTeacherAuditoriumViewModel>();
                    LoadData();
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
                    dataGridViewPeriod.DataSource = LoadTeacherPeriods.GetRange(0, LoadTeacherPeriods.Count);
                    dataGridViewPeriod.Columns[0].Visible = false;
                    dataGridViewPeriod.Columns[1].Visible = false;
                    dataGridViewPeriod.Columns[2].Visible = false;
                    dataGridViewPeriod.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (LoadTeacherAuditoriums != null)
                {
                    dataGridViewAuditorium.DataSource = null;
                    dataGridViewAuditorium.DataSource = LoadTeacherAuditoriums.GetRange(0, LoadTeacherAuditoriums.Count);
                    dataGridViewAuditorium.Columns[0].Visible = false;
                    dataGridViewAuditorium.Columns[1].Visible = false;
                    dataGridViewAuditorium.Columns[2].Visible = false;
                    dataGridViewAuditorium.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewAuditorium.Columns[4].Visible = false;
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

                    //проверка на существование периода в расчасовке
                    for (int i = 0; i < LoadTeacherPeriods.Count; i++)
                    {
                        if (LoadTeacherPeriods[i].PeriodTitle == form.Model.PeriodTitle)
                        {
                            MessageBox.Show("Время на данный период уже есть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    LoadTeacherPeriods.Add(form.Model);

                }
                LoadData();
            }
        }

        private void buttonAddAuditorium_Click(object sender, EventArgs e)
        {
            if (LoadTeacherAuditoriums.Count < 3)
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

                        //проверка на существование аудитории в расчасовке
                        for (int i = 0; i < LoadTeacherAuditoriums.Count; i++)
                        {
                            if (LoadTeacherAuditoriums[i].AuditoriumId == form.Model.AuditoriumId)
                            {
                                MessageBox.Show("Аудитория уже добавлена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        LoadTeacherAuditoriums.Add(form.Model);

                        //пересчет приорирета
                        for (int i = 0; i < LoadTeacherAuditoriums.Count; i++)
                        {
                            LoadTeacherAuditoriums[i].Priority = i+1;
                        }
                    }
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Нельзя добавить больше 3х аудиторий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonUpdPeriod_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeriod.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacherPeriod>();

                //если хотим изменить текущий период
                if (LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex].PeriodId == new Guid(ConfigurationManager.AppSettings["IDPeriod"]))
                {
                    form.Model = LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex];
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Нельзя изменять другой период", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    //пересчет приорирета
                    for (int i = 0; i < LoadTeacherAuditoriums.Count; i++)
                    {
                        LoadTeacherAuditoriums[i].Priority = i + 1;
                    }

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

                        //пересчет приорирета
                        for (int i = 0; i < LoadTeacherAuditoriums.Count; i++)
                        {
                            LoadTeacherAuditoriums[i].Priority = i + 1;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonSaveandClose_Click(object sender, EventArgs e)
        {
            if (comboBoxDiscipline.SelectedValue == null || comboBoxTypeOfClass.SelectedValue == null
                || comboBoxTeacher.SelectedValue == null || (LoadTeacherPeriods == null || LoadTeacherPeriods.Count == 0)
                || (LoadTeacherAuditoriums == null || LoadTeacherAuditoriums.Count == 0)
                || (string.IsNullOrEmpty(textBoxReporting.Text)))
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxDiscipline.SelectedValue == null || comboBoxTypeOfClass.SelectedValue == null
                            || comboBoxTeacher.SelectedValue == null || (LoadTeacherPeriods == null || LoadTeacherPeriods.Count == 0)
                            || (LoadTeacherAuditoriums == null || LoadTeacherAuditoriums.Count == 0)
                            || (string.IsNullOrEmpty(textBoxReporting.Text)))
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Save();
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //сохраняем расчасовку
        private void Save()
        {
            FlowViewModel flow = null;

            if (comboBoxFlow.SelectedValue == null)
            {
                List<FlowViewModel> flows = serviceF.GetList();// все потоки базы
                for (int i = 0; i < flows.Count; i++)//удаляем потоки, где более одной группы
                {
                    if (flows[i].FlowStudyGroups.Count > 1)
                    {
                        flows.Remove(flows[i]);
                        i--;
                    }
                }
                bool flowexists = false;
                for (int i = 0; i < flows.Count; i++)//ищем был ли поток с такой группой и п/г
                {
                    FlowStudyGroupViewModel flowStudyGroup = flows[i].FlowStudyGroups[0];//с чем сравнивать

                    if (flowStudyGroup.StudyGroupTitle == studyGroupTitle && flowStudyGroup.Subgroup.ToString() == textBoxNumberOfSubgroups.Text)
                    {
                        //если поток есть
                        flow = serviceF.GetElement(flows[i].Id);
                        flowexists = true;
                    }
                }
                if (!flowexists)
                {
                    //есть нет потока, создаем
                    List<FlowStudyGroupViewModel> FlowStudyGroups = new List<FlowStudyGroupViewModel>();

                    StudyGroupViewModel studygroup = serviceSG.GetElementByTitle(studyGroupTitle);

                    FlowStudyGroupViewModel model = new FlowStudyGroupViewModel
                    {
                        StudyGroupId = studygroup.Id,
                        StudyGroupTitle = studygroup.Title,
                        Subgroup = textBoxNumberOfSubgroups.Text == "" ? (int?)null : Int32.Parse(textBoxNumberOfSubgroups.Text)
                    };

                    FlowStudyGroups.Add(model);

                    List<FlowStudyGroupBindingModel> FlowStudyGroupBM = new List<FlowStudyGroupBindingModel>();
                    for (int j = 0; j < FlowStudyGroups.Count; ++j)
                    {
                        FlowStudyGroupBM.Add(new FlowStudyGroupBindingModel
                        {
                            Id = FlowStudyGroups[j].Id,
                            FlowId = FlowStudyGroups[j].FlowId,
                            StudyGroupId = FlowStudyGroups[j].StudyGroupId,
                            Subgroup = FlowStudyGroups[j].Subgroup
                        });
                    }

                    serviceF.AddElement(new FlowBindingModel
                    {
                        Title = studyGroupTitle + (textBoxNumberOfSubgroups.Text == "" ? null : " п/г-" + Int32.Parse(textBoxNumberOfSubgroups.Text)),
                        FlowAutoCreation = true,
                        FlowStudyGroups = FlowStudyGroupBM
                    });
                    //записываем новый поток
                    flow = serviceF.GetElementByTitle(studyGroupTitle + (textBoxNumberOfSubgroups.Text == "" ? null : " п/г-" + Int32.Parse(textBoxNumberOfSubgroups.Text)));
                }
            }
            else
            {
                flow = serviceF.GetElement((Guid)comboBoxFlow.SelectedValue);
            }

            List<LoadTeacherPeriodBindingModel> LoadTeacherPeriodBM = new List<LoadTeacherPeriodBindingModel>();
            for (int i = 0; i < LoadTeacherPeriods.Count; ++i)
            {
                LoadTeacherPeriodBM.Add(new LoadTeacherPeriodBindingModel
                {
                    Id = LoadTeacherPeriods[i].Id,
                    LoadTeacherId = LoadTeacherPeriods[i].LoadTeacherId,
                    PeriodId = LoadTeacherPeriods[i].PeriodId,
                    TotalHours = LoadTeacherPeriods[i].TotalHours,
                    HoursFirstWeek = LoadTeacherPeriods[i].HoursFirstWeek,
                    HoursSecondWeek = LoadTeacherPeriods[i].HoursSecondWeek
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
                UpdSchedule(id, service.GetElement((Guid)id).LoadTeacherPeriods, LoadTeacherPeriods, service.GetElement((Guid)id).LoadTeacherAuditoriums, LoadTeacherAuditoriums);

                service.UpdElement(new LoadTeacherBindingModel
                {
                    Id = id.Value,
                    DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                    TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                    TeacherId = (Guid)comboBoxTeacher.SelectedValue,
                    FlowId = service.GetElement((Guid)id).FlowId,
                    LoadTeacherPeriods = LoadTeacherPeriodBM,
                    LoadTeacherAuditoriums = LoadTeacherAuditoriumBM,
                    Reporting = textBoxReporting.Text,
                    NumberOfSubgroups = textBoxNumberOfSubgroups.Text == "" ? (int?)null : Int32.Parse(textBoxNumberOfSubgroups.Text)
                });
            }
            else
            {
                Guid loc_id = Guid.NewGuid();

                service.AddElement(new LoadTeacherBindingModel
                {
                    Id = loc_id,
                    DisciplineId = (Guid)comboBoxDiscipline.SelectedValue,
                    TypeOfClassId = (Guid)comboBoxTypeOfClass.SelectedValue,
                    TeacherId = (Guid)comboBoxTeacher.SelectedValue,
                    FlowId = flow.Id,
                    LoadTeacherPeriods = LoadTeacherPeriodBM,
                    LoadTeacherAuditoriums = LoadTeacherAuditoriumBM,
                    Reporting = textBoxReporting.Text,
                    NumberOfSubgroups = textBoxNumberOfSubgroups.Text == "" ? (int?)null : Int32.Parse(textBoxNumberOfSubgroups.Text)
                });

                AddSchedule(loc_id);//создаем пару
            }
        }

        //добавляем пары в расписание на эту расчасовку
        private void AddSchedule(Guid LoadTeacherId)
        {
            try
            {
                LoadTeacherViewModel loadTeacher;
                List<FlowStudyGroupViewModel> listFlowStudyGroup;

                //добавление занятий
                foreach (var LoadTeacherPeriod in LoadTeacherPeriods)
                {
                    loadTeacher = service.GetElementWhitHoursByPeroid(LoadTeacherId, LoadTeacherPeriod.PeriodId);
                    listFlowStudyGroup = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;

                    for (int i = 0; i < listFlowStudyGroup.Count; i++)
                    {
                        for (int first = 0; first < LoadTeacherPeriod.HoursFirstWeek / 2; first++)
                        {
                            serviceS.AddElement(new ScheduleBindingModel
                            {
                                PeriodId = LoadTeacherPeriod.PeriodId,
                                NumberWeeks = 1,
                                DayOfTheWeek = null,
                                Type = "Занятие",
                                ClassTimeId = null,
                                StudyGroupId = listFlowStudyGroup[i].StudyGroupId,
                                Subgroups = listFlowStudyGroup[i].Subgroup,
                                AuditoriumId = null,
                                LoadTeacherId = LoadTeacherId
                            });
                        }

                        for (int second = 0; second < LoadTeacherPeriod.HoursSecondWeek / 2; second++)
                        {
                            serviceS.AddElement(new ScheduleBindingModel
                            {
                                PeriodId = LoadTeacherPeriod.PeriodId,
                                NumberWeeks = 2,
                                DayOfTheWeek = null,
                                Type = "Занятие",
                                ClassTimeId = null,
                                StudyGroupId = listFlowStudyGroup[i].StudyGroupId,
                                Subgroups = listFlowStudyGroup[i].Subgroup,
                                AuditoriumId = null,
                                LoadTeacherId = LoadTeacherId
                            });
                        }
                    }
                }
                //добавление отчетности
                //loadTeacher = service.GetElement(LoadTeacherId);
                //listFlowStudyGroup = serviceF.GetElement(loadTeacher.FlowId).FlowStudyGroups;

                //List<PeriodViewModel> periods = serviceP.GetListBySemester(new Guid(ConfigurationManager.AppSettings["IDSemester"]));

                //for (int i = 0; i < listFlowStudyGroup.Count; i++)
                //{
                //    for (int first = 0; first < loadTeacher.HoursFirstWeek / 2; first++)
                //    {
                //        serviceS.AddElement(new ScheduleBindingModel
                //        {
                //            PeriodId = periods[0].Id,
                //            NumberWeeks = 1,
                //            DayOfTheWeek = null,
                //            Type = "Сессия",
                //            ClassTimeId = null,
                //            StudyGroupId = listFlowStudyGroup[i].StudyGroupId,
                //            Subgroups = null,
                //            AuditoriumId = null,
                //            LoadTeacherId = LoadTeacherId
                //        });
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdSchedule(Guid? LoadTeacherId, List<LoadTeacherPeriodViewModel> LoadTeacherPeriodOld,
            List<LoadTeacherPeriodViewModel> LoadTeacherPeriodNew, List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriumOld,
            List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriumNew)
        {

            List<LoadTeacherPeriodViewModel> LoadTeacherPeriodUpd = new List<LoadTeacherPeriodViewModel>();
            List<LoadTeacherAuditoriumViewModel> LoadTeacherAuditoriumUpd = new List<LoadTeacherAuditoriumViewModel>();

            //изменения в периодах и часах
            if (LoadTeacherPeriodNew.Count != LoadTeacherPeriodOld.Count)
            {
                //сброс
                Reset(LoadTeacherId);
                return;
            }
            else
            {
                for (int i = 0; i < LoadTeacherPeriodNew.Count; i++)
                {
                    bool equal = false;
                    for (int j = 0; j < LoadTeacherPeriodOld.Count; j++)
                    {
                        if (LoadTeacherPeriodNew[i].PeriodTitle == LoadTeacherPeriodOld[j].PeriodTitle && LoadTeacherPeriodNew[i].TotalHours == LoadTeacherPeriodOld[j].TotalHours)
                        {
                            equal = true;
                        }
                    }
                    if (!equal)
                    {
                        LoadTeacherPeriodUpd.Add(LoadTeacherPeriodNew[i]);
                    }
                }
                if (LoadTeacherPeriodUpd.Count != 0)
                {
                    //сброс
                    Reset(LoadTeacherId);
                    return;
                }
            }

            //изменения в аудиториях
            if (LoadTeacherAuditoriumNew.Count != LoadTeacherAuditoriumOld.Count)
            {
                //сброс
                Reset(LoadTeacherId);
                return;
            }
            else
            {
                for (int i = 0; i < LoadTeacherAuditoriumNew.Count; i++)
                {
                    bool equal = false;
                    for (int j = 0; j < LoadTeacherAuditoriumOld.Count; j++)
                    {
                        if (LoadTeacherAuditoriumNew[i].AuditoriumId == LoadTeacherAuditoriumOld[j].AuditoriumId 
                            && LoadTeacherAuditoriumNew[i].Priority == LoadTeacherAuditoriumOld[j].Priority)
                        {
                            equal = true;
                        }
                    }
                    if (!equal)
                    {
                        LoadTeacherAuditoriumUpd.Add(LoadTeacherAuditoriumNew[i]);
                    }
                }
                if (LoadTeacherAuditoriumUpd.Count != 0)
                {
                    //сброс
                    Reset(LoadTeacherId);
                    return;
                }
            }
        }

        //сброс пар в расписании
        private void Reset(Guid? LoadTeacherId)
        {
            List<ScheduleViewModel> scheduleByLoadTeacher = serviceS.GetListByLoadTeacher(LoadTeacherId, "Занятие");

            //удаляем пары
            for (int i = 0; i < scheduleByLoadTeacher.Count; i++)
            {
                serviceS.DelElement(scheduleByLoadTeacher[i].Id);
            }

            AddSchedule((Guid)LoadTeacherId);
        }

        private void dataGridViewPeriod_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewPeriod.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormLoadTeacherPeriod>();

                //если хотим изменить текущий период
                if (LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex].PeriodId == new Guid(ConfigurationManager.AppSettings["IDPeriod"]))
                {
                    form.Model = LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex];
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadTeacherPeriods[dataGridViewPeriod.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Нельзя изменять другой период", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    //пересчет приорирета
                    for (int i = 0; i < LoadTeacherAuditoriums.Count; i++)
                    {
                        LoadTeacherAuditoriums[i].Priority = i + 1;
                    }

                    LoadData();
                }
            }
        }

        private void comboBoxReportingForms_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxReporting.Text += comboBoxReportingForms.SelectedItem.ToString() + ", ";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBoxFlowActive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFlowActive.Checked == true)
            {
                comboBoxFlow.Enabled = true;
            }
            else
            {
                comboBoxFlow.Enabled = false;
            }
        }

        private void buttonAddFlow_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFlow>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                List<FlowViewModel> listF = serviceF.GetListNotFlowAutoCreation();
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
                        comboBoxFlow.SelectedValue = view.FlowId;
                    }
                }
                LoadData();
            }
        }
    }
}
