namespace ScheduleDesktop
{
    partial class FormTeachers
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
			this.tabControlTeachers = new System.Windows.Forms.TabControl();
			this.panelAction = new System.Windows.Forms.Panel();
			this.panelAction.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDel
			// 
			this.buttonDel.Image = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDel.Location = new System.Drawing.Point(10, 162);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(100, 70);
			this.buttonDel.TabIndex = 2;
			this.buttonDel.Text = "Удалить преподавателя";
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
			this.buttonUpd.Text = "Изменить преподавателя";
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
			this.buttonAdd.Text = "Добавить преподавателя";
			this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// tabControlTeachers
			// 
			this.tabControlTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlTeachers.Location = new System.Drawing.Point(0, 0);
			this.tabControlTeachers.Name = "tabControlTeachers";
			this.tabControlTeachers.SelectedIndex = 0;
			this.tabControlTeachers.Size = new System.Drawing.Size(864, 561);
			this.tabControlTeachers.TabIndex = 0;
			this.tabControlTeachers.SelectedIndexChanged += new System.EventHandler(this.TabControlTeachers_SelectedIndexChanged);
			// 
			// panelAction
			// 
			this.panelAction.Controls.Add(this.buttonAdd);
			this.panelAction.Controls.Add(this.buttonUpd);
			this.panelAction.Controls.Add(this.buttonDel);
			this.panelAction.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelAction.Location = new System.Drawing.Point(864, 0);
			this.panelAction.Name = "panelAction";
			this.panelAction.Size = new System.Drawing.Size(120, 561);
			this.panelAction.TabIndex = 1;
			// 
			// FormTeachers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tabControlTeachers);
			this.Controls.Add(this.panelAction);
			this.Name = "FormTeachers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Преподаватели";
			this.Load += new System.EventHandler(this.FormTeachers_Load);
			this.panelAction.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.TabControl tabControlTeachers;
		private System.Windows.Forms.Panel panelAction;
	}
}