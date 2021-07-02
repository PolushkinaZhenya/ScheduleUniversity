namespace ScheduleDesktop
{
    partial class FormAuditorium
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
			this.labelType = new System.Windows.Forms.Label();
			this.comboBoxType = new System.Windows.Forms.ComboBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.labelNumber = new System.Windows.Forms.Label();
			this.textBoxCapacity = new System.Windows.Forms.TextBox();
			this.labelCapacity = new System.Windows.Forms.Label();
			this.labelEducationalBuilding = new System.Windows.Forms.Label();
			this.comboBoxEducationalBuilding = new System.Windows.Forms.ComboBox();
			this.labelDepartment = new System.Windows.Forms.Label();
			this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
			this.buttonDel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelType
			// 
			this.labelType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(11, 114);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(36, 15);
			this.labelType.TabIndex = 4;
			this.labelType.Text = "Тип : ";
			// 
			// comboBoxType
			// 
			this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxType.FormattingEnabled = true;
			this.comboBoxType.Location = new System.Drawing.Point(109, 111);
			this.comboBoxType.Name = "comboBoxType";
			this.comboBoxType.Size = new System.Drawing.Size(213, 23);
			this.comboBoxType.TabIndex = 5;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(120, 8);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 40);
			this.buttonCancel.TabIndex = 21;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(22, 8);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(80, 40);
			this.buttonSave.TabIndex = 20;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumber.Location = new System.Drawing.Point(109, 58);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new System.Drawing.Size(213, 23);
			this.textBoxNumber.TabIndex = 1;
			// 
			// labelNumber
			// 
			this.labelNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumber.AutoSize = true;
			this.labelNumber.Location = new System.Drawing.Point(11, 61);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(54, 15);
			this.labelNumber.TabIndex = 0;
			this.labelNumber.Text = "Номер : ";
			// 
			// textBoxCapacity
			// 
			this.textBoxCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCapacity.Location = new System.Drawing.Point(109, 85);
			this.textBoxCapacity.Name = "textBoxCapacity";
			this.textBoxCapacity.Size = new System.Drawing.Size(213, 23);
			this.textBoxCapacity.TabIndex = 3;
			// 
			// labelCapacity
			// 
			this.labelCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCapacity.AutoSize = true;
			this.labelCapacity.Location = new System.Drawing.Point(11, 87);
			this.labelCapacity.Name = "labelCapacity";
			this.labelCapacity.Size = new System.Drawing.Size(89, 15);
			this.labelCapacity.TabIndex = 2;
			this.labelCapacity.Text = "Вместимость : ";
			// 
			// labelEducationalBuilding
			// 
			this.labelEducationalBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEducationalBuilding.AutoSize = true;
			this.labelEducationalBuilding.Location = new System.Drawing.Point(11, 142);
			this.labelEducationalBuilding.Name = "labelEducationalBuilding";
			this.labelEducationalBuilding.Size = new System.Drawing.Size(56, 15);
			this.labelEducationalBuilding.TabIndex = 6;
			this.labelEducationalBuilding.Text = "Корпус : ";
			// 
			// comboBoxEducationalBuilding
			// 
			this.comboBoxEducationalBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEducationalBuilding.FormattingEnabled = true;
			this.comboBoxEducationalBuilding.Location = new System.Drawing.Point(109, 139);
			this.comboBoxEducationalBuilding.Name = "comboBoxEducationalBuilding";
			this.comboBoxEducationalBuilding.Size = new System.Drawing.Size(213, 23);
			this.comboBoxEducationalBuilding.TabIndex = 7;
			// 
			// labelDepartment
			// 
			this.labelDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDepartment.AutoSize = true;
			this.labelDepartment.Location = new System.Drawing.Point(11, 170);
			this.labelDepartment.Name = "labelDepartment";
			this.labelDepartment.Size = new System.Drawing.Size(63, 15);
			this.labelDepartment.TabIndex = 8;
			this.labelDepartment.Text = "Кафедра : ";
			// 
			// comboBoxDepartment
			// 
			this.comboBoxDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxDepartment.FormattingEnabled = true;
			this.comboBoxDepartment.Location = new System.Drawing.Point(109, 167);
			this.comboBoxDepartment.Name = "comboBoxDepartment";
			this.comboBoxDepartment.Size = new System.Drawing.Size(213, 23);
			this.comboBoxDepartment.TabIndex = 8;
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(214, 8);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(80, 40);
			this.buttonDel.TabIndex = 22;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Visible = false;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// FormAuditorium
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 200);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.labelDepartment);
			this.Controls.Add(this.comboBoxDepartment);
			this.Controls.Add(this.labelEducationalBuilding);
			this.Controls.Add(this.comboBoxEducationalBuilding);
			this.Controls.Add(this.textBoxCapacity);
			this.Controls.Add(this.labelCapacity);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.comboBoxType);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(this.labelNumber);
			this.Name = "FormAuditorium";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Аудитория";
			this.Load += new System.EventHandler(this.FormAuditorium_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.TextBox textBoxCapacity;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.Label labelEducationalBuilding;
        private System.Windows.Forms.ComboBox comboBoxEducationalBuilding;
        private System.Windows.Forms.Label labelDepartment;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Button buttonDel;
    }
}