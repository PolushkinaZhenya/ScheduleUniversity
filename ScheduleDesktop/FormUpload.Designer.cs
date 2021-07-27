
namespace ScheduleDesktop
{
	partial class FormUpload
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
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageToHtml = new System.Windows.Forms.TabPage();
			this.groupBoxTeachers = new System.Windows.Forms.GroupBox();
			this.buttonLaunchUploadTeachers = new System.Windows.Forms.Button();
			this.buttonUploadTeacherSelectFolder = new System.Windows.Forms.Button();
			this.groupBoxStudyGroup = new System.Windows.Forms.GroupBox();
			this.buttonLaunchUploadStudyGroups = new System.Windows.Forms.Button();
			this.buttonUploadStudyGroupSelectFolder = new System.Windows.Forms.Button();
			this.groupBoxAuditoriums = new System.Windows.Forms.GroupBox();
			this.buttonLaunchUploadAuditoriums = new System.Windows.Forms.Button();
			this.buttonUploadAuditoriumSelectFolder = new System.Windows.Forms.Button();
			this.tabControlMain.SuspendLayout();
			this.tabPageToHtml.SuspendLayout();
			this.groupBoxTeachers.SuspendLayout();
			this.groupBoxStudyGroup.SuspendLayout();
			this.groupBoxAuditoriums.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageToHtml);
			this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlMain.Location = new System.Drawing.Point(0, 0);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(800, 450);
			this.tabControlMain.TabIndex = 0;
			// 
			// tabPageToHtml
			// 
			this.tabPageToHtml.Controls.Add(this.groupBoxAuditoriums);
			this.tabPageToHtml.Controls.Add(this.groupBoxTeachers);
			this.tabPageToHtml.Controls.Add(this.groupBoxStudyGroup);
			this.tabPageToHtml.Location = new System.Drawing.Point(4, 24);
			this.tabPageToHtml.Name = "tabPageToHtml";
			this.tabPageToHtml.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageToHtml.Size = new System.Drawing.Size(792, 422);
			this.tabPageToHtml.TabIndex = 0;
			this.tabPageToHtml.Text = "Выгрузка в html";
			this.tabPageToHtml.UseVisualStyleBackColor = true;
			// 
			// groupBoxTeachers
			// 
			this.groupBoxTeachers.Controls.Add(this.buttonLaunchUploadTeachers);
			this.groupBoxTeachers.Controls.Add(this.buttonUploadTeacherSelectFolder);
			this.groupBoxTeachers.Location = new System.Drawing.Point(8, 144);
			this.groupBoxTeachers.Name = "groupBoxTeachers";
			this.groupBoxTeachers.Size = new System.Drawing.Size(263, 132);
			this.groupBoxTeachers.TabIndex = 1;
			this.groupBoxTeachers.TabStop = false;
			this.groupBoxTeachers.Text = "Выгрузка расписания преподавателей";
			// 
			// buttonLaunchUploadTeachers
			// 
			this.buttonLaunchUploadTeachers.Location = new System.Drawing.Point(48, 83);
			this.buttonLaunchUploadTeachers.Name = "buttonLaunchUploadTeachers";
			this.buttonLaunchUploadTeachers.Size = new System.Drawing.Size(158, 35);
			this.buttonLaunchUploadTeachers.TabIndex = 1;
			this.buttonLaunchUploadTeachers.Text = "Запустить выгрузку";
			this.buttonLaunchUploadTeachers.UseVisualStyleBackColor = true;
			this.buttonLaunchUploadTeachers.Click += new System.EventHandler(this.ButtonLaunchUploadTeachers_Click);
			// 
			// buttonUploadTeacherSelectFolder
			// 
			this.buttonUploadTeacherSelectFolder.Location = new System.Drawing.Point(21, 32);
			this.buttonUploadTeacherSelectFolder.Name = "buttonUploadTeacherSelectFolder";
			this.buttonUploadTeacherSelectFolder.Size = new System.Drawing.Size(220, 35);
			this.buttonUploadTeacherSelectFolder.TabIndex = 0;
			this.buttonUploadTeacherSelectFolder.Text = "Выбрать путь до папки";
			this.buttonUploadTeacherSelectFolder.UseVisualStyleBackColor = true;
			this.buttonUploadTeacherSelectFolder.Click += new System.EventHandler(this.ButtonUploadTeacherSelectFolder_Click);
			// 
			// groupBoxStudyGroup
			// 
			this.groupBoxStudyGroup.Controls.Add(this.buttonLaunchUploadStudyGroups);
			this.groupBoxStudyGroup.Controls.Add(this.buttonUploadStudyGroupSelectFolder);
			this.groupBoxStudyGroup.Location = new System.Drawing.Point(8, 6);
			this.groupBoxStudyGroup.Name = "groupBoxStudyGroup";
			this.groupBoxStudyGroup.Size = new System.Drawing.Size(263, 132);
			this.groupBoxStudyGroup.TabIndex = 0;
			this.groupBoxStudyGroup.TabStop = false;
			this.groupBoxStudyGroup.Text = "Выгрузка расписания учебных групп";
			// 
			// buttonLaunchUploadStudyGroups
			// 
			this.buttonLaunchUploadStudyGroups.Location = new System.Drawing.Point(48, 83);
			this.buttonLaunchUploadStudyGroups.Name = "buttonLaunchUploadStudyGroups";
			this.buttonLaunchUploadStudyGroups.Size = new System.Drawing.Size(158, 35);
			this.buttonLaunchUploadStudyGroups.TabIndex = 1;
			this.buttonLaunchUploadStudyGroups.Text = "Запустить выгрузку";
			this.buttonLaunchUploadStudyGroups.UseVisualStyleBackColor = true;
			this.buttonLaunchUploadStudyGroups.Click += new System.EventHandler(this.ButtonLaunchUploadStudyGroups_Click);
			// 
			// buttonUploadStudyGroupSelectFolder
			// 
			this.buttonUploadStudyGroupSelectFolder.Location = new System.Drawing.Point(21, 32);
			this.buttonUploadStudyGroupSelectFolder.Name = "buttonUploadStudyGroupSelectFolder";
			this.buttonUploadStudyGroupSelectFolder.Size = new System.Drawing.Size(220, 35);
			this.buttonUploadStudyGroupSelectFolder.TabIndex = 0;
			this.buttonUploadStudyGroupSelectFolder.Text = "Выбрать путь до папки";
			this.buttonUploadStudyGroupSelectFolder.UseVisualStyleBackColor = true;
			this.buttonUploadStudyGroupSelectFolder.Click += new System.EventHandler(this.ButtonUploadStudyGroupSelectFolder_Click);
			// 
			// groupBoxAuditoriums
			// 
			this.groupBoxAuditoriums.Controls.Add(this.buttonLaunchUploadAuditoriums);
			this.groupBoxAuditoriums.Controls.Add(this.buttonUploadAuditoriumSelectFolder);
			this.groupBoxAuditoriums.Location = new System.Drawing.Point(8, 282);
			this.groupBoxAuditoriums.Name = "groupBoxAuditoriums";
			this.groupBoxAuditoriums.Size = new System.Drawing.Size(263, 132);
			this.groupBoxAuditoriums.TabIndex = 2;
			this.groupBoxAuditoriums.TabStop = false;
			this.groupBoxAuditoriums.Text = "Выгрузка расписания аудиторий";
			// 
			// buttonLaunchUploadAuditoriums
			// 
			this.buttonLaunchUploadAuditoriums.Location = new System.Drawing.Point(48, 83);
			this.buttonLaunchUploadAuditoriums.Name = "buttonLaunchUploadAuditoriums";
			this.buttonLaunchUploadAuditoriums.Size = new System.Drawing.Size(158, 35);
			this.buttonLaunchUploadAuditoriums.TabIndex = 1;
			this.buttonLaunchUploadAuditoriums.Text = "Запустить выгрузку";
			this.buttonLaunchUploadAuditoriums.UseVisualStyleBackColor = true;
			this.buttonLaunchUploadAuditoriums.Click += new System.EventHandler(this.ButtonLaunchUploadAuditoriums_Click);
			// 
			// buttonUploadAuditoriumSelectFolder
			// 
			this.buttonUploadAuditoriumSelectFolder.Location = new System.Drawing.Point(21, 32);
			this.buttonUploadAuditoriumSelectFolder.Name = "buttonUploadAuditoriumSelectFolder";
			this.buttonUploadAuditoriumSelectFolder.Size = new System.Drawing.Size(220, 35);
			this.buttonUploadAuditoriumSelectFolder.TabIndex = 0;
			this.buttonUploadAuditoriumSelectFolder.Text = "Выбрать путь до папки";
			this.buttonUploadAuditoriumSelectFolder.UseVisualStyleBackColor = true;
			this.buttonUploadAuditoriumSelectFolder.Click += new System.EventHandler(this.ButtonUploadAuditoriumSelectFolder_Click);
			// 
			// FormUpload
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControlMain);
			this.Name = "FormUpload";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Выгрузка расписания";
			this.tabControlMain.ResumeLayout(false);
			this.tabPageToHtml.ResumeLayout(false);
			this.groupBoxTeachers.ResumeLayout(false);
			this.groupBoxStudyGroup.ResumeLayout(false);
			this.groupBoxAuditoriums.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageToHtml;
		private System.Windows.Forms.GroupBox groupBoxStudyGroup;
		private System.Windows.Forms.Button buttonUploadStudyGroupSelectFolder;
		private System.Windows.Forms.Button buttonLaunchUploadStudyGroups;
		private System.Windows.Forms.GroupBox groupBoxTeachers;
		private System.Windows.Forms.Button buttonLaunchUploadTeachers;
		private System.Windows.Forms.Button buttonUploadTeacherSelectFolder;
		private System.Windows.Forms.GroupBox groupBoxAuditoriums;
		private System.Windows.Forms.Button buttonLaunchUploadAuditoriums;
		private System.Windows.Forms.Button buttonUploadAuditoriumSelectFolder;
	}
}