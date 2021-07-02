
namespace ScheduleDesktop
{
	partial class UserControlStudyGroupsForFaculty
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
			this.tabControlCourses = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabControlCourses
			// 
			this.tabControlCourses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlCourses.Location = new System.Drawing.Point(0, 0);
			this.tabControlCourses.Name = "tabControlCourses";
			this.tabControlCourses.SelectedIndex = 0;
			this.tabControlCourses.Size = new System.Drawing.Size(692, 504);
			this.tabControlCourses.TabIndex = 0;
			this.tabControlCourses.SelectedIndexChanged += new System.EventHandler(this.TabControlCourses_SelectedIndexChanged);
			// 
			// UserControlStudyGroupsForFaculty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlCourses);
			this.Name = "UserControlStudyGroupsForFaculty";
			this.Size = new System.Drawing.Size(692, 504);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlCourses;
	}
}
