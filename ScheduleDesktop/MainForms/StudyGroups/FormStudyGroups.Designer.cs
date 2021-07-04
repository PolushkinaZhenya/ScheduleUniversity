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
			this.buttonUpdGroup = new System.Windows.Forms.Button();
			this.buttonDelGroup = new System.Windows.Forms.Button();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonDelGroup);
			this.panelActions.Controls.Add(this.buttonUpdGroup);
			this.panelActions.Controls.Add(this.buttonAddGroup);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelActions.Location = new System.Drawing.Point(864, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(120, 561);
			this.panelActions.TabIndex = 1;
			// 
			// buttonAddGroup
			// 
			this.buttonAddGroup.Image = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAddGroup.Location = new System.Drawing.Point(10, 10);
			this.buttonAddGroup.Name = "buttonAddGroup";
			this.buttonAddGroup.Size = new System.Drawing.Size(100, 70);
			this.buttonAddGroup.TabIndex = 0;
			this.buttonAddGroup.Text = "Добавить группу";
			this.buttonAddGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonAddGroup.UseVisualStyleBackColor = true;
			this.buttonAddGroup.Click += new System.EventHandler(this.ButtonAddGroup_Click);
			// 
			// tabControlFaculties
			// 
			this.tabControlFaculties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlFaculties.Location = new System.Drawing.Point(0, 0);
			this.tabControlFaculties.Name = "tabControlFaculties";
			this.tabControlFaculties.SelectedIndex = 0;
			this.tabControlFaculties.Size = new System.Drawing.Size(864, 561);
			this.tabControlFaculties.TabIndex = 0;
			// 
			// buttonUpdGroup
			// 
			this.buttonUpdGroup.Image = global::ScheduleDesktop.Properties.Resources.Upd_20;
			this.buttonUpdGroup.Location = new System.Drawing.Point(10, 86);
			this.buttonUpdGroup.Name = "buttonUpdGroup";
			this.buttonUpdGroup.Size = new System.Drawing.Size(100, 70);
			this.buttonUpdGroup.TabIndex = 1;
			this.buttonUpdGroup.Text = "Изменить группу";
			this.buttonUpdGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonUpdGroup.UseVisualStyleBackColor = true;
			this.buttonUpdGroup.Click += new System.EventHandler(this.ButtonUpdGroup_Click);
			// 
			// buttonDelGroup
			// 
			this.buttonDelGroup.Image = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDelGroup.Location = new System.Drawing.Point(10, 162);
			this.buttonDelGroup.Name = "buttonDelGroup";
			this.buttonDelGroup.Size = new System.Drawing.Size(100, 70);
			this.buttonDelGroup.TabIndex = 2;
			this.buttonDelGroup.Text = "Удалить \r\nгруппу";
			this.buttonDelGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonDelGroup.UseVisualStyleBackColor = true;
			this.buttonDelGroup.Click += new System.EventHandler(this.ButtonDelGroup_Click);
			// 
			// FormStudyGroups
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
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
		private System.Windows.Forms.Button buttonUpdGroup;
		private System.Windows.Forms.Button buttonDelGroup;
	}
}