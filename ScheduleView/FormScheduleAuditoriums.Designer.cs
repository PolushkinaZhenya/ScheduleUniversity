namespace ScheduleView
{
    partial class FormScheduleAuditoriums
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScheduleAuditoriums));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBoxAuditoriums = new System.Windows.Forms.ListBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 133);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(1131, 529);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 35;
            // 
            // listBoxAuditoriums
            // 
            this.listBoxAuditoriums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAuditoriums.FormattingEnabled = true;
            this.listBoxAuditoriums.ItemHeight = 16;
            this.listBoxAuditoriums.Location = new System.Drawing.Point(1149, 13);
            this.listBoxAuditoriums.Name = "listBoxAuditoriums";
            this.listBoxAuditoriums.Size = new System.Drawing.Size(199, 468);
            this.listBoxAuditoriums.Sorted = true;
            this.listBoxAuditoriums.TabIndex = 34;
            this.listBoxAuditoriums.SelectedIndexChanged += new System.EventHandler(this.listBoxAuditoriums_SelectedIndexChanged);
            this.listBoxAuditoriums.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxAuditoriums_MouseDoubleClick);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(1149, 622);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(199, 40);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "Открыть пару";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpd.Location = new System.Drawing.Point(1149, 484);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(199, 40);
            this.buttonUpd.TabIndex = 1;
            this.buttonUpd.Text = "Переставить пару";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(1149, 576);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(199, 40);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Закрыть пару";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(1149, 530);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(199, 40);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отменить перестановку";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormScheduleAuditoriums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 674);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.listBoxAuditoriums);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonUpd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormScheduleAuditoriums";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расписание аудиторий";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormScheduleAuditoriums_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxAuditoriums;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCancel;
    }
}