namespace ScheduleView
{
    partial class FormLoadTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadTeacher));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveandClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDelPeriod = new System.Windows.Forms.Button();
            this.buttonUpdPeriod = new System.Windows.Forms.Button();
            this.buttonAddPeriod = new System.Windows.Forms.Button();
            this.dataGridViewPeriod = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeOfClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTeacher = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFlow = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDelAuditorium = new System.Windows.Forms.Button();
            this.buttonUpdAuditorium = new System.Windows.Forms.Button();
            this.buttonAddAuditorium = new System.Windows.Forms.Button();
            this.dataGridViewAuditorium = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReporting = new System.Windows.Forms.TextBox();
            this.comboBoxReportingForms = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNumberOfSubgroups = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxFlowActive = new System.Windows.Forms.CheckBox();
            this.buttonAddFlow = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriod)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditorium)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(974, 353);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 40);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveandClose
            // 
            this.buttonSaveandClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveandClose.Location = new System.Drawing.Point(798, 353);
            this.buttonSaveandClose.Name = "buttonSaveandClose";
            this.buttonSaveandClose.Size = new System.Drawing.Size(170, 40);
            this.buttonSaveandClose.TabIndex = 17;
            this.buttonSaveandClose.Text = "Сохранить и закрыть";
            this.buttonSaveandClose.UseVisualStyleBackColor = true;
            this.buttonSaveandClose.Click += new System.EventHandler(this.buttonSaveandClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonDelPeriod);
            this.groupBox1.Controls.Add(this.buttonUpdPeriod);
            this.groupBox1.Controls.Add(this.buttonAddPeriod);
            this.groupBox1.Controls.Add(this.dataGridViewPeriod);
            this.groupBox1.Location = new System.Drawing.Point(439, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 162);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Периоды";
            // 
            // buttonDelPeriod
            // 
            this.buttonDelPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelPeriod.Image = global::ScheduleView.Properties.Resources.Del_20;
            this.buttonDelPeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelPeriod.Location = new System.Drawing.Point(501, 113);
            this.buttonDelPeriod.Name = "buttonDelPeriod";
            this.buttonDelPeriod.Size = new System.Drawing.Size(120, 40);
            this.buttonDelPeriod.TabIndex = 12;
            this.buttonDelPeriod.Text = "Удалить";
            this.buttonDelPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelPeriod.UseVisualStyleBackColor = true;
            this.buttonDelPeriod.Click += new System.EventHandler(this.buttonDelPeriod_Click);
            // 
            // buttonUpdPeriod
            // 
            this.buttonUpdPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdPeriod.Image = global::ScheduleView.Properties.Resources.Upd_20;
            this.buttonUpdPeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdPeriod.Location = new System.Drawing.Point(501, 67);
            this.buttonUpdPeriod.Name = "buttonUpdPeriod";
            this.buttonUpdPeriod.Size = new System.Drawing.Size(120, 40);
            this.buttonUpdPeriod.TabIndex = 11;
            this.buttonUpdPeriod.Text = "Изменить";
            this.buttonUpdPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdPeriod.UseVisualStyleBackColor = true;
            this.buttonUpdPeriod.Click += new System.EventHandler(this.buttonUpdPeriod_Click);
            // 
            // buttonAddPeriod
            // 
            this.buttonAddPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddPeriod.Image = global::ScheduleView.Properties.Resources.Add_20;
            this.buttonAddPeriod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddPeriod.Location = new System.Drawing.Point(501, 21);
            this.buttonAddPeriod.Name = "buttonAddPeriod";
            this.buttonAddPeriod.Size = new System.Drawing.Size(120, 40);
            this.buttonAddPeriod.TabIndex = 10;
            this.buttonAddPeriod.Text = "Добавить";
            this.buttonAddPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAddPeriod.UseVisualStyleBackColor = true;
            this.buttonAddPeriod.Click += new System.EventHandler(this.buttonAddPeriod_Click);
            // 
            // dataGridViewPeriod
            // 
            this.dataGridViewPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPeriod.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPeriod.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewPeriod.Name = "dataGridViewPeriod";
            this.dataGridViewPeriod.RowHeadersVisible = false;
            this.dataGridViewPeriod.RowTemplate.Height = 24;
            this.dataGridViewPeriod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPeriod.Size = new System.Drawing.Size(480, 135);
            this.dataGridViewPeriod.TabIndex = 0;
            this.dataGridViewPeriod.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPeriod_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Дисциплина : ";
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(167, 12);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(225, 24);
            this.comboBoxDiscipline.TabIndex = 1;
            // 
            // comboBoxTypeOfClass
            // 
            this.comboBoxTypeOfClass.FormattingEnabled = true;
            this.comboBoxTypeOfClass.Location = new System.Drawing.Point(166, 42);
            this.comboBoxTypeOfClass.Name = "comboBoxTypeOfClass";
            this.comboBoxTypeOfClass.Size = new System.Drawing.Size(225, 24);
            this.comboBoxTypeOfClass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Тип занятия : ";
            // 
            // comboBoxTeacher
            // 
            this.comboBoxTeacher.FormattingEnabled = true;
            this.comboBoxTeacher.Location = new System.Drawing.Point(167, 72);
            this.comboBoxTeacher.Name = "comboBoxTeacher";
            this.comboBoxTeacher.Size = new System.Drawing.Size(225, 24);
            this.comboBoxTeacher.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Преподаватель : ";
            // 
            // comboBoxFlow
            // 
            this.comboBoxFlow.Enabled = false;
            this.comboBoxFlow.FormattingEnabled = true;
            this.comboBoxFlow.Location = new System.Drawing.Point(166, 102);
            this.comboBoxFlow.Name = "comboBoxFlow";
            this.comboBoxFlow.Size = new System.Drawing.Size(225, 24);
            this.comboBoxFlow.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Поток : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonDelAuditorium);
            this.groupBox2.Controls.Add(this.buttonUpdAuditorium);
            this.groupBox2.Controls.Add(this.buttonAddAuditorium);
            this.groupBox2.Controls.Add(this.dataGridViewAuditorium);
            this.groupBox2.Location = new System.Drawing.Point(439, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 164);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Аудитории";
            // 
            // buttonDelAuditorium
            // 
            this.buttonDelAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelAuditorium.Image = global::ScheduleView.Properties.Resources.Del_20;
            this.buttonDelAuditorium.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelAuditorium.Location = new System.Drawing.Point(501, 113);
            this.buttonDelAuditorium.Name = "buttonDelAuditorium";
            this.buttonDelAuditorium.Size = new System.Drawing.Size(120, 40);
            this.buttonDelAuditorium.TabIndex = 15;
            this.buttonDelAuditorium.Text = "Удалить";
            this.buttonDelAuditorium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDelAuditorium.UseVisualStyleBackColor = true;
            this.buttonDelAuditorium.Click += new System.EventHandler(this.buttonDelAuditorium_Click);
            // 
            // buttonUpdAuditorium
            // 
            this.buttonUpdAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdAuditorium.Image = global::ScheduleView.Properties.Resources.Upd_20;
            this.buttonUpdAuditorium.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdAuditorium.Location = new System.Drawing.Point(501, 67);
            this.buttonUpdAuditorium.Name = "buttonUpdAuditorium";
            this.buttonUpdAuditorium.Size = new System.Drawing.Size(120, 40);
            this.buttonUpdAuditorium.TabIndex = 14;
            this.buttonUpdAuditorium.Text = "Изменить";
            this.buttonUpdAuditorium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonUpdAuditorium.UseVisualStyleBackColor = true;
            this.buttonUpdAuditorium.Click += new System.EventHandler(this.buttonUpdAuditorium_Click);
            // 
            // buttonAddAuditorium
            // 
            this.buttonAddAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddAuditorium.Image = global::ScheduleView.Properties.Resources.Add_20;
            this.buttonAddAuditorium.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddAuditorium.Location = new System.Drawing.Point(501, 21);
            this.buttonAddAuditorium.Name = "buttonAddAuditorium";
            this.buttonAddAuditorium.Size = new System.Drawing.Size(120, 40);
            this.buttonAddAuditorium.TabIndex = 13;
            this.buttonAddAuditorium.Text = "Добавить";
            this.buttonAddAuditorium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAddAuditorium.UseVisualStyleBackColor = true;
            this.buttonAddAuditorium.Click += new System.EventHandler(this.buttonAddAuditorium_Click);
            // 
            // dataGridViewAuditorium
            // 
            this.dataGridViewAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAuditorium.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewAuditorium.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuditorium.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewAuditorium.Name = "dataGridViewAuditorium";
            this.dataGridViewAuditorium.RowHeadersVisible = false;
            this.dataGridViewAuditorium.RowTemplate.Height = 24;
            this.dataGridViewAuditorium.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAuditorium.Size = new System.Drawing.Size(480, 137);
            this.dataGridViewAuditorium.TabIndex = 0;
            this.dataGridViewAuditorium.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAuditorium_CellMouseDoubleClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 48;
            this.label5.Text = "Отчетность : ";
            // 
            // textBoxReporting
            // 
            this.textBoxReporting.Location = new System.Drawing.Point(166, 160);
            this.textBoxReporting.Name = "textBoxReporting";
            this.textBoxReporting.Size = new System.Drawing.Size(225, 22);
            this.textBoxReporting.TabIndex = 8;
            // 
            // comboBoxReportingForms
            // 
            this.comboBoxReportingForms.FormattingEnabled = true;
            this.comboBoxReportingForms.Location = new System.Drawing.Point(166, 189);
            this.comboBoxReportingForms.Name = "comboBoxReportingForms";
            this.comboBoxReportingForms.Size = new System.Drawing.Size(225, 24);
            this.comboBoxReportingForms.TabIndex = 9;
            this.comboBoxReportingForms.SelectionChangeCommitted += new System.EventHandler(this.comboBoxReportingForms_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "Формы отчетности : ";
            // 
            // textBoxNumberOfSubgroups
            // 
            this.textBoxNumberOfSubgroups.Location = new System.Drawing.Point(167, 132);
            this.textBoxNumberOfSubgroups.Name = "textBoxNumberOfSubgroups";
            this.textBoxNumberOfSubgroups.Size = new System.Drawing.Size(225, 22);
            this.textBoxNumberOfSubgroups.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 52;
            this.label7.Text = "№ подгруппы : ";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(702, 353);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 40);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxFlowActive
            // 
            this.checkBoxFlowActive.AutoSize = true;
            this.checkBoxFlowActive.Location = new System.Drawing.Point(142, 105);
            this.checkBoxFlowActive.Name = "checkBoxFlowActive";
            this.checkBoxFlowActive.Size = new System.Drawing.Size(18, 17);
            this.checkBoxFlowActive.TabIndex = 4;
            this.checkBoxFlowActive.UseVisualStyleBackColor = true;
            this.checkBoxFlowActive.CheckedChanged += new System.EventHandler(this.checkBoxFlowActive_CheckedChanged);
            // 
            // buttonAddFlow
            // 
            this.buttonAddFlow.Location = new System.Drawing.Point(397, 102);
            this.buttonAddFlow.Name = "buttonAddFlow";
            this.buttonAddFlow.Size = new System.Drawing.Size(36, 23);
            this.buttonAddFlow.TabIndex = 6;
            this.buttonAddFlow.Text = "...";
            this.buttonAddFlow.UseVisualStyleBackColor = true;
            this.buttonAddFlow.Click += new System.EventHandler(this.buttonAddFlow_Click);
            // 
            // FormLoadTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 400);
            this.Controls.Add(this.buttonAddFlow);
            this.Controls.Add(this.checkBoxFlowActive);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxNumberOfSubgroups);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxReportingForms);
            this.Controls.Add(this.textBoxReporting);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxFlow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxTeacher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTypeOfClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDiscipline);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveandClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoadTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчасовка";
            this.Load += new System.EventHandler(this.FormLoadTeacher_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriod)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditorium)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveandClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelPeriod;
        private System.Windows.Forms.Button buttonUpdPeriod;
        private System.Windows.Forms.Button buttonAddPeriod;
        private System.Windows.Forms.DataGridView dataGridViewPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDiscipline;
        private System.Windows.Forms.ComboBox comboBoxTypeOfClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTeacher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxFlow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDelAuditorium;
        private System.Windows.Forms.Button buttonUpdAuditorium;
        private System.Windows.Forms.Button buttonAddAuditorium;
        private System.Windows.Forms.DataGridView dataGridViewAuditorium;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxReporting;
        private System.Windows.Forms.ComboBox comboBoxReportingForms;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNumberOfSubgroups;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxFlowActive;
        private System.Windows.Forms.Button buttonAddFlow;
    }
}