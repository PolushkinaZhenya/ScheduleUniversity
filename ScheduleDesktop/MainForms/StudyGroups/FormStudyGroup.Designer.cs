namespace ScheduleDesktop
{
    partial class FormStudyGroup
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
			this.textBoxCourse = new System.Windows.Forms.TextBox();
			this.labelCourse = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxNumderStudents = new System.Windows.Forms.TextBox();
			this.labelNumderStudents = new System.Windows.Forms.Label();
			this.textBoxNumderSubgroups = new System.Windows.Forms.TextBox();
			this.labelNumderSubgroups = new System.Windows.Forms.Label();
			this.comboBoxSpecialty = new System.Windows.Forms.ComboBox();
			this.labelSpecialty = new System.Windows.Forms.Label();
			this.labelTypeEducation = new System.Windows.Forms.Label();
			this.comboBoxTypeEducation = new System.Windows.Forms.ComboBox();
			this.labelFormEducation = new System.Windows.Forms.Label();
			this.comboBoxFormEducation = new System.Windows.Forms.ComboBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.textBoxlGroupNumber = new System.Windows.Forms.TextBox();
			this.labelGroupNumber = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxCourse
			// 
			this.textBoxCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCourse.Location = new System.Drawing.Point(146, 186);
			this.textBoxCourse.Name = "textBoxCourse";
			this.textBoxCourse.Size = new System.Drawing.Size(194, 23);
			this.textBoxCourse.TabIndex = 8;
			this.textBoxCourse.TextChanged += new System.EventHandler(this.TextBoxCourse_TextChanged);
			// 
			// labelCourse
			// 
			this.labelCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCourse.AutoSize = true;
			this.labelCourse.Location = new System.Drawing.Point(12, 188);
			this.labelCourse.Name = "labelCourse";
			this.labelCourse.Size = new System.Drawing.Size(42, 15);
			this.labelCourse.TabIndex = 8;
			this.labelCourse.Text = "Курс : ";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTitle.Location = new System.Drawing.Point(146, 72);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(194, 23);
			this.textBoxTitle.TabIndex = 1;
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(12, 75);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(68, 15);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Название : ";
			// 
			// textBoxNumderStudents
			// 
			this.textBoxNumderStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumderStudents.Location = new System.Drawing.Point(146, 244);
			this.textBoxNumderStudents.Name = "textBoxNumderStudents";
			this.textBoxNumderStudents.Size = new System.Drawing.Size(194, 23);
			this.textBoxNumderStudents.TabIndex = 12;
			// 
			// labelNumderStudents
			// 
			this.labelNumderStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumderStudents.AutoSize = true;
			this.labelNumderStudents.Location = new System.Drawing.Point(12, 247);
			this.labelNumderStudents.Name = "labelNumderStudents";
			this.labelNumderStudents.Size = new System.Drawing.Size(112, 15);
			this.labelNumderStudents.TabIndex = 11;
			this.labelNumderStudents.Text = "Кол-во студентов : ";
			// 
			// textBoxNumderSubgroups
			// 
			this.textBoxNumderSubgroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumderSubgroups.Location = new System.Drawing.Point(146, 273);
			this.textBoxNumderSubgroups.Name = "textBoxNumderSubgroups";
			this.textBoxNumderSubgroups.Size = new System.Drawing.Size(194, 23);
			this.textBoxNumderSubgroups.TabIndex = 14;
			// 
			// labelNumderSubgroups
			// 
			this.labelNumderSubgroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumderSubgroups.AutoSize = true;
			this.labelNumderSubgroups.Location = new System.Drawing.Point(12, 276);
			this.labelNumderSubgroups.Name = "labelNumderSubgroups";
			this.labelNumderSubgroups.Size = new System.Drawing.Size(110, 15);
			this.labelNumderSubgroups.TabIndex = 13;
			this.labelNumderSubgroups.Text = "Кол-во подгрупп : ";
			// 
			// comboBoxSpecialty
			// 
			this.comboBoxSpecialty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSpecialty.FormattingEnabled = true;
			this.comboBoxSpecialty.Location = new System.Drawing.Point(146, 101);
			this.comboBoxSpecialty.Name = "comboBoxSpecialty";
			this.comboBoxSpecialty.Size = new System.Drawing.Size(194, 23);
			this.comboBoxSpecialty.TabIndex = 3;
			this.comboBoxSpecialty.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSpecialty_SelectedIndexChanged);
			// 
			// labelSpecialty
			// 
			this.labelSpecialty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSpecialty.AutoSize = true;
			this.labelSpecialty.Location = new System.Drawing.Point(12, 104);
			this.labelSpecialty.Name = "labelSpecialty";
			this.labelSpecialty.Size = new System.Drawing.Size(101, 15);
			this.labelSpecialty.TabIndex = 2;
			this.labelSpecialty.Text = "Специальность : ";
			// 
			// labelTypeEducation
			// 
			this.labelTypeEducation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTypeEducation.AutoSize = true;
			this.labelTypeEducation.Location = new System.Drawing.Point(12, 132);
			this.labelTypeEducation.Name = "labelTypeEducation";
			this.labelTypeEducation.Size = new System.Drawing.Size(92, 15);
			this.labelTypeEducation.TabIndex = 4;
			this.labelTypeEducation.Text = "Тип обучения : ";
			// 
			// comboBoxTypeEducation
			// 
			this.comboBoxTypeEducation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTypeEducation.FormattingEnabled = true;
			this.comboBoxTypeEducation.Location = new System.Drawing.Point(146, 129);
			this.comboBoxTypeEducation.Name = "comboBoxTypeEducation";
			this.comboBoxTypeEducation.Size = new System.Drawing.Size(194, 23);
			this.comboBoxTypeEducation.TabIndex = 5;
			this.comboBoxTypeEducation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTypeEducation_SelectedIndexChanged);
			// 
			// labelFormEducation
			// 
			this.labelFormEducation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFormEducation.AutoSize = true;
			this.labelFormEducation.Location = new System.Drawing.Point(12, 160);
			this.labelFormEducation.Name = "labelFormEducation";
			this.labelFormEducation.Size = new System.Drawing.Size(110, 15);
			this.labelFormEducation.TabIndex = 6;
			this.labelFormEducation.Text = "Форма обучения : ";
			// 
			// comboBoxFormEducation
			// 
			this.comboBoxFormEducation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxFormEducation.FormattingEnabled = true;
			this.comboBoxFormEducation.Location = new System.Drawing.Point(146, 157);
			this.comboBoxFormEducation.Name = "comboBoxFormEducation";
			this.comboBoxFormEducation.Size = new System.Drawing.Size(194, 23);
			this.comboBoxFormEducation.TabIndex = 7;
			this.comboBoxFormEducation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFormEducation_SelectedIndexChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(142, 12);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 40);
			this.buttonCancel.TabIndex = 21;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(30, 12);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(80, 40);
			this.buttonSave.TabIndex = 20;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(249, 14);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(80, 40);
			this.buttonDel.TabIndex = 22;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Visible = false;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// textBoxlGroupNumber
			// 
			this.textBoxlGroupNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxlGroupNumber.Location = new System.Drawing.Point(146, 215);
			this.textBoxlGroupNumber.Name = "textBoxlGroupNumber";
			this.textBoxlGroupNumber.Size = new System.Drawing.Size(194, 23);
			this.textBoxlGroupNumber.TabIndex = 10;
			this.textBoxlGroupNumber.TextChanged += new System.EventHandler(this.TextBoxlGroupNumber_TextChanged);
			// 
			// labelGroupNumber
			// 
			this.labelGroupNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGroupNumber.AutoSize = true;
			this.labelGroupNumber.Location = new System.Drawing.Point(12, 217);
			this.labelGroupNumber.Name = "labelGroupNumber";
			this.labelGroupNumber.Size = new System.Drawing.Size(98, 15);
			this.labelGroupNumber.TabIndex = 9;
			this.labelGroupNumber.Text = "Номер группы : ";
			// 
			// FormStudyGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 310);
			this.Controls.Add(this.textBoxlGroupNumber);
			this.Controls.Add(this.labelGroupNumber);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelFormEducation);
			this.Controls.Add(this.comboBoxFormEducation);
			this.Controls.Add(this.labelTypeEducation);
			this.Controls.Add(this.comboBoxTypeEducation);
			this.Controls.Add(this.labelSpecialty);
			this.Controls.Add(this.comboBoxSpecialty);
			this.Controls.Add(this.textBoxNumderSubgroups);
			this.Controls.Add(this.labelNumderSubgroups);
			this.Controls.Add(this.textBoxNumderStudents);
			this.Controls.Add(this.labelNumderStudents);
			this.Controls.Add(this.textBoxCourse);
			this.Controls.Add(this.labelCourse);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.labelTitle);
			this.Name = "FormStudyGroup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Учебная группа";
			this.Load += new System.EventHandler(this.FormStudyGroup_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCourse;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxNumderStudents;
        private System.Windows.Forms.Label labelNumderStudents;
        private System.Windows.Forms.TextBox textBoxNumderSubgroups;
        private System.Windows.Forms.Label labelNumderSubgroups;
        private System.Windows.Forms.ComboBox comboBoxSpecialty;
        private System.Windows.Forms.Label labelSpecialty;
        private System.Windows.Forms.Label labelTypeEducation;
        private System.Windows.Forms.ComboBox comboBoxTypeEducation;
        private System.Windows.Forms.Label labelFormEducation;
        private System.Windows.Forms.ComboBox comboBoxFormEducation;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.TextBox textBoxlGroupNumber;
		private System.Windows.Forms.Label labelGroupNumber;
	}
}