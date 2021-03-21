namespace ScheduleView
{
    partial class FormStudyGroups
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
            this.listBox_1course = new System.Windows.Forms.ListBox();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.listBox_2course = new System.Windows.Forms.ListBox();
            this.listBox_3course = new System.Windows.Forms.ListBox();
            this.listBox_4course = new System.Windows.Forms.ListBox();
            this.listBox_5course = new System.Windows.Forms.ListBox();
            this.listBox_6course = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_1course
            // 
            this.listBox_1course.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listBox_1course.FormattingEnabled = true;
            this.listBox_1course.ItemHeight = 16;
            this.listBox_1course.Location = new System.Drawing.Point(11, 58);
            this.listBox_1course.Name = "listBox_1course";
            this.listBox_1course.Size = new System.Drawing.Size(120, 212);
            this.listBox_1course.Sorted = true;
            this.listBox_1course.TabIndex = 0;
            this.listBox_1course.Click += new System.EventHandler(this.listBox_1course_Click);
            this.listBox_1course.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_1course_MouseDoubleClick);
            // 
            // buttonRef
            // 
            this.buttonRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRef.Location = new System.Drawing.Point(1165, 150);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(90, 40);
            this.buttonRef.TabIndex = 19;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Location = new System.Drawing.Point(1165, 104);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(90, 40);
            this.buttonDel.TabIndex = 18;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpd.Location = new System.Drawing.Point(1165, 58);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(90, 40);
            this.buttonUpd.TabIndex = 17;
            this.buttonUpd.Text = "Изменить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(1165, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(90, 40);
            this.buttonAdd.TabIndex = 16;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(11, 292);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(515, 216);
            this.dataGridView.TabIndex = 15;
            // 
            // listBox_2course
            // 
            this.listBox_2course.FormattingEnabled = true;
            this.listBox_2course.ItemHeight = 16;
            this.listBox_2course.Location = new System.Drawing.Point(137, 58);
            this.listBox_2course.Name = "listBox_2course";
            this.listBox_2course.Size = new System.Drawing.Size(120, 212);
            this.listBox_2course.Sorted = true;
            this.listBox_2course.TabIndex = 20;
            this.listBox_2course.Click += new System.EventHandler(this.listBox_2course_Click);
            this.listBox_2course.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_2course_MouseDoubleClick);
            // 
            // listBox_3course
            // 
            this.listBox_3course.FormattingEnabled = true;
            this.listBox_3course.ItemHeight = 16;
            this.listBox_3course.Location = new System.Drawing.Point(263, 58);
            this.listBox_3course.Name = "listBox_3course";
            this.listBox_3course.Size = new System.Drawing.Size(120, 212);
            this.listBox_3course.Sorted = true;
            this.listBox_3course.TabIndex = 21;
            this.listBox_3course.Click += new System.EventHandler(this.listBox_3course_Click);
            // 
            // listBox_4course
            // 
            this.listBox_4course.FormattingEnabled = true;
            this.listBox_4course.ItemHeight = 16;
            this.listBox_4course.Location = new System.Drawing.Point(389, 58);
            this.listBox_4course.Name = "listBox_4course";
            this.listBox_4course.Size = new System.Drawing.Size(120, 212);
            this.listBox_4course.Sorted = true;
            this.listBox_4course.TabIndex = 22;
            this.listBox_4course.Click += new System.EventHandler(this.listBox_4course_Click);
            // 
            // listBox_5course
            // 
            this.listBox_5course.FormattingEnabled = true;
            this.listBox_5course.ItemHeight = 16;
            this.listBox_5course.Location = new System.Drawing.Point(515, 58);
            this.listBox_5course.Name = "listBox_5course";
            this.listBox_5course.Size = new System.Drawing.Size(120, 212);
            this.listBox_5course.Sorted = true;
            this.listBox_5course.TabIndex = 23;
            this.listBox_5course.Click += new System.EventHandler(this.listBox_5course_Click);
            // 
            // listBox_6course
            // 
            this.listBox_6course.FormattingEnabled = true;
            this.listBox_6course.ItemHeight = 16;
            this.listBox_6course.Location = new System.Drawing.Point(641, 58);
            this.listBox_6course.Name = "listBox_6course";
            this.listBox_6course.Size = new System.Drawing.Size(120, 212);
            this.listBox_6course.Sorted = true;
            this.listBox_6course.TabIndex = 24;
            this.listBox_6course.Click += new System.EventHandler(this.listBox_6course_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "1 курс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "2 курс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "3 курс";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "4 курс";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "5 курс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(670, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "6 курс";
            // 
            // FormStudyGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 605);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_6course);
            this.Controls.Add(this.listBox_5course);
            this.Controls.Add(this.listBox_4course);
            this.Controls.Add(this.listBox_3course);
            this.Controls.Add(this.listBox_2course);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.listBox_1course);
            this.Name = "FormStudyGroups";
            this.Text = "Учебные группы";
            this.Load += new System.EventHandler(this.FormStudyGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_1course;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ListBox listBox_2course;
        private System.Windows.Forms.ListBox listBox_3course;
        private System.Windows.Forms.ListBox listBox_4course;
        private System.Windows.Forms.ListBox listBox_5course;
        private System.Windows.Forms.ListBox listBox_6course;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}