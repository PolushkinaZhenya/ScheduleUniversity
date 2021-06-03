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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.типыКафедрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.типыАудиторийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.типыЗанятийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеКорпусаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.времяПереходаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.времяПроведенияПарToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеГодаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.семестрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.периодыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.кафедрыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.аудиторииToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.преподавателиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.дисциплиныToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.факультетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.специальностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеГруппыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.потокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеПланыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.расчасовкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.dataGridViewAll = new System.Windows.Forms.DataGridView();
			this.listBoxStudyGroups = new System.Windows.Forms.ListBox();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonScheduleAud = new System.Windows.Forms.Button();
			this.buttonSetting = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonScheduleTeach = new System.Windows.Forms.Button();
			this.toolStripMenuItemSync = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.кафедрыToolStripMenuItem1,
            this.аудиторииToolStripMenuItem1,
            this.преподавателиToolStripMenuItem1,
            this.дисциплиныToolStripMenuItem1,
            this.факультетыToolStripMenuItem,
            this.специальностиToolStripMenuItem,
            this.учебныеГруппыToolStripMenuItem,
            this.потокиToolStripMenuItem,
            this.учебныеПланыToolStripMenuItem,
            this.расчасовкиToolStripMenuItem,
            this.toolStripMenuItemSync});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1049, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// справочникиToolStripMenuItem
			// 
			this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыКафедрToolStripMenuItem,
            this.типыАудиторийToolStripMenuItem,
            this.типыЗанятийToolStripMenuItem,
            this.учебныеКорпусаToolStripMenuItem,
            this.времяПереходаToolStripMenuItem,
            this.времяПроведенияПарToolStripMenuItem1,
            this.учебныеГодаToolStripMenuItem,
            this.семестрыToolStripMenuItem,
            this.периодыToolStripMenuItem});
			this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// типыКафедрToolStripMenuItem
			// 
			this.типыКафедрToolStripMenuItem.Name = "типыКафедрToolStripMenuItem";
			this.типыКафедрToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.типыКафедрToolStripMenuItem.Text = "Типы кафедр";
			this.типыКафедрToolStripMenuItem.Click += new System.EventHandler(this.типыКафедрToolStripMenuItem_Click);
			// 
			// типыАудиторийToolStripMenuItem
			// 
			this.типыАудиторийToolStripMenuItem.Name = "типыАудиторийToolStripMenuItem";
			this.типыАудиторийToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.типыАудиторийToolStripMenuItem.Text = "Типы аудиторий";
			this.типыАудиторийToolStripMenuItem.Click += new System.EventHandler(this.типыАудиторийToolStripMenuItem_Click);
			// 
			// типыЗанятийToolStripMenuItem
			// 
			this.типыЗанятийToolStripMenuItem.Name = "типыЗанятийToolStripMenuItem";
			this.типыЗанятийToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.типыЗанятийToolStripMenuItem.Text = "Типы занятий";
			this.типыЗанятийToolStripMenuItem.Click += new System.EventHandler(this.типыЗанятийToolStripMenuItem_Click);
			// 
			// учебныеКорпусаToolStripMenuItem
			// 
			this.учебныеКорпусаToolStripMenuItem.Name = "учебныеКорпусаToolStripMenuItem";
			this.учебныеКорпусаToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.учебныеКорпусаToolStripMenuItem.Text = "Учебные корпуса";
			this.учебныеКорпусаToolStripMenuItem.Click += new System.EventHandler(this.учебныеКорпусаToolStripMenuItem_Click);
			// 
			// времяПереходаToolStripMenuItem
			// 
			this.времяПереходаToolStripMenuItem.Name = "времяПереходаToolStripMenuItem";
			this.времяПереходаToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.времяПереходаToolStripMenuItem.Text = "Время перехода";
			this.времяПереходаToolStripMenuItem.Click += new System.EventHandler(this.времяПереходаToolStripMenuItem_Click);
			// 
			// времяПроведенияПарToolStripMenuItem1
			// 
			this.времяПроведенияПарToolStripMenuItem1.Name = "времяПроведенияПарToolStripMenuItem1";
			this.времяПроведенияПарToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
			this.времяПроведенияПарToolStripMenuItem1.Text = "Время проведения пар";
			this.времяПроведенияПарToolStripMenuItem1.Click += new System.EventHandler(this.времяПроведенияПарToolStripMenuItem1_Click);
			// 
			// учебныеГодаToolStripMenuItem
			// 
			this.учебныеГодаToolStripMenuItem.Name = "учебныеГодаToolStripMenuItem";
			this.учебныеГодаToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.учебныеГодаToolStripMenuItem.Text = "Учебные года";
			this.учебныеГодаToolStripMenuItem.Click += new System.EventHandler(this.учебныеГодаToolStripMenuItem_Click);
			// 
			// семестрыToolStripMenuItem
			// 
			this.семестрыToolStripMenuItem.Name = "семестрыToolStripMenuItem";
			this.семестрыToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.семестрыToolStripMenuItem.Text = "Семестры";
			this.семестрыToolStripMenuItem.Click += new System.EventHandler(this.семестрыToolStripMenuItem_Click);
			// 
			// периодыToolStripMenuItem
			// 
			this.периодыToolStripMenuItem.Name = "периодыToolStripMenuItem";
			this.периодыToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.периодыToolStripMenuItem.Text = "Периоды";
			this.периодыToolStripMenuItem.Click += new System.EventHandler(this.периодыToolStripMenuItem_Click);
			// 
			// кафедрыToolStripMenuItem1
			// 
			this.кафедрыToolStripMenuItem1.Name = "кафедрыToolStripMenuItem1";
			this.кафедрыToolStripMenuItem1.Size = new System.Drawing.Size(69, 20);
			this.кафедрыToolStripMenuItem1.Text = "Кафедры";
			this.кафедрыToolStripMenuItem1.Click += new System.EventHandler(this.кафедрыToolStripMenuItem1_Click);
			// 
			// аудиторииToolStripMenuItem1
			// 
			this.аудиторииToolStripMenuItem1.Name = "аудиторииToolStripMenuItem1";
			this.аудиторииToolStripMenuItem1.Size = new System.Drawing.Size(79, 20);
			this.аудиторииToolStripMenuItem1.Text = "Аудитории";
			this.аудиторииToolStripMenuItem1.Click += new System.EventHandler(this.аудиторииToolStripMenuItem1_Click);
			// 
			// преподавателиToolStripMenuItem1
			// 
			this.преподавателиToolStripMenuItem1.Name = "преподавателиToolStripMenuItem1";
			this.преподавателиToolStripMenuItem1.Size = new System.Drawing.Size(104, 20);
			this.преподавателиToolStripMenuItem1.Text = "Преподаватели";
			this.преподавателиToolStripMenuItem1.Click += new System.EventHandler(this.преподавателиToolStripMenuItem1_Click);
			// 
			// дисциплиныToolStripMenuItem1
			// 
			this.дисциплиныToolStripMenuItem1.Name = "дисциплиныToolStripMenuItem1";
			this.дисциплиныToolStripMenuItem1.Size = new System.Drawing.Size(91, 20);
			this.дисциплиныToolStripMenuItem1.Text = "Дисциплины";
			this.дисциплиныToolStripMenuItem1.Click += new System.EventHandler(this.дисциплиныToolStripMenuItem1_Click);
			// 
			// факультетыToolStripMenuItem
			// 
			this.факультетыToolStripMenuItem.Name = "факультетыToolStripMenuItem";
			this.факультетыToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
			this.факультетыToolStripMenuItem.Text = "Факультеты";
			this.факультетыToolStripMenuItem.Click += new System.EventHandler(this.факультетыToolStripMenuItem_Click);
			// 
			// специальностиToolStripMenuItem
			// 
			this.специальностиToolStripMenuItem.Name = "специальностиToolStripMenuItem";
			this.специальностиToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
			this.специальностиToolStripMenuItem.Text = "Специальности";
			this.специальностиToolStripMenuItem.Click += new System.EventHandler(this.специальностиToolStripMenuItem_Click);
			// 
			// учебныеГруппыToolStripMenuItem
			// 
			this.учебныеГруппыToolStripMenuItem.Name = "учебныеГруппыToolStripMenuItem";
			this.учебныеГруппыToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
			this.учебныеГруппыToolStripMenuItem.Text = "Учебные группы";
			this.учебныеГруппыToolStripMenuItem.Click += new System.EventHandler(this.учебныеГруппыToolStripMenuItem_Click);
			// 
			// потокиToolStripMenuItem
			// 
			this.потокиToolStripMenuItem.Name = "потокиToolStripMenuItem";
			this.потокиToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.потокиToolStripMenuItem.Text = "Потоки";
			this.потокиToolStripMenuItem.Click += new System.EventHandler(this.потокиToolStripMenuItem_Click);
			// 
			// учебныеПланыToolStripMenuItem
			// 
			this.учебныеПланыToolStripMenuItem.Name = "учебныеПланыToolStripMenuItem";
			this.учебныеПланыToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
			this.учебныеПланыToolStripMenuItem.Text = "Учебные планы";
			this.учебныеПланыToolStripMenuItem.Click += new System.EventHandler(this.учебныеПланыToolStripMenuItem_Click);
			// 
			// расчасовкиToolStripMenuItem
			// 
			this.расчасовкиToolStripMenuItem.Name = "расчасовкиToolStripMenuItem";
			this.расчасовкиToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.расчасовкиToolStripMenuItem.Text = "Расчасовки";
			this.расчасовкиToolStripMenuItem.Click += new System.EventHandler(this.расчасовкиToolStripMenuItem_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(892, 523);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(148, 32);
			this.buttonCancel.TabIndex = 33;
			this.buttonCancel.Text = "Отменить перестановку";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(9, 131);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridViewAll);
			this.splitContainer1.Size = new System.Drawing.Size(879, 462);
			this.splitContainer1.SplitterDistance = 333;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 36;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer2.Size = new System.Drawing.Size(879, 333);
			this.splitContainer2.SplitterDistance = 132;
			this.splitContainer2.SplitterWidth = 3;
			this.splitContainer2.TabIndex = 0;
			// 
			// dataGridViewAll
			// 
			this.dataGridViewAll.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewAll.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dataGridViewAll.Name = "dataGridViewAll";
			this.dataGridViewAll.ReadOnly = true;
			this.dataGridViewAll.RowHeadersVisible = false;
			this.dataGridViewAll.RowTemplate.Height = 24;
			this.dataGridViewAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewAll.Size = new System.Drawing.Size(879, 126);
			this.dataGridViewAll.TabIndex = 15;
			this.dataGridViewAll.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAll_CellMouseDoubleClick);
			// 
			// listBoxStudyGroups
			// 
			this.listBoxStudyGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxStudyGroups.FormattingEnabled = true;
			this.listBoxStudyGroups.Location = new System.Drawing.Point(892, 92);
			this.listBoxStudyGroups.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.listBoxStudyGroups.Name = "listBoxStudyGroups";
			this.listBoxStudyGroups.Size = new System.Drawing.Size(149, 381);
			this.listBoxStudyGroups.Sorted = true;
			this.listBoxStudyGroups.TabIndex = 35;
			this.listBoxStudyGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxStudyGroups_SelectedIndexChanged);
			this.listBoxStudyGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxStudyGroups_MouseDoubleClick);
			// 
			// buttonDel
			// 
			this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDel.Location = new System.Drawing.Point(892, 561);
			this.buttonDel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(148, 32);
			this.buttonDel.TabIndex = 34;
			this.buttonDel.Text = "Убрать из расписания";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpd.Location = new System.Drawing.Point(892, 486);
			this.buttonUpd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(148, 32);
			this.buttonUpd.TabIndex = 32;
			this.buttonUpd.Text = "Переставить пару";
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
			// 
			// buttonScheduleAud
			// 
			this.buttonScheduleAud.Image = global::ScheduleView.Properties.Resources.Schedule_20;
			this.buttonScheduleAud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonScheduleAud.Location = new System.Drawing.Point(9, 25);
			this.buttonScheduleAud.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonScheduleAud.Name = "buttonScheduleAud";
			this.buttonScheduleAud.Size = new System.Drawing.Size(157, 32);
			this.buttonScheduleAud.TabIndex = 37;
			this.buttonScheduleAud.Text = "Расписание аудиторий";
			this.buttonScheduleAud.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScheduleAud.UseVisualStyleBackColor = true;
			this.buttonScheduleAud.Click += new System.EventHandler(this.buttonScheduleAud_Click);
			// 
			// buttonSetting
			// 
			this.buttonSetting.Image = ((System.Drawing.Image)(resources.GetObject("buttonSetting.Image")));
			this.buttonSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSetting.Location = new System.Drawing.Point(451, 25);
			this.buttonSetting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonSetting.Name = "buttonSetting";
			this.buttonSetting.Size = new System.Drawing.Size(90, 32);
			this.buttonSetting.TabIndex = 3;
			this.buttonSetting.Text = "Настройки";
			this.buttonSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSetting.UseVisualStyleBackColor = true;
			this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(356, 25);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(90, 32);
			this.buttonSave.TabIndex = 2;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonScheduleTeach
			// 
			this.buttonScheduleTeach.Image = global::ScheduleView.Properties.Resources.Schedule_20;
			this.buttonScheduleTeach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonScheduleTeach.Location = new System.Drawing.Point(170, 25);
			this.buttonScheduleTeach.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonScheduleTeach.Name = "buttonScheduleTeach";
			this.buttonScheduleTeach.Size = new System.Drawing.Size(182, 32);
			this.buttonScheduleTeach.TabIndex = 38;
			this.buttonScheduleTeach.Text = "Расписание преподавателей";
			this.buttonScheduleTeach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScheduleTeach.UseVisualStyleBackColor = true;
			this.buttonScheduleTeach.Click += new System.EventHandler(this.buttonScheduleTeach_Click);
			// 
			// toolStripMenuItemSync
			// 
			this.toolStripMenuItemSync.Name = "toolStripMenuItemSync";
			this.toolStripMenuItemSync.Size = new System.Drawing.Size(106, 20);
			this.toolStripMenuItemSync.Text = "Синхронизация";
			this.toolStripMenuItemSync.Click += new System.EventHandler(this.ToolStripMenuItemSync_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1049, 600);
			this.Controls.Add(this.buttonScheduleTeach);
			this.Controls.Add(this.buttonScheduleAud);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.listBoxStudyGroups);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonUpd);
			this.Controls.Add(this.buttonSetting);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Расписание университета";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеКорпусаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяПереходаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кафедрыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem аудиторииToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem преподавателиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem дисциплиныToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem времяПроведенияПарToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem типыАудиторийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыКафедрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыЗанятийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem факультетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специальностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеГруппыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem потокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеГодаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem семестрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem периодыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеПланыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расчасовкиToolStripMenuItem;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridViewAll;
        private System.Windows.Forms.ListBox listBoxStudyGroups;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonScheduleAud;
        private System.Windows.Forms.Button buttonScheduleTeach;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSync;
	}
}