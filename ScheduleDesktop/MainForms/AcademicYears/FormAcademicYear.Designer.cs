
namespace ScheduleDesktop
{
	partial class FormAcademicYear
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.dataGridViewSemesters = new System.Windows.Forms.DataGridView();
			this.buttonCreateSemesters = new System.Windows.Forms.Button();
			this.buttonAddSemester = new System.Windows.Forms.Button();
			this.buttonUpdSemester = new System.Windows.Forms.Button();
			this.buttonDelSemester = new System.Windows.Forms.Button();
			this.panelSemester = new System.Windows.Forms.Panel();
			this.textBoxSemester = new System.Windows.Forms.TextBox();
			this.buttonSemesterSave = new System.Windows.Forms.Button();
			this.buttonSemseterCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSemesters)).BeginInit();
			this.panelSemester.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(12, 9);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(62, 15);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Название:";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(80, 6);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(246, 23);
			this.textBoxTitle.TabIndex = 1;
			// 
			// dataGridViewSemesters
			// 
			this.dataGridViewSemesters.AllowUserToAddRows = false;
			this.dataGridViewSemesters.AllowUserToDeleteRows = false;
			this.dataGridViewSemesters.AllowUserToResizeColumns = false;
			this.dataGridViewSemesters.AllowUserToResizeRows = false;
			this.dataGridViewSemesters.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridViewSemesters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSemesters.Location = new System.Drawing.Point(12, 87);
			this.dataGridViewSemesters.Name = "dataGridViewSemesters";
			this.dataGridViewSemesters.RowHeadersVisible = false;
			this.dataGridViewSemesters.RowTemplate.Height = 25;
			this.dataGridViewSemesters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewSemesters.Size = new System.Drawing.Size(331, 111);
			this.dataGridViewSemesters.TabIndex = 2;
			// 
			// buttonCreateSemesters
			// 
			this.buttonCreateSemesters.Location = new System.Drawing.Point(42, 46);
			this.buttonCreateSemesters.Name = "buttonCreateSemesters";
			this.buttonCreateSemesters.Size = new System.Drawing.Size(250, 35);
			this.buttonCreateSemesters.TabIndex = 3;
			this.buttonCreateSemesters.Text = "Сформировать семестры";
			this.buttonCreateSemesters.UseVisualStyleBackColor = true;
			this.buttonCreateSemesters.Click += new System.EventHandler(this.ButtonCreateSemesters_Click);
			// 
			// buttonAddSemester
			// 
			this.buttonAddSemester.Image = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAddSemester.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAddSemester.Location = new System.Drawing.Point(26, 215);
			this.buttonAddSemester.Name = "buttonAddSemester";
			this.buttonAddSemester.Size = new System.Drawing.Size(110, 40);
			this.buttonAddSemester.TabIndex = 4;
			this.buttonAddSemester.Text = "Добавить семестр";
			this.buttonAddSemester.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonAddSemester.UseVisualStyleBackColor = true;
			this.buttonAddSemester.Click += new System.EventHandler(this.ButtonAddSemester_Click);
			// 
			// buttonUpdSemester
			// 
			this.buttonUpdSemester.Image = global::ScheduleDesktop.Properties.Resources.Upd_20;
			this.buttonUpdSemester.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonUpdSemester.Location = new System.Drawing.Point(157, 215);
			this.buttonUpdSemester.Name = "buttonUpdSemester";
			this.buttonUpdSemester.Size = new System.Drawing.Size(110, 40);
			this.buttonUpdSemester.TabIndex = 5;
			this.buttonUpdSemester.Text = "Изменить семестр";
			this.buttonUpdSemester.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonUpdSemester.UseVisualStyleBackColor = true;
			this.buttonUpdSemester.Click += new System.EventHandler(this.ButtonUpdSemester_Click);
			// 
			// buttonDelSemester
			// 
			this.buttonDelSemester.Image = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDelSemester.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDelSemester.Location = new System.Drawing.Point(96, 274);
			this.buttonDelSemester.Name = "buttonDelSemester";
			this.buttonDelSemester.Size = new System.Drawing.Size(110, 40);
			this.buttonDelSemester.TabIndex = 6;
			this.buttonDelSemester.Text = "Удалить семестр";
			this.buttonDelSemester.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttonDelSemester.UseVisualStyleBackColor = true;
			this.buttonDelSemester.Click += new System.EventHandler(this.ButtonDelSemester_Click);
			// 
			// panelSemester
			// 
			this.panelSemester.Controls.Add(this.buttonSemseterCancel);
			this.panelSemester.Controls.Add(this.buttonSemesterSave);
			this.panelSemester.Controls.Add(this.textBoxSemester);
			this.panelSemester.Location = new System.Drawing.Point(12, 338);
			this.panelSemester.Name = "panelSemester";
			this.panelSemester.Size = new System.Drawing.Size(331, 100);
			this.panelSemester.TabIndex = 7;
			this.panelSemester.Visible = false;
			// 
			// textBoxSemester
			// 
			this.textBoxSemester.Location = new System.Drawing.Point(14, 18);
			this.textBoxSemester.Name = "textBoxSemester";
			this.textBoxSemester.Size = new System.Drawing.Size(300, 23);
			this.textBoxSemester.TabIndex = 0;
			// 
			// buttonSemesterSave
			// 
			this.buttonSemesterSave.Location = new System.Drawing.Point(68, 56);
			this.buttonSemesterSave.Name = "buttonSemesterSave";
			this.buttonSemesterSave.Size = new System.Drawing.Size(100, 30);
			this.buttonSemesterSave.TabIndex = 1;
			this.buttonSemesterSave.Text = "Сохранить";
			this.buttonSemesterSave.UseVisualStyleBackColor = true;
			this.buttonSemesterSave.Click += new System.EventHandler(this.ButtonSemesterSave_Click);
			// 
			// buttonSemseterCancel
			// 
			this.buttonSemseterCancel.Location = new System.Drawing.Point(214, 56);
			this.buttonSemseterCancel.Name = "buttonSemseterCancel";
			this.buttonSemseterCancel.Size = new System.Drawing.Size(100, 30);
			this.buttonSemseterCancel.TabIndex = 2;
			this.buttonSemseterCancel.Text = "Отмена";
			this.buttonSemseterCancel.UseVisualStyleBackColor = true;
			this.buttonSemseterCancel.Click += new System.EventHandler(this.ButtonSemseterCancel_Click);
			// 
			// FormAcademicYear
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panelSemester);
			this.Controls.Add(this.buttonDelSemester);
			this.Controls.Add(this.buttonUpdSemester);
			this.Controls.Add(this.buttonAddSemester);
			this.Controls.Add(this.buttonCreateSemesters);
			this.Controls.Add(this.dataGridViewSemesters);
			this.Controls.Add(this.textBoxTitle);
			this.Controls.Add(this.labelTitle);
			this.Name = "FormAcademicYear";
			this.Text = "Учебный год";
			this.Load += new System.EventHandler(this.FormAcademicYear_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSemesters)).EndInit();
			this.panelSemester.ResumeLayout(false);
			this.panelSemester.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.DataGridView dataGridViewSemesters;
		private System.Windows.Forms.Button buttonCreateSemesters;
		private System.Windows.Forms.Button buttonAddSemester;
		private System.Windows.Forms.Button buttonUpdSemester;
		private System.Windows.Forms.Button buttonDelSemester;
		private System.Windows.Forms.Panel panelSemester;
		private System.Windows.Forms.Button buttonSemesterSave;
		private System.Windows.Forms.TextBox textBoxSemester;
		private System.Windows.Forms.Button buttonSemseterCancel;
	}
}