
namespace ScheduleDesktop
{
	partial class UserControlScheduleStudentGroups
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
			this.tabControlFaculties = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabControlFaculties
			// 
			this.tabControlFaculties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlFaculties.Location = new System.Drawing.Point(0, 0);
			this.tabControlFaculties.Name = "tabControlFaculties";
			this.tabControlFaculties.SelectedIndex = 0;
			this.tabControlFaculties.Size = new System.Drawing.Size(1068, 645);
			this.tabControlFaculties.TabIndex = 0;
			this.tabControlFaculties.SelectedIndexChanged += new System.EventHandler(this.TabControlFaculties_SelectedIndexChanged);
			// 
			// UserControlScheduleStudentGroups
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlFaculties);
			this.Name = "UserControlScheduleStudentGroups";
			this.Size = new System.Drawing.Size(1068, 645);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlFaculties;
	}
}
