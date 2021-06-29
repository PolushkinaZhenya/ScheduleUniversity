using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.Interfaces;
using ScheduleBusinessLogic.ViewModels;
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
    public partial class FormSemester : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly ISemesterService service;

        private readonly IAcademicYearService serviceAY;

        private Guid? id;

        public FormSemester(ISemesterService service, IAcademicYearService serviceAY)
        {
            InitializeComponent();
            this.service = service;
            this.serviceAY = serviceAY;
        }

        private void FormSemester_Load(object sender, EventArgs e)
        {
            try
            {
                List<AcademicYearViewModel> listAY = serviceAY.GetList();
                if (listAY != null)
                {
                    comboBoxAcademicYear.DisplayMember = "Title";
                    comboBoxAcademicYear.ValueMember = "Id";
                    comboBoxAcademicYear.DataSource = listAY;
                    comboBoxAcademicYear.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    SemesterViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        comboBoxAcademicYear.SelectedValue = view.AcademicYearId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text) || string.IsNullOrEmpty(comboBoxAcademicYear.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new SemesterBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxTitle.Text,
                        AcademicYearId = (Guid)comboBoxAcademicYear.SelectedValue
                    });
                }
                else
                {
                    service.AddElement(new SemesterBindingModel
                    {
                        Title = textBoxTitle.Text,
                        AcademicYearId = (Guid)comboBoxAcademicYear.SelectedValue
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
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
