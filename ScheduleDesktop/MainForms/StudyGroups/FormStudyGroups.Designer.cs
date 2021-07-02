namespace ScheduleDesktop
{
    partial class FormStudyGroups
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
			this.buttonAddGroup = new System.Windows.Forms.Button();
			this.tabControlFaculties = new System.Windows.Forms.TabControl();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonAddGroup);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelActions.Location = new System.Drawing.Point(908, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(90, 442);
			this.panelActions.TabIndex = 1;
			// 
			// buttonAddGroup
			// 
			this.buttonAddGroup.Location = new System.Drawing.Point(5, 12);
			this.buttonAddGroup.Name = "buttonAddGroup";
			this.buttonAddGroup.Size = new System.Drawing.Size(80, 50);
			this.buttonAddGroup.TabIndex = 0;
			this.buttonAddGroup.Text = "Добавить группу";
			this.buttonAddGroup.UseVisualStyleBackColor = true;
			this.buttonAddGroup.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// tabControlFaculties
			// 
			this.tabControlFaculties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlFaculties.Location = new System.Drawing.Point(0, 0);
			this.tabControlFaculties.Name = "tabControlFaculties";
			this.tabControlFaculties.SelectedIndex = 0;
			this.tabControlFaculties.Size = new System.Drawing.Size(908, 442);
			this.tabControlFaculties.TabIndex = 0;
			// 
			// FormStudyGroups
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 442);
			this.Controls.Add(this.tabControlFaculties);
			this.Controls.Add(this.panelActions);
			this.Name = "FormStudyGroups";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Учебные группы";
			this.Load += new System.EventHandler(this.FormStudyGroups_Load);
			this.panelActions.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.Button buttonAddGroup;
		private System.Windows.Forms.TabControl tabControlFaculties;
	}
}