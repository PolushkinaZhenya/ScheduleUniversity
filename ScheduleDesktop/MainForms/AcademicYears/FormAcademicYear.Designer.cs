
namespace ScheduleDesktop
{
	partial class FormAcademicYear
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.dataGridViewSemesters = new System.Windows.Forms.DataGridView();
			this.buttonCreateSemesters = new System.Windows.Forms.Button();
			this.groupBoxPeriods = new System.Windows.Forms.GroupBox();
			this.buttonCreatePeriods = new System.Windows.Forms.Button();
			this.dataGridViewPeriods = new System.Windows.Forms.DataGridView();
			this.numericUpDownPeriodLength = new System.Windows.Forms.NumericUpDown();
			this.labelInterval = new System.Windows.Forms.Label();
			this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
			this.labelStartDate = new System.Windows.Forms.Label();
			this.numericUpDownPeriodsCount = new System.Windows.Forms.NumericUpDown();
			this.labelPeriodsCount = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSemesters)).BeginInit();
			this.groupBoxPeriods.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriodLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriodsCount)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(12, 9);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(62, 15);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Название:";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(80, 6);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(246, 23);
			this.textBoxTitle.TabIndex = 1;
			// 
			// dataGridViewSemesters
			// 
			this.dataGridViewSemesters.AllowUserToAddRows = false;
			this.dataGridViewSemesters.AllowUserToDeleteRows = false;
			this.dataGridViewSemesters.AllowUserToResizeColumns = false;
			this.dataGridViewSemesters.AllowUserToResizeRows = false;
			this.dataGridViewSemesters.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewSemesters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSemesters.Location = new System.Drawing.Point(12, 87);
			this.dataGridViewSemesters.Name = "dataGridViewSemesters";
			this.dataGridViewSemesters.RowHeadersVisible = false;
			this.dataGridViewSemesters.RowTemplate.Height = 25;
			this.dataGridViewSemesters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewSemesters.Size = new System.Drawing.Size(331, 111);
			this.dataGridViewSemesters.TabIndex = 2;
			this.dataGridViewSemesters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewSemesters_KeyDown);
			// 
			// buttonCreateSemesters
			// 
			this.buttonCreateSemesters.Location = new System.Drawing.Point(48, 40);
			this.buttonCreateSemesters.Name = "buttonCreateSemesters";
			this.buttonCreateSemesters.Size = new System.Drawing.Size(250, 35);
			this.buttonCreateSemesters.TabIndex = 3;
			this.buttonCreateSemesters.Text = "Сформировать семестры";
			this.buttonCreateSemesters.UseVisualStyleBackColor = true;
			this.buttonCreateSemesters.Click += new System.EventHandler(this.ButtonCreateSemesters_Click);
			// 
			// groupBoxPeriods
			// 
			this.groupBoxPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxPeriods.Controls.Add(this.buttonCreatePeriods);
			this.groupBoxPeriods.Controls.Add(this.dataGridViewPeriods);
			this.groupBoxPeriods.Controls.Add(this.numericUpDownPeriodLength);
			this.groupBoxPeriods.Controls.Add(this.labelInterval);
			this.groupBoxPeriods.Controls.Add(this.dateTimePickerStartDate);
			this.groupBoxPeriods.Controls.Add(this.labelStartDate);
			this.groupBoxPeriods.Controls.Add(this.numericUpDownPeriodsCount);
			this.groupBoxPeriods.Controls.Add(this.labelPeriodsCount);
			this.groupBoxPeriods.Location = new System.Drawing.Point(365, 6);
			this.groupBoxPeriods.Name = "groupBoxPeriods";
			this.groupBoxPeriods.Size = new System.Drawing.Size(461, 284);
			this.groupBoxPeriods.TabIndex = 4;
			this.groupBoxPeriods.TabStop = false;
			this.groupBoxPeriods.Text = "Периоды";
			// 
			// buttonCreatePeriods
			// 
			this.buttonCreatePeriods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreatePeriods.Location = new System.Drawing.Point(345, 89);
			this.buttonCreatePeriods.Name = "buttonCreatePeriods";
			this.buttonCreatePeriods.Size = new System.Drawing.Size(110, 30);
			this.buttonCreatePeriods.TabIndex = 6;
			this.buttonCreatePeriods.Text = "Сформировать";
			this.buttonCreatePeriods.UseVisualStyleBackColor = true;
			this.buttonCreatePeriods.Click += new System.EventHandler(this.ButtonCreatePeriods_Click);
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
			this.dataGridViewPeriods.Location = new System.Drawing.Point(6, 139);
			this.dataGridViewPeriods.Name = "dataGridViewPeriods";
			this.dataGridViewPeriods.RowHeadersVisible = false;
			this.dataGridViewPeriods.RowTemplate.Height = 25;
			this.dataGridViewPeriods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewPeriods.Size = new System.Drawing.Size(449, 139);
			this.dataGridViewPeriods.TabIndex = 7;
			this.dataGridViewPeriods.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewPeriods_KeyDown);
			// 
			// numericUpDownPeriodLength
			// 
			this.numericUpDownPeriodLength.Location = new System.Drawing.Point(155, 96);
			this.numericUpDownPeriodLength.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.numericUpDownPeriodLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPeriodLength.Name = "numericUpDownPeriodLength";
			this.numericUpDownPeriodLength.Size = new System.Drawing.Size(40, 23);
			this.numericUpDownPeriodLength.TabIndex = 5;
			this.numericUpDownPeriodLength.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// labelInterval
			// 
			this.labelInterval.AutoSize = true;
			this.labelInterval.Location = new System.Drawing.Point(21, 98);
			this.labelInterval.Name = "labelInterval";
			this.labelInterval.Size = new System.Drawing.Size(121, 15);
			this.labelInterval.TabIndex = 4;
			this.labelInterval.Text = "Продолжительность";
			// 
			// dateTimePickerStartDate
			// 
			this.dateTimePickerStartDate.Location = new System.Drawing.Point(155, 59);
			this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
			this.dateTimePickerStartDate.Size = new System.Drawing.Size(146, 23);
			this.dateTimePickerStartDate.TabIndex = 3;
			// 
			// labelStartDate
			// 
			this.labelStartDate.AutoSize = true;
			this.labelStartDate.Location = new System.Drawing.Point(21, 65);
			this.labelStartDate.Name = "labelStartDate";
			this.labelStartDate.Size = new System.Drawing.Size(122, 15);
			this.labelStartDate.TabIndex = 2;
			this.labelStartDate.Text = "Дата начала первого";
			// 
			// numericUpDownPeriodsCount
			// 
			this.numericUpDownPeriodsCount.Location = new System.Drawing.Point(155, 25);
			this.numericUpDownPeriodsCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDownPeriodsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPeriodsCount.Name = "numericUpDownPeriodsCount";
			this.numericUpDownPeriodsCount.Size = new System.Drawing.Size(40, 23);
			this.numericUpDownPeriodsCount.TabIndex = 1;
			this.numericUpDownPeriodsCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// labelPeriodsCount
			// 
			this.labelPeriodsCount.AutoSize = true;
			this.labelPeriodsCount.Location = new System.Drawing.Point(21, 27);
			this.labelPeriodsCount.Name = "labelPeriodsCount";
			this.labelPeriodsCount.Size = new System.Drawing.Size(128, 15);
			this.labelPeriodsCount.TabIndex = 0;
			this.labelPeriodsCount.Text = "Количество периодов";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.Location = new System.Drawing.Point(220, 232);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(93, 35);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSave.Location = new System.Drawing.Point(34, 232);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(93, 35);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// FormAcademicYear
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(838, 302);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.groupBoxPeriods);
			this.Controls.Add(this.buttonCreateSemesters);
			this.Controls.Add(this.dataGridViewSemesters);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.labelTitle);
			this.Name = "FormAcademicYear";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Учебный год";
			this.Load += new System.EventHandler(this.FormAcademicYear_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSemesters)).EndInit();
			this.groupBoxPeriods.ResumeLayout(false);
			this.groupBoxPeriods.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriodLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeriodsCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.DataGridView dataGridViewSemesters;
		private System.Windows.Forms.Button buttonCreateSemesters;
		private System.Windows.Forms.GroupBox groupBoxPeriods;
		private System.Windows.Forms.Label labelStartDate;
		private System.Windows.Forms.NumericUpDown numericUpDownPeriodsCount;
		private System.Windows.Forms.Label labelPeriodsCount;
		private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
		private System.Windows.Forms.NumericUpDown numericUpDownPeriodLength;
		private System.Windows.Forms.Label labelInterval;
		private System.Windows.Forms.DataGridView dataGridViewPeriods;
		private System.Windows.Forms.Button buttonCreatePeriods;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
	}
}