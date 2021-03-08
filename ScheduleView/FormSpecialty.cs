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
    public partial class FormSpecialty : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly ISpecialtyService service;

        private readonly IFacultyService serviceF;

        private Guid? id;

        public FormSpecialty(ISpecialtyService service, IFacultyService serviceF)
        {
            InitializeComponent();
            this.service = service;
            this.serviceF = serviceF;
        }

        private void FormSpecialty_Load(object sender, EventArgs e)
        {
            try
            {
                List<FacultyViewModel> listF = serviceF.GetList();
                if (listF != null)
                {
                    comboBoxFaculty.DisplayMember = "Title";
                    comboBoxFaculty.ValueMember = "Id";
                    comboBoxFaculty.DataSource = listF;
                    comboBoxFaculty.SelectedItem = null;
                }

                if (id.HasValue)
                {
                    SpecialtyViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxCode.Text = view.Code;
                        textBoxTitle.Text = view.Title;
                        textBoxAbbreviatedTitle.Text = view.AbbreviatedTitle;
                        comboBoxFaculty.SelectedValue = view.FacultyId;
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
            if (string.IsNullOrEmpty(textBoxCode.Text) || string.IsNullOrEmpty(textBoxTitle.Text) 
                || string.IsNullOrEmpty(textBoxAbbreviatedTitle.Text)
                || comboBoxFaculty.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new SpecialtyBindingModel
                    {
                        Id = id.Value,
                        Code = textBoxCode.Text,
                        Title = textBoxTitle.Text,
                        AbbreviatedTitle = textBoxAbbreviatedTitle.Text,
                        FacultyId = (Guid)comboBoxFaculty.SelectedValue
                    });
                }
                else
                {
                    service.AddElement(new SpecialtyBindingModel
                    {
                        Code = textBoxCode.Text,
                        Title = textBoxTitle.Text,
                        AbbreviatedTitle = textBoxAbbreviatedTitle.Text,
                        FacultyId = (Guid)comboBoxFaculty.SelectedValue
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
