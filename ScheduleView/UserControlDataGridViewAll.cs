using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleServiceDAL.ViewModels;

namespace ScheduleView
{
    public partial class UserControlDataGridViewAll : UserControl
    {
        public List<TypeOfClassViewModel> listTC { get; set; }

        public UserControlDataGridViewAll(List<TypeOfClassViewModel> listTC)
        {
            InitializeComponent();
            this.listTC = listTC;
        }

        private void UserControlDataGridViewAll_Load(object sender, EventArgs e)
        {
            DataGridViewColumn column1 = new DataGridViewColumn();
            column1.HeaderText = "Дисциплина";
            column1.Name = "Discipline";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns.Add(column1);

            DataGridViewColumn column3 = new DataGridViewColumn();
            column3.HeaderText = "Всего часов";
            column3.Name = "NumderOfHours";
            column3.CellTemplate = new DataGridViewTextBoxCell();
            column3.Width = 80;
            dataGridView.Columns.Add(column3);

            for (int i = 0; i < listTC.Count; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.HeaderText = listTC[i].AbbreviatedTitle;
                column.Name = listTC[i].AbbreviatedTitle.ToString();
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.Width = 80;
                dataGridView.Columns.Add(column);
            }

            DataGridViewColumn column4 = new DataGridViewColumn();
            column4.HeaderText = "Отчетность";
            column4.Name = "Reporting";
            column4.CellTemplate = new DataGridViewTextBoxCell();
            column4.Width = 200;
            dataGridView.Columns.Add(column4);

            //DataGridViewColumn column5 = new DataGridViewColumn();
            //column5.HeaderText = "Кол-во подгрупп";
            //column5.Name = "NumberOfSubgroups";
            //column5.CellTemplate = new DataGridViewTextBoxCell();
            //column5.Width = 80;
            //dataGridView.Columns.Add(column5);
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

        public int GetValue(string str, int i)
        {
            object o = dataGridView[str, i].Value;

            if (o == null)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(o.ToString());
            }
        }

        public int GetRowByDisciplineTitle(string DisciplineTitle)
        {
            int Count = dataGridView.RowCount;
            for (int i = 0; i < Count; i++)
            {
                object s = dataGridView["Discipline", i].Value;

                if (s !=null && s.ToString() == DisciplineTitle)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
