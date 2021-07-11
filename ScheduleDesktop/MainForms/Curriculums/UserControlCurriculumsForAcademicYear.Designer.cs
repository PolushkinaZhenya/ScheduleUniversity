
namespace ScheduleDesktop
{
	partial class UserControlCurriculumsForAcademicYear
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
			this.tabControlSemesters = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabControlSemesters
			// 
			this.tabControlSemesters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlSemesters.Location = new System.Drawing.Point(0, 0);
			this.tabControlSemesters.Name = "tabControlSemesters";
			this.tabControlSemesters.SelectedIndex = 0;
			this.tabControlSemesters.Size = new System.Drawing.Size(678, 549);
			this.tabControlSemesters.TabIndex = 0;
			// 
			// UserControlCurriculumsForAcademicYear
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlSemesters);
			this.Name = "UserControlCurriculumsForAcademicYear";
			this.Size = new System.Drawing.Size(678, 549);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlSemesters;
	}
}
