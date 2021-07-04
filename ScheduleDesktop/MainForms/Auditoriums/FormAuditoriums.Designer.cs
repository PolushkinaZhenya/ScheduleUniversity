namespace ScheduleDesktop
{
    partial class FormAuditoriums
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
			this.tabControlEducationalBuildings = new System.Windows.Forms.TabControl();
			this.buttonAddAuditorium = new System.Windows.Forms.Button();
			this.panelActions = new System.Windows.Forms.Panel();
			this.buttonUpdAuditorium = new System.Windows.Forms.Button();
			this.buttonDelAuditorium = new System.Windows.Forms.Button();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlEducationalBuildings
			// 
			this.tabControlEducationalBuildings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlEducationalBuildings.Location = new System.Drawing.Point(0, 0);
			this.tabControlEducationalBuildings.Name = "tabControlEducationalBuildings";
			this.tabControlEducationalBuildings.SelectedIndex = 0;
			this.tabControlEducationalBuildings.Size = new System.Drawing.Size(864, 561);
			this.tabControlEducationalBuildings.TabIndex = 0;
			// 
			// buttonAddAuditorium
			// 
			this.buttonAddAuditorium.Image = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAddAuditorium.Location = new System.Drawing.Point(10, 10);
			this.buttonAddAuditorium.Name = "buttonAddAuditorium";
			this.buttonAddAuditorium.Size = new System.Drawing.Size(100, 70);
			this.buttonAddAuditorium.TabIndex = 0;
			this.buttonAddAuditorium.Text = "Добавить аудиторию";
			this.buttonAddAuditorium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonAddAuditorium.UseVisualStyleBackColor = true;
			this.buttonAddAuditorium.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonDelAuditorium);
			this.panelActions.Controls.Add(this.buttonUpdAuditorium);
			this.panelActions.Controls.Add(this.buttonAddAuditorium);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelActions.Location = new System.Drawing.Point(864, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(120, 561);
			this.panelActions.TabIndex = 1;
			// 
			// buttonUpdAuditorium
			// 
			this.buttonUpdAuditorium.Image = global::ScheduleDesktop.Properties.Resources.Upd_20;
			this.buttonUpdAuditorium.Location = new System.Drawing.Point(10, 86);
			this.buttonUpdAuditorium.Name = "buttonUpdAuditorium";
			this.buttonUpdAuditorium.Size = new System.Drawing.Size(100, 70);
			this.buttonUpdAuditorium.TabIndex = 1;
			this.buttonUpdAuditorium.Text = "Изменить аудиторию";
			this.buttonUpdAuditorium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonUpdAuditorium.UseVisualStyleBackColor = true;
			this.buttonUpdAuditorium.Click += new System.EventHandler(this.ButtonUpdAuditorium_Click);
			// 
			// buttonDelAuditorium
			// 
			this.buttonDelAuditorium.Image = global::ScheduleDesktop.Properties.Resources.Del_20;
			this.buttonDelAuditorium.Location = new System.Drawing.Point(10, 162);
			this.buttonDelAuditorium.Name = "buttonDelAuditorium";
			this.buttonDelAuditorium.Size = new System.Drawing.Size(100, 70);
			this.buttonDelAuditorium.TabIndex = 2;
			this.buttonDelAuditorium.Text = "Удалить аудиторию";
			this.buttonDelAuditorium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonDelAuditorium.UseVisualStyleBackColor = true;
			this.buttonDelAuditorium.Click += new System.EventHandler(this.ButtonDelAuditorium_Click);
			// 
			// FormAuditoriums
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.tabControlEducationalBuildings);
			this.Controls.Add(this.panelActions);
			this.Name = "FormAuditoriums";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Аудитории";
			this.Load += new System.EventHandler(this.FormAuditoriums_Load);
			this.panelActions.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.TabControl tabControlEducationalBuildings;
		private System.Windows.Forms.Button buttonAddAuditorium;
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.Button buttonUpdAuditorium;
		private System.Windows.Forms.Button buttonDelAuditorium;
	}
}