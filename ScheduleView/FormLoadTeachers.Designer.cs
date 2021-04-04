namespace ScheduleView
{
    partial class FormLoadTeachers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.listBoxStudyGroups = new System.Windows.Forms.ListBox();
            this.comboBoxAcademicYear = new System.Windows.Forms.ComboBox();
            this.comboBoxSemester = new System.Windows.Forms.ComboBox();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Location = new System.Drawing.Point(1258, 107);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(90, 40);
            this.buttonDel.TabIndex = 23;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpd.Location = new System.Drawing.Point(1258, 61);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(90, 40);
            this.buttonUpd.TabIndex = 22;
            this.buttonUpd.Text = "Изменить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(1258, 15);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(90, 40);
            this.buttonAdd.TabIndex = 21;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 530);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1240, 156);
            this.dataGridView.TabIndex = 20;
            // 
            // listBoxStudyGroups
            // 
            this.listBoxStudyGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxStudyGroups.FormattingEnabled = true;
            this.listBoxStudyGroups.ItemHeight = 16;
            this.listBoxStudyGroups.Location = new System.Drawing.Point(1094, 14);
            this.listBoxStudyGroups.Name = "listBoxStudyGroups";
            this.listBoxStudyGroups.Size = new System.Drawing.Size(158, 420);
            this.listBoxStudyGroups.Sorted = true;
            this.listBoxStudyGroups.TabIndex = 26;
            this.listBoxStudyGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxStudyGroups_SelectedIndexChanged);
            this.listBoxStudyGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxStudyGroups_MouseDoubleClick);
            // 
            // comboBoxAcademicYear
            // 
            this.comboBoxAcademicYear.FormattingEnabled = true;
            this.comboBoxAcademicYear.Location = new System.Drawing.Point(512, 14);
            this.comboBoxAcademicYear.Name = "comboBoxAcademicYear";
            this.comboBoxAcademicYear.Size = new System.Drawing.Size(121, 24);
            this.comboBoxAcademicYear.TabIndex = 27;
            this.comboBoxAcademicYear.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAcademicYear_SelectionChangeCommitted);
            // 
            // comboBoxSemester
            // 
            this.comboBoxSemester.FormattingEnabled = true;
            this.comboBoxSemester.Location = new System.Drawing.Point(724, 14);
            this.comboBoxSemester.Name = "comboBoxSemester";
            this.comboBoxSemester.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSemester.TabIndex = 28;
            this.comboBoxSemester.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSemester_SelectionChangeCommitted);
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Location = new System.Drawing.Point(948, 14);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(121, 24);
            this.comboBoxPeriod.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Год:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Семестр:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(880, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Период:";
            // 
            // FormLoadTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 698);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPeriod);
            this.Controls.Add(this.comboBoxSemester);
            this.Controls.Add(this.comboBoxAcademicYear);
            this.Controls.Add(this.listBoxStudyGroups);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormLoadTeachers";
            this.Text = "Расчасовки";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLoadTeachers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ListBox listBoxStudyGroups;
        private System.Windows.Forms.ComboBox comboBoxAcademicYear;
        private System.Windows.Forms.ComboBox comboBoxSemester;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}