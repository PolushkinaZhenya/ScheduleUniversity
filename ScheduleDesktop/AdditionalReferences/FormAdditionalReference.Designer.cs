
using ScheduleBusinessLogic.BindingModels;
using ScheduleBusinessLogic.ViewModels;

namespace ScheduleDesktop.AdditionalReferences
{
	partial class FormAdditionalReference<B, V>
		where B : AdditionalReferenceBindingModel, new()
		where V : AdditionalReferenceViewModel
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
			this.panelControls = new System.Windows.Forms.Panel();
			this.panelActions = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.panelActions.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelControls
			// 
			this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControls.Location = new System.Drawing.Point(0, 0);
			this.panelControls.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panelControls.Name = "panelControls";
			this.panelControls.Size = new System.Drawing.Size(933, 462);
			this.panelControls.TabIndex = 0;
			// 
			// panelActions
			// 
			this.panelActions.Controls.Add(this.buttonCancel);
			this.panelActions.Controls.Add(this.buttonSave);
			this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelActions.Location = new System.Drawing.Point(0, 462);
			this.panelActions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panelActions.Name = "panelActions";
			this.panelActions.Size = new System.Drawing.Size(933, 57);
			this.panelActions.TabIndex = 1;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(827, 9);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(93, 35);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(716, 9);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(93, 35);
			this.buttonSave.TabIndex = 0;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// FormAdditionalReference
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 519);
			this.Controls.Add(this.panelControls);
			this.Controls.Add(this.panelActions);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "FormAdditionalReference";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormAdditionalReference";
			this.Load += new System.EventHandler(this.FormAdditionalReference_Load);
			this.panelActions.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelControls;
		private System.Windows.Forms.Panel panelActions;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
	}
}