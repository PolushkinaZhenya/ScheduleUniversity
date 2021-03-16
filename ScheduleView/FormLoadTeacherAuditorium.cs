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
    public partial class FormLoadTeacherAuditorium : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IAuditoriumService service;

        private LoadTeacherAuditoriumViewModel model;

        public LoadTeacherAuditoriumViewModel Model
        {
            set
            {
                model = value;
            }
            get
            {
                return model;
            }
        }

        public FormLoadTeacherAuditorium(IAuditoriumService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormLoadTeacherAuditorium_Load(object sender, EventArgs e)
        {
            try
            {
                List<AuditoriumViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxAuditorium.DisplayMember = "Number";
                    comboBoxAuditorium.ValueMember = "Id";
                    comboBoxAuditorium.DataSource = list;
                    comboBoxAuditorium.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxAuditorium.SelectedValue = model.AuditoriumId;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAuditorium.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new LoadTeacherAuditoriumViewModel
                    {
                        AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue,
                        AuditoriumTitle = comboBoxAuditorium.Text
                    };
                }
                else
                {
                    model.AuditoriumId = (Guid)comboBoxAuditorium.SelectedValue;
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
