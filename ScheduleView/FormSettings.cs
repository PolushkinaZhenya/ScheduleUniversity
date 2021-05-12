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
using System.Configuration;

namespace ScheduleView
{
    public partial class FormSettings : Form
    {
        private readonly IAcademicYearService serviceAY;

        private readonly ISemesterService serviceS;

        private readonly IPeriodService serviceP;

        public FormSettings(IAcademicYearService serviceAY, ISemesterService serviceS, IPeriodService serviceP)
        {
            InitializeComponent();
            this.serviceAY = serviceAY;
            this.serviceS = serviceS;
            this.serviceP = serviceP;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<AcademicYearViewModel> listAY = serviceAY.GetList();

                if (listAY.Count != 0)
                {
                    comboBoxAcademicYear.DisplayMember = "Title";
                    comboBoxAcademicYear.ValueMember = "Id";
                    comboBoxAcademicYear.DataSource = listAY;
                    comboBoxAcademicYear.SelectedItem = null;

                    if (ConfigurationManager.AppSettings["IDAcademicYear"] != "" && ConfigurationManager.AppSettings["IDSemester"] != ""
                        && ConfigurationManager.AppSettings["IDPeriod"] != "")
                    {
                        Guid IDAcademicYear = new Guid(ConfigurationManager.AppSettings["IDAcademicYear"]);
                        AcademicYearViewModel viewAY = serviceAY.GetElement(IDAcademicYear);
                        if (viewAY != null)
                        {
                            comboBoxAcademicYear.SelectedValue = viewAY.Id;

                            List<SemesterViewModel> list = serviceS.GetListByAcademicYear(IDAcademicYear);
                            if (list != null)
                            {
                                comboBoxSemester.DisplayMember = "Title";
                                comboBoxSemester.ValueMember = "Id";
                                comboBoxSemester.DataSource = list;
                                comboBoxSemester.SelectedItem = null;
                            }
                        }

                        Guid IDSemester = new Guid(ConfigurationManager.AppSettings["IDSemester"]);
                        SemesterViewModel viewS = serviceS.GetElement(IDSemester);
                        if (viewS != null)
                        {
                            comboBoxSemester.SelectedValue = viewS.Id;

                            List<PeriodViewModel> list = serviceP.GetListBySemester(IDSemester);
                            if (list != null)
                            {
                                comboBoxPeriod.DisplayMember = "Title";
                                comboBoxPeriod.ValueMember = "Id";
                                comboBoxPeriod.DataSource = list;
                                comboBoxPeriod.SelectedItem = null;
                            }
                        }

                        Guid IDPeriod = new Guid(ConfigurationManager.AppSettings["IDPeriod"]);
                        PeriodViewModel viewP = serviceP.GetElement(IDPeriod);
                        if (viewP != null)
                        {
                            comboBoxPeriod.SelectedValue = viewP.Id;
                        }

                        int DayOfTheWeek = Int32.Parse(ConfigurationManager.AppSettings["DayOfTheWeek"]);
                        textBoxDayOfTheWeek.Text = DayOfTheWeek.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Создайте учебный год", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxAcademicYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBoxSemester.DataSource = null;
            comboBoxPeriod.DataSource = null;

            Guid AcademicYearId = (Guid)comboBoxAcademicYear.SelectedValue;

            List<SemesterViewModel> list = serviceS.GetListByAcademicYear(AcademicYearId);
            if (list.Count != 0)
            {
                comboBoxSemester.DisplayMember = "Title";
                comboBoxSemester.ValueMember = "Id";
                comboBoxSemester.DataSource = list;
                comboBoxSemester.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Создайте семестр для данного учебного года", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void comboBoxSemester_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBoxPeriod.DataSource = null;

            Guid SemesterId = (Guid)comboBoxSemester.SelectedValue;

            List<PeriodViewModel> list = serviceP.GetListBySemester(SemesterId);
            if (list.Count != 0)
            {
                comboBoxPeriod.DisplayMember = "Title";
                comboBoxPeriod.ValueMember = "Id";
                comboBoxPeriod.DataSource = list;
                comboBoxPeriod.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Создайте период для данного семестра", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAcademicYear.SelectedValue == null || comboBoxSemester.SelectedValue == null || comboBoxPeriod.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                settings["IDAcademicYear"].Value = comboBoxAcademicYear.SelectedValue.ToString();
                settings["IDSemester"].Value = comboBoxSemester.SelectedValue.ToString();
                settings["IDPeriod"].Value = comboBoxPeriod.SelectedValue.ToString();
                settings["DayOfTheWeek"].Value = textBoxDayOfTheWeek.Text;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                
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
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
