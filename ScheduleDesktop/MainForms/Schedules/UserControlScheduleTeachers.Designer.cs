
namespace ScheduleDesktop
{
	partial class UserControlScheduleTeachers
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
			this.tabControlTeachers = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabControlTeachers
			// 
			this.tabControlTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlTeachers.Location = new System.Drawing.Point(0, 0);
			this.tabControlTeachers.Name = "tabControlTeachers";
			this.tabControlTeachers.SelectedIndex = 0;
			this.tabControlTeachers.Size = new System.Drawing.Size(748, 659);
			this.tabControlTeachers.TabIndex = 0;
			this.tabControlTeachers.SelectedIndexChanged += new System.EventHandler(this.TabControlTeachers_SelectedIndexChanged);
			// 
			// UserControlScheduleTeachers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlTeachers);
			this.Name = "UserControlScheduleTeachers";
			this.Size = new System.Drawing.Size(748, 659);
			this.Load += new System.EventHandler(this.UserControlScheduleTeachers_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlTeachers;
	}
}
