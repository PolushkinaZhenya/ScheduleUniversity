namespace ScheduleDesktop
{
    partial class FormTeacher
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
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.labelPatronymic = new System.Windows.Forms.Label();
			this.textBoxSurname = new System.Windows.Forms.TextBox();
			this.labelSurname = new System.Windows.Forms.Label();
			this.textBoxPatronymic = new System.Windows.Forms.TextBox();
			this.groupBoxDepartments = new System.Windows.Forms.GroupBox();
			this.checkedListBoxDepartments = new System.Windows.Forms.CheckedListBox();
			this.textBoxSearchDepartment = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxShortName = new System.Windows.Forms.TextBox();
			this.labelShortName = new System.Windows.Forms.Label();
			this.groupBoxDepartments.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(152, 128);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(232, 23);
			this.textBoxName.TabIndex = 5;
			this.textBoxName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// labelName
			// 
			this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(54, 130);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(40, 15);
			this.labelName.TabIndex = 4;
			this.labelName.Text = "Имя : ";
			// 
			// labelPatronymic
			// 
			this.labelPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPatronymic.AutoSize = true;
			this.labelPatronymic.Location = new System.Drawing.Point(54, 157);
			this.labelPatronymic.Name = "labelPatronymic";
			this.labelPatronymic.Size = new System.Drawing.Size(67, 15);
			this.labelPatronymic.TabIndex = 6;
			this.labelPatronymic.Text = "Отчество : ";
			// 
			// textBoxSurname
			// 
			this.textBoxSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSurname.Location = new System.Drawing.Point(152, 101);
			this.textBoxSurname.Name = "textBoxSurname";
			this.textBoxSurname.Size = new System.Drawing.Size(232, 23);
			this.textBoxSurname.TabIndex = 3;
			this.textBoxSurname.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// labelSurname
			// 
			this.labelSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSurname.AutoSize = true;
			this.labelSurname.Location = new System.Drawing.Point(54, 104);
			this.labelSurname.Name = "labelSurname";
			this.labelSurname.Size = new System.Drawing.Size(67, 15);
			this.labelSurname.TabIndex = 2;
			this.labelSurname.Text = "Фамилия : ";
			// 
			// textBoxPatronymic
			// 
			this.textBoxPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPatronymic.Location = new System.Drawing.Point(152, 154);
			this.textBoxPatronymic.Name = "textBoxPatronymic";
			this.textBoxPatronymic.Size = new System.Drawing.Size(232, 23);
			this.textBoxPatronymic.TabIndex = 7;
			this.textBoxPatronymic.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// groupBoxDepartments
			// 
			this.groupBoxDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxDepartments.Controls.Add(this.checkedListBoxDepartments);
			this.groupBoxDepartments.Controls.Add(this.textBoxSearchDepartment);
			this.groupBoxDepartments.Location = new System.Drawing.Point(12, 197);
			this.groupBoxDepartments.Name = "groupBoxDepartments";
			this.groupBoxDepartments.Size = new System.Drawing.Size(423, 232);
			this.groupBoxDepartments.TabIndex = 8;
			this.groupBoxDepartments.TabStop = false;
			this.groupBoxDepartments.Text = "Кафедры";
			// 
			// checkedListBoxDepartments
			// 
			this.checkedListBoxDepartments.FormattingEnabled = true;
			this.checkedListBoxDepartments.Location = new System.Drawing.Point(9, 51);
			this.checkedListBoxDepartments.Name = "checkedListBoxDepartments";
			this.checkedListBoxDepartments.Size = new System.Drawing.Size(394, 202);
			this.checkedListBoxDepartments.TabIndex = 1;
			this.checkedListBoxDepartments.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxDepartments_ItemCheck);
			// 
			// textBoxSearchDepartment
			// 
			this.textBoxSearchDepartment.Location = new System.Drawing.Point(9, 22);
			this.textBoxSearchDepartment.Name = "textBoxSearchDepartment";
			this.textBoxSearchDepartment.Size = new System.Drawing.Size(394, 23);
			this.textBoxSearchDepartment.TabIndex = 0;
			this.textBoxSearchDepartment.TextChanged += new System.EventHandler(this.TextBoxSearchDepartment_TextChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(355, 12);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 40);
			this.buttonCancel.TabIndex = 21;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(12, 12);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(80, 40);
			this.buttonSave.TabIndex = 20;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// textBoxShortName
			// 
			this.textBoxShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxShortName.Location = new System.Drawing.Point(152, 72);
			this.textBoxShortName.Name = "textBoxShortName";
			this.textBoxShortName.Size = new System.Drawing.Size(232, 23);
			this.textBoxShortName.TabIndex = 1;
			// 
			// labelShortName
			// 
			this.labelShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelShortName.AutoSize = true;
			this.labelShortName.Location = new System.Drawing.Point(54, 75);
			this.labelShortName.Name = "labelShortName";
			this.labelShortName.Size = new System.Drawing.Size(85, 15);
			this.labelShortName.TabIndex = 0;
			this.labelShortName.Text = "Краткое имя : ";
			// 
			// FormTeacher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(445, 441);
			this.Controls.Add(this.textBoxShortName);
			this.Controls.Add(this.labelShortName);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBoxDepartments);
			this.Controls.Add(this.textBoxPatronymic);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelPatronymic);
			this.Controls.Add(this.textBoxSurname);
			this.Controls.Add(this.labelSurname);
			this.Name = "FormTeacher";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Преподаватель";
			this.Load += new System.EventHandler(this.FormTeacher_Load);
			this.groupBoxDepartments.ResumeLayout(false);
			this.groupBoxDepartments.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.GroupBox groupBoxDepartments;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.CheckedListBox checkedListBoxDepartments;
		private System.Windows.Forms.TextBox textBoxSearchDepartment;
		private System.Windows.Forms.TextBox textBoxShortName;
		private System.Windows.Forms.Label labelShortName;
	}
}