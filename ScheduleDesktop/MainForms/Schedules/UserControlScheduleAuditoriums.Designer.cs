
namespace ScheduleDesktop
{
	partial class UserControlScheduleAuditoriums
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
			this.tabControlEducationalBuildings = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// tabControlEducationalBuildings
			// 
			this.tabControlEducationalBuildings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlEducationalBuildings.Location = new System.Drawing.Point(0, 0);
			this.tabControlEducationalBuildings.Name = "tabControlEducationalBuildings";
			this.tabControlEducationalBuildings.SelectedIndex = 0;
			this.tabControlEducationalBuildings.Size = new System.Drawing.Size(656, 479);
			this.tabControlEducationalBuildings.TabIndex = 0;
			this.tabControlEducationalBuildings.SelectedIndexChanged += new System.EventHandler(this.TabControlEducationalBuildings_SelectedIndexChanged);
			// 
			// UserControlScheduleAuditoriums
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlEducationalBuildings);
			this.Name = "UserControlScheduleAuditoriums";
			this.Size = new System.Drawing.Size(656, 479);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlEducationalBuildings;
	}
}
