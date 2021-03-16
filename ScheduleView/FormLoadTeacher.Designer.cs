namespace ScheduleView
{
    partial class FormLoadTeacher
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRefPeriod = new System.Windows.Forms.Button();
            this.buttonDelPeriod = new System.Windows.Forms.Button();
            this.buttonUpdPeriod = new System.Windows.Forms.Button();
            this.buttonAddPeriod = new System.Windows.Forms.Button();
            this.dataGridViewPeriod = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeOfClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTeacher = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFlow = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonRefAuditorium = new System.Windows.Forms.Button();
            this.buttonDelAuditorium = new System.Windows.Forms.Button();
            this.buttonUpdAuditorium = new System.Windows.Forms.Button();
            this.buttonAddAuditorium = new System.Windows.Forms.Button();
            this.dataGridViewAuditorium = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriod)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditorium)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(717, 574);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 35);
            this.buttonCancel.TabIndex = 40;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(621, 574);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 35);
            this.buttonSave.TabIndex = 39;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonRefPeriod);
            this.groupBox1.Controls.Add(this.buttonDelPeriod);
            this.groupBox1.Controls.Add(this.buttonUpdPeriod);
            this.groupBox1.Controls.Add(this.buttonAddPeriod);
            this.groupBox1.Controls.Add(this.dataGridViewPeriod);
            this.groupBox1.Location = new System.Drawing.Point(364, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 275);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Периоды";
            // 
            // buttonRefPeriod
            // 
            this.buttonRefPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefPeriod.Location = new System.Drawing.Point(340, 144);
            this.buttonRefPeriod.Name = "buttonRefPeriod";
            this.buttonRefPeriod.Size = new System.Drawing.Size(90, 35);
            this.buttonRefPeriod.TabIndex = 4;
            this.buttonRefPeriod.Text = "Обновить";
            this.buttonRefPeriod.UseVisualStyleBackColor = true;
            this.buttonRefPeriod.Click += new System.EventHandler(this.buttonRefPeriod_Click);
            // 
            // buttonDelPeriod
            // 
            this.buttonDelPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelPeriod.Location = new System.Drawing.Point(340, 103);
            this.buttonDelPeriod.Name = "buttonDelPeriod";
            this.buttonDelPeriod.Size = new System.Drawing.Size(90, 35);
            this.buttonDelPeriod.TabIndex = 3;
            this.buttonDelPeriod.Text = "Удалить";
            this.buttonDelPeriod.UseVisualStyleBackColor = true;
            this.buttonDelPeriod.Click += new System.EventHandler(this.buttonDelPeriod_Click);
            // 
            // buttonUpdPeriod
            // 
            this.buttonUpdPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdPeriod.Location = new System.Drawing.Point(340, 62);
            this.buttonUpdPeriod.Name = "buttonUpdPeriod";
            this.buttonUpdPeriod.Size = new System.Drawing.Size(90, 35);
            this.buttonUpdPeriod.TabIndex = 2;
            this.buttonUpdPeriod.Text = "Изменить";
            this.buttonUpdPeriod.UseVisualStyleBackColor = true;
            this.buttonUpdPeriod.Click += new System.EventHandler(this.buttonUpdPeriod_Click);
            // 
            // buttonAddPeriod
            // 
            this.buttonAddPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddPeriod.Location = new System.Drawing.Point(340, 21);
            this.buttonAddPeriod.Name = "buttonAddPeriod";
            this.buttonAddPeriod.Size = new System.Drawing.Size(90, 35);
            this.buttonAddPeriod.TabIndex = 1;
            this.buttonAddPeriod.Text = "Добавить";
            this.buttonAddPeriod.UseVisualStyleBackColor = true;
            this.buttonAddPeriod.Click += new System.EventHandler(this.buttonAddPeriod_Click);
            // 
            // dataGridViewPeriod
            // 
            this.dataGridViewPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPeriod.Location = new System.Drawing.Point(15, 21);
            this.dataGridViewPeriod.Name = "dataGridViewPeriod";
            this.dataGridViewPeriod.RowHeadersVisible = false;
            this.dataGridViewPeriod.RowTemplate.Height = 24;
            this.dataGridViewPeriod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPeriod.Size = new System.Drawing.Size(319, 235);
            this.dataGridViewPeriod.TabIndex = 0;
            this.dataGridViewPeriod.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPeriod_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Дисциплина : ";
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(133, 12);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(225, 24);
            this.comboBoxDiscipline.TabIndex = 41;
            // 
            // comboBoxTypeOfClass
            // 
            this.comboBoxTypeOfClass.FormattingEnabled = true;
            this.comboBoxTypeOfClass.Location = new System.Drawing.Point(133, 42);
            this.comboBoxTypeOfClass.Name = "comboBoxTypeOfClass";
            this.comboBoxTypeOfClass.Size = new System.Drawing.Size(225, 24);
            this.comboBoxTypeOfClass.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Тип занятия : ";
            // 
            // comboBoxTeacher
            // 
            this.comboBoxTeacher.FormattingEnabled = true;
            this.comboBoxTeacher.Location = new System.Drawing.Point(133, 72);
            this.comboBoxTeacher.Name = "comboBoxTeacher";
            this.comboBoxTeacher.Size = new System.Drawing.Size(225, 24);
            this.comboBoxTeacher.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Преподаватель : ";
            // 
            // comboBoxFlow
            // 
            this.comboBoxFlow.FormattingEnabled = true;
            this.comboBoxFlow.Location = new System.Drawing.Point(133, 102);
            this.comboBoxFlow.Name = "comboBoxFlow";
            this.comboBoxFlow.Size = new System.Drawing.Size(225, 24);
            this.comboBoxFlow.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Поток : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonRefAuditorium);
            this.groupBox2.Controls.Add(this.buttonDelAuditorium);
            this.groupBox2.Controls.Add(this.buttonUpdAuditorium);
            this.groupBox2.Controls.Add(this.buttonAddAuditorium);
            this.groupBox2.Controls.Add(this.dataGridViewAuditorium);
            this.groupBox2.Location = new System.Drawing.Point(364, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 275);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Аудитории";
            // 
            // buttonRefAuditorium
            // 
            this.buttonRefAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefAuditorium.Location = new System.Drawing.Point(340, 144);
            this.buttonRefAuditorium.Name = "buttonRefAuditorium";
            this.buttonRefAuditorium.Size = new System.Drawing.Size(90, 35);
            this.buttonRefAuditorium.TabIndex = 4;
            this.buttonRefAuditorium.Text = "Обновить";
            this.buttonRefAuditorium.UseVisualStyleBackColor = true;
            this.buttonRefAuditorium.Click += new System.EventHandler(this.buttonRefAuditorium_Click);
            // 
            // buttonDelAuditorium
            // 
            this.buttonDelAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelAuditorium.Location = new System.Drawing.Point(340, 103);
            this.buttonDelAuditorium.Name = "buttonDelAuditorium";
            this.buttonDelAuditorium.Size = new System.Drawing.Size(90, 35);
            this.buttonDelAuditorium.TabIndex = 3;
            this.buttonDelAuditorium.Text = "Удалить";
            this.buttonDelAuditorium.UseVisualStyleBackColor = true;
            this.buttonDelAuditorium.Click += new System.EventHandler(this.buttonDelAuditorium_Click);
            // 
            // buttonUpdAuditorium
            // 
            this.buttonUpdAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdAuditorium.Location = new System.Drawing.Point(340, 62);
            this.buttonUpdAuditorium.Name = "buttonUpdAuditorium";
            this.buttonUpdAuditorium.Size = new System.Drawing.Size(90, 35);
            this.buttonUpdAuditorium.TabIndex = 2;
            this.buttonUpdAuditorium.Text = "Изменить";
            this.buttonUpdAuditorium.UseVisualStyleBackColor = true;
            this.buttonUpdAuditorium.Click += new System.EventHandler(this.buttonUpdAuditorium_Click);
            // 
            // buttonAddAuditorium
            // 
            this.buttonAddAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddAuditorium.Location = new System.Drawing.Point(340, 21);
            this.buttonAddAuditorium.Name = "buttonAddAuditorium";
            this.buttonAddAuditorium.Size = new System.Drawing.Size(90, 35);
            this.buttonAddAuditorium.TabIndex = 1;
            this.buttonAddAuditorium.Text = "Добавить";
            this.buttonAddAuditorium.UseVisualStyleBackColor = true;
            this.buttonAddAuditorium.Click += new System.EventHandler(this.buttonAddAuditorium_Click);
            // 
            // dataGridViewAuditorium
            // 
            this.dataGridViewAuditorium.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAuditorium.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuditorium.Location = new System.Drawing.Point(15, 21);
            this.dataGridViewAuditorium.Name = "dataGridViewAuditorium";
            this.dataGridViewAuditorium.RowHeadersVisible = false;
            this.dataGridViewAuditorium.RowTemplate.Height = 24;
            this.dataGridViewAuditorium.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAuditorium.Size = new System.Drawing.Size(319, 235);
            this.dataGridViewAuditorium.TabIndex = 0;
            this.dataGridViewAuditorium.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAuditorium_CellMouseDoubleClick);
            // 
            // FormLoadTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 621);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxFlow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxTeacher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTypeOfClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDiscipline);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormLoadTeacher";
            this.Text = "Расчасовка";
            this.Load += new System.EventHandler(this.FormLoadTeacher_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPeriod)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditorium)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRefPeriod;
        private System.Windows.Forms.Button buttonDelPeriod;
        private System.Windows.Forms.Button buttonUpdPeriod;
        private System.Windows.Forms.Button buttonAddPeriod;
        private System.Windows.Forms.DataGridView dataGridViewPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDiscipline;
        private System.Windows.Forms.ComboBox comboBoxTypeOfClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTeacher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxFlow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRefAuditorium;
        private System.Windows.Forms.Button buttonDelAuditorium;
        private System.Windows.Forms.Button buttonUpdAuditorium;
        private System.Windows.Forms.Button buttonAddAuditorium;
        private System.Windows.Forms.DataGridView dataGridViewAuditorium;
    }
}