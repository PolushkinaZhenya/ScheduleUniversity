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
    public partial class FormFlowStudyGroup : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStudyGroupService service;

        private FlowStudyGroupViewModel model;

        public FlowStudyGroupViewModel Model
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

        public FormFlowStudyGroup(IStudyGroupService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormFlowStudyGroup_Load(object sender, EventArgs e)
        {
            try
            {
                List<StudyGroupViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxStudyGroup.DisplayMember = "Title";
                    comboBoxStudyGroup.ValueMember = "Id";
                    comboBoxStudyGroup.DataSource = list;
                    comboBoxStudyGroup.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxStudyGroup.SelectedValue = model.StudyGroupId;
                textBoxSubgroup.Text = model.Subgroup.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxStudyGroup.SelectedValue == null)
            {
                MessageBox.Show("Заполите все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new FlowStudyGroupViewModel
                    {
                        StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue,
                        StudyGroupTitle = comboBoxStudyGroup.Text,
                        Subgroup = textBoxSubgroup.Text == "" ? (int?)null : Int32.Parse(textBoxSubgroup.Text)
                    };
                }
                else
                {
                    model.StudyGroupId = (Guid)comboBoxStudyGroup.SelectedValue;
                    model.Subgroup = textBoxSubgroup.Text == "" ? (int?)null : Int32.Parse(textBoxSubgroup.Text);

                    //if (textBoxSubgroup.Text == string.Empty)
                    //{
                    //    model.Subgroup = null;
                    //}
                    //else
                    //{
                    //    model.Subgroup = Int32.Parse(textBoxSubgroup.Text);
                    //}

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
