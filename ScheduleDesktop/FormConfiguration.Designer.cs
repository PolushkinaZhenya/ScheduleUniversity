
namespace ScheduleDesktop
{
	partial class FormConfiguration
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelSUBD = new System.Windows.Forms.Label();
			this.comboBoxSUBD = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxConnectionString = new System.Windows.Forms.TextBox();
			this.buttonCheck = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonApplyMigrations = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelSUBD
			// 
			this.labelSUBD.AutoSize = true;
			this.labelSUBD.Location = new System.Drawing.Point(12, 9);
			this.labelSUBD.Name = "labelSUBD";
			this.labelSUBD.Size = new System.Drawing.Size(40, 15);
			this.labelSUBD.TabIndex = 0;
			this.labelSUBD.Text = "СУБД:";
			// 
			// comboBoxSUBD
			// 
			this.comboBoxSUBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSUBD.FormattingEnabled = true;
			this.comboBoxSUBD.Items.AddRange(new object[] {
            "MSSQL",
            "Postgresql"});
			this.comboBoxSUBD.Location = new System.Drawing.Point(156, 6);
			this.comboBoxSUBD.Name = "comboBoxSUBD";
			this.comboBoxSUBD.Size = new System.Drawing.Size(163, 23);
			this.comboBoxSUBD.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Строка подключения:";
			// 
			// textBoxConnectionString
			// 
			this.textBoxConnectionString.Location = new System.Drawing.Point(156, 51);
			this.textBoxConnectionString.Multiline = true;
			this.textBoxConnectionString.Name = "textBoxConnectionString";
			this.textBoxConnectionString.Size = new System.Drawing.Size(591, 65);
			this.textBoxConnectionString.TabIndex = 3;
			// 
			// buttonCheck
			// 
			this.buttonCheck.Location = new System.Drawing.Point(411, 132);
			this.buttonCheck.Name = "buttonCheck";
			this.buttonCheck.Size = new System.Drawing.Size(100, 30);
			this.buttonCheck.TabIndex = 4;
			this.buttonCheck.Text = "Проверить";
			this.buttonCheck.UseVisualStyleBackColor = true;
			this.buttonCheck.Click += new System.EventHandler(this.ButtonCheck_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(517, 132);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 30);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(623, 132);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 30);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonApplyMigrations
			// 
			this.buttonApplyMigrations.Location = new System.Drawing.Point(14, 132);
			this.buttonApplyMigrations.Name = "buttonApplyMigrations";
			this.buttonApplyMigrations.Size = new System.Drawing.Size(155, 30);
			this.buttonApplyMigrations.TabIndex = 7;
			this.buttonApplyMigrations.Text = "Применить миграции";
			this.buttonApplyMigrations.UseVisualStyleBackColor = true;
			this.buttonApplyMigrations.Click += new System.EventHandler(this.ButtonApplyMigrations_Click);
			// 
			// FormConfiguration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 174);
			this.Controls.Add(this.buttonApplyMigrations);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonCheck);
			this.Controls.Add(this.textBoxConnectionString);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxSUBD);
			this.Controls.Add(this.labelSUBD);
			this.Name = "FormConfiguration";
			this.Text = "Настройки соединения";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelSUBD;
		private System.Windows.Forms.ComboBox comboBoxSUBD;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxConnectionString;
		private System.Windows.Forms.Button buttonCheck;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonApplyMigrations;
	}
}