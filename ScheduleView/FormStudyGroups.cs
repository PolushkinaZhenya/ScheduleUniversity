using ScheduleModel;
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
    public partial class FormStudyGroups : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IStudyGroupService service;

        public FormStudyGroups(IStudyGroupService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormStudyGroups_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<StudyGroupViewModel> listCourse = service.GetListCourse();
                List<StudyGroupViewModel> listStudyGroup;

                Width = 200;
                Controls.Clear();

                Button buttonAdd = new Button();
                buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
                buttonAdd.Location = new Point(70, 10);
                buttonAdd.Name = "buttonAdd";
                buttonAdd.Size = new Size(90, 40);
                buttonAdd.TabIndex = 11;
                buttonAdd.Text = "Добавить";
                buttonAdd.UseVisualStyleBackColor = true;
                buttonAdd.Click += new EventHandler(this.buttonAdd_Click);
                buttonAdd.Image = Properties.Resources.Add_20;
                buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                Controls.Add(buttonAdd);

                Width += listCourse.Count * 110;

                for (int i = 0; i < listCourse.Count; i++)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Location = new Point(40 + (60 + 60) * i, 15);
                    label.Name = "label" + i;
                    label.Size = new Size(60, 15);
                    label.TabIndex = 41;
                    label.Text = listCourse[i].Course + " курс";
                    Controls.Add(label);

                    DataGridView dataGridView = new DataGridView();
                    dataGridView.AllowUserToAddRows = false;
                    dataGridView.AllowUserToDeleteRows = false;
                    dataGridView.AllowUserToOrderColumns = true;
                    dataGridView.AllowUserToResizeColumns = false;
                    dataGridView.AllowUserToResizeRows = false;
                    dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)));
                    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    dataGridView.ColumnHeadersVisible = false;
                    dataGridView.Location = new Point(20 + (100 + 15) * i, 45);
                    dataGridView.Name = "dataGridView" + i;
                    dataGridView.ReadOnly = true;
                    dataGridView.RowHeadersVisible = false;
                    dataGridView.RowTemplate.Height = 24;
                    dataGridView.Size = new Size(100, 300);
                    dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
                    dataGridView.TabIndex = 43;
                    dataGridView.MultiSelect = false;
                    dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseDoubleClick);

                    Controls.Add(dataGridView);

                    listStudyGroup = service.GetListByCourse(listCourse[i].Course);
                    if (listStudyGroup != null)
                    {
                        dataGridView.DataSource = listStudyGroup;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].Visible = false;
                        dataGridView.Columns[4].Visible = false;
                        dataGridView.Columns[5].Visible = false;
                        dataGridView.Columns[6].Visible = false;
                        dataGridView.Columns[7].Visible = false;
                        dataGridView.Columns[8].Visible = false;
                    }
                }
                this.CenterToScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //string name = (sender as DataGridView).Name;
            DataGridView dataGrid = (sender as DataGridView);

            if (dataGrid.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormStudyGroup>();
                form.Id = (Guid)dataGrid.SelectedRows[0].Cells[0].Value;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStudyGroup>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
