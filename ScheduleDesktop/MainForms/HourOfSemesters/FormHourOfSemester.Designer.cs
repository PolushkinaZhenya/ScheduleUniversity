
namespace ScheduleDesktop
{
	partial class FormHourOfSemester
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
			this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
			this.labelDiscipline = new System.Windows.Forms.Label();
			this.labelSemester = new System.Windows.Forms.Label();
			this.comboBoxStudyGroup = new System.Windows.Forms.ComboBox();
			this.labelStudyGroup = new System.Windows.Forms.Label();
			this.splitContainerData = new System.Windows.Forms.SplitContainer();
			this.panelWishes = new System.Windows.Forms.Panel();
			this.textBoxWishes = new System.Windows.Forms.TextBox();
			this.labelWishes = new System.Windows.Forms.Label();
			this.panelReporting = new System.Windows.Forms.Panel();
			this.labelReportingForms = new System.Windows.Forms.Label();
			this.comboBoxReportingForms = new System.Windows.Forms.ComboBox();
			this.textBoxReporting = new System.Windows.Forms.TextBox();
			this.labelReporting = new System.Windows.Forms.Label();
			this.panelData = new System.Windows.Forms.Panel();
			this.textBoxSemester = new System.Windows.Forms.TextBox();
			this.buttonAddPanel = new System.Windows.Forms.Button();
			this.panelActions = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).BeginInit();
			this.splitContainerData.Panel2.SuspendLayout();
			this.splitContainerData.SuspendLayout();
			this.panelWishes.SuspendLayout();
			this.panelReporting.SuspendLayout();
			this.panelData.SuspendLayout();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxDiscipline
			// 
			this.comboBoxDiscipline.FormattingEnabled = true;
			this.comboBoxDiscipline.Location = new System.Drawing.Point(407, 9);
			this.comboBoxDiscipline.Name = "comboBoxDiscipline";
			this.comboBoxDiscipline.Size = new System.Drawing.Size(197, 23);
			this.comboBoxDiscipline.TabIndex = 3;
			// 
			// labelDiscipline
			// 
			this.labelDiscipline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDiscipline.AutoSize = true;
			this.labelDiscipline.Location = new System.Drawing.Point(319, 12);
			this.labelDiscipline.Name = "labelDiscipline";
			this.labelDiscipline.Size = new System.Drawing.Size(82, 15);
			this.labelDiscipline.TabIndex = 2;
			this.labelDiscipline.Text = "Дисциплина: ";
			// 
			// labelSemester
			// 
			this.labelSemester.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSemester.AutoSize = true;
			this.labelSemester.Location = new System.Drawing.Point(14, 12);
			this.labelSemester.Name = "labelSemester";
			this.labelSemester.Size = new System.Drawing.Size(60, 15);
			this.labelSemester.TabIndex = 0;
			this.labelSemester.Text = "Семестр: ";
			// 
			// comboBoxStudyGroup
			// 
			this.comboBoxStudyGroup.FormattingEnabled = true;
			this.comboBoxStudyGroup.Location = new System.Drawing.Point(688, 9);
			this.comboBoxStudyGroup.Name = "comboBoxStudyGroup";
			this.comboBoxStudyGroup.Size = new System.Drawing.Size(197, 23);
			this.comboBoxStudyGroup.TabIndex = 5;
			// 
			// labelStudyGroup
			// 
			this.labelStudyGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStudyGroup.AutoSize = true;
			this.labelStudyGroup.Location = new System.Drawing.Point(630, 12);
			this.labelStudyGroup.Name = "labelStudyGroup";
			this.labelStudyGroup.Size = new System.Drawing.Size(52, 15);
			this.labelStudyGroup.TabIndex = 4;
			this.labelStudyGroup.Text = "Группа: ";
			// 
			// splitContainerData
			// 
			this.splitContainerData.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.splitContainerData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerData.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerData.Location = new System.Drawing.Point(0, 46);
			this.splitContainerData.Name = "splitContainerData";
			this.splitContainerData.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerData.Panel1
			// 
			this.splitContainerData.Panel1.AutoScroll = true;
			this.splitContainerData.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
			// 
			// splitContainerData.Panel2
			// 
			this.splitContainerData.Panel2.AutoScroll = true;
			this.splitContainerData.Panel2.Controls.Add(this.panelWishes);
			this.splitContainerData.Panel2.Controls.Add(this.panelReporting);
			this.splitContainerData.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.splitContainerData.Size = new System.Drawing.Size(943, 678);
			this.splitContainerData.SplitterDistance = 542;
			this.splitContainerData.TabIndex = 1;
			// 
			// panelWishes
			// 
			this.panelWishes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelWishes.Controls.Add(this.textBoxWishes);
			this.panelWishes.Controls.Add(this.labelWishes);
			this.panelWishes.Location = new System.Drawing.Point(12, 55);
			this.panelWishes.Name = "panelWishes";
			this.panelWishes.Size = new System.Drawing.Size(919, 71);
			this.panelWishes.TabIndex = 2;
			// 
			// textBoxWishes
			// 
			this.textBoxWishes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxWishes.Location = new System.Drawing.Point(92, 10);
			this.textBoxWishes.Multiline = true;
			this.textBoxWishes.Name = "textBoxWishes";
			this.textBoxWishes.Size = new System.Drawing.Size(815, 52);
			this.textBoxWishes.TabIndex = 1;
			// 
			// labelWishes
			// 
			this.labelWishes.AutoSize = true;
			this.labelWishes.Location = new System.Drawing.Point(13, 13);
			this.labelWishes.Name = "labelWishes";
			this.labelWishes.Size = new System.Drawing.Size(74, 15);
			this.labelWishes.TabIndex = 0;
			this.labelWishes.Text = "Пожелания:";
			// 
			// panelReporting
			// 
			this.panelReporting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelReporting.Controls.Add(this.labelReportingForms);
			this.panelReporting.Controls.Add(this.comboBoxReportingForms);
			this.panelReporting.Controls.Add(this.textBoxReporting);
			this.panelReporting.Controls.Add(this.labelReporting);
			this.panelReporting.Location = new System.Drawing.Point(12, 6);
			this.panelReporting.Name = "panelReporting";
			this.panelReporting.Size = new System.Drawing.Size(919, 43);
			this.panelReporting.TabIndex = 0;
			// 
			// labelReportingForms
			// 
			this.labelReportingForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReportingForms.AutoSize = true;
			this.labelReportingForms.Location = new System.Drawing.Point(588, 10);
			this.labelReportingForms.Name = "labelReportingForms";
			this.labelReportingForms.Size = new System.Drawing.Size(116, 15);
			this.labelReportingForms.TabIndex = 2;
			this.labelReportingForms.Text = "Формы отчетности:";
			// 
			// comboBoxReportingForms
			// 
			this.comboBoxReportingForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxReportingForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxReportingForms.FormattingEnabled = true;
			this.comboBoxReportingForms.Items.AddRange(new object[] {
            "Зачет",
            "Зачет с оценкой",
            "Экзамен",
            "Курсовая работа",
            "Курсовой проект"});
			this.comboBoxReportingForms.Location = new System.Drawing.Point(710, 7);
			this.comboBoxReportingForms.Name = "comboBoxReportingForms";
			this.comboBoxReportingForms.Size = new System.Drawing.Size(197, 23);
			this.comboBoxReportingForms.TabIndex = 3;
			this.comboBoxReportingForms.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReportingForms_SelectedIndexChanged);
			// 
			// textBoxReporting
			// 
			this.textBoxReporting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxReporting.Location = new System.Drawing.Point(92, 7);
			this.textBoxReporting.Name = "textBoxReporting";
			this.textBoxReporting.Size = new System.Drawing.Size(478, 23);
			this.textBoxReporting.TabIndex = 1;
			// 
			// labelReporting
			// 
			this.labelReporting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReporting.AutoSize = true;
			this.labelReporting.Location = new System.Drawing.Point(13, 10);
			this.labelReporting.Name = "labelReporting";
			this.labelReporting.Size = new System.Drawing.Size(73, 15);
			this.labelReporting.TabIndex = 0;
			this.labelReporting.Text = "Отчетность:";
			// 
			// panelData
			// 
			this.panelData.Controls.Add(this.textBoxSemester);
			this.panelData.Controls.Add(this.buttonAddPanel);
			this.panelData.Controls.Add(this.labelSemester);
			this.panelData.Controls.Add(this.labelDiscipline);
			this.panelData.Controls.Add(this.comboBoxStudyGroup);
			this.panelData.Controls.Add(this.comboBoxDiscipline);
			this.panelData.Controls.Add(this.labelStudyGroup);
			this.panelData.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelData.Location = new System.Drawing.Point(0, 0);
			this.panelData.Name = "panelData";
			this.panelData.Size = new System.Drawing.Size(943, 46);
			this.panelData.TabIndex = 0;
			// 
			// textBoxSemester
			// 
			this.textBoxSemester.Location = new System.Drawing.Point(80, 9);
			this.textBoxSemester.Name = "textBoxSemester";
			this.textBoxSemester.ReadOnly = true;
			this.textBoxSemester.Size = new System.Drawing.Size(222, 23);
			this.textBoxSemester.TabIndex = 1;
			// 
			// buttonAddPanel
			// 
			this.buttonAddPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddPanel.BackgroundImage = global::ScheduleDesktop.Properties.Resources.Add_20;
			this.buttonAddPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonAddPanel.Location = new System.Drawing.Point(900, 3);
			this.buttonAddPanel.Name = "buttonAddPanel";
			this.buttonAddPanel.Size = new System.Drawing.Size(40, 40);
			this.buttonAddPanel.TabIndex = 6;
			this.buttonAddPanel.UseVisualStyleBackColor = true;
			this.buttonAddPanel.Click += new System.EventHandler(this.ButtonAddPanel_Click);
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonSave);
			this.panelActions.Controls.Add(this.buttonCancel);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelActions.Location = new System.Drawing.Point(0, 724);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(943, 45);
			this.panelActions.TabIndex = 2;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(733, 3);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(79, 38);
			this.buttonSave.TabIndex = 0;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(852, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(79, 38);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// FormHourOfSemester
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(943, 769);
			this.Controls.Add(this.splitContainerData);
			this.Controls.Add(this.panelActions);
			this.Controls.Add(this.panelData);
			this.Name = "FormHourOfSemester";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Расчасовка";
			this.Load += new System.EventHandler(this.FormHourOfSemester_Load);
			this.splitContainerData.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerData)).EndInit();
			this.splitContainerData.ResumeLayout(false);
			this.panelWishes.ResumeLayout(false);
			this.panelWishes.PerformLayout();
			this.panelReporting.ResumeLayout(false);
			this.panelReporting.PerformLayout();
			this.panelData.ResumeLayout(false);
			this.panelData.PerformLayout();
			this.panelActions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxDiscipline;
		private System.Windows.Forms.Label labelDiscipline;
		private System.Windows.Forms.Label labelSemester;
		private System.Windows.Forms.ComboBox comboBoxStudyGroup;
		private System.Windows.Forms.Label labelStudyGroup;
		private System.Windows.Forms.SplitContainer splitContainerData;
		private System.Windows.Forms.Panel panelData;
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.Panel panelReporting;
		private System.Windows.Forms.Label labelReportingForms;
		private System.Windows.Forms.ComboBox comboBoxReportingForms;
		private System.Windows.Forms.TextBox textBoxReporting;
		private System.Windows.Forms.Label labelReporting;
		private System.Windows.Forms.Panel panelWishes;
		private System.Windows.Forms.TextBox textBoxWishes;
		private System.Windows.Forms.Label labelWishes;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonAddPanel;
		private System.Windows.Forms.TextBox textBoxSemester;
	}
}