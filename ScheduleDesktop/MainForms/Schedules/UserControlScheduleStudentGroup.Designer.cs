
namespace ScheduleDesktop
{
	partial class UserControlScheduleStudentGroup
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.splitContainerSchedule = new System.Windows.Forms.SplitContainer();
			this.dataGridViewFirstWeek = new System.Windows.Forms.DataGridView();
			this.ColumnDayOfWeekFirst = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelFirstWeek = new System.Windows.Forms.Panel();
			this.dataGridViewSecondWeek = new System.Windows.Forms.DataGridView();
			this.ColumnDayOfWeekSecond = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewFreeLessons = new System.Windows.Forms.DataGridView();
			this.panelActions = new System.Windows.Forms.Panel();
			this.checkBoxForcedSet = new System.Windows.Forms.CheckBox();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.panelAuditoriums = new System.Windows.Forms.Panel();
			this.checkBoxSetToFreeAuditorium = new System.Windows.Forms.CheckBox();
			this.textBoxAuditorium = new System.Windows.Forms.TextBox();
			this.dataGridViewAudiroriums = new System.Windows.Forms.DataGridView();
			this.ColumnAuditoriumId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAuditoriumTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelSecondWeek = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSchedule)).BeginInit();
			this.splitContainerSchedule.Panel1.SuspendLayout();
			this.splitContainerSchedule.Panel2.SuspendLayout();
			this.splitContainerSchedule.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirstWeek)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSecondWeek)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreeLessons)).BeginInit();
			this.panelActions.SuspendLayout();
			this.panelAuditoriums.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAudiroriums)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.splitContainerSchedule);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.dataGridViewFreeLessons);
			this.splitContainerMain.Panel2.Controls.Add(this.panelActions);
			this.splitContainerMain.Panel2.Controls.Add(this.panelAuditoriums);
			this.splitContainerMain.Size = new System.Drawing.Size(899, 680);
			this.splitContainerMain.SplitterDistance = 466;
			this.splitContainerMain.TabIndex = 0;
			// 
			// splitContainerSchedule
			// 
			this.splitContainerSchedule.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.splitContainerSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSchedule.Location = new System.Drawing.Point(0, 0);
			this.splitContainerSchedule.Name = "splitContainerSchedule";
			this.splitContainerSchedule.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerSchedule.Panel1
			// 
			this.splitContainerSchedule.Panel1.Controls.Add(this.dataGridViewFirstWeek);
			this.splitContainerSchedule.Panel1.Controls.Add(this.panelFirstWeek);
			// 
			// splitContainerSchedule.Panel2
			// 
			this.splitContainerSchedule.Panel2.Controls.Add(this.dataGridViewSecondWeek);
			this.splitContainerSchedule.Panel2.Controls.Add(this.panelSecondWeek);
			this.splitContainerSchedule.Size = new System.Drawing.Size(899, 466);
			this.splitContainerSchedule.SplitterDistance = 237;
			this.splitContainerSchedule.TabIndex = 0;
			// 
			// dataGridViewFirstWeek
			// 
			this.dataGridViewFirstWeek.AllowUserToAddRows = false;
			this.dataGridViewFirstWeek.AllowUserToDeleteRows = false;
			this.dataGridViewFirstWeek.AllowUserToResizeColumns = false;
			this.dataGridViewFirstWeek.AllowUserToResizeRows = false;
			this.dataGridViewFirstWeek.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewFirstWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewFirstWeek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDayOfWeekFirst});
			this.dataGridViewFirstWeek.Cursor = System.Windows.Forms.Cursors.Default;
			this.dataGridViewFirstWeek.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewFirstWeek.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewFirstWeek.MultiSelect = false;
			this.dataGridViewFirstWeek.Name = "dataGridViewFirstWeek";
			this.dataGridViewFirstWeek.ReadOnly = true;
			this.dataGridViewFirstWeek.RowHeadersVisible = false;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFirstWeek.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewFirstWeek.RowTemplate.Height = 25;
			this.dataGridViewFirstWeek.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewFirstWeek.Size = new System.Drawing.Size(899, 213);
			this.dataGridViewFirstWeek.TabIndex = 0;
			this.dataGridViewFirstWeek.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFirstWeek_CellClick);
			this.dataGridViewFirstWeek.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
			this.dataGridViewFirstWeek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyDown);
			this.dataGridViewFirstWeek.Resize += new System.EventHandler(this.DataGridView_Resize);
			// 
			// ColumnDayOfWeekFirst
			// 
			this.ColumnDayOfWeekFirst.HeaderText = "День недели";
			this.ColumnDayOfWeekFirst.Name = "ColumnDayOfWeekFirst";
			this.ColumnDayOfWeekFirst.ReadOnly = true;
			this.ColumnDayOfWeekFirst.Width = 150;
			// 
			// panelFirstWeek
			// 
			this.panelFirstWeek.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelFirstWeek.Location = new System.Drawing.Point(0, 213);
			this.panelFirstWeek.Name = "panelFirstWeek";
			this.panelFirstWeek.Size = new System.Drawing.Size(899, 24);
			this.panelFirstWeek.TabIndex = 1;
			// 
			// dataGridViewSecondWeek
			// 
			this.dataGridViewSecondWeek.AllowUserToAddRows = false;
			this.dataGridViewSecondWeek.AllowUserToDeleteRows = false;
			this.dataGridViewSecondWeek.AllowUserToResizeColumns = false;
			this.dataGridViewSecondWeek.AllowUserToResizeRows = false;
			this.dataGridViewSecondWeek.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewSecondWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSecondWeek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDayOfWeekSecond});
			this.dataGridViewSecondWeek.Cursor = System.Windows.Forms.Cursors.Default;
			this.dataGridViewSecondWeek.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewSecondWeek.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewSecondWeek.MultiSelect = false;
			this.dataGridViewSecondWeek.Name = "dataGridViewSecondWeek";
			this.dataGridViewSecondWeek.RowHeadersVisible = false;
			this.dataGridViewSecondWeek.RowTemplate.Height = 25;
			this.dataGridViewSecondWeek.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewSecondWeek.Size = new System.Drawing.Size(899, 201);
			this.dataGridViewSecondWeek.TabIndex = 0;
			this.dataGridViewSecondWeek.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSecondWeek_CellClick);
			this.dataGridViewSecondWeek.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
			this.dataGridViewSecondWeek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyDown);
			this.dataGridViewSecondWeek.Resize += new System.EventHandler(this.DataGridView_Resize);
			// 
			// ColumnDayOfWeekSecond
			// 
			this.ColumnDayOfWeekSecond.HeaderText = "День недели";
			this.ColumnDayOfWeekSecond.Name = "ColumnDayOfWeekSecond";
			this.ColumnDayOfWeekSecond.Width = 150;
			// 
			// dataGridViewFreeLessons
			// 
			this.dataGridViewFreeLessons.AllowUserToAddRows = false;
			this.dataGridViewFreeLessons.AllowUserToDeleteRows = false;
			this.dataGridViewFreeLessons.AllowUserToOrderColumns = true;
			this.dataGridViewFreeLessons.AllowUserToResizeColumns = false;
			this.dataGridViewFreeLessons.AllowUserToResizeRows = false;
			this.dataGridViewFreeLessons.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewFreeLessons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewFreeLessons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewFreeLessons.Location = new System.Drawing.Point(0, 39);
			this.dataGridViewFreeLessons.MultiSelect = false;
			this.dataGridViewFreeLessons.Name = "dataGridViewFreeLessons";
			this.dataGridViewFreeLessons.ReadOnly = true;
			this.dataGridViewFreeLessons.RowHeadersVisible = false;
			this.dataGridViewFreeLessons.RowTemplate.Height = 25;
			this.dataGridViewFreeLessons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewFreeLessons.Size = new System.Drawing.Size(780, 171);
			this.dataGridViewFreeLessons.TabIndex = 1;
			this.dataGridViewFreeLessons.SelectionChanged += new System.EventHandler(this.DataGridViewFreeLessons_SelectionChanged);
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.checkBoxForcedSet);
			this.panelActions.Controls.Add(this.buttonSelect);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelActions.Location = new System.Drawing.Point(0, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(780, 39);
			this.panelActions.TabIndex = 0;
			// 
			// checkBoxForcedSet
			// 
			this.checkBoxForcedSet.AutoSize = true;
			this.checkBoxForcedSet.Location = new System.Drawing.Point(124, 10);
			this.checkBoxForcedSet.Name = "checkBoxForcedSet";
			this.checkBoxForcedSet.Size = new System.Drawing.Size(208, 19);
			this.checkBoxForcedSet.TabIndex = 3;
			this.checkBoxForcedSet.Text = "Принудительная установка пары";
			this.checkBoxForcedSet.UseVisualStyleBackColor = true;
			// 
			// buttonSelect
			// 
			this.buttonSelect.BackColor = System.Drawing.Color.White;
			this.buttonSelect.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Schedule_20;
			this.buttonSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonSelect.Location = new System.Drawing.Point(3, 3);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(30, 30);
			this.buttonSelect.TabIndex = 0;
			this.buttonSelect.UseVisualStyleBackColor = false;
			this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
			// 
			// panelAuditoriums
			// 
			this.panelAuditoriums.Controls.Add(this.checkBoxSetToFreeAuditorium);
			this.panelAuditoriums.Controls.Add(this.textBoxAuditorium);
			this.panelAuditoriums.Controls.Add(this.dataGridViewAudiroriums);
			this.panelAuditoriums.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelAuditoriums.Location = new System.Drawing.Point(780, 0);
			this.panelAuditoriums.Name = "panelAuditoriums";
			this.panelAuditoriums.Size = new System.Drawing.Size(119, 210);
			this.panelAuditoriums.TabIndex = 2;
			// 
			// checkBoxSetToFreeAuditorium
			// 
			this.checkBoxSetToFreeAuditorium.Checked = true;
			this.checkBoxSetToFreeAuditorium.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSetToFreeAuditorium.Location = new System.Drawing.Point(12, 163);
			this.checkBoxSetToFreeAuditorium.Name = "checkBoxSetToFreeAuditorium";
			this.checkBoxSetToFreeAuditorium.Size = new System.Drawing.Size(104, 37);
			this.checkBoxSetToFreeAuditorium.TabIndex = 2;
			this.checkBoxSetToFreeAuditorium.Text = "Ставить в свбодную";
			this.checkBoxSetToFreeAuditorium.UseVisualStyleBackColor = true;
			// 
			// textBoxAuditorium
			// 
			this.textBoxAuditorium.Location = new System.Drawing.Point(3, 134);
			this.textBoxAuditorium.Name = "textBoxAuditorium";
			this.textBoxAuditorium.Size = new System.Drawing.Size(113, 23);
			this.textBoxAuditorium.TabIndex = 1;
			this.textBoxAuditorium.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxAuditorium_KeyDown);
			// 
			// dataGridViewAudiroriums
			// 
			this.dataGridViewAudiroriums.AllowUserToAddRows = false;
			this.dataGridViewAudiroriums.AllowUserToDeleteRows = false;
			this.dataGridViewAudiroriums.AllowUserToResizeColumns = false;
			this.dataGridViewAudiroriums.AllowUserToResizeRows = false;
			this.dataGridViewAudiroriums.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewAudiroriums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAudiroriums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAuditoriumId,
            this.ColumnAuditoriumTitle});
			this.dataGridViewAudiroriums.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGridViewAudiroriums.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewAudiroriums.MultiSelect = false;
			this.dataGridViewAudiroriums.Name = "dataGridViewAudiroriums";
			this.dataGridViewAudiroriums.ReadOnly = true;
			this.dataGridViewAudiroriums.RowHeadersVisible = false;
			this.dataGridViewAudiroriums.RowTemplate.Height = 25;
			this.dataGridViewAudiroriums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewAudiroriums.Size = new System.Drawing.Size(119, 128);
			this.dataGridViewAudiroriums.TabIndex = 0;
			this.dataGridViewAudiroriums.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewAudiroriums_CellMouseClick);
			// 
			// ColumnAuditoriumId
			// 
			this.ColumnAuditoriumId.HeaderText = "Id";
			this.ColumnAuditoriumId.Name = "ColumnAuditoriumId";
			this.ColumnAuditoriumId.ReadOnly = true;
			this.ColumnAuditoriumId.Visible = false;
			// 
			// ColumnAuditoriumTitle
			// 
			this.ColumnAuditoriumTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnAuditoriumTitle.HeaderText = "Аудитория";
			this.ColumnAuditoriumTitle.Name = "ColumnAuditoriumTitle";
			this.ColumnAuditoriumTitle.ReadOnly = true;
			// 
			// panelSecondWeek
			// 
			this.panelSecondWeek.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelSecondWeek.Location = new System.Drawing.Point(0, 201);
			this.panelSecondWeek.Name = "panelSecondWeek";
			this.panelSecondWeek.Size = new System.Drawing.Size(899, 24);
			this.panelSecondWeek.TabIndex = 2;
			// 
			// UserControlScheduleStudentGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerMain);
			this.Name = "UserControlScheduleStudentGroup";
			this.Size = new System.Drawing.Size(899, 680);
			this.Load += new System.EventHandler(this.UserControlScheduleStudentGroup_Load);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.splitContainerSchedule.Panel1.ResumeLayout(false);
			this.splitContainerSchedule.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSchedule)).EndInit();
			this.splitContainerSchedule.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirstWeek)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSecondWeek)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreeLessons)).EndInit();
			this.panelActions.ResumeLayout(false);
			this.panelActions.PerformLayout();
			this.panelAuditoriums.ResumeLayout(false);
			this.panelAuditoriums.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAudiroriums)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.SplitContainer splitContainerSchedule;
		private System.Windows.Forms.DataGridView dataGridViewFirstWeek;
		private System.Windows.Forms.DataGridView dataGridViewSecondWeek;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDayOfWeekFirst;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDayOfWeekSecond;
		private System.Windows.Forms.DataGridView dataGridViewFreeLessons;
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.DataGridView dataGridViewAudiroriums;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditoriumId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditoriumTitle;
		private System.Windows.Forms.Panel panelAuditoriums;
		private System.Windows.Forms.TextBox textBoxAuditorium;
		private System.Windows.Forms.CheckBox checkBoxSetToFreeAuditorium;
		private System.Windows.Forms.CheckBox checkBoxForcedSet;
		private System.Windows.Forms.Panel panelFirstWeek;
		private System.Windows.Forms.Panel panelSecondWeek;
	}
}
