using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScheduleBusinessLogic.ViewModels;

namespace ScheduleView
{
    public partial class UserControlDataGridViewSchedule : UserControl
    {
        public UserControlDataGridViewSchedule()
        {
            InitializeComponent();
        }

        private void UserControlDataGridViewSchedule_Load(object sender, EventArgs e)
        {
            DataGridViewColumn column1 = new DataGridViewColumn();
            column1.HeaderText = "День недели";
            column1.Name = "DayOfTheWeek";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //column1.Frozen = true;
            dataGridView.Columns.Add(column1);

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView_CellMouseClick);
        }
        
        public void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedCells[0].ColumnIndex == 0)
            {
                dataGridView.ClearSelection();
            }
        }

        public void RowDayOfTheWeekAdd(List<string> list, int dayOfTheWeek)
        {
            for (int i = 0; i < dayOfTheWeek; i++)
            {
                dataGridView.Rows.Add();
                dataGridView["DayOfTheWeek", i].Value = list[i];
            }
        }

        public void ColumnClassTimeAdd(List<ClassTimeViewModel> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DataGridViewColumn column2 = new DataGridViewColumn();
                column2.HeaderText = list[i].Number.ToString() + "\n" + list[i].StartTime + "-" + list[i].EndTime;
                column2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column2.Name = list[i].Number.ToString();
                column2.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView.Columns.Add(column2);
            }
        }

        public void Clear()
        {
            dataGridView.Rows.Clear();

            for (int i = dataGridView.Columns.Count; i > 1; i--)
            {
                dataGridView.Columns.RemoveAt(i - 1);
            }

        }

        public object Value(string str, int i, string val)
        {
            if (dataGridView[str, i].Value != null)
            {
                return dataGridView[str, i].Value += "\n" + val;
            }
            else
            {
                return dataGridView[str, i].Value = val;
            }
        }

        public int GetIndexDayOfTheWeek(string DayOfTheWeek)
        {
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (dataGridView["DayOfTheWeek", i].Value.ToString() == DayOfTheWeek)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
