
namespace ScheduleDesktop
{
	partial class UserControlStudentGroupsForLoad
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
			this.listBoxStudentGroups = new System.Windows.Forms.ListBox();
			this.tabControlLoads = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// listBoxStudentGroups
			// 
			this.listBoxStudentGroups.Dock = System.Windows.Forms.DockStyle.Right;
			this.listBoxStudentGroups.FormattingEnabled = true;
			this.listBoxStudentGroups.ItemHeight = 15;
			this.listBoxStudentGroups.Location = new System.Drawing.Point(826, 0);
			this.listBoxStudentGroups.Name = "listBoxStudentGroups";
			this.listBoxStudentGroups.Size = new System.Drawing.Size(167, 701);
			this.listBoxStudentGroups.TabIndex = 0;
			this.listBoxStudentGroups.SelectedIndexChanged += new System.EventHandler(this.ListBoxStudentGroups_SelectedIndexChanged);
			// 
			// tabControlLoads
			// 
			this.tabControlLoads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlLoads.Location = new System.Drawing.Point(0, 0);
			this.tabControlLoads.Name = "tabControlLoads";
			this.tabControlLoads.SelectedIndex = 0;
			this.tabControlLoads.Size = new System.Drawing.Size(826, 701);
			this.tabControlLoads.TabIndex = 1;
			// 
			// UserControlStudentGroupsForLoad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlLoads);
			this.Controls.Add(this.listBoxStudentGroups);
			this.Name = "UserControlStudentGroupsForLoad";
			this.Size = new System.Drawing.Size(993, 701);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxStudentGroups;
		private System.Windows.Forms.TabControl tabControlLoads;
	}
}
