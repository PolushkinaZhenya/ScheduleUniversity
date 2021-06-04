namespace ScheduleView
{
    partial class FormTypeOfDepartments
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTypeOfDepartments));
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonDel
			// 
			this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDel.Image = global::ScheduleView.Properties.Resources.Del_20;
			this.buttonDel.Location = new System.Drawing.Point(518, 81);
			this.buttonDel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(90, 32);
			this.buttonDel.TabIndex = 3;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpd.Image = global::ScheduleView.Properties.Resources.Upd_20;
			this.buttonUpd.Location = new System.Drawing.Point(518, 45);
			this.buttonUpd.Margin = new System.Windows.Forms.Padding(2);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(90, 32);
			this.buttonUpd.TabIndex = 2;
			this.buttonUpd.Text = "Изменить";
			this.buttonUpd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.Image = global::ScheduleView.Properties.Resources.Add_20;
			this.buttonAdd.Location = new System.Drawing.Point(518, 8);
			this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(90, 32);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeColumns = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.RowTemplate.ReadOnly = true;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(514, 206);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDoubleClick);
			this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyDown);
			// 
			// FormTypeOfDepartments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(616, 206);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonUpd);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.dataGridView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FormTypeOfDepartments";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Типы кафедр";
			this.Load += new System.EventHandler(this.FormTypeOfDepartments_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}