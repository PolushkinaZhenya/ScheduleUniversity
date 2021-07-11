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
			this.tabControlSettings.SuspendLayout();
			this.tabPageConfig.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).BeginInit();
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
			this.ClientSize = new System.Drawing.Size(677, 384);
			this.Controls.Add(this.tabControlSettings);
			this.Name = "FormSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Настройки системы";
			this.Load += new System.EventHandler(this.FormSettings_Load);
			this.tabControlSettings.ResumeLayout(false);
			this.tabPageConfig.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.TabControl tabControlSettings;
		private System.Windows.Forms.TabPage tabPageConfig;
		private System.Windows.Forms.TabPage tabPageColors;
		private System.Windows.Forms.DataGridView dataGridViewPeriods;
		private System.Windows.Forms.Button buttonSelectPeriod;
	}
}