namespace ScheduleView
{
    partial class FormSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSave));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxFaculty = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.comboBoxIn = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxWeek = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сделать выгрузку по:";
            // 
            // comboBoxBy
            // 
            this.comboBoxBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBy.FormattingEnabled = true;
            this.comboBoxBy.Location = new System.Drawing.Point(166, 54);
            this.comboBoxBy.Name = "comboBoxBy";
            this.comboBoxBy.Size = new System.Drawing.Size(178, 24);
            this.comboBoxBy.TabIndex = 1;
            this.comboBoxBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(530, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Внимание! Выгрузка делается по текущему периоду, указанному в настройках";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxFaculty
            // 
            this.groupBoxFaculty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFaculty.Location = new System.Drawing.Point(13, 89);
            this.groupBoxFaculty.Name = "groupBoxFaculty";
            this.groupBoxFaculty.Size = new System.Drawing.Size(532, 32);
            this.groupBoxFaculty.TabIndex = 3;
            this.groupBoxFaculty.TabStop = false;
            this.groupBoxFaculty.Text = "Факультеты";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(455, 212);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 40);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.Location = new System.Drawing.Point(349, 212);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(100, 40);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "Выгрузить";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // comboBoxIn
            // 
            this.comboBoxIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxIn.FormattingEnabled = true;
            this.comboBoxIn.Location = new System.Drawing.Point(166, 157);
            this.comboBoxIn.Name = "comboBoxIn";
            this.comboBoxIn.Size = new System.Drawing.Size(178, 24);
            this.comboBoxIn.TabIndex = 7;
            this.comboBoxIn.SelectedIndexChanged += new System.EventHandler(this.comboBoxIn_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сделать выгрузку в:";
            // 
            // comboBoxWeek
            // 
            this.comboBoxWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWeek.FormattingEnabled = true;
            this.comboBoxWeek.Location = new System.Drawing.Point(166, 187);
            this.comboBoxWeek.Name = "comboBoxWeek";
            this.comboBoxWeek.Size = new System.Drawing.Size(178, 24);
            this.comboBoxWeek.TabIndex = 9;
            this.comboBoxWeek.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Выгрузить неделю:";
            this.label4.Visible = false;
            // 
            // FormSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 265);
            this.Controls.Add(this.comboBoxWeek);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.groupBoxFaculty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBy);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выгрузка расписания";
            this.Load += new System.EventHandler(this.FormSave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxFaculty;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ComboBox comboBoxIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxWeek;
        private System.Windows.Forms.Label label4;
    }
}