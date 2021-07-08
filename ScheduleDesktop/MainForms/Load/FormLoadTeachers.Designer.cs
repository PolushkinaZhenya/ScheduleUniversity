namespace ScheduleDesktop
{
    partial class FormLoadTeachers
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
			this.tabControlFaculties = new System.Windows.Forms.TabControl();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDel
			// 
			this.buttonDel.Image = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDel.Location = new System.Drawing.Point(10, 162);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(100, 70);
			this.buttonDel.TabIndex = 3;
			this.buttonDel.Text = "Удалить";
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
			this.buttonUpd.TabIndex = 2;
			this.buttonUpd.Text = "Изменить";
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
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "Добавить";
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
			this.panelActions.Location = new System.Drawing.Point(892, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(120, 654);
			this.panelActions.TabIndex = 1;
			// 
			// tabControlFaculties
			// 
			this.tabControlFaculties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlFaculties.Location = new System.Drawing.Point(0, 0);
			this.tabControlFaculties.Name = "tabControlFaculties";
			this.tabControlFaculties.SelectedIndex = 0;
			this.tabControlFaculties.Size = new System.Drawing.Size(892, 654);
			this.tabControlFaculties.TabIndex = 0;
			this.tabControlFaculties.SelectedIndexChanged += new System.EventHandler(this.TabControlFaculties_SelectedIndexChanged);
			// 
			// FormLoadTeachers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 654);
			this.Controls.Add(this.tabControlFaculties);
			this.Controls.Add(this.panelActions);
			this.Name = "FormLoadTeachers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Расчасовки";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FormLoadTeachers_Load);
			this.panelActions.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.TabControl tabControlFaculties;
	}
}