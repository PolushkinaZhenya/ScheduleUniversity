namespace ScheduleDesktop
{
    partial class FormSettings
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
			this.label5 = new System.Windows.Forms.Label();
			this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxSemester = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxAcademicYear = new System.Windows.Forms.ComboBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxDayOfTheWeek = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControlSettings = new System.Windows.Forms.TabControl();
			this.tabPageConfig = new System.Windows.Forms.TabPage();
			this.tabPageColors = new System.Windows.Forms.TabPage();
			this.tabControlSettings.SuspendLayout();
			this.tabPageConfig.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 15);
			this.label5.TabIndex = 29;
			this.label5.Text = "Текущий период : ";
			// 
			// comboBoxPeriod
			// 
			this.comboBoxPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxPeriod.FormattingEnabled = true;
			this.comboBoxPeriod.Location = new System.Drawing.Point(166, 71);
			this.comboBoxPeriod.Name = "comboBoxPeriod";
			this.comboBoxPeriod.Size = new System.Drawing.Size(497, 23);
			this.comboBoxPeriod.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 15);
			this.label4.TabIndex = 27;
			this.label4.Text = "Текущий семестр : ";
			// 
			// comboBoxSemester
			// 
			this.comboBoxSemester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSemester.FormattingEnabled = true;
			this.comboBoxSemester.Location = new System.Drawing.Point(166, 42);
			this.comboBoxSemester.Name = "comboBoxSemester";
			this.comboBoxSemester.Size = new System.Drawing.Size(497, 23);
			this.comboBoxSemester.TabIndex = 2;
			this.comboBoxSemester.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSemester_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 15);
			this.label2.TabIndex = 25;
			this.label2.Text = "Текущий учебный год : ";
			// 
			// comboBoxAcademicYear
			// 
			this.comboBoxAcademicYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxAcademicYear.FormattingEnabled = true;
			this.comboBoxAcademicYear.Location = new System.Drawing.Point(166, 14);
			this.comboBoxAcademicYear.Name = "comboBoxAcademicYear";
			this.comboBoxAcademicYear.Size = new System.Drawing.Size(497, 23);
			this.comboBoxAcademicYear.TabIndex = 1;
			this.comboBoxAcademicYear.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAcademicYear_SelectionChangeCommitted);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(588, 197);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(79, 38);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(504, 197);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(79, 38);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBoxDayOfTheWeek
			// 
			this.textBoxDayOfTheWeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDayOfTheWeek.Location = new System.Drawing.Point(166, 100);
			this.textBoxDayOfTheWeek.Name = "textBoxDayOfTheWeek";
			this.textBoxDayOfTheWeek.Size = new System.Drawing.Size(497, 23);
			this.textBoxDayOfTheWeek.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 15);
			this.label1.TabIndex = 31;
			this.label1.Text = "Кол-во учебных дней : ";
			// 
			// tabControlSettings
			// 
			this.tabControlSettings.Controls.Add(this.tabPageConfig);
			this.tabControlSettings.Controls.Add(this.tabPageColors);
			this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
			this.tabControlSettings.Name = "tabControlSettings";
			this.tabControlSettings.SelectedIndex = 0;
			this.tabControlSettings.Size = new System.Drawing.Size(677, 184);
			this.tabControlSettings.TabIndex = 0;
			// 
			// tabPageConfig
			// 
			this.tabPageConfig.Controls.Add(this.label2);
			this.tabPageConfig.Controls.Add(this.label1);
			this.tabPageConfig.Controls.Add(this.comboBoxAcademicYear);
			this.tabPageConfig.Controls.Add(this.textBoxDayOfTheWeek);
			this.tabPageConfig.Controls.Add(this.comboBoxSemester);
			this.tabPageConfig.Controls.Add(this.label5);
			this.tabPageConfig.Controls.Add(this.label4);
			this.tabPageConfig.Controls.Add(this.comboBoxPeriod);
			this.tabPageConfig.Location = new System.Drawing.Point(4, 24);
			this.tabPageConfig.Name = "tabPageConfig";
			this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageConfig.Size = new System.Drawing.Size(669, 156);
			this.tabPageConfig.TabIndex = 0;
			this.tabPageConfig.Text = "Настройки";
			this.tabPageConfig.UseVisualStyleBackColor = true;
			// 
			// tabPageColors
			// 
			this.tabPageColors.Location = new System.Drawing.Point(4, 24);
			this.tabPageColors.Name = "tabPageColors";
			this.tabPageColors.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageColors.Size = new System.Drawing.Size(669, 156);
			this.tabPageColors.TabIndex = 1;
			this.tabPageColors.Text = "Цвета";
			this.tabPageColors.UseVisualStyleBackColor = true;
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 246);
			this.Controls.Add(this.tabControlSettings);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Name = "FormSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Настройки";
			this.Load += new System.EventHandler(this.FormSettings_Load);
			this.tabControlSettings.ResumeLayout(false);
			this.tabPageConfig.ResumeLayout(false);
			this.tabPageConfig.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSemester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAcademicYear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxDayOfTheWeek;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControlSettings;
		private System.Windows.Forms.TabPage tabPageConfig;
		private System.Windows.Forms.TabPage tabPageColors;
	}
}