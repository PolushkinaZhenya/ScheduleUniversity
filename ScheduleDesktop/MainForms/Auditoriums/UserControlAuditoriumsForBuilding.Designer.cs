
namespace ScheduleDesktop
{
	partial class UserControlAuditoriumsForBuilding
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
			this.tabControlDepartments = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabControlDepartments
			// 
			this.tabControlDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlDepartments.Location = new System.Drawing.Point(0, 0);
			this.tabControlDepartments.Name = "tabControlDepartments";
			this.tabControlDepartments.SelectedIndex = 0;
			this.tabControlDepartments.Size = new System.Drawing.Size(749, 545);
			this.tabControlDepartments.TabIndex = 0;
			// 
			// UserControlAuditoriumsForBuilding
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlDepartments);
			this.Name = "UserControlAuditoriumsForBuilding";
			this.Size = new System.Drawing.Size(749, 545);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlDepartments;
	}
}
