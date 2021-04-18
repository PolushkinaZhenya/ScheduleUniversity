using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleServiceDAL.Interfaces;
using ScheduleServiceDAL.ViewModels;

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
            dataGridView.Columns.Add(column1);
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
                //column2.HeaderCell.Style.Font = new Font(dataGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Bold);
                column2.Name = list[i].Number.ToString();
                column2.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView.Columns.Add(column2);
            }
        }

        public void RowClear()
        {
            dataGridView.Rows.Clear();
        }
    }
}
