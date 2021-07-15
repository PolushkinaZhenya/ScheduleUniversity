namespace ScheduleDesktop
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
			this.типыКафедрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.типыАудиторийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.типыЗанятийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеКорпусаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.времяПереходаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.времяПроведенияПарToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.кафедрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.дисциплиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.факультетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.специальностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеГодаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеПланыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.аудиторииToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.преподавателиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.учебныеГруппыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.потокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonScheduleAud = new System.Windows.Forms.Button();
			this.buttonSetting = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonScheduleTeach = new System.Windows.Forms.Button();
			this.buttonScheduleStudyGroups = new System.Windows.Forms.Button();
			this.buttonHourOfSemesters = new System.Windows.Forms.Button();
			this.panelActions = new System.Windows.Forms.Panel();
			this.buttonBD = new System.Windows.Forms.Button();
			this.panelContent = new System.Windows.Forms.Panel();
			this.menuStrip.SuspendLayout();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.учебныеГодаToolStripMenuItem,
            this.учебныеПланыToolStripMenuItem,
            this.аудиторииToolStripMenuItem1,
            this.преподавателиToolStripMenuItem1,
            this.учебныеГруппыToolStripMenuItem,
            this.потокиToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1117, 24);
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
            this.времяПроведенияПарToolStripMenuItem,
            this.кафедрыToolStripMenuItem,
            this.дисциплиныToolStripMenuItem,
            this.факультетыToolStripMenuItem,
            this.специальностиToolStripMenuItem});
			this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// типыКафедрToolStripMenuItem
			// 
			this.типыКафедрToolStripMenuItem.Name = "типыКафедрToolStripMenuItem";
			this.типыКафедрToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.типыКафедрToolStripMenuItem.Text = "Типы кафедр";
			this.типыКафедрToolStripMenuItem.Click += new System.EventHandler(this.ТипыКафедрToolStripMenuItem_Click);
			// 
			// типыАудиторийToolStripMenuItem
			// 
			this.типыАудиторийToolStripMenuItem.Name = "типыАудиторийToolStripMenuItem";
			this.типыАудиторийToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.типыАудиторийToolStripMenuItem.Text = "Типы аудиторий";
			this.типыАудиторийToolStripMenuItem.Click += new System.EventHandler(this.ТипыАудиторийToolStripMenuItem_Click);
			// 
			// типыЗанятийToolStripMenuItem
			// 
			this.типыЗанятийToolStripMenuItem.Name = "типыЗанятийToolStripMenuItem";
			this.типыЗанятийToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.типыЗанятийToolStripMenuItem.Text = "Типы занятий";
			this.типыЗанятийToolStripMenuItem.Click += new System.EventHandler(this.ТипыЗанятийToolStripMenuItem_Click);
			// 
			// учебныеКорпусаToolStripMenuItem
			// 
			this.учебныеКорпусаToolStripMenuItem.Name = "учебныеКорпусаToolStripMenuItem";
			this.учебныеКорпусаToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.учебныеКорпусаToolStripMenuItem.Text = "Учебные корпуса";
			this.учебныеКорпусаToolStripMenuItem.Click += new System.EventHandler(this.УчебныеКорпусаToolStripMenuItem_Click);
			// 
			// времяПереходаToolStripMenuItem
			// 
			this.времяПереходаToolStripMenuItem.Name = "времяПереходаToolStripMenuItem";
			this.времяПереходаToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.времяПереходаToolStripMenuItem.Text = "Время перехода";
			this.времяПереходаToolStripMenuItem.Click += new System.EventHandler(this.ВремяПереходаToolStripMenuItem_Click);
			// 
			// времяПроведенияПарToolStripMenuItem
			// 
			this.времяПроведенияПарToolStripMenuItem.Name = "времяПроведенияПарToolStripMenuItem";
			this.времяПроведенияПарToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.времяПроведенияПарToolStripMenuItem.Text = "Время проведения пар";
			this.времяПроведенияПарToolStripMenuItem.Click += new System.EventHandler(this.ВремяПроведенияПарToolStripMenuItem_Click);
			// 
			// кафедрыToolStripMenuItem
			// 
			this.кафедрыToolStripMenuItem.Name = "кафедрыToolStripMenuItem";
			this.кафедрыToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.кафедрыToolStripMenuItem.Text = "Кафедры";
			this.кафедрыToolStripMenuItem.Click += new System.EventHandler(this.КафедрыToolStripMenuItem_Click);
			// 
			// дисциплиныToolStripMenuItem
			// 
			this.дисциплиныToolStripMenuItem.Name = "дисциплиныToolStripMenuItem";
			this.дисциплиныToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.дисциплиныToolStripMenuItem.Text = "Дисциплины";
			this.дисциплиныToolStripMenuItem.Click += new System.EventHandler(this.ДисциплиныToolStripMenuItem_Click);
			// 
			// факультетыToolStripMenuItem
			// 
			this.факультетыToolStripMenuItem.Name = "факультетыToolStripMenuItem";
			this.факультетыToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.факультетыToolStripMenuItem.Text = "Факультеты";
			this.факультетыToolStripMenuItem.Click += new System.EventHandler(this.ФакультетыToolStripMenuItem_Click);
			// 
			// специальностиToolStripMenuItem
			// 
			this.специальностиToolStripMenuItem.Name = "специальностиToolStripMenuItem";
			this.специальностиToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.специальностиToolStripMenuItem.Text = "Специальности";
			this.специальностиToolStripMenuItem.Click += new System.EventHandler(this.СпециальностиToolStripMenuItem_Click);
			// 
			// учебныеГодаToolStripMenuItem
			// 
			this.учебныеГодаToolStripMenuItem.Name = "учебныеГодаToolStripMenuItem";
			this.учебныеГодаToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.учебныеГодаToolStripMenuItem.Text = "Учебные года";
			this.учебныеГодаToolStripMenuItem.Click += new System.EventHandler(this.УчебныеГодаToolStripMenuItem_Click);
			// 
			// учебныеПланыToolStripMenuItem
			// 
			this.учебныеПланыToolStripMenuItem.Name = "учебныеПланыToolStripMenuItem";
			this.учебныеПланыToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
			this.учебныеПланыToolStripMenuItem.Text = "Учебные планы";
			this.учебныеПланыToolStripMenuItem.Click += new System.EventHandler(this.УчебныеПланыToolStripMenuItem_Click);
			// 
			// аудиторииToolStripMenuItem1
			// 
			this.аудиторииToolStripMenuItem1.Name = "аудиторииToolStripMenuItem1";
			this.аудиторииToolStripMenuItem1.Size = new System.Drawing.Size(79, 20);
			this.аудиторииToolStripMenuItem1.Text = "Аудитории";
			this.аудиторииToolStripMenuItem1.Click += new System.EventHandler(this.АудиторииToolStripMenuItem_Click);
			// 
			// преподавателиToolStripMenuItem1
			// 
			this.преподавателиToolStripMenuItem1.Name = "преподавателиToolStripMenuItem1";
			this.преподавателиToolStripMenuItem1.Size = new System.Drawing.Size(104, 20);
			this.преподавателиToolStripMenuItem1.Text = "Преподаватели";
			this.преподавателиToolStripMenuItem1.Click += new System.EventHandler(this.ПреподавателиToolStripMenuItem_Click);
			// 
			// учебныеГруппыToolStripMenuItem
			// 
			this.учебныеГруппыToolStripMenuItem.Name = "учебныеГруппыToolStripMenuItem";
			this.учебныеГруппыToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
			this.учебныеГруппыToolStripMenuItem.Text = "Учебные группы";
			this.учебныеГруппыToolStripMenuItem.Click += new System.EventHandler(this.УчебныеГруппыToolStripMenuItem_Click);
			// 
			// потокиToolStripMenuItem
			// 
			this.потокиToolStripMenuItem.Name = "потокиToolStripMenuItem";
			this.потокиToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.потокиToolStripMenuItem.Text = "Потоки";
			this.потокиToolStripMenuItem.Click += new System.EventHandler(this.ПотокиToolStripMenuItem_Click);
			// 
			// buttonScheduleAud
			// 
			this.buttonScheduleAud.Image = global::ScheduleDesktop.Properties.Resources.Schedule_20;
			this.buttonScheduleAud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonScheduleAud.Location = new System.Drawing.Point(200, 13);
			this.buttonScheduleAud.Margin = new System.Windows.Forms.Padding(2);
			this.buttonScheduleAud.Name = "buttonScheduleAud";
			this.buttonScheduleAud.Size = new System.Drawing.Size(183, 37);
			this.buttonScheduleAud.TabIndex = 1;
			this.buttonScheduleAud.Text = "Расписание аудиторий";
			this.buttonScheduleAud.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScheduleAud.UseVisualStyleBackColor = true;
			// 
			// buttonSetting
			// 
			this.buttonSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSetting.Location = new System.Drawing.Point(960, 13);
			this.buttonSetting.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSetting.Name = "buttonSetting";
			this.buttonSetting.Size = new System.Drawing.Size(105, 37);
			this.buttonSetting.TabIndex = 5;
			this.buttonSetting.Text = "Настройки";
			this.buttonSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSetting.UseVisualStyleBackColor = true;
			this.buttonSetting.Click += new System.EventHandler(this.ButtonSetting_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(849, 13);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(105, 37);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonScheduleTeach
			// 
			this.buttonScheduleTeach.Image = global::ScheduleDesktop.Properties.Resources.Schedule_20;
			this.buttonScheduleTeach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonScheduleTeach.Location = new System.Drawing.Point(388, 13);
			this.buttonScheduleTeach.Margin = new System.Windows.Forms.Padding(2);
			this.buttonScheduleTeach.Name = "buttonScheduleTeach";
			this.buttonScheduleTeach.Size = new System.Drawing.Size(212, 37);
			this.buttonScheduleTeach.TabIndex = 2;
			this.buttonScheduleTeach.Text = "Расписание преподавателей";
			this.buttonScheduleTeach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScheduleTeach.UseVisualStyleBackColor = true;
			// 
			// buttonScheduleStudyGroups
			// 
			this.buttonScheduleStudyGroups.Image = global::ScheduleDesktop.Properties.Resources.Schedule_20;
			this.buttonScheduleStudyGroups.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonScheduleStudyGroups.Location = new System.Drawing.Point(13, 13);
			this.buttonScheduleStudyGroups.Margin = new System.Windows.Forms.Padding(2);
			this.buttonScheduleStudyGroups.Name = "buttonScheduleStudyGroups";
			this.buttonScheduleStudyGroups.Size = new System.Drawing.Size(183, 37);
			this.buttonScheduleStudyGroups.TabIndex = 0;
			this.buttonScheduleStudyGroups.Text = "Расписание групп";
			this.buttonScheduleStudyGroups.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonScheduleStudyGroups.UseVisualStyleBackColor = true;
			this.buttonScheduleStudyGroups.Click += new System.EventHandler(this.ButtonScheduleStudyGroups_Click);
			// 
			// buttonHourOfSemesters
			// 
			this.buttonHourOfSemesters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonHourOfSemesters.Location = new System.Drawing.Point(651, 13);
			this.buttonHourOfSemesters.Margin = new System.Windows.Forms.Padding(2);
			this.buttonHourOfSemesters.Name = "buttonHourOfSemesters";
			this.buttonHourOfSemesters.Size = new System.Drawing.Size(105, 37);
			this.buttonHourOfSemesters.TabIndex = 3;
			this.buttonHourOfSemesters.Text = "Расчасовки";
			this.buttonHourOfSemesters.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonHourOfSemesters.UseVisualStyleBackColor = true;
			this.buttonHourOfSemesters.Click += new System.EventHandler(this.ButtonHourOfSemesters_Click);
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonBD);
			this.panelActions.Controls.Add(this.buttonScheduleStudyGroups);
			this.panelActions.Controls.Add(this.buttonSetting);
			this.panelActions.Controls.Add(this.buttonSave);
			this.panelActions.Controls.Add(this.buttonHourOfSemesters);
			this.panelActions.Controls.Add(this.buttonScheduleAud);
			this.panelActions.Controls.Add(this.buttonScheduleTeach);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelActions.Location = new System.Drawing.Point(0, 24);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(1117, 63);
			this.panelActions.TabIndex = 0;
			// 
			// buttonBD
			// 
			this.buttonBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonBD.Location = new System.Drawing.Point(1069, 13);
			this.buttonBD.Margin = new System.Windows.Forms.Padding(2);
			this.buttonBD.Name = "buttonBD";
			this.buttonBD.Size = new System.Drawing.Size(37, 37);
			this.buttonBD.TabIndex = 6;
			this.buttonBD.Text = "БД";
			this.buttonBD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonBD.UseVisualStyleBackColor = true;
			this.buttonBD.Click += new System.EventHandler(this.ButtonBD_Click);
			// 
			// panelContent
			// 
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 87);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(1117, 605);
			this.panelContent.TabIndex = 1;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1117, 692);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.panelActions);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Расписание университета";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.panelActions.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеКорпусаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяПереходаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кафедрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аудиторииToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem преподавателиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem дисциплиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem времяПроведенияПарToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыАудиторийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыКафедрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыЗанятийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem факультетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специальностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеГруппыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem потокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеГодаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеПланыToolStripMenuItem;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Button buttonScheduleAud;
        private System.Windows.Forms.Button buttonScheduleTeach;
		private System.Windows.Forms.Button buttonScheduleStudyGroups;
		private System.Windows.Forms.Button buttonHourOfSemesters;
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.Panel panelContent;
		private System.Windows.Forms.Button buttonBD;
	}
}