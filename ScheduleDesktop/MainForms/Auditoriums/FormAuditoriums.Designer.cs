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
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlEducationalBuildings
			// 
			this.tabControlEducationalBuildings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlEducationalBuildings.Location = new System.Drawing.Point(0, 0);
			this.tabControlEducationalBuildings.Name = "tabControlEducationalBuildings";
			this.tabControlEducationalBuildings.SelectedIndex = 0;
			this.tabControlEducationalBuildings.Size = new System.Drawing.Size(771, 429);
			this.tabControlEducationalBuildings.TabIndex = 0;
			// 
			// buttonAddAuditorium
			// 
			this.buttonAddAuditorium.Image = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAddAuditorium.Location = new System.Drawing.Point(5, 12);
			this.buttonAddAuditorium.Name = "buttonAddAuditorium";
			this.buttonAddAuditorium.Size = new System.Drawing.Size(80, 70);
			this.buttonAddAuditorium.TabIndex = 0;
			this.buttonAddAuditorium.Text = "Добавить аудиторию";
			this.buttonAddAuditorium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.buttonAddAuditorium.UseVisualStyleBackColor = true;
			this.buttonAddAuditorium.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonAddAuditorium);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelActions.Location = new System.Drawing.Point(771, 0);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(90, 429);
			this.panelActions.TabIndex = 1;
			// 
			// FormAuditoriums
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 429);
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
	}
}