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
    public partial class FormAcademicYear : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Guid Id { set { id = value; } }

        private readonly IAcademicYearService service;

        private Guid? id;

        public FormAcademicYear(IAcademicYearService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormAcademicYear_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    AcademicYearViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxAcademicYear.Text = view.Title;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAcademicYear.Text) )
            {
                MessageBox.Show("Заполните данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new AcademicYearBindingModel
                    {
                        Id = id.Value,
                        Title = textBoxAcademicYear.Text
                    });
                }
                else
                {
                    service.AddElement(new AcademicYearBindingModel
                    {
                        Title = textBoxAcademicYear.Text
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
