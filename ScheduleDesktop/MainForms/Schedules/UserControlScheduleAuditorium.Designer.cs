
namespace ScheduleDesktop
{
	partial class UserControlScheduleAuditorium
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.splitContainerSchedule = new System.Windows.Forms.SplitContainer();
			this.dataGridViewFirstWeek = new System.Windows.Forms.DataGridView();
			this.ColumnDayOfWeekFirst = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelFirstWeek = new System.Windows.Forms.Panel();
			this.dataGridViewSecondWeek = new System.Windows.Forms.DataGridView();
			this.ColumnDayOfWeekSecond = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelSecondWeek = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSchedule)).BeginInit();
			this.splitContainerSchedule.Panel1.SuspendLayout();
			this.splitContainerSchedule.Panel2.SuspendLayout();
			this.splitContainerSchedule.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirstWeek)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSecondWeek)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.VSplit;
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.splitContainerSchedule);
			this.splitContainerMain.Panel2Collapsed = true;
			this.splitContainerMain.Size = new System.Drawing.Size(964, 615);
			this.splitContainerMain.SplitterDistance = 421;
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
			this.splitContainerSchedule.Size = new System.Drawing.Size(964, 615);
			this.splitContainerSchedule.SplitterDistance = 311;
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
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewFirstWeek.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewFirstWeek.RowTemplate.Height = 25;
			this.dataGridViewFirstWeek.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewFirstWeek.Size = new System.Drawing.Size(964, 287);
			this.dataGridViewFirstWeek.TabIndex = 0;
			this.dataGridViewFirstWeek.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFirstWeek_CellClick);
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
			this.panelFirstWeek.Location = new System.Drawing.Point(0, 287);
			this.panelFirstWeek.Name = "panelFirstWeek";
			this.panelFirstWeek.Size = new System.Drawing.Size(964, 24);
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
			this.dataGridViewSecondWeek.Size = new System.Drawing.Size(964, 276);
			this.dataGridViewSecondWeek.TabIndex = 0;
			this.dataGridViewSecondWeek.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSecondWeek_CellClick);
			this.dataGridViewSecondWeek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyDown);
			this.dataGridViewSecondWeek.Resize += new System.EventHandler(this.DataGridView_Resize);
			// 
			// ColumnDayOfWeekSecond
			// 
			this.ColumnDayOfWeekSecond.HeaderText = "День недели";
			this.ColumnDayOfWeekSecond.Name = "ColumnDayOfWeekSecond";
			this.ColumnDayOfWeekSecond.Width = 150;
			// 
			// panelSecondWeek
			// 
			this.panelSecondWeek.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelSecondWeek.Location = new System.Drawing.Point(0, 276);
			this.panelSecondWeek.Name = "panelSecondWeek";
			this.panelSecondWeek.Size = new System.Drawing.Size(964, 24);
			this.panelSecondWeek.TabIndex = 2;
			// 
			// UserControlScheduleAuditorium
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerMain);
			this.Name = "UserControlScheduleAuditorium";
			this.Size = new System.Drawing.Size(964, 615);
			this.Load += new System.EventHandler(this.UserControlScheduleAuditorium_Load);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.splitContainerSchedule.Panel1.ResumeLayout(false);
			this.splitContainerSchedule.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSchedule)).EndInit();
			this.splitContainerSchedule.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFirstWeek)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSecondWeek)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.SplitContainer splitContainerSchedule;
		private System.Windows.Forms.DataGridView dataGridViewFirstWeek;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDayOfWeekFirst;
		private System.Windows.Forms.Panel panelFirstWeek;
		private System.Windows.Forms.DataGridView dataGridViewSecondWeek;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDayOfWeekSecond;
		private System.Windows.Forms.Panel panelSecondWeek;
	}
}
