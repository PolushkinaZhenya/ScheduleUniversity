using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScheduleServiceDAL.ViewModels;

namespace ScheduleView
{
    public partial class UserControlDataGridView : UserControl
    {
        public UserControlDataGridView()
        {
            InitializeComponent();
        }

        private void UserControlDataGridView_Load(object sender, EventArgs e)
        {
            DataGridViewColumn column0 = new DataGridViewColumn();
            column0.HeaderText = "Id";
            column0.Name = "Id";
            column0.CellTemplate = new DataGridViewTextBoxCell();
            column0.Visible = false;
            dataGridView.Columns.Add(column0);

            DataGridViewColumn column1 = new DataGridViewColumn();
            column1.HeaderText = "Дисциплина";
            column1.Name = "Discipline";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column1.ReadOnly = true;
            dataGridView.Columns.Add(column1);

            DataGridViewColumn column2 = new DataGridViewColumn();
            column2.HeaderText = "Преподаватель";
            column2.Name = "Teacher";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            column2.ReadOnly = true;
            dataGridView.Columns.Add(column2);

            DataGridViewComboBoxColumn column3 = new DataGridViewComboBoxColumn();
            column3.HeaderText = "Поток";
            column3.Name = "Flow";
            column3.CellTemplate = new DataGridViewComboBoxCell();
            column3.ReadOnly = false;
            column3.Width = 120;
            dataGridView.Columns.Add(column3);

            DataGridViewColumn column4 = new DataGridViewColumn();
            column4.HeaderText = "Всего часов";
            column4.Name = "NumderOfHours";
            column4.CellTemplate = new DataGridViewTextBoxCell();
            column4.Width = 80;
            column4.ReadOnly = true;
            dataGridView.Columns.Add(column4);

            for (int i = 0; i < 8; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.HeaderText = i + 1 + "-ая";
                column.Name = (i + 1).ToString();
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.Width = 40;
                column.ReadOnly = true;
                dataGridView.Columns.Add(column);
            }

            for (int i = 0; i < 3; i++)
            {
                DataGridViewColumn column5 = new DataGridViewColumn();
                column5.HeaderText = "Аудитория " + (i + 1);
                column5.Name = "Auditorium" + (i + 1);
                column5.CellTemplate = new DataGridViewTextBoxCell();
                column5.ReadOnly = true;
                dataGridView.Columns.Add(column5);
            }
        }

        public void RowAdd()
        {
            dataGridView.Rows.Add();
        }

        public void RowClear()
        {
            dataGridView.Rows.Clear();
        }

        public object Value(string str, int i, string val)
        {
            return dataGridView[str, i].Value = val;
        }

        public object ValueHoursWeek(int row, string val1, string val2)
        {
            for (int i = 0; i < 7; i = i + 2)
            {
                dataGridView[(i + 1).ToString(), row].Value = val1;
                dataGridView[(i + 2).ToString(), row].Value = val2;
            }
            return dataGridView;
        }

        public void ValueFlow(int i, List<FlowStudyGroupViewModel> listF)
        {
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView["Flow", i];//поиск ячейки

            List<string> listf = new List<string>();
            for (int f = 0; f < listF.Count; f++)
            {
                listf.Add(listF[f].StudyGroupTitle + (listF[f].Subgroup == null ? null : " п/г-" + listF[f].Subgroup));
            }
            cell.DataSource = listf;
            cell.Value = listf[0];
        }

        public int SelectedRowsCount()
        {
            return dataGridView.SelectedRows.Count;
        }

        public int RowsCount()
        {
            return dataGridView.RowCount;
        }

        public Guid GetId()
        {
            return new Guid(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}
