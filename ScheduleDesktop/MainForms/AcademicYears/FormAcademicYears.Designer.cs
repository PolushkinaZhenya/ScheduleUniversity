
namespace ScheduleDesktop
{
	partial class FormAcademicYears
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
			this.panelActions = new System.Windows.Forms.Panel();
			this.buttonDelAcademinYear = new System.Windows.Forms.Button();
			this.buttonUpdAcademinYear = new System.Windows.Forms.Button();
			this.buttonAddAcademinYear = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.panelActions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonDelAcademinYear);
			this.panelActions.Controls.Add(this.buttonUpdAcademinYear);
			this.panelActions.Controls.Add(this.buttonAddAcademinYear);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelActions.Location = new System.Drawing.Point(264, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(120, 561);
			this.panelActions.TabIndex = 1;
			// 
			// buttonDelAcademinYear
			// 
			this.buttonDelAcademinYear.Image = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDelAcademinYear.Location = new System.Drawing.Point(10, 162);
			this.buttonDelAcademinYear.Name = "buttonDelAcademinYear";
			this.buttonDelAcademinYear.Size = new System.Drawing.Size(100, 70);
			this.buttonDelAcademinYear.TabIndex = 2;
			this.buttonDelAcademinYear.Text = "Удалить учебный год";
			this.buttonDelAcademinYear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonDelAcademinYear.UseVisualStyleBackColor = true;
			this.buttonDelAcademinYear.Click += new System.EventHandler(this.ButtonDelAcademinYear_Click);
			// 
			// buttonUpdAcademinYear
			// 
			this.buttonUpdAcademinYear.Image = global::ScheduleDesktop.Properties.Resources.Upd_20;
			this.buttonUpdAcademinYear.Location = new System.Drawing.Point(10, 86);
			this.buttonUpdAcademinYear.Name = "buttonUpdAcademinYear";
			this.buttonUpdAcademinYear.Size = new System.Drawing.Size(100, 70);
			this.buttonUpdAcademinYear.TabIndex = 1;
			this.buttonUpdAcademinYear.Text = "Изменить учебный год";
			this.buttonUpdAcademinYear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonUpdAcademinYear.UseVisualStyleBackColor = true;
			this.buttonUpdAcademinYear.Click += new System.EventHandler(this.ButtonUpdAcademinYear_Click);
			// 
			// buttonAddAcademinYear
			// 
			this.buttonAddAcademinYear.Image = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAddAcademinYear.Location = new System.Drawing.Point(10, 10);
			this.buttonAddAcademinYear.Name = "buttonAddAcademinYear";
			this.buttonAddAcademinYear.Size = new System.Drawing.Size(100, 70);
			this.buttonAddAcademinYear.TabIndex = 0;
			this.buttonAddAcademinYear.Text = "Добавить учебный год";
			this.buttonAddAcademinYear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonAddAcademinYear.UseVisualStyleBackColor = true;
			this.buttonAddAcademinYear.Click += new System.EventHandler(this.ButtonAddAcademinYear_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeColumns = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.RowTemplate.Height = 25;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(264, 561);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDoubleClick);
			this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyDown);
			// 
			// FormAcademicYears
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 561);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.panelActions);
			this.Name = "FormAcademicYears";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Учебные года";
			this.Load += new System.EventHandler(this.FormAcademicYears_Load);
			this.panelActions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.Button buttonDelAcademinYear;
		private System.Windows.Forms.Button buttonUpdAcademinYear;
		private System.Windows.Forms.Button buttonAddAcademinYear;
		private System.Windows.Forms.DataGridView dataGridView;
	}
}