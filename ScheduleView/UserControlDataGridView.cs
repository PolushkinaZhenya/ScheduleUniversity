using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            DataGridViewColumn column1 = new DataGridViewColumn();
            column1.HeaderText = "Дисциплина";
            column1.Name = "Discipline";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns.Add(column1);

            DataGridViewColumn column2 = new DataGridViewColumn();
            column2.HeaderText = "Преподаватель";
            column2.Name = "Teacher";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView.Columns.Add(column2);

            DataGridViewColumn column3 = new DataGridViewColumn();
            column3.HeaderText = "Всего часов";
            column3.Name = "NumderOfHours";
            column3.CellTemplate = new DataGridViewTextBoxCell();
            column3.Width = 80;
            dataGridView.Columns.Add(column3);

            for (int i = 0; i < 16; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.HeaderText = (i+1) + "-ая";
                column.Name = (i+1).ToString();
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.Width = 40;
                dataGridView.Columns.Add(column);
            }

            for (int i=0; i<3; i++)
            {
                DataGridViewColumn column4 = new DataGridViewColumn();
                column4.HeaderText = "Аудитория "+(i+1);
                column4.Name = "Auditorium"+(i+1);
                column4.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView.Columns.Add(column4);
            }

            //DataGridViewColumn column4 = new DataGridViewColumn();
            //column4.HeaderText = "Аудитория 1";
            //column4.Name = "Auditorium1";
            //column4.CellTemplate = new DataGridViewTextBoxCell();
            //dataGridView.Columns.Add(column4);

            //DataGridViewColumn column5 = new DataGridViewColumn();
            //column5.HeaderText = "Аудитория 2";
            //column5.Name = "Auditorium2";
            //column5.CellTemplate = new DataGridViewTextBoxCell();
            //dataGridView.Columns.Add(column5);

            //DataGridViewColumn column6 = new DataGridViewColumn();
            //column6.HeaderText = "Аудитория 3";
            //column6.Name = "Auditorium3";
            //column6.CellTemplate = new DataGridViewTextBoxCell();
            //dataGridView.Columns.Add(column6);
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
    }
}
