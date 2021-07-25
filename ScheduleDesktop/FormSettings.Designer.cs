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
			this.tabControlSettings = new System.Windows.Forms.TabControl();
			this.tabPageConfig = new System.Windows.Forms.TabPage();
			this.buttonSelectPeriod = new System.Windows.Forms.Button();
			this.dataGridViewPeriods = new System.Windows.Forms.DataGridView();
			this.tabPageColors = new System.Windows.Forms.TabPage();
			this.groupBoxSetLessons = new System.Windows.Forms.GroupBox();
			this.buttonFlowBisy = new System.Windows.Forms.Button();
			this.labelFlowBisy = new System.Windows.Forms.Label();
			this.buttonAuditoriumBisy = new System.Windows.Forms.Button();
			this.labelAuditoriumBisy = new System.Windows.Forms.Label();
			this.buttonTeacherBisy = new System.Windows.Forms.Button();
			this.labelTeacherBisy = new System.Windows.Forms.Label();
			this.buttonGroupBisy = new System.Windows.Forms.Button();
			this.labelGroupBisy = new System.Windows.Forms.Label();
			this.buttonAllow = new System.Windows.Forms.Button();
			this.labelAllow = new System.Windows.Forms.Label();
			this.tabControlSettings.SuspendLayout();
			this.tabPageConfig.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).BeginInit();
			this.tabPageColors.SuspendLayout();
			this.groupBoxSetLessons.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlSettings
			// 
			this.tabControlSettings.Controls.Add(this.tabPageConfig);
			this.tabControlSettings.Controls.Add(this.tabPageColors);
			this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
			this.tabControlSettings.Name = "tabControlSettings";
			this.tabControlSettings.SelectedIndex = 0;
			this.tabControlSettings.Size = new System.Drawing.Size(677, 384);
			this.tabControlSettings.TabIndex = 0;
			// 
			// tabPageConfig
			// 
			this.tabPageConfig.Controls.Add(this.buttonSelectPeriod);
			this.tabPageConfig.Controls.Add(this.dataGridViewPeriods);
			this.tabPageConfig.Location = new System.Drawing.Point(4, 24);
			this.tabPageConfig.Name = "tabPageConfig";
			this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageConfig.Size = new System.Drawing.Size(669, 356);
			this.tabPageConfig.TabIndex = 0;
			this.tabPageConfig.Text = "Настройки учебного года";
			this.tabPageConfig.UseVisualStyleBackColor = true;
			// 
			// buttonSelectPeriod
			// 
			this.buttonSelectPeriod.Location = new System.Drawing.Point(588, 10);
			this.buttonSelectPeriod.Name = "buttonSelectPeriod";
			this.buttonSelectPeriod.Size = new System.Drawing.Size(75, 53);
			this.buttonSelectPeriod.TabIndex = 1;
			this.buttonSelectPeriod.Text = "Выбрать";
			this.buttonSelectPeriod.UseVisualStyleBackColor = true;
			this.buttonSelectPeriod.Click += new System.EventHandler(this.ButtonSelectPeriod_Click);
			// 
			// dataGridViewPeriods
			// 
			this.dataGridViewPeriods.AllowUserToAddRows = false;
			this.dataGridViewPeriods.AllowUserToDeleteRows = false;
			this.dataGridViewPeriods.AllowUserToResizeColumns = false;
			this.dataGridViewPeriods.AllowUserToResizeRows = false;
			this.dataGridViewPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewPeriods.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPeriods.Location = new System.Drawing.Point(8, 10);
			this.dataGridViewPeriods.MultiSelect = false;
			this.dataGridViewPeriods.Name = "dataGridViewPeriods";
			this.dataGridViewPeriods.RowHeadersVisible = false;
			this.dataGridViewPeriods.RowTemplate.Height = 25;
			this.dataGridViewPeriods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewPeriods.Size = new System.Drawing.Size(571, 340);
			this.dataGridViewPeriods.TabIndex = 0;
			// 
			// tabPageColors
			// 
			this.tabPageColors.Controls.Add(this.groupBoxSetLessons);
			this.tabPageColors.Location = new System.Drawing.Point(4, 24);
			this.tabPageColors.Name = "tabPageColors";
			this.tabPageColors.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageColors.Size = new System.Drawing.Size(669, 356);
			this.tabPageColors.TabIndex = 1;
			this.tabPageColors.Text = "Цвета";
			this.tabPageColors.UseVisualStyleBackColor = true;
			// 
			// groupBoxSetLessons
			// 
			this.groupBoxSetLessons.Controls.Add(this.buttonFlowBisy);
			this.groupBoxSetLessons.Controls.Add(this.labelFlowBisy);
			this.groupBoxSetLessons.Controls.Add(this.buttonAuditoriumBisy);
			this.groupBoxSetLessons.Controls.Add(this.labelAuditoriumBisy);
			this.groupBoxSetLessons.Controls.Add(this.buttonTeacherBisy);
			this.groupBoxSetLessons.Controls.Add(this.labelTeacherBisy);
			this.groupBoxSetLessons.Controls.Add(this.buttonGroupBisy);
			this.groupBoxSetLessons.Controls.Add(this.labelGroupBisy);
			this.groupBoxSetLessons.Controls.Add(this.buttonAllow);
			this.groupBoxSetLessons.Controls.Add(this.labelAllow);
			this.groupBoxSetLessons.Location = new System.Drawing.Point(8, 6);
			this.groupBoxSetLessons.Name = "groupBoxSetLessons";
			this.groupBoxSetLessons.Size = new System.Drawing.Size(253, 178);
			this.groupBoxSetLessons.TabIndex = 0;
			this.groupBoxSetLessons.TabStop = false;
			this.groupBoxSetLessons.Text = "При расстановке пар";
			// 
			// buttonFlowBisy
			// 
			this.buttonFlowBisy.Location = new System.Drawing.Point(151, 141);
			this.buttonFlowBisy.Name = "buttonFlowBisy";
			this.buttonFlowBisy.Size = new System.Drawing.Size(75, 23);
			this.buttonFlowBisy.TabIndex = 9;
			this.buttonFlowBisy.UseVisualStyleBackColor = true;
			this.buttonFlowBisy.Click += new System.EventHandler(this.ButtonColorSelect_Click);
			// 
			// labelFlowBisy
			// 
			this.labelFlowBisy.AutoSize = true;
			this.labelFlowBisy.Location = new System.Drawing.Point(19, 145);
			this.labelFlowBisy.Name = "labelFlowBisy";
			this.labelFlowBisy.Size = new System.Drawing.Size(110, 15);
			this.labelFlowBisy.TabIndex = 8;
			this.labelFlowBisy.Text = "Поточное занятие:";
			// 
			// buttonAuditoriumBisy
			// 
			this.buttonAuditoriumBisy.Location = new System.Drawing.Point(151, 112);
			this.buttonAuditoriumBisy.Name = "buttonAuditoriumBisy";
			this.buttonAuditoriumBisy.Size = new System.Drawing.Size(75, 23);
			this.buttonAuditoriumBisy.TabIndex = 7;
			this.buttonAuditoriumBisy.UseVisualStyleBackColor = true;
			this.buttonAuditoriumBisy.Click += new System.EventHandler(this.ButtonColorSelect_Click);
			// 
			// labelAuditoriumBisy
			// 
			this.labelAuditoriumBisy.AutoSize = true;
			this.labelAuditoriumBisy.Location = new System.Drawing.Point(19, 116);
			this.labelAuditoriumBisy.Name = "labelAuditoriumBisy";
			this.labelAuditoriumBisy.Size = new System.Drawing.Size(107, 15);
			this.labelAuditoriumBisy.TabIndex = 6;
			this.labelAuditoriumBisy.Text = "Аудитория занята:";
			// 
			// buttonTeacherBisy
			// 
			this.buttonTeacherBisy.Location = new System.Drawing.Point(151, 83);
			this.buttonTeacherBisy.Name = "buttonTeacherBisy";
			this.buttonTeacherBisy.Size = new System.Drawing.Size(75, 23);
			this.buttonTeacherBisy.TabIndex = 5;
			this.buttonTeacherBisy.UseVisualStyleBackColor = true;
			this.buttonTeacherBisy.Click += new System.EventHandler(this.ButtonColorSelect_Click);
			// 
			// labelTeacherBisy
			// 
			this.labelTeacherBisy.AutoSize = true;
			this.labelTeacherBisy.Location = new System.Drawing.Point(19, 87);
			this.labelTeacherBisy.Name = "labelTeacherBisy";
			this.labelTeacherBisy.Size = new System.Drawing.Size(126, 15);
			this.labelTeacherBisy.TabIndex = 4;
			this.labelTeacherBisy.Text = "Преподаватель занят:";
			// 
			// buttonGroupBisy
			// 
			this.buttonGroupBisy.Location = new System.Drawing.Point(151, 54);
			this.buttonGroupBisy.Name = "buttonGroupBisy";
			this.buttonGroupBisy.Size = new System.Drawing.Size(75, 23);
			this.buttonGroupBisy.TabIndex = 3;
			this.buttonGroupBisy.UseVisualStyleBackColor = true;
			this.buttonGroupBisy.Click += new System.EventHandler(this.ButtonColorSelect_Click);
			// 
			// labelGroupBisy
			// 
			this.labelGroupBisy.AutoSize = true;
			this.labelGroupBisy.Location = new System.Drawing.Point(19, 58);
			this.labelGroupBisy.Name = "labelGroupBisy";
			this.labelGroupBisy.Size = new System.Drawing.Size(87, 15);
			this.labelGroupBisy.TabIndex = 2;
			this.labelGroupBisy.Text = "Группа занята:";
			// 
			// buttonAllow
			// 
			this.buttonAllow.Location = new System.Drawing.Point(151, 25);
			this.buttonAllow.Name = "buttonAllow";
			this.buttonAllow.Size = new System.Drawing.Size(75, 23);
			this.buttonAllow.TabIndex = 1;
			this.buttonAllow.UseVisualStyleBackColor = true;
			this.buttonAllow.Click += new System.EventHandler(this.ButtonColorSelect_Click);
			// 
			// labelAllow
			// 
			this.labelAllow.AutoSize = true;
			this.labelAllow.Location = new System.Drawing.Point(19, 29);
			this.labelAllow.Name = "labelAllow";
			this.labelAllow.Size = new System.Drawing.Size(99, 15);
			this.labelAllow.TabIndex = 0;
			this.labelAllow.Text = "Свободная пара:";
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 384);
			this.Controls.Add(this.tabControlSettings);
			this.Name = "FormSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Настройки системы";
			this.Load += new System.EventHandler(this.FormSettings_Load);
			this.tabControlSettings.ResumeLayout(false);
			this.tabPageConfig.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).EndInit();
			this.tabPageColors.ResumeLayout(false);
			this.groupBoxSetLessons.ResumeLayout(false);
			this.groupBoxSetLessons.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.TabControl tabControlSettings;
		private System.Windows.Forms.TabPage tabPageConfig;
		private System.Windows.Forms.TabPage tabPageColors;
		private System.Windows.Forms.DataGridView dataGridViewPeriods;
		private System.Windows.Forms.Button buttonSelectPeriod;
		private System.Windows.Forms.GroupBox groupBoxSetLessons;
		private System.Windows.Forms.Label labelAllow;
		private System.Windows.Forms.Button buttonAllow;
		private System.Windows.Forms.Button buttonGroupBisy;
		private System.Windows.Forms.Label labelGroupBisy;
		private System.Windows.Forms.Button buttonFlowBisy;
		private System.Windows.Forms.Label labelFlowBisy;
		private System.Windows.Forms.Button buttonAuditoriumBisy;
		private System.Windows.Forms.Label labelAuditoriumBisy;
		private System.Windows.Forms.Button buttonTeacherBisy;
		private System.Windows.Forms.Label labelTeacherBisy;
	}
}