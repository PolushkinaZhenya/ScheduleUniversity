namespace ScheduleView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыАудиторийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыКафедрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(688, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыАудиторийToolStripMenuItem,
            this.типыКафедрToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // типыАудиторийToolStripMenuItem
            // 
            this.типыАудиторийToolStripMenuItem.Name = "типыАудиторийToolStripMenuItem";
            this.типыАудиторийToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.типыАудиторийToolStripMenuItem.Text = "Типы аудиторий";
            this.типыАудиторийToolStripMenuItem.Click += new System.EventHandler(this.типыАудиторийToolStripMenuItem_Click);
            // 
            // типыКафедрToolStripMenuItem
            // 
            this.типыКафедрToolStripMenuItem.Name = "типыКафедрToolStripMenuItem";
            this.типыКафедрToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.типыКафедрToolStripMenuItem.Text = "Типы кафедр";
            this.типыКафедрToolStripMenuItem.Click += new System.EventHandler(this.типыКафедрToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 392);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Расписание университета";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыАудиторийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыКафедрToolStripMenuItem;
    }
}