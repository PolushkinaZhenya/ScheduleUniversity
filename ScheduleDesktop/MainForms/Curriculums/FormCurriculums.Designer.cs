namespace ScheduleDesktop
{
    partial class FormCurriculums
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
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.panelActions = new System.Windows.Forms.Panel();
			this.tabControlAcademicYears = new System.Windows.Forms.TabControl();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDel
			// 
			this.buttonDel.Image = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDel.Location = new System.Drawing.Point(10, 162);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(100, 70);
			this.buttonDel.TabIndex = 2;
			this.buttonDel.Text = "Удалить запись";
			this.buttonDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Image = global::ScheduleDesktop.Properties.Resources.Upd_20;
			this.buttonUpd.Location = new System.Drawing.Point(10, 86);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(100, 70);
			this.buttonUpd.TabIndex = 1;
			this.buttonUpd.Text = "Изменить запись";
			this.buttonUpd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Image = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAdd.Location = new System.Drawing.Point(10, 10);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(100, 70);
			this.buttonAdd.TabIndex = 0;
			this.buttonAdd.Text = "Добавить запись";
			this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonAdd);
			this.panelActions.Controls.Add(this.buttonDel);
			this.panelActions.Controls.Add(this.buttonUpd);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelActions.Location = new System.Drawing.Point(599, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(120, 429);
			this.panelActions.TabIndex = 1;
			// 
			// tabControlAcademicYears
			// 
			this.tabControlAcademicYears.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlAcademicYears.Location = new System.Drawing.Point(0, 0);
			this.tabControlAcademicYears.Name = "tabControlAcademicYears";
			this.tabControlAcademicYears.SelectedIndex = 0;
			this.tabControlAcademicYears.Size = new System.Drawing.Size(599, 429);
			this.tabControlAcademicYears.TabIndex = 0;
			this.tabControlAcademicYears.SelectedIndexChanged += new System.EventHandler(this.TabControlAcademicYears_SelectedIndexChanged);
			// 
			// FormCurriculums
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(719, 429);
			this.Controls.Add(this.tabControlAcademicYears);
			this.Controls.Add(this.panelActions);
			this.Name = "FormCurriculums";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Учебные планы";
			this.Load += new System.EventHandler(this.FormCurriculums_Load);
			this.panelActions.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.TabControl tabControlAcademicYears;
	}
}