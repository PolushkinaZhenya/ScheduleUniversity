
namespace ScheduleDesktop
{
	partial class UserControlHourOfSemesterTypeOfClass
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelTypeOfClass = new System.Windows.Forms.Label();
			this.comboBoxTypeOfClass = new System.Windows.Forms.ComboBox();
			this.labelTeacher = new System.Windows.Forms.Label();
			this.comboBoxTeacher = new System.Windows.Forms.ComboBox();
			this.numericUpDownSubgroupNumber = new System.Windows.Forms.NumericUpDown();
			this.panelData = new System.Windows.Forms.Panel();
			this.dataGridViewPeriods = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonCreateDuplicat = new System.Windows.Forms.Button();
			this.checkBoxSubgroupNumber = new System.Windows.Forms.CheckBox();
			this.panelFlow = new System.Windows.Forms.Panel();
			this.comboBoxFlow = new System.Windows.Forms.ComboBox();
			this.buttonDelFlow = new System.Windows.Forms.Button();
			this.buttonAddFlow = new System.Windows.Forms.Button();
			this.labelFlow = new System.Windows.Forms.Label();
			this.numericUpDownTotalHours = new System.Windows.Forms.NumericUpDown();
			this.labelTotlaHours = new System.Windows.Forms.Label();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.groupBoxAuditorium = new System.Windows.Forms.GroupBox();
			this.dataGridViewAuditorium = new System.Windows.Forms.DataGridView();
			this.ColumnAuditoriumId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAudId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAuditorium = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelAuditorumActions = new System.Windows.Forms.Panel();
			this.buttonUpAuditorium = new System.Windows.Forms.Button();
			this.buttonDownAuditorium = new System.Windows.Forms.Button();
			this.buttonDelAuditorium = new System.Windows.Forms.Button();
			this.buttonAddAuditorium = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubgroupNumber)).BeginInit();
			this.panelData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).BeginInit();
			this.panel1.SuspendLayout();
			this.panelFlow.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalHours)).BeginInit();
			this.groupBox.SuspendLayout();
			this.groupBoxAuditorium.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditorium)).BeginInit();
			this.panelAuditorumActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTypeOfClass
			// 
			this.labelTypeOfClass.AutoSize = true;
			this.labelTypeOfClass.Location = new System.Drawing.Point(18, 17);
			this.labelTypeOfClass.Name = "labelTypeOfClass";
			this.labelTypeOfClass.Size = new System.Drawing.Size(94, 15);
			this.labelTypeOfClass.TabIndex = 0;
			this.labelTypeOfClass.Text = "Форма занятий:";
			// 
			// comboBoxTypeOfClass
			// 
			this.comboBoxTypeOfClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTypeOfClass.FormattingEnabled = true;
			this.comboBoxTypeOfClass.Location = new System.Drawing.Point(118, 14);
			this.comboBoxTypeOfClass.Name = "comboBoxTypeOfClass";
			this.comboBoxTypeOfClass.Size = new System.Drawing.Size(184, 23);
			this.comboBoxTypeOfClass.TabIndex = 1;
			// 
			// labelTeacher
			// 
			this.labelTeacher.AutoSize = true;
			this.labelTeacher.Location = new System.Drawing.Point(319, 17);
			this.labelTeacher.Name = "labelTeacher";
			this.labelTeacher.Size = new System.Drawing.Size(94, 15);
			this.labelTeacher.TabIndex = 2;
			this.labelTeacher.Text = "Преподаватель:";
			// 
			// comboBoxTeacher
			// 
			this.comboBoxTeacher.FormattingEnabled = true;
			this.comboBoxTeacher.Location = new System.Drawing.Point(419, 14);
			this.comboBoxTeacher.Name = "comboBoxTeacher";
			this.comboBoxTeacher.Size = new System.Drawing.Size(222, 23);
			this.comboBoxTeacher.TabIndex = 3;
			// 
			// numericUpDownSubgroupNumber
			// 
			this.numericUpDownSubgroupNumber.Enabled = false;
			this.numericUpDownSubgroupNumber.Location = new System.Drawing.Point(605, 54);
			this.numericUpDownSubgroupNumber.Name = "numericUpDownSubgroupNumber";
			this.numericUpDownSubgroupNumber.Size = new System.Drawing.Size(36, 23);
			this.numericUpDownSubgroupNumber.TabIndex = 8;
			// 
			// panelData
			// 
			this.panelData.Controls.Add(this.dataGridViewPeriods);
			this.panelData.Controls.Add(this.panel1);
			this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelData.Location = new System.Drawing.Point(220, 19);
			this.panelData.Name = "panelData";
			this.panelData.Size = new System.Drawing.Size(717, 168);
			this.panelData.TabIndex = 0;
			// 
			// dataGridViewPeriods
			// 
			this.dataGridViewPeriods.AllowUserToAddRows = false;
			this.dataGridViewPeriods.AllowUserToDeleteRows = false;
			this.dataGridViewPeriods.AllowUserToResizeColumns = false;
			this.dataGridViewPeriods.AllowUserToResizeRows = false;
			this.dataGridViewPeriods.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPeriods.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewPeriods.Location = new System.Drawing.Point(0, 100);
			this.dataGridViewPeriods.Name = "dataGridViewPeriods";
			this.dataGridViewPeriods.RowHeadersVisible = false;
			this.dataGridViewPeriods.RowTemplate.Height = 25;
			this.dataGridViewPeriods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewPeriods.Size = new System.Drawing.Size(717, 68);
			this.dataGridViewPeriods.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonDelete);
			this.panel1.Controls.Add(this.buttonCreateDuplicat);
			this.panel1.Controls.Add(this.checkBoxSubgroupNumber);
			this.panel1.Controls.Add(this.labelTypeOfClass);
			this.panel1.Controls.Add(this.comboBoxTeacher);
			this.panel1.Controls.Add(this.panelFlow);
			this.panel1.Controls.Add(this.labelTeacher);
			this.panel1.Controls.Add(this.numericUpDownTotalHours);
			this.panel1.Controls.Add(this.labelTotlaHours);
			this.panel1.Controls.Add(this.comboBoxTypeOfClass);
			this.panel1.Controls.Add(this.numericUpDownSubgroupNumber);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(717, 100);
			this.panel1.TabIndex = 0;
			// 
			// buttonCreateDuplicat
			// 
			this.buttonCreateDuplicat.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Duplicate;
			this.buttonCreateDuplicat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCreateDuplicat.Location = new System.Drawing.Point(675, 9);
			this.buttonCreateDuplicat.Name = "buttonCreateDuplicat";
			this.buttonCreateDuplicat.Size = new System.Drawing.Size(30, 30);
			this.buttonCreateDuplicat.TabIndex = 2;
			this.buttonCreateDuplicat.UseVisualStyleBackColor = true;
			this.buttonCreateDuplicat.Click += new System.EventHandler(this.ButtonCreateDuplicat_Click);
			// 
			// checkBoxSubgroupNumber
			// 
			this.checkBoxSubgroupNumber.AutoSize = true;
			this.checkBoxSubgroupNumber.Location = new System.Drawing.Point(510, 55);
			this.checkBoxSubgroupNumber.Name = "checkBoxSubgroupNumber";
			this.checkBoxSubgroupNumber.Size = new System.Drawing.Size(89, 19);
			this.checkBoxSubgroupNumber.TabIndex = 7;
			this.checkBoxSubgroupNumber.Text = "Подгруппа:";
			this.checkBoxSubgroupNumber.UseVisualStyleBackColor = true;
			this.checkBoxSubgroupNumber.CheckedChanged += new System.EventHandler(this.CheckBoxSubgroupNumber_CheckedChanged);
			// 
			// panelFlow
			// 
			this.panelFlow.Controls.Add(this.comboBoxFlow);
			this.panelFlow.Controls.Add(this.buttonDelFlow);
			this.panelFlow.Controls.Add(this.buttonAddFlow);
			this.panelFlow.Controls.Add(this.labelFlow);
			this.panelFlow.Location = new System.Drawing.Point(6, 43);
			this.panelFlow.Name = "panelFlow";
			this.panelFlow.Size = new System.Drawing.Size(296, 40);
			this.panelFlow.TabIndex = 4;
			// 
			// comboBoxFlow
			// 
			this.comboBoxFlow.FormattingEnabled = true;
			this.comboBoxFlow.Location = new System.Drawing.Point(68, 9);
			this.comboBoxFlow.Name = "comboBoxFlow";
			this.comboBoxFlow.Size = new System.Drawing.Size(155, 23);
			this.comboBoxFlow.TabIndex = 1;
			// 
			// buttonDelFlow
			// 
			this.buttonDelFlow.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDelFlow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonDelFlow.Location = new System.Drawing.Point(251, 8);
			this.buttonDelFlow.Name = "buttonDelFlow";
			this.buttonDelFlow.Size = new System.Drawing.Size(25, 25);
			this.buttonDelFlow.TabIndex = 3;
			this.buttonDelFlow.UseVisualStyleBackColor = true;
			this.buttonDelFlow.Click += new System.EventHandler(this.ButtonDelFlow_Click);
			// 
			// buttonAddFlow
			// 
			this.buttonAddFlow.Location = new System.Drawing.Point(222, 8);
			this.buttonAddFlow.Name = "buttonAddFlow";
			this.buttonAddFlow.Size = new System.Drawing.Size(30, 25);
			this.buttonAddFlow.TabIndex = 2;
			this.buttonAddFlow.Text = "...";
			this.buttonAddFlow.UseVisualStyleBackColor = true;
			this.buttonAddFlow.Click += new System.EventHandler(this.ButtonAddFlow_Click);
			// 
			// labelFlow
			// 
			this.labelFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFlow.AutoSize = true;
			this.labelFlow.Location = new System.Drawing.Point(12, 12);
			this.labelFlow.Name = "labelFlow";
			this.labelFlow.Size = new System.Drawing.Size(50, 15);
			this.labelFlow.TabIndex = 0;
			this.labelFlow.Text = "Поток : ";
			// 
			// numericUpDownTotalHours
			// 
			this.numericUpDownTotalHours.Location = new System.Drawing.Point(401, 53);
			this.numericUpDownTotalHours.Name = "numericUpDownTotalHours";
			this.numericUpDownTotalHours.Size = new System.Drawing.Size(53, 23);
			this.numericUpDownTotalHours.TabIndex = 6;
			// 
			// labelTotlaHours
			// 
			this.labelTotlaHours.AutoSize = true;
			this.labelTotlaHours.Location = new System.Drawing.Point(319, 56);
			this.labelTotlaHours.Name = "labelTotlaHours";
			this.labelTotlaHours.Size = new System.Drawing.Size(76, 15);
			this.labelTotlaHours.TabIndex = 5;
			this.labelTotlaHours.Text = "Всего часов:";
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.panelData);
			this.groupBox.Controls.Add(this.groupBoxAuditorium);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(940, 190);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Запись расчасовки";
			// 
			// groupBoxAuditorium
			// 
			this.groupBoxAuditorium.Controls.Add(this.dataGridViewAuditorium);
			this.groupBoxAuditorium.Controls.Add(this.panelAuditorumActions);
			this.groupBoxAuditorium.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBoxAuditorium.Location = new System.Drawing.Point(3, 19);
			this.groupBoxAuditorium.Name = "groupBoxAuditorium";
			this.groupBoxAuditorium.Size = new System.Drawing.Size(217, 168);
			this.groupBoxAuditorium.TabIndex = 1;
			this.groupBoxAuditorium.TabStop = false;
			this.groupBoxAuditorium.Text = "Аудитории";
			// 
			// dataGridViewAuditorium
			// 
			this.dataGridViewAuditorium.AllowUserToAddRows = false;
			this.dataGridViewAuditorium.AllowUserToDeleteRows = false;
			this.dataGridViewAuditorium.AllowUserToResizeColumns = false;
			this.dataGridViewAuditorium.AllowUserToResizeRows = false;
			this.dataGridViewAuditorium.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewAuditorium.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAuditorium.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAuditoriumId,
            this.ColumnAudId,
            this.ColumnAuditorium});
			this.dataGridViewAuditorium.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewAuditorium.Location = new System.Drawing.Point(3, 54);
			this.dataGridViewAuditorium.MultiSelect = false;
			this.dataGridViewAuditorium.Name = "dataGridViewAuditorium";
			this.dataGridViewAuditorium.RowHeadersVisible = false;
			this.dataGridViewAuditorium.RowTemplate.Height = 25;
			this.dataGridViewAuditorium.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewAuditorium.Size = new System.Drawing.Size(211, 111);
			this.dataGridViewAuditorium.TabIndex = 1;
			this.dataGridViewAuditorium.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAuditorium_CellEndEdit);
			// 
			// ColumnAuditoriumId
			// 
			this.ColumnAuditoriumId.HeaderText = "Id";
			this.ColumnAuditoriumId.Name = "ColumnAuditoriumId";
			this.ColumnAuditoriumId.Visible = false;
			// 
			// ColumnAudId
			// 
			this.ColumnAudId.HeaderText = "AuditoriumId";
			this.ColumnAudId.Name = "ColumnAudId";
			this.ColumnAudId.Visible = false;
			// 
			// ColumnAuditorium
			// 
			this.ColumnAuditorium.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnAuditorium.HeaderText = "Аудитория";
			this.ColumnAuditorium.Name = "ColumnAuditorium";
			// 
			// panelAuditorumActions
			// 
			this.panelAuditorumActions.Controls.Add(this.buttonUpAuditorium);
			this.panelAuditorumActions.Controls.Add(this.buttonDownAuditorium);
			this.panelAuditorumActions.Controls.Add(this.buttonDelAuditorium);
			this.panelAuditorumActions.Controls.Add(this.buttonAddAuditorium);
			this.panelAuditorumActions.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelAuditorumActions.Location = new System.Drawing.Point(3, 19);
			this.panelAuditorumActions.Name = "panelAuditorumActions";
			this.panelAuditorumActions.Size = new System.Drawing.Size(211, 35);
			this.panelAuditorumActions.TabIndex = 0;
			// 
			// buttonUpAuditorium
			// 
			this.buttonUpAuditorium.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Arrow_Up;
			this.buttonUpAuditorium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonUpAuditorium.Location = new System.Drawing.Point(133, 2);
			this.buttonUpAuditorium.Name = "buttonUpAuditorium";
			this.buttonUpAuditorium.Size = new System.Drawing.Size(30, 30);
			this.buttonUpAuditorium.TabIndex = 3;
			this.buttonUpAuditorium.UseVisualStyleBackColor = true;
			this.buttonUpAuditorium.Click += new System.EventHandler(this.ButtonUpAuditorium_Click);
			// 
			// buttonDownAuditorium
			// 
			this.buttonDownAuditorium.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Arrow_Down;
			this.buttonDownAuditorium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonDownAuditorium.Location = new System.Drawing.Point(178, 2);
			this.buttonDownAuditorium.Name = "buttonDownAuditorium";
			this.buttonDownAuditorium.Size = new System.Drawing.Size(30, 30);
			this.buttonDownAuditorium.TabIndex = 2;
			this.buttonDownAuditorium.UseVisualStyleBackColor = true;
			this.buttonDownAuditorium.Click += new System.EventHandler(this.ButtonDownAuditorium_Click);
			// 
			// buttonDelAuditorium
			// 
			this.buttonDelAuditorium.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDelAuditorium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonDelAuditorium.Location = new System.Drawing.Point(52, 2);
			this.buttonDelAuditorium.Name = "buttonDelAuditorium";
			this.buttonDelAuditorium.Size = new System.Drawing.Size(30, 30);
			this.buttonDelAuditorium.TabIndex = 1;
			this.buttonDelAuditorium.UseVisualStyleBackColor = true;
			this.buttonDelAuditorium.Click += new System.EventHandler(this.ButtonDelAuditorium_Click);
			// 
			// buttonAddAuditorium
			// 
			this.buttonAddAuditorium.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAddAuditorium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonAddAuditorium.Location = new System.Drawing.Point(3, 2);
			this.buttonAddAuditorium.Name = "buttonAddAuditorium";
			this.buttonAddAuditorium.Size = new System.Drawing.Size(30, 30);
			this.buttonAddAuditorium.TabIndex = 0;
			this.buttonAddAuditorium.UseVisualStyleBackColor = true;
			this.buttonAddAuditorium.Click += new System.EventHandler(this.ButtonAddAuditorium_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonDelete.Location = new System.Drawing.Point(675, 53);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(30, 30);
			this.buttonDelete.TabIndex = 9;
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			// 
			// UserControlHourOfSemesterTypeOfClass
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox);
			this.Name = "UserControlHourOfSemesterTypeOfClass";
			this.Size = new System.Drawing.Size(940, 190);
			this.Load += new System.EventHandler(this.UserControlHourOfSemesterTypeOfClass_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubgroupNumber)).EndInit();
			this.panelData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriods)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelFlow.ResumeLayout(false);
			this.panelFlow.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalHours)).EndInit();
			this.groupBox.ResumeLayout(false);
			this.groupBoxAuditorium.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditorium)).EndInit();
			this.panelAuditorumActions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelTypeOfClass;
		private System.Windows.Forms.ComboBox comboBoxTypeOfClass;
		private System.Windows.Forms.Label labelTeacher;
		private System.Windows.Forms.ComboBox comboBoxTeacher;
		private System.Windows.Forms.NumericUpDown numericUpDownSubgroupNumber;
		private System.Windows.Forms.Panel panelData;
		private System.Windows.Forms.NumericUpDown numericUpDownTotalHours;
		private System.Windows.Forms.Label labelTotlaHours;
		private System.Windows.Forms.Panel panelFlow;
		private System.Windows.Forms.ComboBox comboBoxFlow;
		private System.Windows.Forms.Button buttonDelFlow;
		private System.Windows.Forms.Button buttonAddFlow;
		private System.Windows.Forms.Label labelFlow;
		private System.Windows.Forms.DataGridView dataGridViewPeriods;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.GroupBox groupBoxAuditorium;
		private System.Windows.Forms.DataGridView dataGridViewAuditorium;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditoriumId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAudId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditorium;
		private System.Windows.Forms.Panel panelAuditorumActions;
		private System.Windows.Forms.Button buttonUpAuditorium;
		private System.Windows.Forms.Button buttonDownAuditorium;
		private System.Windows.Forms.Button buttonDelAuditorium;
		private System.Windows.Forms.Button buttonAddAuditorium;
		private System.Windows.Forms.CheckBox checkBoxSubgroupNumber;
		private System.Windows.Forms.Button buttonCreateDuplicat;
		private System.Windows.Forms.Button buttonDelete;
	}
}
